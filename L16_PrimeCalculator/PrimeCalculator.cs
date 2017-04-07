using System;
using System.Collections.Generic;

namespace L16_PrimeCalculator
{
    class PrimeCalculator
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;           

            while (keepGoing)
            {
                int userInput = GetInput();
                int resultOutput = CalcInput(userInput);

                //begin the program processing
                Console.WriteLine("The " + userInput + "th prime number is " +
                                    resultOutput);

                //exit program               
                if (ExitProgram())
                {
                    Console.WriteLine("Goodbye!");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }

        //get the user's input
        public static int GetInput()
        {
            string input = "";
            int resultInt = 0;

            Console.WriteLine("Enter a whole number greater than 1 and less " +
                                "than 200.");
            input = Console.ReadLine();

            //check that there is actually some input and that its an integer
            if(!int.TryParse(input, out resultInt))
            {
                Console.WriteLine("Invalid entry");
                return GetInput();
            }

            //check that the input is within range
            if (resultInt > 200 || resultInt <= 1)
            {
                Console.WriteLine("Number is too high or too low");
                return GetInput();
            }
            else
            {
                return resultInt;
            }
        }

        //calculate the nth (user inputed value) prime
        public static int CalcInput(int input)
        {
            int count = 0;
            List<int> primes = new List<int>();
            
            //prevent the computer from running too long and find the nth prime
            for (int i = 0; i < 2000; i++)
            {                             
                if (isPrime(i) && count < input)
                {
                    primes.Add(i);
                    count++;
                    Console.WriteLine(count + ": " + i);
                }
            }

            return primes[primes.Count-1];              
        }

        //check if a number is prime
        public static Boolean isPrime(int input)
        {            
            // check for 0 
            if ((input & 1) == 0)
            {
                //check if its a 2
                if (input == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            //test each number 3 or more against the square 
            for (int i = 3; (i * i) <= input; i += 2)
            {
                if ((input % i) == 0)
                {
                    return false;
                }
            }
            
            //exclude 1
            return input != 1;
        }

        //exit the program when the user wants to
        public static Boolean ExitProgram()
        {
            Console.WriteLine("Do you want to continue? Enter Y or N.");
            var KP = Console.ReadKey(true);

            while (KP.Key != ConsoleKey.N && KP.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Not a vaid answer. Do you want to " +
                    "continue? Enter Y or N.");
                KP = Console.ReadKey(true);
            }
            return KP.Key == ConsoleKey.N ? true : false;
        }

    }
}
