using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class CSVHandler
    {
        static string csvFilePath = "/BridgeLabz/AddressBookSystem/AddressBook/contact.csv";
        static Dictionary<string, List<Contact>> contactList = new Dictionary<string, List<Contact>>();
        internal static void WriteIntoCSVFile(Dictionary<string, List<Contact>> contactList)
        {
            //create stream writer stream and pass the csv file path
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                //creating the csv writer path
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //create the header that are the properties of the contact list
                    csvWriter.WriteHeader<Contact>();
                    csvWriter.NextRecord();

                    foreach (var data in contactList)
                    {
                        string key = data.Key;
                        foreach (var person in data.Value)
                        {
                            //write the list as record in the file
                            csvWriter.WriteField(key);
                            csvWriter.WriteRecord(person);
                            csvWriter.NextRecord();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// csv operation
        /// </summary>
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = "/BridgeLabz/AddressBookSystem/AddressBook/data.txt";
            string exportFilePath = "/BridgeLabz/AddressBookSystem/AddressBook/contact.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>();
                Console.WriteLine("Read data successfully from demo.csv, here are city");
                foreach (Contact addressData in records)
                {
                    Console.Write("\t" + addressData.firstName); 
                }
                Console.WriteLine("\n************ reading from csv file and write to csv file");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
