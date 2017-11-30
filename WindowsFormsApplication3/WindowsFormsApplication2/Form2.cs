using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        public delegate void StudentRatingProcessor(Group group);

        enum RatingStatus { Passed, Notpassed };

        

        class StudentGroupActions
        {
            //печать рейтинговой ведомости
            public static void PrintRatingVedomost(Group group)
            {
                string s="";

                MessageBox.Show(group.GroupTitle);
                for (int i = 0; i < group.GroupSize; i++)
                {
                    s= s+ (Environment.NewLine+group[i].FIO + "  ");
                    for (int j = 0; j < 4; j++)
                        s = s + (group[i][j] + " ");
                }
                MessageBox.Show(s);
                s = "";
            }
            //расчет рейтинга студентов
            public static void CalculateRatings(Group group)
            {
                for (int i = 0; i < group.GroupSize; i++)
                {
                    int summBalls = 0;
                    for (int j = 0; j < 4; j++) summBalls += group[i][j];

                    if (summBalls >= (10 * 4 / 2)) group[i].Rating = (int)RatingStatus.Passed;
                    else group[i].Rating = (int)RatingStatus.Notpassed;
                }
            }
            //печать зачетной ведомости
            public static void PrintRankingList(Group group)
            {
                string s="";
                MessageBox.Show(group.GroupTitle);
                for (int i = 0; i < group.GroupSize; i++)
                {
                    s = s+ (group[i].FIO + "  ")+ ((group[i].Rating == (int)RatingStatus.Passed) ? "ЗАЧТЕНО" : "НЕЗАЧТЕНО")+ Environment.NewLine;
                }
                MessageBox.Show(s);
                s = "";
            }
        }

        public class Student
        {
            String fio;
            public String FIO { set { fio = value; } get { return fio; } }

            Byte[] balls;
            public Byte this[int i] { get { return balls[i]; } set { balls[i] = value; } }

            int rating;
            public int Rating { get { return rating; } set { rating = value; } }

            public Student(String FIO)
            {
                rating = 0;
                balls = new Byte[4];
                fio = FIO;
            }
        }

        public class Group
        {
            int groupSize;
            string groupTitle = "";

            public string GroupTitle { get { return groupTitle; } }
            public int GroupSize { get { return groupSize; } }

            Student[] students;
            public Student this[int i] { get { return students[i]; } }

            public Group(string Title, int Size)
            {
                groupTitle = Title;
                groupSize = Size;
                students = new Student[Size];
            }
            public void InitRandom()
            {
                try
                {
                    Random rnd = new System.Random();
                    for (int i = 0; i < GroupSize; i++)
                    {
                        String randomString = "";
                        for (int j = 0; j < 5; j++)
                            randomString += (rnd.Next(255).ToString());
                        students[i] = new Student(randomString);

                        for (int j = 0; j < 4; j++) students[i][j] = (byte)rnd.Next(10);
                    }
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Group ist110 = new Group("IST110", 10);
            ist110.InitRandom();

            StudentRatingProcessor studentRating;

            StudentRatingProcessor Print = StudentGroupActions.PrintRatingVedomost;
            StudentRatingProcessor Calculate = StudentGroupActions.CalculateRatings;
            StudentRatingProcessor PrintList = StudentGroupActions.PrintRankingList;

            studentRating = Print;
            studentRating += Calculate;
            studentRating += PrintList;

            studentRating(ist110);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
    }
    
}
