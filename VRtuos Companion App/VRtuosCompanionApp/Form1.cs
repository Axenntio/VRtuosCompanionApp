using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace VRtuosCompanionApp
{
    public partial class Form1 : Form
    {
        private static InputDevice inputDevice;
        private static OutputDevice outputDevice;

        static UdpClient udpServer;
        static UdpClient udpClient;
        static Thread thdUDPServer;

        private static ConnectionStatus connectionStatus = ConnectionStatus.Disconnected;
        static string address;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDevices();

            //Run the server thread and create a client
            udpServer = new UdpClient(28008);
            thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.IsBackground = true;
            thdUDPServer.Start();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            inputDevice.Dispose();
            outputDevice.Dispose();

            Disconnect();
            if (udpServer != null)
                udpServer.Close();
            if (thdUDPServer != null)
            {
                thdUDPServer.Join(2000);
                thdUDPServer.Abort();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        private void Connect(bool isAutomatic = false)
        {
            //Decides if it should fill in the ip address,
            //or if it should set it to the one in the textbox
            if (!isAutomatic)
            {
                Disconnect();
                address = IPTextbox.Text;
            }
            else
            {
                IPTextbox.Text = address;
            }


            if (IPAddress.TryParse(address, out IPAddress iPAddress))
            {
                udpClient = new UdpClient();

                try
                {
                    udpClient.Connect(iPAddress, 28008);
                    //Sends answer to the server and asks for a reaction
                    //OR just asks for a reaction
                    if (isAutomatic)
                    {
                        SendData(Encoding.ASCII.GetBytes("YesThereIs"), (int)code.connectionData);
                        SendData(Encoding.ASCII.GetBytes("IsAnybodyThere"), (int)code.connectionData);
                    }
                    else
                        SendData(Encoding.ASCII.GetBytes("IsAnybodyThere"), (int)code.connectionData);

                }
                catch (Exception)
                {
                    ConnectionStatusLabel.ForeColor = Color.Red;
                    ConnectionStatusLabel.Text = "Error";
                    return;
                }
                connectionStatus = ConnectionStatus.Connecting;
                Timer.Enabled = true;
            }
            else
            {
                ConnectionStatusLabel.ForeColor = Color.Red;
                ConnectionStatusLabel.Text = "Incorrect IP address";
            }
        }

        private void Disconnect()
        {
            if (udpClient != null)
                udpClient.Close();
            connectionStatus = ConnectionStatus.Disconnected;
        }

        private void RefreshDevices()
        {
            InputCombo.Items.Clear();
            foreach (InputDevice device in InputDevice.GetAll())
            {
                InputCombo.Items.Add(device.Name);
            }
            InputCombo.SelectedIndex = InputCombo.Items.Count - 1;

            OutputCombo.Items.Clear();
            foreach (OutputDevice device in OutputDevice.GetAll())
            {
                OutputCombo.Items.Add(device.Name);
            }
            OutputCombo.SelectedIndex = OutputCombo.Items.Count - 1;
        }

        private static void OnMidiRecieved(object sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event != null)
            {
                if (e.Event.EventType == MidiEventType.NoteOn ||
                    e.Event.EventType == MidiEventType.NoteOff)
                {
                    NoteEvent noteEvent = e.Event as NoteEvent;
                    SendMidi(noteEvent);
                }
                else if (e.Event.EventType == MidiEventType.ControlChange)
                {
                    ControlChangeEvent ccEvent = e.Event as ControlChangeEvent;
                    SendMidi(ccEvent);
                }
                else if (e.Event.EventType == MidiEventType.ProgramChange)
                {
                    ProgramChangeEvent pcEvent = e.Event as ProgramChangeEvent;
                    SendMidi(pcEvent);
                }
            }
        }


        private static void SendMidi(ControlChangeEvent controlChangeEvent)
        {
            if (connectionStatus == ConnectionStatus.Connected)
            {
                MidiEventToBytesConverter converter = new MidiEventToBytesConverter();
                SendData(converter.Convert(controlChangeEvent), (int)code.midi);
            }
        }

        private static void SendMidi(NoteEvent noteEvent)
        {
            if (connectionStatus == ConnectionStatus.Connected)
            {
                MidiEventToBytesConverter converter = new MidiEventToBytesConverter();
                SendData(converter.Convert(noteEvent), (int)code.midi);
            }
        }

        private static void SendMidi(ProgramChangeEvent programChangeEvent)
        {
            if (connectionStatus == ConnectionStatus.Connected)
            {
                MidiEventToBytesConverter converter = new MidiEventToBytesConverter();
                SendData(converter.Convert(programChangeEvent), (int)code.midi);
            }
        }


        private void InputCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inputDevice != null)
            {
                inputDevice.StopEventsListening();
                inputDevice.Dispose();
            }

            inputDevice = InputDevice.GetByName(InputCombo.SelectedItem.ToString());
            inputDevice.EventReceived += new EventHandler<MidiEventReceivedEventArgs>(Form1.OnMidiRecieved);

            if (!inputDevice.IsListeningForEvents)
                inputDevice.StartEventsListening();
        }

        private void OutputCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Dispose();
            }
            outputDevice = OutputDevice.GetByName(OutputCombo.SelectedItem.ToString());
        }

        public static void PlayMidi(MidiEvent noteEvent)
        {
            if (outputDevice != null)
                outputDevice.SendEvent(noteEvent);
        }


        private static void SendData(byte[] data, int code)
        {
            //Make the first byte an int code.
            //This will let the other end decide what to do with the data quicker
            byte[] toSend = new byte[data.Length + 1];
            toSend[0] = (byte)code;
            data.CopyTo(toSend, 1);

            udpClient.Send(toSend, toSend.Length);
        }

        private void serverThread()
        {
            while (true)
            {
                try
                {
                    //Get the other IP, read data
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    Byte[] receiveBytes = udpServer.Receive(ref RemoteIpEndPoint);
                    byte[] data = new byte[receiveBytes.Length - 1];
                    Array.Copy(receiveBytes, 1, data, 0, receiveBytes.Length - 1);
                    string returnData = Encoding.ASCII.GetString(data);

                    Console.WriteLine(RemoteIpEndPoint.Address.ToString()
                                            + ":" + returnData.ToString());

                    switch (receiveBytes[0])
                    {
                        case 10:
                            //If midi, play it
                            BytesToMidiEventConverter converter = new BytesToMidiEventConverter();
                            MidiEvent tmpevent = converter.Convert(data);
                            PlayMidi(tmpevent);
                            break;

                        case 20:
                            //Reacts
                            if (returnData.ToString() == "IsAnybodyThere")
                            {
                                if (connectionStatus != ConnectionStatus.Connected && connectionStatus != ConnectionStatus.Connecting)
                                {
                                    address = RemoteIpEndPoint.Address.ToString();

                                    MethodInvoker inv = delegate
                                    {
                                        Connect(true);
                                    };
                                    Invoke(inv);
                                }
                                else
                                {
                                    //Answers
                                    SendData(Encoding.ASCII.GetBytes("YesThereIs"), (int)code.connectionData);
                                }
                            }
                            else if (returnData.ToString() == "YesThereIs")
                            {
                                //Connection is established
                                connectionStatus = ConnectionStatus.Connected;
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    connectionStatus = ConnectionStatus.Disconnected;
                    break;
                }
            }
        }

        int timeout = 50;
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Just for visuals
            switch (connectionStatus)
            {
                case ConnectionStatus.Connecting:
                    ConnectionStatusLabel.ForeColor = Color.Yellow;
                    ConnectionStatusLabel.Text = "Connecting...";
                    timeout--;
                    if (timeout <= 0)
                        Disconnect();
                    break;

                case ConnectionStatus.Connected:
                    ConnectionStatusLabel.ForeColor = Color.Green;
                    ConnectionStatusLabel.Text = "Connected";
                    Timer.Enabled = false;
                    timeout = 50;
                    break;

                case ConnectionStatus.Disconnected:
                    ConnectionStatusLabel.ForeColor = Color.Red;
                    ConnectionStatusLabel.Text = "Disconnected";
                    timeout = 50;
                    break;
            }
        }
    }

    enum ConnectionStatus
    {
        Connecting,
        Connected,
        Disconnected,
    }

    enum code
    {
        midi = 10,
        connectionData = 20
    }
}
