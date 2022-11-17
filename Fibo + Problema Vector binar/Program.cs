using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibo___Problema_Vector_binar
{
    internal class Program
    {
        /// <summary>
        ///  Se da un vector de N lungime, 
        ///  vectorul poate contine doar 1 sau 0, 
        ///  se cere numarul vectorilor posibili in care v[i]*v[i+1] = 0
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti lungimea Vectorului:");
            int tocheck = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Exista ");
            ProblemCheck(tocheck);
            Console.Write(" de vectori posibili care satisfac cerinta.");
            Console.WriteLine();
            Console.ReadLine();
        }
        private static void ProblemCheck(int fibo)
        {
            if (fibo > 15) // VALORILE COINCID CU VALORILE DIN SIRUL LUI FIBONACCI CU UN OFFSET de 2. Peste 15 dureaza metoda de calculare a vectorilor individual
            {
                FiboOffset(fibo);
                return;
            }
            int pad = fibo;
            int n = (int)Math.Pow(2, pad);
            int count = 0;

            for (int i = 0; i < n; i++) // genereaza toate combinatiile de vectori de lungime "pad".
            {
                int[] v = new int[pad];
                v = GenerateBinarySeq(i, pad); // genereaza un vector cu elemente binare.
                VectorCheck(v, ref count); // verifica vectorul generat
            }
            Console.Write(count);

        }
        private static int[] GenerateBinarySeq(int i, int pad) // genereaza toate combinatiile de vectori, tratand fiecare vector ca o secventa binara, i este valoare secventei binare in zecimal
        {
            int[] v = new int[pad];
            string array = "";
            Stack<int> stack = new Stack<int>();
            while (i > 0)
            {
                stack.Push(i % 2);
                i = i / 2;
            }
            int z = pad - stack.Count;
            for (int j = 0; j < z; j++)
            {
                stack.Push(0);
            }
            while (stack.Count > 0)
            {
                for (int p = 0; p <= stack.Count; p++)
                {
                    array += stack.Pop().ToString();
                    //Console.Write(array);
                }
            }
            //Console.WriteLine(array);
            char[] arraytocheck = array.ToCharArray();
            for (int l = 0; l < arraytocheck.Length; l++)
            {
                v[l] = int.Parse(Convert.ToString(arraytocheck[l]));
                //Console.Write(arraytocheck[l]);
            }
            return v;
        }

        private static void VectorCheck(int[] v, ref int count)
        {
            for (int j = 0; j < v.Length - 1; j++)
            {
                if (v[j] == 0)
                {
                    continue;
                }
                if (v[j] == 1)
                {
                    if (j > 0)
                    {
                        if (v[j - 1] == 1)
                        {
                            return;
                        }
                    }
                    if (v[j + 1] == 1)
                    {
                        return;
                    }
                }
            }
            count++;
        }
        private static void FiboOffset(int v) 
            // sirul lui fibonacci cu un offset de 2. 
            // Adica FiboOffset(i) = Fibo(i+2)
            // considerand ca fibo(0) = 0;
        {
            int prev = 1;
            int nr = 1;
            for (int i = 0; i < v; i++)
            {
                int prevaux = nr;
                nr = prev + nr;
                prev = prevaux;
            }
            Console.WriteLine(nr);
        }
    }
}
