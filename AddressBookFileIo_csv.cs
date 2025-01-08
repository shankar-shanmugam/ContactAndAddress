using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;

namespace AddressBookApp
{
    internal class AddressBookFileIo_csv
    {
        private static string csvPath = @"F:\c#practice\Collection in c#\AddressBookApp\addressbook.csv";

        public static bool IsCsvFileExist()
        {
            return File.Exists(csvPath);
        }

        public static void CreateCsvFile()
        {
            try
            {
                if (!IsCsvFileExist())
                {
                    using (var writer = new StreamWriter(csvPath))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        // Write header row
                        csv.WriteHeader<Contacts>();
                        Console.WriteLine("CSV file created successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("CSV file already exists.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteAddressBookToCsv(Address_Book book)
        {
            try
            {
                if (book == null || book.GetContacts().Count == 0)
                {
                    Console.WriteLine("Address book is empty. Nothing to write.");
                    return;
                }

                using (var writer = new StreamWriter(csvPath, true)) // Append mode
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (var contact in book.GetContacts())
                    {
                        csv.WriteRecord(contact);
                        csv.NextRecord(); // Move to the next line
                    }
                }

                Console.WriteLine("Address book written to CSV file successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static Address_Book ReadAddressBookFromCsv()
        {
            Address_Book book = new Address_Book();

            try
            {
                if (IsCsvFileExist())
                {
                    using (var reader = new StreamReader(csvPath))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Ignore missing header validation
                        MissingFieldFound = null // Ignore missing field validation
                    }))
                    {
                        var contacts = csv.GetRecords<Contacts>();
                        foreach (var contact in contacts)
                        {
                            book.GetContacts().Add(contact);
                        }
                    }

                    Console.WriteLine("Address book loaded from CSV file successfully.");
                }
                else
                {
                    throw new FileNotFoundException("CSV file is not found in the specified path.", csvPath);
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

            return book;
        }

        public static void ViewAddressBookFromCsv()
        {
            try
            {
                if (IsCsvFileExist())
                {
                  string s= File.ReadAllText(csvPath);
                    Console.WriteLine(s);
                }
                else
                {
                    throw new FileNotFoundException("CSV file is not found in the specified path.", csvPath);
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