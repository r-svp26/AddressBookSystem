using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBook
{
    public class FileOperation
    {
        static string filepath = @"V:\BridgeLabz\AddressBookSystem\AddressBook\data.txt";
        /// <summary>
        /// write person details into data.txt
        /// </summary>
        /// <param name="addressDictionary"></param>
        internal static void WriteInTextFile(Dictionary<string, List<Contact>> contactList, string filePath)
        {
            if (File.Exists(filepath))
            {
                //using streamWriter write the data into the file 
                StreamWriter writer = new StreamWriter(filepath);
                foreach (var dickey in contactList)
                {
                    //write line method append next dat in the next line
                    writer.WriteLine("AddressBook Name:" + dickey.Key);
                    foreach (var list in dickey.Value)
                    {
                        string s = "Name:" + list.firstName + " " + list.lastName + " Address:" + list.address + " City:" + list.city + " State:" + list.state + " Zipcode:" + list.zipCode + " Ph.No:" + list.phoneNumber;
                        writer.WriteLine(s);
                    }
                    writer.WriteLine();
                }
                //close the stream
                writer.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        /// <summary>
        /// Reading data from data.txt and display to the console
        /// </summary>
        /// <param name="filePath"></param>
        internal static void ReadFromTextFile(string filePath)
        {
            Console.WriteLine("<---------Data from Text File---------->");
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
