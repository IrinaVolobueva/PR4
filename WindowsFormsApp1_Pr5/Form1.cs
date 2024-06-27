using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1_Pr4
{
    public partial class SortingAnArray : Form
    {

        public SortingAnArray()
        {
            InitializeComponent();
        }
        public delegate void SortingDelegate();

        public void Sorting()
        {
            SortingDelegate sortingDelegate = SortingImplementation;
            sortingDelegate();
        }

        private void SortingImplementation()
        {
            if (!String.IsNullOrEmpty(arrayTextBox.Text))
            {
                string[] elements = arrayTextBox.Text.Split(' ');
                if (AreAllInts(elements))
                {
                    int[] intArray = elements.Select(int.Parse).ToArray();
                    ArrayProcessor<int> array = new ArrayProcessor<int>(intArray);
                    array.CocktailSort();

                    foreach (int element in array.array)
                    {
                        shakerTextBox.Text += element + " ";
                    }

                    scopeTextBox.Text += array.FindRange();
                }
                else if (AreAllDoubles(elements))
                {
                    double[] doubleArray = elements.Select(double.Parse).ToArray();
                    ArrayProcessor<double> array = new ArrayProcessor<double>(doubleArray);
                    array.CocktailSort();

                    foreach (double element in array.array)
                    {
                        shakerTextBox.Text += element + " ";
                    }

                    scopeTextBox.Text += array.FindRange();
                }
                else
                {
                    MessageBox.Show("Элементы массива должны быть одного типа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Строка не может быть пустой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Метод AreAllInts() помогает определить тип int.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        private bool AreAllInts(string[] elements)
        {
            foreach (string element in elements)
            {
                if (!Int32.TryParse(element, out int i))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Метод AreAllInts() помогает определить тип double.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        private bool AreAllDoubles(string[] elements)
        {
            foreach (string element in elements)
            {
                if (!Double.TryParse(element, out double i))
                {
                    return false;
                }
            }
            return true;
        }
        private void calculate_Click(object sender, EventArgs e)
        {
            Sorting();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arrayTextBox.Clear();
            shakerTextBox.Clear();
            scopeTextBox.Clear();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sorting();
        }

        private void aboutTheProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTheProgramm about = new AboutTheProgramm();
            about.Show();
        }
    }
}
