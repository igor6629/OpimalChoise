using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalChoice_
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            tests = new Tests();
            currentQuestions = random.Next(0, tests.Questions.Count);
            countQuestions = tests.Questions.Count;
            count = 1;
            show();
            random = new Random();
        }

        private Tests tests;
        private int countQuestions;
        private int currentQuestions;
        private int countCorrectQuestions;
        private int correctQuestions;
        private int count;
        private Random random = new Random();

        public void show()
        {
            label_questions.Text = tests.Questions[currentQuestions].QuestionStr;
            radioButton1.Text = "";
            radioButton2.Text = "";
            radioButton3.Text = "";
            radioButton4.Text = "";
            int sizeStr = 150;
            bool isFirst;
            while (radioButton1.Text == "" && radioButton2.Text == "" && radioButton3.Text == "" &&
                   radioButton4.Text == "")
            {
                isFirst = true;
                while (tests.Questions[currentQuestions].Answers.Count != 0)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            if (isFirst)
                            {
                                correctQuestions = 1;
                                isFirst = false;
                            }
                            if (radioButton1.Text == "")
                            {
                                radioButton1.Text = tests.Questions[currentQuestions].Answers.First();
                                if (radioButton1.Text.Length > sizeStr)
                                    radioButton1.Text = radioButton1.Text.Insert(sizeStr, Environment.NewLine);
                                tests.Questions[currentQuestions].Answers.RemoveAt(0);
                            }
                            break;
                        case 2:
                            if (isFirst)
                            {
                                correctQuestions = 2;
                                isFirst = false;
                            }
                            if (radioButton2.Text == "")
                            {
                                radioButton2.Text = tests.Questions[currentQuestions].Answers.First();
                                if (radioButton2.Text.Length > sizeStr)
                                    radioButton2.Text = radioButton2.Text.Insert(sizeStr, Environment.NewLine);
                                tests.Questions[currentQuestions].Answers.RemoveAt(0);
                            }
                            break;
                        case 3:
                            if (isFirst)
                            {
                                correctQuestions = 3;
                                isFirst = false;
                            }
                            if (radioButton3.Text == "")
                            {
                                radioButton3.Text = tests.Questions[currentQuestions].Answers.First();
                                if (radioButton3.Text.Length > sizeStr)
                                    radioButton3.Text = radioButton3.Text.Insert(sizeStr, Environment.NewLine);
                                tests.Questions[currentQuestions].Answers.RemoveAt(0);
                            }
                            break;
                        case 4:
                            if (isFirst)
                            {
                                correctQuestions = 4;
                                isFirst = false;
                            }
                            if (radioButton4.Text == "")
                            {
                                radioButton4.Text = tests.Questions[currentQuestions].Answers.First();
                                if (radioButton4.Text.Length > sizeStr)
                                    radioButton4.Text = radioButton4.Text.Insert(sizeStr, Environment.NewLine);
                                tests.Questions[currentQuestions].Answers.RemoveAt(0);
                            }
                            break;
                    }
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            tests.Questions.RemoveAt(currentQuestions);
            currentQuestions = random.Next(0, tests.Questions.Count);
            int temp = countCorrectQuestions;
            switch (correctQuestions)
            {
                case 1:
                    if (radioButton1.Checked)
                    {
                        countCorrectQuestions++;
                    }
                    break;
                case 2:
                    if (radioButton2.Checked)
                    {
                        countCorrectQuestions++;
                    }
                    break;
                case 3:
                    if (radioButton3.Checked)
                    {
                        countCorrectQuestions++;
                    }
                    break;
                case 4:
                    if (radioButton4.Checked)
                    {
                        countCorrectQuestions++;
                    }
                    break;
            }
            if (temp == countCorrectQuestions)
            {
                MessageBox.Show("Неправильный ответ", "Тестирование", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Правильный ответ", "Тестирование", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            if (tests.Questions.Count > 0 && count != 5)
            {
                count++;
                show();
            }
            else
            {
                MessageBox.Show(
                    "Результат тестирования: " + countCorrectQuestions + " ответов из 5",
                    "Тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = false;
            }
        }
    }
}
