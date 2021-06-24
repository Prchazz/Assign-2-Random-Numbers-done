using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program

    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();



        }
        //-----------------variables------------------

        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static string message = "Please enter your name ";
        private static string message2 = "Do you want to add another name y/n? ";
        private static string userInput;
        private static int raffleNumber;
        private static string otherGuest;
        private static Random _rdm = new Random();


        //-----------------Method 1 -------------------
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();

            while (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Name can't be empty. Please enter your name.");
                userInput = Console.ReadLine();
            }

            return userInput;


        }
        //-----------------Method 2---------------------
        private static void GetUserInfo()
        {
            string userName;

            do
            {
                userName = GetUserInput(message);
                raffleNumber = GenerateRandomNumber(min, max);
                AddGuestInRaffle(raffleNumber, userName);
                otherGuest = GetUserInput(message2);

            }
            while (otherGuest == "y");
        }

        //-----------------Method 3----------------------
        private static int GenerateRandomNumber(int min, int max)
        {
            int randomNum = _rdm.Next(min, max);
            return randomNum;
        }
        //-----------------Method 4-----------------------
        private static void AddGuestInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }
        //-----------------Method 5------------------------
        private static void PrintGuestsName()
        {
            foreach (var kvp in guests)

            {
                Console.WriteLine(kvp);
            }
        }
        //------------------Method 6------------------------
        private static int GetRaffleNumber(Dictionary<int, string> guests)
        {
            int index = _rdm.Next(guests.Count);
            int key = guests.Keys.ElementAt(index);
            return key;
        }
        //------------------Method 7------------------------
        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}");
        }

    }

}
