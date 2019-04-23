using System;

namespace HeapSort
{
    class Program
    {

        private static void Heapify(int[] mass, int index, int size)
        {
            int left = Int32.MinValue;
            int right = Int32.MinValue;
            
            if (2*index+1 <= size)
            {
             left = mass[2*index+1];   
            }
            if ((2*index+2) <= size)
            {
             right = mass[2*index+2];   
            }

            if (index*2+1 <= size && mass[index] < left)
            {
                int buf = mass[index];
                mass[index] = mass[index*2+1];
                mass[index*2+1] = buf;

                Heapify(mass, index*2+1, size);
            }

            if ((index*2+2) <= size && mass[index] < right)
            {
                int buf = mass[index];
                mass[index] = mass[index*2+2];
                mass[index*2+2] = buf;

                Heapify(mass, index*2+2, size);
            }
        }

        private static void HeapBuild(int[] mass, int size)
        {
            for (int i = mass.Length/2-1; i >= 0; i--)
            {
                Heapify(mass, i, size);
            }
        }

        private static void HeapSort(int[] mass)
        {
            int size = mass.Length-1;
            HeapBuild(mass, size);
            while (size > 0)
            {
                int buf = mass[size];
                mass[size] = mass[0];
                mass[0] = buf;
                size--;
                Heapify(mass, 0, size);
            }
        }

        static void Main(string[] args)
        {
            int[] mass = {1,3,5,7,9,2,4,6,8,43,15,27,10,12};
            foreach (int item in mass)
            {
                Console.Write("{0} ",item);
            }
            Console.WriteLine("Before sort");

            HeapSort(mass);

            foreach (var item in mass)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("After heap sort");
        }
    }
}
