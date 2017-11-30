using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        int click;
        Dispatcher m1 = new Dispatcher();
        Locksmith m2 = new Locksmith();
        Loader m3 = new Loader();
        public Form3()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Cargo i = new Cargo();
            richTextBox1.AppendText(i.Location_Cargo() + Environment.NewLine);
        }

               private void button8_Click(object sender, EventArgs e)
        {
            click = 1;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button12.Enabled = true;
            button11.Enabled = true;
            textBox1.Enabled = true;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            click = 2;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button12.Enabled = true;
            button11.Enabled = true;
            textBox1.Enabled = true;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            click = 3;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button12.Enabled = true;
            button11.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            switch (click)
            {
                case 1:
                    richTextBox1.AppendText("Задача: " + m1.Work + Environment.NewLine);

                    break;
                case 2:
                    richTextBox1.AppendText("Задача: " + m2.Work + Environment.NewLine);

                    break;
                case 3:
                    richTextBox1.AppendText("Задача: " + m3.Work + Environment.NewLine);

                    break;
            }
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button12.Enabled = false;
            button11.Enabled = false;
            textBox1.Enabled = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            switch (click)
            {
                case 1:
                    m1.Work = textBox1.Text; 
                    richTextBox1.AppendText("Задача обновлена: " + m1.Work + Environment.NewLine);

                    break;
                case 2:
                    m2.Work = textBox1.Text;
                    richTextBox1.AppendText("Задача обновлена: " + m2.Work + Environment.NewLine);

                    break;
                case 3:
                    m3.Work = textBox1.Text;
                    richTextBox1.AppendText("Задача обновлена: " + m3.Work + Environment.NewLine);

                    break;
            }
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button12.Enabled = false;
            button11.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Clear();
        }

        private void сухогрузToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargo_Ship S1 = new Cargo_Ship();
            richTextBox1.AppendText(S1.State("Сухогруз") + Environment.NewLine);
        }

        private void танкерToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cargo_Ship S1 = new Cargo_Ship();
            richTextBox1.AppendText(S1.State("Танкер") + Environment.NewLine);
        }

        private void контейнеровозToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cargo_Ship S1 = new Cargo_Ship();
            richTextBox1.AppendText(S1.State("Контейнеровоз") + Environment.NewLine);
            
        }

        private void сервисныйКорабльToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Service_Ship S4 = new Service_Ship();
            richTextBox1.AppendText(S4.Location() + Environment.NewLine);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
    }
}
