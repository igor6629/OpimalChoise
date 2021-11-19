using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalChoice_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Обновление матрицы 
        void refreshWeightsMatrix()
        {
            Graph graph = Graph.getInstance();
            dataGridView2.Columns.Clear(); // очищаем матрицу смежности
            for (int i = 0; i < graph.N; i++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.Name = "column" + i.ToString();
                column.HeaderText = (i + 1).ToString();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns.Add(column);
                dataGridView2.Rows.Add();
            }
            // заполняем диагональные элементы
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2[j, i].Value = graph.A[i, j];
                    if (i == j)
                    {
                        dataGridView2[i, j].ReadOnly = true;
                        dataGridView2[i,j].Style.BackColor=Color.DarkGray;
                    }
                }
            }
        }

        // Обновить размер матрицы
        private void button_RefrashMatrix_Click(object sender, EventArgs e)
        {
            Regex rxNums = new Regex(@"^\d+$"); // любые цифры
            if (!rxNums.IsMatch(textBox_MatrixSize.Text))
                MessageBox.Show("Повторите ввод количества вершин графа", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Graph graph = Graph.getInstance();
                graph.N = Int32.Parse(textBox_MatrixSize.Text);
                graph.newMatrix();
                refreshWeightsMatrix();
            }
        }

        // загрузка с файла
        private void button7_Click(object sender, EventArgs e)
        {
            Graph graph = Graph.getInstance();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Входные данные(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            MessageBox.Show("Файл успешно считан");
            string[] row = fileText.Split('\n');
            graph.N = Convert.ToInt32(row[0]);
            graph.newMatrix();
            for (int i = 1; i < graph.N + 1; i++)
            {
                string[] column = row[i].Split(' ');
                for (int j = 0; j < graph.N; j++)
                    graph.A[i - 1, j] = Convert.ToInt32(column[j]);
            }
            // обновляем данные на форме
            textBox_MatrixSize.Text = graph.N.ToString();
            refreshWeightsMatrix();
        }

        // сохранение в файл
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Матрица смежности(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            Graph graph = Graph.getInstance();
            string toFIle = "";
            toFIle = graph.N.ToString() + "\n";
            for (int i = 0; i < graph.N; i++)
            {
                for (int j = 0; j < graph.N; j++)
                {
                    toFIle += dataGridView2[i, j].Value.ToString() + " ";
                }
                toFIle += "\n";
            }
            System.IO.File.WriteAllText(filename, toFIle);
            MessageBox.Show("Файл сохранен");
        }

        // очистка
        private void button2_Click(object sender, EventArgs e)
        {
            Graph graph = Graph.getInstance();
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2[i, j].Value = 0;
                    graph.A[i, j] = 0;
                }
            }
        }

        // Поиск оптимального пути
        private void button1_Click(object sender, EventArgs e)
        {
            Graph graph = Graph.getInstance();
            for (int i = 0; i < graph.N; i++)
            {
                for (int j = 0; j < graph.N; j++)
                {
                    graph.A[i, j] = Convert.ToInt32(dataGridView2[j, i].Value);
                }
            }
            graph.Dijkstra();
            textBox1.Clear();
            for (int i = 1; i < graph.N; i++)
            {
                textBox1.Text += "Оптимальное расстояние от 1 вершины до " + (i + 1).ToString() + " равно:  " +
                                 graph.d[i].ToString() + "\r\n";
            }

        }

        private void теорияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheoryForm theoryForm = new TheoryForm();
            theoryForm.Show();
        }

        private void тестированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.Show();
        }
    }
}
