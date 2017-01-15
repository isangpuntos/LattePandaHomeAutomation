package com.isang.puntos.lphomeautomationclient;

import android.app.ProgressDialog;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity
{
    private ArrayList<String> ipList = new ArrayList<String>();
    private TCPClient mTcpClient;
    private ConnectTask connectTask;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        initializeButtonEvents();
    }

    private class ConnectTask extends AsyncTask<String, String, TCPClient>
    {
        @Override
        protected TCPClient doInBackground(String... message)
        {

            //we create a TCPClient object and
            mTcpClient = new TCPClient(new TCPClient.OnMessageReceived()
            {
                @Override
                //here the messageReceived method is implemented
                public void messageReceived(String message)
                {
                    //this method calls the onProgressUpdate
                    publishProgress(message);
                }
            }, message[0]);
            mTcpClient.run();

            return null;
        }

        @Override
        protected void onProgressUpdate(String... values)
        {
            super.onProgressUpdate(values);
        }
    }

    /*private class ScanIpTask extends AsyncTask<Void, String, Void>
    {
        static final String subnet = "192.168.1.";
        static final int lower = 1;
        static final int upper = 30;
        static final int timeout = 5000;
        ProgressDialog progressBar;

        @Override
        protected void onPreExecute()
        {
            ipList.clear();
            progressBar = new ProgressDialog(MainActivity.this);
            progressBar.setCancelable(false);
            progressBar.setMessage("Scanning...");
            progressBar.setProgressStyle(ProgressDialog.STYLE_SPINNER);
            progressBar.setMax(100);
            progressBar.show();
        }

        @Override
        protected Void doInBackground(Void... params)
        {
            for (int i = lower; i <= upper; i++)
            {
                String host = subnet + i;

                try
                {
                    InetAddress inetAddress = InetAddress.getByName(host);
                    if (inetAddress.isReachable(timeout))
                    {
                        publishProgress(inetAddress.getHostName());
                    }

                }
                catch (UnknownHostException e)
                {
                    e.printStackTrace();
                    Toast.makeText(MainActivity.this,e.getMessage(),Toast.LENGTH_SHORT);
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                    Toast.makeText(MainActivity.this,e.getMessage(),Toast.LENGTH_SHORT);
                }
                catch(Exception e)
                {
                    Toast.makeText(MainActivity.this,e.getMessage(),Toast.LENGTH_SHORT);
                }
            }

            return null;
        }

        @Override
        protected void onProgressUpdate(String... values)
        {
            ipList.add(values[0]);
            Toast.makeText(MainActivity.this, values[0], Toast.LENGTH_LONG).show();
        }

        @Override
        protected void onPostExecute(Void aVoid)
        {
            if (progressBar != null && progressBar.isShowing())
            {
                progressBar.dismiss();
            }
            fillSpinnerList();
        }
    }
    */
    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        /*MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.refresh, menu);*/
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case R.id.refresh:
                //new ScanIpTask().execute();
                //Toast.makeText(this, "Menu Item 1 selected", Toast.LENGTH_SHORT).show();
                break;
        }
        return true;
    }

    private void initializeButtonEvents()
    {
        ((Button)findViewById(R.id.button)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                Log.e(((Button)findViewById(R.id.button)).getText().toString().trim(),((Button)findViewById(R.id.button)).getText().toString().trim());
                if(((Button)findViewById(R.id.button)).getText().toString().trim().toLowerCase().equals("connect"))
                {
                    String ipAddress = ((EditText)findViewById(R.id.editText2)).getText().toString();
                    if(ipAddress.matches("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
                    {
                        connectTask = new ConnectTask();
                        connectTask.execute("192.168.1.2");
                        ((Button) findViewById(R.id.button)).setText("DISCONNECT");
                    }
                    else
                    {
                        Toast.makeText(MainActivity.this,"Please enter a valid IP Address",Toast.LENGTH_SHORT).show();
                    }
                }
                else
                {
                    mTcpClient.sendMessage("<EOF>");
                    mTcpClient.stopClient();
                    mTcpClient  = null;
                    connectTask.cancel(true);
                    connectTask = null;
                    ((Button)findViewById(R.id.button)).setText(" CONNECT ");
                }

            }
        });
        ((Button)findViewById(R.id.button3)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                if(mTcpClient != null)
                    mTcpClient.sendMessage("outlet1");
            }
        });
        ((Button)findViewById(R.id.button4)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                if(mTcpClient != null)
                    mTcpClient.sendMessage("outlet2");
            }
        });
        ((Button)findViewById(R.id.button6)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                if(mTcpClient != null)
                    mTcpClient.sendMessage("outlet3");
            }
        });
        ((Button)findViewById(R.id.button7)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                if(mTcpClient != null)
                    mTcpClient.sendMessage("outlet4");
            }
        });
        ((Button)findViewById(R.id.button8)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                if(mTcpClient != null)
                    mTcpClient.sendMessage("outlet5");
            }
        });
        ((Button)findViewById(R.id.button9)).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View arg0)
            {
                if(mTcpClient != null)
                    mTcpClient.sendMessage("outlet6");
            }
        });

    }

    /*private void initializeSpinner()
    {
        final Spinner spinner = (Spinner) findViewById(R.id.spinner);
        spinner.setOnTouchListener(new View.OnTouchListener()
        {
            @Override
            public boolean onTouch(View v, MotionEvent event)
            {
                //getServers();
                return false;
            }
        });

        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
        {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id)
            {
                String selectedItemText = (String) parent.getItemAtPosition(position);

                if (position > 0)
                {
                    // Notify the selected item text
                    Toast.makeText
                            (getApplicationContext(), "Selected : " + selectedItemText, Toast.LENGTH_SHORT)
                            .show();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent)
            {

            }
        });
        fillSpinnerList();
    }

    private void fillSpinnerList()
    {
        final List<String> serverName = ipList;

        if(ipList.size() > 0)
            serverName.add(0,"Select Server");
        else
            serverName.add(0,"Please scan to list server");

        final ArrayAdapter<String> spinnerArrayAdapter = new ArrayAdapter<String>(MainActivity.this, R.layout.spinner_item, serverName)
        {
            @Override
            public boolean isEnabled(int position)
            {
                if (position == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            @Override
            public View getDropDownView(int position, View convertView, ViewGroup parent)
            {
                View view = super.getDropDownView(position, convertView, parent);
                TextView tv = (TextView) view;
                if (position == 0)
                {
                    tv.setTextColor(Color.GRAY);
                }
                else
                {
                    tv.setTextColor(Color.BLACK);
                }
                return view;
            }
        };
        spinnerArrayAdapter.setDropDownViewResource(R.layout.spinner_item);
        ((Spinner) (findViewById(R.id.spinner))).setAdapter(spinnerArrayAdapter);
    }*/





}
