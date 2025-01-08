using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml;

namespace AddressBookApp
{
    internal class AddressBookFileIo_Json
    {
        private static string path = @"F:\c#practice\Collection in c#\AddressBookApp\addressbook.json";

        public static bool IsFileExist()
        {
            return File.Exists(path);
        }

        public static void CreateTextFile()
        {
            try
            {
                if (!IsFileExist())
                {
                    using (File.Create(path))
                    {
                        Console.WriteLine("Text file created successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("File already exists.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteAddressBookToFile(Address_Book book)
        {
            try
            {
                if (book == null)
                {
                    Console.WriteLine("Address book is empty. Nothing to write.");
                    return;
                }

                // Serialize the address book into JSON format
               

                string result = JsonConvert.SerializeObject(book.GetContacts(), Newtonsoft.Json.Formatting.Indented);
               

                if (IsFileExist())
                {
                    File.AppendAllText(path, result);
                    Console.WriteLine($"Address book written to file successfully.");
                }
                else
                {
                    CreateTextFile();
                    File.AppendAllText(path, result);
                    Console.WriteLine($"Address book written to file successfully.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static Address_Book ReadAddressBookFromFile()
        {
            try
            {
                if (IsFileExist())
                {
                    // Read the file content
                    string json = File.ReadAllText(path);

                    // Deserialize JSON back to Address_Book object
                    var book = JsonConvert.DeserializeObject<HashSet<Contacts>>(json);

                    Console.WriteLine("Address book loaded from file successfully.");
                    return new Address_Book(book);
                }
                else
                {
                    throw new FileNotFoundException("File is not found in the specified path.", path);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static void ViewAddressBookFromFile()
        {
            try
            {
                if (IsFileExist())
                {
                    // Read and display the file content
                    string json = File.ReadAllText(path);
                    Console.WriteLine("Content of the Address Book file:");
                    Console.WriteLine(json);
                }
                else
                {
                    throw new FileNotFoundException("File is not found in the specified path.", path);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
