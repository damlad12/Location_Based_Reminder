using Remind_Location.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remind_Location
{
    public partial class Form2 : Form
    {

        private bool NewUser = false;
        private bool Login = false;
        public Form2()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            UserRepository userrepo = new UserRepository();

            if (NewUser)
            {
                if (userrepo.UserExists(username))
                {
                    MessageBox.Show("Username already exists.");
                }

                else
                {
                    userrepo.CreateNewUser(username, password);
                    MessageBox.Show("Username created");
                    Form1 form1 = new Form1(username);
                    form1.ShowDialog();
                }
            }

            else
            {
                if (userrepo.CorrectPassword(username, password))
                {
                    MessageBox.Show("Correct password.");
                    Form1 form1 = new Form1(username);
                    form1.ShowDialog();
                }
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewUser = true;
            button2.Visible = false;
            button3.Visible = false;
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            button1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Login = true;
            button2.Visible = false;
            button3.Visible = false;
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            button1.Visible = true;
        }
    }
}
