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

        //Queue ismini “ZEYNEPOZTURKMEN” olarak belirleyelim ve constructor üzerinden Queue ismini ve göndermek istediğimiz mesajı set edelim. Uygulamayı çalıştırmadan önce RabbitMQ Management ekranı üzerinden Queues tab’ına bir bakalım. Management ekranına “localhost:15672” adresinden erişebilirsiniz.

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
