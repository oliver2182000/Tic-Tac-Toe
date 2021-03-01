using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Tic_Tac_Toe
{
    public partial class Multiplayer : Form
    {
        public Multiplayer(bool isHost, string ip = null )
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            if (isHost)
            {
                Player1 = 'X';
                Player2 = 'O';
                Server = new TcpListener(System.Net.IPAddress.Any, 5732);
                Server.Start();
                socket = Server.AcceptSocket();

            }
            else
            {
                Player1 = 'O';
                Player2 = 'X';
                try
                {
                    Client = new TcpClient(ip, 5732);
                    socket = Client.Client;
                    MessageReceiver.RunWorkerAsync();

                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Close();

                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckState())
                return;
            Freeze();
            label1.Text = "Opponent's Turn";
            MoveReception();
            label1.Text = "Your Turn";
            if (!CheckState())
                Unfreeze();
            
            
            
        }

        private char Player1;
        private char Player2;
        private Socket socket;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener Server = null;
        private TcpClient Client;

        private bool CheckState()
        {
            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button1.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == Player1)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                label1.Text = "It's a draw!";
                MessageBox.Show("It's a draw!");
                return true;
            }
            return false;
        }
        private void Freeze()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

        }
        private void Unfreeze()
        {
            if (button1.Text == "")
                button1.Enabled = true;
            if (button2.Text == "")
                button2.Enabled = true;
            if (button3.Text == "")
                button3.Enabled = true;
            if (button3.Text == "")
                button3.Enabled = true;
            if (button4.Text == "")
                button4.Enabled = true;
            if (button5.Text == "")
                button5.Enabled = true;
            if (button6.Text == "")
                button6.Enabled = true;
            if (button7.Text == "")
                button7.Enabled = true;
            if (button8.Text == "")
                button8.Enabled = true;
            if (button9.Text == "")
                button9.Enabled = true;

        }
        private void MoveReception()
        {
            byte[] buffer = new byte[1];
            socket.Receive(buffer);
            if (buffer[0] == 1)
                button1.Text = Player2.ToString();
            if (buffer[0] == 2)
                button2.Text = Player2.ToString();
            if (buffer[0] == 3)
                button3.Text = Player2.ToString();
            if (buffer[0] == 4)
                button4.Text = Player2.ToString();
            if (buffer[0] == 5)
                button5.Text = Player2.ToString();
            if (buffer[0] == 6)
                button6.Text = Player2.ToString();
            if (buffer[0] == 7)
                button7.Text = Player2.ToString();
            if (buffer[0] == 8)
                button8.Text = Player2.ToString();
            if (buffer[0] == 9)
                button9.Text = Player2.ToString();


        }

        private void Multiplayer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] number = { 1 };
            socket.Send(number);
            button1.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] number = { 2 };
            socket.Send(number);
            button2.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] number = { 3 };
            socket.Send(number);
            button3.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] number = { 4 };
            socket.Send(number);
            button4.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] number = { 5 };
            socket.Send(number);
            button5.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] number = { 6 };
            socket.Send(number);
            button6.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] number = { 7 };
            socket.Send(number);
            button7.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] number = { 8 };
            socket.Send(number);
            button8.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] number = { 9 };
            socket.Send(number);
            button9.Text = Player1.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void Multiplayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (Server != null)
                Server.Stop();
        }
    }
}
