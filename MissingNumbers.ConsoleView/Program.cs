namespace MissingNumbers.ConsoleView
{
    using MissingNumbers.BusinessLogic.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        #region Attributes
        /// <summary>
        /// Regular expression that validate numbers with a only whitespace.
        /// </summary>
        private const string RX_ONLYNUMBER_WITH_ONE_WHITESPACE = "^[(0-9 ]*$";

        /// <summary>
        /// Regular expression that validate numbers only.
        /// </summary>
        private const string RX_ONLYNUMBER = "^[(0-9]*$";

        /// <summary>
        /// Static attribute to access the business layer.
        /// </summary>
        private static readonly IMissingNumber missingNumber = new MissingNumbers.BusinessLogic.Implement.MissingNumber();
        #endregion

        #region Main Builder App
        /// <summary>
        /// Main app.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, input the length value of arr array");
                int n = GetLengthArray();

                Console.WriteLine("Please, enter the first array of numbers join by a white space");
                Console.WriteLine("Ex: 123 456 789");
                List<int> arrValues = GetArray(n);

                Console.WriteLine("Please, input the length value of brr array");
                int m = GetLengthArray();

                Console.WriteLine("Please, enter the second array of numbers join by a white space");
                Console.WriteLine("Ex: 123 456 789");
                List<int> brrValues = GetArray(m);

                List<int> result = missingNumber.GetMissingNumbers(n, arrValues, m, brrValues);
                if (result.Any())
                {
                    string numbers = string.Join(" ", result);
                    Console.WriteLine($"This is the missing numbers: {numbers}");
                }
                else
                {
                    Console.WriteLine($"No missing number found");
                }
            }
            catch (ArgumentException arEx)
            {
                Console.WriteLine(arEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, occurred was an error");
            }

            Console.ReadLine();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Get the array of what user inputted.
        /// </summary>
        /// <param name="n">Length of the array</param>
        /// <returns>Returns the list of numbers inputted by the user.</returns>
        private static List<int> GetArray(int n)
        {
            bool isValid = false;
            List<int> list = new List<int>();
            string input = string.Empty;
            string[] stringList;
            List<int> intList = new List<int>();

            Regex regex = new Regex(RX_ONLYNUMBER_WITH_ONE_WHITESPACE);
            while (!isValid)
            {
                input = Console.ReadLine();
                if (!regex.IsMatch(input) || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ups!, this input is not type integer");
                    Console.WriteLine("Please, input the value of array... only integers numbers");
                }
                else if (HasConsecutiveSpaces(input))
                {
                    Console.WriteLine("Please, enter only one white space");
                    Console.WriteLine("Ex: 234 654 789");
                }
                else
                {
                    stringList = input.Trim().Split(" ");
                    intList = stringList.Select(int.Parse).ToList();
                    if (!intList.Count.Equals(n))
                    {
                        Console.WriteLine("The defined length does not match the set entered");
                        Console.WriteLine($"The length was {n}");
                        Console.WriteLine("Please, input again the array's value");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }

            return intList;
        }

        /// <summary>
        /// This method is for get the length to array inputted by user.
        /// </summary>
        /// <returns>Return the length inputted by user of type interger.</returns>
        private static int GetLengthArray()
        {
            Regex regex = new Regex(RX_ONLYNUMBER);
            bool isValid = false;
            string input = string.Empty;
            while (!isValid)
            {
                input = Console.ReadLine();
                if (!regex.IsMatch(input) || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ups!, this input is not type integer");
                    Console.WriteLine("Please, input the length value of arr array... only integers numbers");
                }
                else if (HasConsecutiveSpaces(input))
                {
                    Console.WriteLine("Please, enter only one white space");
                    Console.WriteLine("Ex: 234");
                }
                else
                {
                    isValid = true;
                }
            }

            return int.Parse(input.Trim());
        }

        /// <summary>
        /// This method is for valid the whitespaces.
        /// </summary>
        /// <param name="text">Text to valid with whitespaces.</param>
        /// <returns>Return <c>true</c> if the text inputted is correct.</returns>
        private static bool HasConsecutiveSpaces(string text)
        {
            bool inSpace = false;

            foreach (char ch in text)
            {
                if (ch == ' ')
                {
                    if (inSpace)
                    {
                        return true;
                    }

                    inSpace = true;
                }
                else
                {
                    inSpace = false;
                }
            }

            return false;
        } 
        #endregion
    }
}
