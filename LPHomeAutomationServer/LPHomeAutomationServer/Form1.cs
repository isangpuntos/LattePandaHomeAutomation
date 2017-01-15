using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace LPHomeAutomationServer
{
    public partial class Form1 : Form
    {
        private Label[] labelArray;
        ServerThread serverThread = null;

        public Form1()
        {
            InitializeComponent();
            labelArray = new Label[8]{conn1,conn2,o1,o2,o3,o4,o5,o6};
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serverThread = new ServerThread(labelArray);
            Thread oThread = new Thread(new ThreadStart(serverThread.StartListen));
            oThread.Start();
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(AddressChangedCallback);
            if(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                    conn1.BackColor = Color.Green;
                    conn1.Text = "Ready";
            }
        }

        private void AddressChangedCallback(object sender, EventArgs e)
        {
            if (conn1.BackColor == Color.Red)
            {
                if (conn1.InvokeRequired)
                {
                    conn1.Invoke((MethodInvoker)delegate
                    {
                        conn1.BackColor = Color.Green;
                        conn1.Text = "Ready";
                    });
                }
            }
            else
            {
                conn1.Invoke((MethodInvoker)delegate
                {
                    conn1.BackColor = Color.Red;
                    conn1.Text = "Not Ready";
                });
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serverThread != null)
            {
                serverThread.CloseSerialPort();
            }
            MessageBox.Show("Exited");
            Application.Exit();
        }
    }
}
