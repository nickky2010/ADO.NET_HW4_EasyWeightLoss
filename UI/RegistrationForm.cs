using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class RegistrationForm : Form
    {
        public User User { get; private set; }
        public RegistrationForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Text = "Mad";
            textBox4.Text = "123456";
            textBox5.Text = "123456";
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == textBox4.Text)
            {
                User = new User
                {
                    Login = textBox1.Text,
                    Password = textBox4.Text,
                    Age = Convert.ToInt32(numericUpDown1.Value),
                    Sex = (Sex)comboBox1.SelectedIndex,
                    ActivityLevel = (ActivityLevel)comboBox2.SelectedIndex
                };
                User.Roles.Add(new Role { RoleName = "User"});
                DialogResult = DialogResult.OK;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != textBox4.Text)
            {
                label7.Visible = true;
                textBox5.ForeColor = Color.Red;
            }
            else
            {
                label7.Visible = false;
                textBox5.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
