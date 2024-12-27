using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookApp
{
    public class Address_Book
    {
        private static List<Contacts> Contacts;

        public Address_Book()
        {
            Contacts = new List<Contacts>();
        }

        public void AddContacts(Contacts contact)
        {
            Contacts.Add(contact);
            Console.WriteLine($"{contact.FirstName} {contact.LastName} added successfully.");
        }

        public void EditContacts(Contacts Personcontacts)
        {
            if (Contacts == null)
            {
                Console.WriteLine(" No contacts are Added---->Empty ");
                return;
            }

            foreach(Contacts contact in Contacts)
            {
                if (contact.FirstName.Equals(Personcontacts.FirstName) && contact.LastName.Equals(Personcontacts.LastName ))
                {
                    Console.WriteLine($" {contact.FirstName} can edit ");

                    Console.WriteLine(" enter your updated phone number : ");

                    contact.Phone_Number = Console.ReadLine();

                    Console.WriteLine($"{contact.FirstName} Enter your updated Email ");

                    contact.Email = Console.ReadLine();

                    Console.WriteLine($"{contact.FirstName} Enter your updated address : ");

                    contact.Address = Console.ReadLine();

                    Console.WriteLine(" updated successfully ");

                    return;
                }
                
            }

            throw new PersonNotFoundException(" No match found with Name ");
            
        }

        public void RemoveContacts(Contacts PersonContacts)
        {
            if (Contacts == null)
            {
                Console.WriteLine(" No contacts are Added---->Empty ");
                return;
            }
             int count=  Contacts.RemoveAll(x => x.FirstName.Equals(PersonContacts.FirstName));
            if(count == 1)
                Console.WriteLine($"{PersonContacts.FirstName} is removed successfully ");
            else
                throw new PersonNotFoundException(" person not in list ");
        }

          

        public void AddMultipleContacts(List<Contacts> contactList)
        {
            Contacts.AddRange(contactList);
            Console.WriteLine($"{contactList.Count} contacts added successfully.");
        }

    }
}
