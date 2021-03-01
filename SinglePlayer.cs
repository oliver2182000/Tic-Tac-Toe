using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class SinglePlayer : Form
    {
        public enum Player
        {
            X, O
        }
        Player Player1;
        List<Button> buttons; 
        Random random = new Random(); 
        int player1Wins = 0; 
        int AiWins = 0; 

        public SinglePlayer()
        {
            InitializeComponent();
            resetGame();
            
        }

        private void PlayerMoves(object sender, EventArgs e)
        {
            label3.Text = "AI's Turn";
            var button = (Button)sender;
            Player1 = Player.X; 
            button.Text = Player1.ToString(); 
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Green; 
            buttons.Remove(button); 
            Check(); 
            timer1.Start(); 

        }

        private void Restart(object sender, EventArgs e)
        {
            resetGame();
        }

        private void AiMoves(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                label3.Text = "Your Turn";
                int index = random.Next(buttons.Count); 
                buttons[index].Enabled = false; 
                Player1 = Player.O; 
                buttons[index].Text = Player1.ToString(); 
                buttons[index].BackColor = System.Drawing.Color.Red;
                buttons.RemoveAt(index);
                Check();
                timer1.Stop();
            }
        }
        private void SinglePlayer_Load(object sender, EventArgs e)
        {

        }
        private void loadbuttons()
        {
           
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button9, button8 };
        }
        private void resetGame()
        {
           
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "bot")
                {
                    ((Button)X).Enabled = true; 
                    ((Button)X).Text = "";
                    ((Button)X).BackColor = Color.White;
                }
            }

            loadbuttons(); 
        }
        private void Check()
        {

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                timer1.Stop();
                MessageBox.Show("Player Wins");
                player1Wins++;
                label1.Text = "Player Wins- " + player1Wins;
                resetGame();
            }

            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                timer1.Stop();
                MessageBox.Show("Computer Wins");
                AiWins++;
                label2.Text = "AI Wins- " + AiWins;
                resetGame();
            }
        
        }

    }
}
