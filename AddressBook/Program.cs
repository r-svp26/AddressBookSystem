using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressManagement.ReadInput();
        }
    }
}
