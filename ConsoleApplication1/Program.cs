using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int[] generateArray(int n)
        {
            int[] A = new int[n];
            Random r = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                int v = r.Next(0, 100);
                if (v < 40)
                {
                    A[i] = r.Next(1, 11);//land
                }
                else
                    A[i] = 0;//sea
            }
            return A;
        }//*****
        static void Print(int[] A)
        {

            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
        }
        static int getMax(int[] A)
        {
            int max = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[max] < A[i])
                    max = i;
            }
            return max;
        }
        static int getNumber(int[] A, int value)//returns how often value occurs in array
        {
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == value)
                    sum++;
            }
            return sum;
        }
        static int[] longestIsland(int[] A)
        {
            int[] B = new int[A.Length + 2];
            B[0] = 0; B[11] = 0;
            for (int i = 1; i < B.Length - 1; i++)
            {
                int x = i - 1;
                B[i] = A[i - 1];
            }
            int Start = 0;
            int End = 0;
            int MaxLength = 0;
            int[] Indexes = new int[2];
            for (int i = 0; i < B.Length - 1; i++)
            {
                if (B[i] == 0 && B[i + 1] != 0)
                    Start = i;
                else if (B[i + 1] == 0 && B[i] != 0)
                {
                    End = i;
                    if (End - Start > MaxLength)
                        MaxLength = End - Start;
                }
                
            }
            Indexes[0] = Start;
            Indexes[1] = End;
            return Indexes;
        }
        static bool onTheLongest(int[] A) 
            {
            getMax(A);
            longestIsland(A);
            if (getMax(A)>=longestIsland(A)[0] && getMax(A) <= longestIsland(A)[1])
            {
                return true;
            }
            else
                return false;
            }
        static void Main(string[] args)
        {
            int n = 10;
            Console.WriteLine("Task 1: generate hights.(0=sea 0<Land)");
            int[] A = generateArray(n);
            int longest = longestIsland(A)[1] - longestIsland(A)[0];
            //A[5] = 10; A[8] = 10;
            Print(A);
            Console.WriteLine("\nTask 2: Find the first highest peak.");
            Console.WriteLine("Index of maximum: {0}, its value: {1}", getMax(A), A[getMax(A)]);
            Console.WriteLine("Task 3: How often is the highest peak attend?");
            Console.WriteLine(getNumber(A, A[getMax(A)]));
            Console.WriteLine("The length of the longest island is: "+ longest);
            Console.WriteLine("\nThe end!");
            Console.WriteLine("Is the highest pesk on the longest island?"+ onTheLongest(A));
            Console.ReadKey();
        }
    }
}
