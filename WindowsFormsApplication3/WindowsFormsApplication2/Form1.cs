using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Show(); 
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form3();
            ifrm.Show();
            this.Hide();
        }


    }
}
