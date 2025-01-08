using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp
{
    public static class ContactData
    {
        public static  Contacts EnterContactDetails()
        {
            Contacts contact = new Contacts();

            Console.WriteLine("Enter the following contact details:");

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("City: ");
            contact.City = Console.ReadLine();

            Console.Write("State: ");
            contact.State = Console.ReadLine();

            Console.Write("Phone Number: ");
            contact.Phone_Number = Console.ReadLine();

            Console.Write("Postal Code: ");
            contact.PostalCode = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("Address: ");
            contact.Address = Console.ReadLine();

            Console.WriteLine("\nContact details entered successfully.");
            return contact;
        }


    }
}
