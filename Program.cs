using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine ("Author - Inno Khabi");
            Console.WriteLine ("This program converts any number to binary. \nYou can press Escape then Return/Enter to quit.");
            while (true)
            {
                ConvertToBinary ();
                if(Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
            Console.ReadLine ();
        }

        static void ConvertToBinary ()
        {

            //get input (number to be converted)
            int Input = 1;
            try
            {
                Console.Write ("\nPlease enter a number: ");
                Input = Convert.ToInt32 (Console.ReadLine ());

                //make our multiples i.e 1,2,4,8,16,32,64
                int a = 1;
                List<int> Bits = new List<int> ();
                while (a <= Input)
                {
                    Bits.Add (a);
                    a *= 2;
                }

                //create new list for holding needed bits 
                List<int> NewNeededBits = new List<int> ();
                foreach(int bit in Bits)
                {
                    if (bit <= Input)
                    {
                        NewNeededBits.Add (bit);
                    }
                }

                NewNeededBits.Reverse ();

               /* foreach (int i in NewNeededBits)
                {
                    Console.WriteLine (i);
                }*/

                //make array for with elements.count equal to number of bits needed
                //and initialise all values to zero
                int[] BinaryResult = new int[ NewNeededBits.Count] ;
                BinaryResult[ 0 ] = 1;
                for (int j = 1; j < BinaryResult.Length ; j++)
                {
                    BinaryResult[ j ] = 0; 
                }

                int UnfinalisedOutput = NewNeededBits[ 0 ];

                //check if input index zero == bits array index zero 
                if(Input == UnfinalisedOutput)
                {
                    BinaryResult[ 0 ] = 1;
                    for (int k = 1; k < NewNeededBits.Count; k++)
                    {
                        BinaryResult[ k ] = 0;
                    }
                }
                else
                {
                    for (int l = 1; l < NewNeededBits.Count; l++)
                    {
                        UnfinalisedOutput += NewNeededBits[ l ];
                        if (UnfinalisedOutput == Input) //make current index 1 and everything zeros and break
                        {
                            BinaryResult[ l ] = 1;
                            break;
                        }
                        else if(UnfinalisedOutput > Input) //make current index 0 
                        {
                            BinaryResult[ l ] = 0;
                            UnfinalisedOutput -= NewNeededBits[ l ];
                        }
                        else if(UnfinalisedOutput < Input)
                        {
                            BinaryResult[ l ] = 1;
                        }
                    }
                }

                //print out the result
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (int bit in BinaryResult)
                {
                    Console.Write (bit);
                }

                Console.ForegroundColor = ConsoleColor.White;
            }

            catch (Exception e)
            {
                Console.WriteLine (e.Message) ;
            }

        }
    }
}
