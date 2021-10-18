using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.Services.Common;
using OtpNet;

namespace Bitskins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private Bot _bot = new Bot("ff275896-465a-4be6-a895-4f94836bf895", "D5KtAakQ8qLT1-wgjk4w9hAkKI8");
        

        private void button1_Click(object sender, EventArgs e)
        {
            int minPrice = (Convert.ToInt32(textBox1.Text));
            int maxPrice = (Convert.ToInt32(textBox2.Text));
            int margin = Convert.ToInt32(textBox4.Text);
            int timeout = Convert.ToInt32(textBox3.Text);


            _bot.Start(minPrice, maxPrice, margin, timeout);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
