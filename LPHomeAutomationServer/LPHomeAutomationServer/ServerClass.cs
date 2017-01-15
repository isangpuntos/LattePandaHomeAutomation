using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace LPHomeAutomationServer
{
    class ServerClass
    {
        private static Label[] labelArray;
        private static SerialPortHandler serialPortHandler;
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private class SerialPortHandler
        {
            SerialPort serialPort = new SerialPort();

            List<string> ComPortNames(String VID, String PID)
            {
                String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
                Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
                List<string> comports = new List<string>();
                RegistryKey rk1 = Registry.LocalMachine;
                RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
                foreach (String s3 in rk2.GetSubKeyNames())
                {
                    RegistryKey rk3 = rk2.OpenSubKey(s3);
                    foreach (String s in rk3.GetSubKeyNames())
                    {
                        if (_rx.Match(s).Success)
                        {
                            RegistryKey rk4 = rk3.OpenSubKey(s);
                            foreach (String s2 in rk4.GetSubKeyNames())
                            {
                                RegistryKey rk5 = rk4.OpenSubKey(s2);
                                RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                                comports.Add((string)rk6.GetValue("PortName"));
                            }
                        }
                    }
                }
                return comports;
            }

            public void connect()
            {
                try
                {
                    while (!serialPort.IsOpen)
                    {
                        List<string> names = ComPortNames("2341", "8036");
                        if (names.Count > 0)
                        {
                            foreach (String s in SerialPort.GetPortNames())
                            {
                                if (names.Contains(s))
                                {
                                    serialPort.BaudRate = 9600;
                                    serialPort.PortName = s;
                                    serialPort.Open();
                                    changeLabelValueColor(1);
                                    changeLabelText(1, "Connected");
                                }
                            }
                        }
                        else
                            Console.WriteLine("No COM ports found");

                        names.Clear();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to open port");
                }
            }

            public void sendCommand(String command)
            {
                if(serialPort.IsOpen)
                    serialPort.Write(command);
            }
            public void closePort()
            {
                if(serialPort.IsOpen)
                    serialPort.Close();
            }
        }

        public ServerClass()
        {

        }

        public static void setSignalParam(Label[] labelParam)
        {
            labelArray = labelParam;
        }

        public static void StartListening()
        {
            serialPortHandler = new SerialPortHandler();
            Thread spThread = new Thread(new ThreadStart(serialPortHandler.connect));
            spThread.Start();

            byte[] bytes = new Byte[1024];
            
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    allDone.Reset();
                    
                    listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
                    
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Clear();
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));
                
                content = state.sb.ToString();
                MatchCollection matches = Regex.Matches(content, "outlet[0-9]+");
                foreach (Match match in matches)
                {
                    foreach (Capture capture in match.Captures)
                    {
                        content = (capture.Value.Substring(capture.Value.LastIndexOf("outlet") + 6));
                        changeLabelValueColor(Convert.ToInt32(content) + 1);
                        serialPortHandler.sendCommand(content);
                    }
                }
                
                if (content.IndexOf("<EOF>") > -1)
                { 
                    Send(handler, content);
                }
                else
                {
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void changeLabelValueColor(int labelIndex)
        {
            if(labelArray[labelIndex].InvokeRequired)
            {
                labelArray[labelIndex].Invoke((MethodInvoker)delegate {
                    if(labelArray[labelIndex].BackColor.Equals(Color.Red))
                        labelArray[labelIndex].BackColor = Color.Green;
                    else
                        labelArray[labelIndex].BackColor = Color.Red;
                });
            }
        }

        private static void changeLabelText(int labelIndex, string text)
        {
            if (labelArray[labelIndex].InvokeRequired)
            {
                labelArray[labelIndex].Invoke((MethodInvoker)delegate {
                        labelArray[labelIndex].Text = text;
                });
            }
        }

        public static void closeSerialPort()
        {
            if(serialPortHandler != null)
            {
                serialPortHandler.closePort();
            }
        }

    }

    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    public class ServerThread
    {
        public ServerThread(Label[] labelParam)
        {
            ServerClass.setSignalParam(labelParam);
        }

        public void StartListen()
        {
            ServerClass.StartListening();
        }

        public void CloseSerialPort()
        {
            ServerClass.closeSerialPort();
        }
    }
}
