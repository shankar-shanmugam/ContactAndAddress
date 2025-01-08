using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    public class AddressBookController
    {
        private static  Dictionary<string, Address_Book> multiAddressBookController;
        private static  Dictionary<string, List<Contacts>> contactsByCity;
        private static  Dictionary<string, List<Contacts>> contactsByState;

        public AddressBookController()
        {
            multiAddressBookController = new Dictionary<string, Address_Book>();
            contactsByCity = new Dictionary<string, List<Contacts>>();
            contactsByState = new Dictionary<string, List<Contacts>>();
        }

        public void AddNameToAddressBook(string name, Address_Book book)
        {
            if (!multiAddressBookController.ContainsKey(name))
            {
                multiAddressBookController.Add(name, book);
                Console.WriteLine($"{name} added as key to ---> Address book you passed");
            }
            else
            {
                Console.WriteLine($"Address book with name {name} already exists.");
            }
        }

        public List<Contacts> SearchContactByCity(string cityName)
        {
            var contacts = new List<Contacts>();
            foreach (var keyValuePair in multiAddressBookController)
            {
                Address_Book book = keyValuePair.Value;
                contacts.AddRange(book.SearchByCity(cityName));
            }

            if (contacts.Count == 0)
            {
                Console.WriteLine($"No contacts found in city: {cityName}");
            }
            else
            {
                Console.WriteLine($"Contacts in city {cityName}:");
                contacts.ForEach(c => Console.WriteLine(c));
            }

            return contacts;
        }

        public List<Contacts> SearchContactByState(string state)
        {
            var contacts = new List<Contacts>();
            foreach (var keyValuePair in multiAddressBookController)
            {
                Address_Book book = keyValuePair.Value;
                contacts.AddRange(book.SearchByState(state));
            }

            if (contacts.Count == 0)
            {
                Console.WriteLine($"No contacts found in state: {state}");
            }
            else
            {
                Console.WriteLine($"Contacts in state {state}:");
                contacts.ForEach(c => Console.WriteLine(c));
            }

            return contacts;
        }

        public void AddContactsToDictionaryByCity(string cityName)
        {
            var contacts = SearchContactByCity(cityName);
            if (contactsByCity.ContainsKey(cityName))
            {
                Console.WriteLine($"City {cityName} already exists in the dictionary.");
                return;
            }

            contactsByCity[cityName] = contacts;
            Console.WriteLine($"Contacts from city {cityName} added to dictionary.");
        }

        public Address_Book GetAddressBookByName(string name)
        {
            if (multiAddressBookController.ContainsKey(name))
            {
                return multiAddressBookController[name];
            }
            return null;
        }

        public void AddContactsToDictionaryByState(string state)
        {
            var contacts = SearchContactByState(state);
            if (contactsByState.ContainsKey(state))
            {
                Console.WriteLine($"State {state} already exists in the dictionary.");
                return;
            }

            contactsByState[state] = contacts;
            Console.WriteLine($"Contacts from state {state} added to dictionary.");
        }

        public void ViewContactByCity(string city)
        {
            if (contactsByCity.TryGetValue(city, out var persons))
            {
                Console.WriteLine($"Contacts in city {city}:");
                persons.ForEach(c => Console.WriteLine(c));
            }
            else
            {
                Console.WriteLine($"No contacts found for city: {city}");
            }
        }

        public void ViewContactByState(string state)
        {
            if (contactsByState.TryGetValue(state, out var persons))
            {
                Console.WriteLine($"Contacts in state {state}:");
                persons.ForEach(c => Console.WriteLine(c));
            }
            else
            {
                Console.WriteLine($"No contacts found for state: {state}");
            }
        }


        public static void CountContactsByState(string state)
        {
            // Check if the dictionary is null or empty
            if (contactsByState == null || contactsByState.Count == 0)
            {
                Console.WriteLine("Dictionary is empty or not initialized.");
                return;
            }

            // Check if the state exists in the dictionary
            if (contactsByState.ContainsKey(state))
            {
                int count = contactsByState[state].Count;
                Console.WriteLine($"Total number of contacts present in {state} is {count}.");
            }
            else
            {
                Console.WriteLine($"No contacts found for the state: {state}");
            }
        }

        public static void CountContactsByCity(string city)
        {
            if (contactsByCity == null || contactsByCity.Count == 0)
            {
                Console.WriteLine("Dictionary is empty or not initialized.");
                return;
            }

            if (contactsByCity.ContainsKey(city))
            {
                int count = contactsByCity[city].Count;
                Console.WriteLine($"Total number of contacts present in {city} is {count}.");
            }
            else
            {
                Console.WriteLine($"No contacts found for the city: {city}");
            }
        }




    }
}
