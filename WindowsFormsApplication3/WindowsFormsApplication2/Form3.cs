using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public delegate void EventContainer();
        public event EventContainer Event1;
        int click;
        
        Dispatcher m1 = new Dispatcher();
        Locksmith m2 = new Locksmith();
        Loader m3 = new Loader();
  

        public Form3()
        {
            InitializeComponent();
            DT = new DelegateTime(StartTime);
        }
        ThreadClass TC1 = new ThreadClass();
        ThreadClass TC2 = new ThreadClass();
        ThreadClass TC3 = new ThreadClass();


        public delegate void DelegateTime(Label label);
        DelegateTime DT;
        Thread t1;

        void StartTime(Label label)
        {
            string s = DateTime.Now.Hour.ToString("..");
            s += ":";
            s += DateTime.Now.Minute.ToString("..");
            s += ":" + DateTime.Now.Second.ToString("..");
            label.Text = s;
        }

        void LabelTime()
        {
            t1 = Thread.CurrentThread;
                while (true)
            {
                Invoke(DT, label3);                               
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(label3, "Обед: диспетчеры - 12:00; Механики - 13:00; грузчики - 14:00");

            t1 = new Thread(LabelTime); 
            t1.IsBackground = true; 
            t1.Priority = ThreadPriority.Lowest;
            t1.Start(); 
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Cargo i = new Cargo();
            richTextBox1.AppendText(i.Location_Cargo() + Environment.NewLine);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
        
            ClassEvent CE = new ClassEvent();
            Event1 += CE.Message1;
            Event1 += CE.Message2;

            if (System.DateTime.Now.ToShortTimeString().Remove(System.DateTime.Now.ToShortTimeString().LastIndexOf(':')) == "12")
            {
                Event1();
                Event1 -= CE.Message1;
                Event1 -= CE.Message2;
           
            }
            else
            {
                click = 1;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button12.Enabled = true;
                textBox1.Enabled = true;
                button11.Enabled = true;
            }
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
       
            ClassEvent CE = new ClassEvent();
            Event1 += CE.Message1;
            Event1 += CE.Message2;

            if (System.DateTime.Now.ToShortTimeString().Remove(System.DateTime.Now.ToShortTimeString().LastIndexOf(':')) == "13")
            {
                Event1();
                Event1 -= CE.Message1;
                Event1 -= CE.Message2;
            
            }
            else
            {
                click = 2;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button12.Enabled = true;
                button11.Enabled = true;
                textBox1.Enabled = true;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
          
            ClassEvent CE = new ClassEvent();
            Event1 += CE.Message1;
            Event1 += CE.Message2;

            if (System.DateTime.Now.ToShortTimeString().Remove(System.DateTime.Now.ToShortTimeString().LastIndexOf(':')) == "14")
            {
                Event1();
                Event1 -= CE.Message1;
                Event1 -= CE.Message2;
            
            }
            else
            {
                click = 3;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button12.Enabled = true;
                button11.Enabled = true;
                textBox1.Enabled = true;
            }
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


                    /*  ThreadClass TC1 = new ThreadClass(progressBar1, button11);
                      Thread myThread1 = new Thread(new ThreadStart(TC1.PB));
                      Thread t = Thread.CurrentThread;
                      myThread1.IsBackground = true;
                      if (t.IsAlive == false)
                          myThread1.Start();
                      else
                          MessageBox.Show("Работники выпоняют задачу, подождите");*/


                    Thread myThread1 = new Thread(new ParameterizedThreadStart(TC1.PB));
                    myThread1.IsBackground = true;

                    if (TC1.PB1 == false)
                        myThread1.Start(progressBar1);
                    else
                        MessageBox.Show("Работники выпоняют задачу, подождите");

                    break;
                case 2:
                    m2.Work = textBox1.Text;
                    richTextBox1.AppendText("Задача обновлена: " + m2.Work + Environment.NewLine);

                    Thread myThread2 = new Thread(new ParameterizedThreadStart(TC2.PB));
                    myThread2.IsBackground = true;

                    if (TC2.PB1 == false)
                        myThread2.Start(progressBar2);
                    else
                        MessageBox.Show("Работники выпоняют задачу, подождите");

                    break;
                case 3:
                    m3.Work = textBox1.Text;
                    richTextBox1.AppendText("Задача обновлена: " + m3.Work + Environment.NewLine);

                    Thread myThread3 = new Thread(new ParameterizedThreadStart(TC3.PB));
                    myThread3.IsBackground = true;

                    if (TC3.PB1 == false)
                        myThread3.Start(progressBar3);
                    else
                        MessageBox.Show("Работники выпоняют задачу, подождите");

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
            t1.Abort();
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();

        }

        public int SetProgressBar(int i)
        {
            progressBar1.Minimum=0;
            progressBar1.Maximum= 1000;
            progressBar1.Value = i;
            return i;
        }


    }


}




 
 

