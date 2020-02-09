using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Divider
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; //n is the integer that the user gives
            Console.WriteLine("Enter number"); //user output instructions
            n = int.Parse(Console.ReadLine()); //reading user's number

            int sum = 0; //sum will be the sum of the dividers


// creating loop as to find all the dividers for the number that the user has given by making i which is the counter equal to the number
//given by the user and performing the loop before the counter becomes 0 and downgrading it as to get all numbers
                for (int i = n; i > 0; i--) 
                {
                    n = n - 1; //substracting 1 from the number that the user gives as we do not want to divide the number given by the user
                    if ((n % 3 == 0) || (n % 5 == 0)) //checking if the numbers in the loop (numbers up to the user's input) are divisable by 3 or 5
                    {
                        //Console.WriteLine(n); //a testing method i provide as to view the numbers which are divisable. t is set as a comment as it is not a specification of the problem
                        sum = sum + n;//adding up the numbers which are divisable by 3 or 5
                    }
                }

//ouprinting the sum. this is done outside the loop as we only want to print the sum once. the sum is calculated in the llok as to capture all numbers which are divisable by 3 or 5
            Console.WriteLine("The sum is: " + sum); 
            Console.ReadLine(); //add a readline so the program will not close immediatly and the user has time to view results
        }
    }
}
