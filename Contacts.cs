using System;

namespace AddressBookApp
{
    public class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone_Number { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Contacts other = (Contacts)obj;
            return this.FirstName == other.FirstName && this.LastName == other.LastName;
        }

        // Override GetHashCode to ensure consistency with Equals
        public override int GetHashCode()
        {
            // Use HashCode.Combine to generate a hash code based on FirstName and LastName
            return HashCode.Combine(FirstName, LastName);
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Address: {Address}, City: {City}, State: {State}, " +
                   $"Postal Code: {PostalCode}, Phone: {Phone_Number}, Email: {Email}";
        }
    }
}