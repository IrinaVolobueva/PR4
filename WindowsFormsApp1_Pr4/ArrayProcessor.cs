using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1_Pr4
{
    internal class ArrayProcessor <T> where T : IComparable<T>
     {
        public T[] array;

        public ArrayProcessor(T[] array)
        {
            this.array = array;
        }

        public void CocktailSort() // Шейкерная сортировка
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        Swap(i, i + 1);
                        swapped = true;
                    }
                }
                for (int i = array.Length - 1; i > 0; i--)
                {
                    if (array[i].CompareTo(array[i - 1]) < 0)
                    {
                        Swap(i, i - 1);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public T FindRange() // Размах массива
        {
            T min = array.Min();
            T max = array.Max();
            return (dynamic)max - (dynamic)min;
        }

        private void Swap(int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
