using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookApp
{
    public class Address_Book
    {
        private HashSet<Contacts> Contacts;
        internal static int TodatCount = 0;
        public Address_Book()
        {
            Contacts = new HashSet<Contacts>();
            TodatCount++;
            Console.WriteLine($" Total Address_book created as of now {TodatCount}");
        }
        public Address_Book(HashSet<Contacts> Contacts)
        {
            this.Contacts = Contacts;
            TodatCount++;
            Console.WriteLine($" Total Address_book created as of now {TodatCount}");
        }

        public HashSet<Contacts> GetContacts()
        {
            return Contacts;
        }
        public void AddContacts(Contacts contact)
        {

            if (contact != null)
            {
                Contacts.Add(contact);
                Console.WriteLine($"{contact.FirstName} {contact.LastName} added successfully.");
            }
            else
            {
                Console.WriteLine("person already present in the list..don't try to duplicate");
            }
        }

        public List<Contacts> SearchByCity(string city)
        {
            return Contacts.Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Contacts> SearchByState(string state)
        {
            return Contacts.Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void EditContacts(Contacts Personcontacts)
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("No contacts are added ----> Empty.");
                return;
            }

            foreach (Contacts contact in Contacts)
            {
                if (contact.FirstName.Equals(Personcontacts.FirstName) && contact.LastName.Equals(Personcontacts.LastName))
                {
                    Console.WriteLine($"Editing contact: {contact.FirstName} {contact.LastName}");

                    Console.WriteLine("Choose what to edit:");
                    Console.WriteLine("1. Phone Number");
                    Console.WriteLine("2. Email");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. State");
                    Console.WriteLine("5. city");
                    Console.WriteLine("6. Exit");

                    bool editing = true;
                    while (editing)
                    {
                        Console.Write("Enter your choice: ");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter your updated phone number: ");
                                contact.Phone_Number = Console.ReadLine();
                                Console.WriteLine("Phone number updated successfully.");
                                break;

                            case 2:
                                Console.Write("Enter your updated email: ");
                                contact.Email = Console.ReadLine();
                                Console.WriteLine("Email updated successfully.");
                                break;

                            case 3:
                                Console.Write("Enter your updated address: ");
                                contact.Address = Console.ReadLine();
                                Console.WriteLine("Address updated successfully.");
                                break;

                            case 4:
                                Console.Write("Enter your updated state: ");
                                contact.State = Console.ReadLine();
                                Console.WriteLine("state updated successfully.");
                                break;

                            case 5:
                                Console.Write("Enter your updated city: ");
                                contact.City = Console.ReadLine();
                                Console.WriteLine("City updated successfully.");
                                break;

                            case 6:
                                editing = false;
                                Console.WriteLine("Exiting edit mode.");
                                break;

                            default:
                                Console.WriteLine("Invalid choice! Please try again.");
                                break;
                        }
                    }
                    return;
                }
            }

            throw new PersonNotFoundException("No match found with the given name.");
        }
        public void RemoveContacts(Contacts PersonContacts)
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine(" Nothing in the list ");
                return;
            }
          Contacts contactToRemove =  Contacts.First(c => c.FirstName.ToLower() == PersonContacts.FirstName);

            if (contactToRemove == null)
            {
                throw new PersonNotFoundException(" person not in list ");
            }
            if (Contacts.Remove(contactToRemove))
                  Console.WriteLine($"{contactToRemove.FirstName} is removed successfully ");
              else
                Console.WriteLine($"{contactToRemove.FirstName} is not removed successfully ");
        }
        public void AddMultipleContacts(HashSet<Contacts> contactList)
        {
            Contacts.UnionWith(contactList);
            Console.WriteLine($"{contactList.Count} contacts added successfully.");
        }
        public void DisplayAddressBook()
        {
            Console.WriteLine("Displaying the List of contacts");
            foreach (var contact in Contacts)
            {
                Console.WriteLine(contact);
            }
        }
        public void SortContactsByName()
        {
            if (Contacts == null || Contacts.Count == 0)
            {
                Console.WriteLine("The address book is empty. No contacts to sort.");
                return;
            }

            List<Contacts> sortedContacts = Contacts.ToList();

            sortedContacts.Sort((contact1, contact2) =>
            {
                int firstNameComparison = contact1.FirstName.CompareTo(contact2.FirstName);
                return firstNameComparison != 0 ? firstNameComparison : contact1.LastName.CompareTo(contact2.LastName);
            });

            Console.WriteLine("Contacts sorted alphabetically by name:");
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }
        public void SortContacts(string criterion)
        {
            if (Contacts == null || Contacts.Count == 0)
            {
                Console.WriteLine("The address book is empty. No contacts to sort.");
                return;
            }

            // Convert HashSet to List for sorting
            List<Contacts> sortedContacts = Contacts.ToList();

            // Determine sorting logic based on the criterion
            switch (criterion.ToLower())
            {
                case "city":
                    sortedContacts.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
                    break;

                case "state":
                    sortedContacts.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
                    break;
                case "postalcode":
                    sortedContacts.Sort((contact1, contact2) => contact1.PostalCode.CompareTo(contact2.PostalCode));
                    break;

                default:
                    Console.WriteLine("Invalid sorting criterion. Please use 'City', 'State', or 'ZipCode'.");
                    return;
            }

            Console.WriteLine($"Contacts sorted by {criterion}:");
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }


    }
}
