using System;
using System.Collections.Generic;

namespace AddressBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookController controller = new AddressBookController();
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\n=== Address Book Management System ===");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Manage Contacts by City");
                Console.WriteLine("3. Manage Contacts by State");
                Console.WriteLine("4. View Contact Statistics");
                Console.WriteLine("5. File Operations");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateNewAddressBook(controller);
                        break;
                    case "2":
                        ManageContactsByCity(controller);
                        break;
                    case "3":
                        ManageContactsByState(controller);
                        break;
                    case "4":
                        ViewContactStatistics(controller);
                        break;
                    case "5":
                        HandleFileOperations(controller);
                        break;
                    case "6":
                        continueProgram = false;
                        Console.WriteLine("Thank you for using Address Book Management System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
        

        private static void CreateNewAddressBook(AddressBookController controller)
        {
            Console.Write("\nEnter name for the new Address Book: ");
            string bookName = Console.ReadLine();

            Address_Book newBook = CreateAddress_Book(); 
            controller.AddNameToAddressBook(bookName, newBook);
        }

        private static void ManageContactsByCity(AddressBookController controller)
        {
            Console.WriteLine("\n=== City Management ===");
            Console.WriteLine("1. Add Contacts to City Dictionary");
            Console.WriteLine("2. View Contacts by City");
            Console.WriteLine("3. Count Contacts by City");
            Console.Write("\nEnter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter city name: ");
                    string cityToAdd = Console.ReadLine();
                    controller.AddContactsToDictionaryByCity(cityToAdd);
                    break;
                case "2":
                    Console.Write("Enter city name to view contacts: ");
                    string cityToView = Console.ReadLine();
                    controller.ViewContactByCity(cityToView);
                    break;
                case "3":
                    Console.Write("Enter city name to count contacts: ");
                    string cityToCount = Console.ReadLine();
                    AddressBookController.CountContactsByCity(cityToCount);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void ManageContactsByState(AddressBookController controller)
        {
            Console.WriteLine("\n=== State Management ===");
            Console.WriteLine("1. Add Contacts to State Dictionary");
            Console.WriteLine("2. View Contacts by State");
            Console.WriteLine("3. Count Contacts by State");
            Console.Write("\nEnter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter state name: ");
                    string stateToAdd = Console.ReadLine();
                    controller.AddContactsToDictionaryByState(stateToAdd);
                    break;
                case "2":
                    Console.Write("Enter state name to view contacts: ");
                    string stateToView = Console.ReadLine();
                    controller.ViewContactByState(stateToView);
                    break;
                case "3":
                    Console.Write("Enter state name to count contacts: ");
                    string stateToCount = Console.ReadLine();
                    AddressBookController.CountContactsByState(stateToCount);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void ViewContactStatistics(AddressBookController controller)
        {
            Console.WriteLine("\n=== Contact Statistics ===");
            Console.WriteLine("1. View/Count by City");
            Console.WriteLine("2. View/Count by State");
            Console.Write("\nEnter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter city name: ");
                    string city = Console.ReadLine();
                    controller.ViewContactByCity(city);
                    AddressBookController.CountContactsByCity(city);
                    break;
                case "2":
                    Console.Write("Enter state name: ");
                    string state = Console.ReadLine();
                    controller.ViewContactByState(state);
                    AddressBookController.CountContactsByState(state);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
        public static Address_Book CreateAddress_Book()
        {
            Address_Book book = new Address_Book();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\nEnter your choice:");
                Console.WriteLine("1. Add a new contact to address Book");
                Console.WriteLine("2. Edit a contact in address book");
                Console.WriteLine("3. Remove a contact in address book");
                Console.WriteLine("4. Add multiple contacts into address book");
                Console.WriteLine("5. Display the List of contacts stored ");
                Console.WriteLine("6. Sort the contacts by Name in Alphabetical Order");
                Console.WriteLine("7. Sort the contacts by postalCode or state or city ");
                Console.WriteLine("8. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter contact details to add:");
                        Contacts newContact = ContactData.EnterContactDetails();
                        book.AddContacts(newContact);
                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the contact to edit:");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();

                        Contacts editContact = new Contacts { FirstName = firstName, LastName = lastName };
                        try
                        {
                            book.EditContacts(editContact);
                        }
                        catch (PersonNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the name of the contact to remove:");
                        Console.Write("First Name: ");
                        string removeFirstName = Console.ReadLine();

                        Contacts removeContact = new Contacts { FirstName = removeFirstName };
                        try
                        {
                            book.RemoveContacts(removeContact);
                        }
                        catch (PersonNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the number of contacts to add:");
                        int count = Convert.ToInt32(Console.ReadLine());
                        HashSet<Contacts> multipleContacts = new HashSet<Contacts>();

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Enter details for contact {i + 1}:");
                            Contacts contact = ContactData.EnterContactDetails();
                            multipleContacts.Add(contact);
                        }
                        book.AddMultipleContacts(multipleContacts);
                        break;

                    case 5:
                            book.DisplayAddressBook();
                            break;

                    case 6:
                        book.SortContactsByName();
                        break;

                    case 7:
                        Console.WriteLine("choose the following \n 1) To sort by postalCode \n 2) To sort by city \n 3) To sort by state");
                        int option=Convert.ToInt32(Console.ReadLine());
                        switch(option)
                        {
                            case 1:
                                book.SortContacts("postalcode");
                                break;

                            case 2:
                                book.SortContacts("city");
                                break;
                            case 3:
                                book.SortContacts("state");
                                break;
                        }
                        break;


                    case 8:
                        flag = false;
                        Console.WriteLine("Exiting Address Book...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }

            return book;
        }

        private static void HandleJsonOperations(AddressBookController controller)
        {
            Console.WriteLine("\n=== JSON File Operations ===");
            Console.WriteLine("1. Create JSON File");
            Console.WriteLine("2. Write Address Book to JSON");
            Console.WriteLine("3. Read Address Book from JSON");
            Console.WriteLine("4. View JSON File Content");
            Console.Write("\nEnter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddressBookFileIo_Json.CreateTextFile();
                    break;
                case "2":
                    Console.Write("Enter the name of address book to save: ");
                    string bookName = Console.ReadLine();
                    var book = controller.GetAddressBookByName(bookName);
                    if (book != null)
                    {
                        AddressBookFileIo_Json.WriteAddressBookToFile(book);
                    }
                    else
                    {
                        Console.WriteLine("Address book not found!");
                    }
                    break;
                case "3":
                    var loadedBook = AddressBookFileIo_Json.ReadAddressBookFromFile();
                    if (loadedBook != null)
                    {
                        Console.Write("Enter name for loaded address book: ");
                        string name = Console.ReadLine();
                        controller.AddNameToAddressBook(name, loadedBook);
                    }
                    break;
                case "4":
                    AddressBookFileIo_Json.ViewAddressBookFromFile();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void HandleCsvOperations(AddressBookController controller)
        {
            Console.WriteLine("\n=== CSV File Operations ===");
            Console.WriteLine("1. Create CSV File");
            Console.WriteLine("2. Write Address Book to CSV");
            Console.WriteLine("3. Read Address Book from CSV");
            Console.WriteLine("4. View CSV File Content");
            Console.Write("\nEnter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddressBookFileIo_csv.CreateCsvFile();
                    break;
                case "2":
                    Console.Write("Enter the name of address book to save: ");
                    string bookName = Console.ReadLine();
                    // Assuming we add a method to get address book by name
                    var book = controller.GetAddressBookByName(bookName);
                    if (book != null)
                    {
                        AddressBookFileIo_csv.WriteAddressBookToCsv(book);
                    }
                    else
                    {
                        Console.WriteLine("Address book not found!");
                    }
                    break;
                case "3":
                    var loadedBook = AddressBookFileIo_csv.ReadAddressBookFromCsv();
                    Console.Write("Enter name for loaded address book: ");
                    string name = Console.ReadLine();
                    controller.AddNameToAddressBook(name, loadedBook);
                    break;
                case "4":
                    AddressBookFileIo_csv.ViewAddressBookFromCsv();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void HandleFileOperations(AddressBookController controller)
        {
            Console.WriteLine("\n=== File Operations ===");
            Console.WriteLine("1. JSON Operations");
            Console.WriteLine("2. CSV Operations");
            Console.Write("\nEnter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    HandleJsonOperations(controller);
                    break;
                case "2":
                    HandleCsvOperations(controller);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

