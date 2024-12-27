using System;
using System.Collections.Generic;

namespace AddressBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Address_Book addressBook = new Address_Book();

              Contacts smith=  new Contacts 
                {
                    FirstName = "dyne",
                    LastName = "smith",
                    Phone_Number = "1234567890",
                    Email = "smithdoe@gmail.com",
                    Address = "123 Main St",
                    City = "chennai",
                    PostalCode = "638005",
                    State = "TamilNadu"

                };

              Contacts virat =  new Contacts  // add method
                {
                    FirstName = "virat",
                    LastName = "sharma",
                    Phone_Number = "0987654321",
                    Email = "virat123@gmail.com",
                    Address = "456 Elm St",
                    City = "chennai",
                    PostalCode = "638005",
                    State = "TamilNadu"
                };

                addressBook.AddContacts(virat);
                addressBook.AddContacts(smith);

                addressBook.RemoveContacts(virat); // remove

                addressBook.EditContacts(smith); // edit

                //List<Contacts> list = new List<Contacts>();
                //list.Add(virat);
                //list.Add(smith);

                //addressBook.AddMultipleContacts(list);  // MultipleContacts
            }
        }

    }
}

