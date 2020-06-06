using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormRabbitMQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly string _queueName = "ZEYNEPOZTURKMEN";
        private static Publisher _publisher;

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;

            _publisher = new Publisher(_queueName, name + " " + surname);
        }
    }
}
