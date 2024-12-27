using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException(string message) : base(message)
        {
        
        }

    }
}
