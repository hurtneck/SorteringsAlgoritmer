using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace nummer_sortering
{
    internal class Program
    {
        static int numSwaps = 0;
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            Random rng = new Random();

            int[] unsortedList = { 1, 4, 3, 2, 0, 6, 7, 5 }; //new int[10000];
            /* for (int i = 0; i < unsortedList.Length; i++)
             {
                 unsortedList[i] = rng.Next(999);
             }*/
            Console.WriteLine("Detta är den osorterade listan");//skriver ut "detta är den osoterade listan"
            PrintArray(unsortedList);
            timer.Start();
            int[] sortedList = Quicksort(unsortedList);
            timer.Stop();

            Console.WriteLine($"\n\nDet tog {timer.Elapsed.TotalSeconds} att sortera. Resultatet är:");//skriver ut "detta ä den sorterade listan"
            Console.WriteLine($"Vi har gjort {numSwaps}byten");
            PrintArray(sortedList);//kommer skirva ut listan

            Console.ReadKey();
        }
        static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            numSwaps += 1;
        }


        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
                if (i % 20 == 0 && i != 0)
                {
                    Console.Write("\n");
                }

            }
        }

        static int[] Uselesssort(int[] unsorted)
        {
            Swap(unsorted, 0, 1);
            System.Threading.Thread.Sleep(1000);//paus för 1 sekund
            return unsorted;
        }

        static int[] BogoSort(int[] unsorted)
        {

            /* while (i< numSwaps-1)
             {
                 if (unsorted[i] > unsorted[i + 1])
                 {
                     isSorted = false;
                 }

                 if (i == 0) 

                 i++;
             }*/

            while (IsSorted(unsorted) == false)
            {
                unsorted = Shuffle(unsorted);



            }




            // 1 2 3 5 4 6 7 8 9
            //Kolla om listan är sorterad
            //om inte
            //blanda listan
            //gör om allt
            return unsorted;
        }

        static int[] Shuffle(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, i, rnd.Next(0, array.Length));
            }
            return array;
        }


        static bool IsSorted(int[] array)
        {
            for (int x = 0; x < array.Length - 1; x++)
            {
                if (array[x] > array[x + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static int[] Bubblesort(int[] unsorted)
        {
            bool hasSwitched = true;
            while (hasSwitched == true)
            {
                hasSwitched = false;
                for (int x = 0; x < unsorted.Length - 1; x++)
                {
                    if (unsorted[x] > unsorted[x + 1])
                    {
                        Swap(unsorted, x, x + 1);
                        hasSwitched = true;
                    }
                }
            }


            //gå igenom listan
            //jämför plats A och plats B
            //om plats A är mer än plats B
            //byt plats A och plats B
            //markera att byte har skett
            //A+1 och B+1(kolla nästa platser i listan)
            //gör om allt inga byten sker
            return unsorted;
        }

        static int[] SelectionSort(int[] unsorted)
        {
            int smallestValue = 1000000;//misna värdet i listan
            int smallestIndex = 0;//plasten för den minsta värdet
            for (int x = 0; x < unsorted.Length; x++)
            {
                for (int i = x; i < unsorted.Length; i++)
                {
                    if (unsorted[i] < smallestValue)
                    {
                        smallestValue = unsorted[i];
                        smallestIndex = i;
                    }
                }
                Swap(unsorted, x, smallestIndex);
                smallestValue = 1000000;
            }
            return unsorted;
        }

        static int[] Quicksort(int[] unsorted)
        {





            return unsorted;
        }
    }
}
