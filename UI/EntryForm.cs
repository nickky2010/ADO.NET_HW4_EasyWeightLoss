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
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
        }
        public string Login => textBox1.Text;
        public string Password => textBox2.Text;
        public string ErrorMessage
        {
            get => label3.Text;
            set { label3.Text = value; }
        }
    }
}
