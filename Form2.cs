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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Multiplayer newObject = new Multiplayer(false, textBox1.Text);
            Visible = false;
            if (!newObject.IsDisposed)
                newObject.ShowDialog();
            Visible = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Multiplayer newObject = new Multiplayer(true);
            Visible = false;
            if (!newObject.IsDisposed)
                newObject.ShowDialog();
            Visible = true;
        }
    }
}
