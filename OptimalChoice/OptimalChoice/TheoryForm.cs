using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalChoice_
{
    public partial class TheoryForm : Form
    {
        public TheoryForm()
        {
            InitializeComponent();
            string fileQuestions = "теория.txt"; ;
            var inFile = new StreamReader(fileQuestions);
            textBox1.Text = inFile.ReadToEnd(); //считываем данные
            inFile.Close();
        }
    }
}
