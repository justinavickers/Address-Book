using System;
using System.Collections.Generic;

namespace AddressBook {

class Contact {
    public string FirstName {get; set; }
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Address {get; set;}
    public string FullName {
    get {
        return $"{FirstName} {LastName}";
    }
    }
}

class AddressBook {
    public Dictionary<string, Contact> Contacts = new Dictionary<string, Contact>();
    public void AddContact(Contact contact) {
        try {
            Contacts.Add(contact.Email, contact);
        }
        catch(ArgumentException exception)
         {
             Console.WriteLine($"A contact already exists for {contact.Email}.");
        }
    }
    public Contact GetByEmail(string email) {
        return Contacts[email];
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create a few contacts
        Contact deanna = new Contact() {
            FirstName = "Deanna", LastName = "Vickers",
            Email = "deanna2000@gmail.com",
            Address = "2824 Funny Lane, Spring Hill, TN 32980"
        };
        Contact dylan = new Contact() {
            FirstName = "Dylan", LastName = "Lance",
            Email = "freedomaintnotfree@yahoo.com",
            Address = "209 Paul Buckley Lane La Vergne, TN 39287"
        };
        Contact bob = new Contact() {
            FirstName = "Bob", LastName = "Smith",
            Email = "bob.smith@email.com",
            Address = "100 Some Ln, Testville, TN 11111"
        };
        Contact sue = new Contact() {
            FirstName = "Sue", LastName = "Jones",
            Email = "sue.jones@email.com",
            Address = "322 Hard Way, Testville, TN 11111"
        };
        Contact juan = new Contact() {
            FirstName = "Juan", LastName = "Lopez",
            Email = "juan.lopez@email.com",
            Address = "888 Easy St, Testville, TN 11111"
        };


        AddressBook addressBook = new AddressBook();
        addressBook.AddContact(bob);
        addressBook.AddContact(deanna);
        addressBook.AddContact(dylan);
        addressBook.AddContact(sue);
        addressBook.AddContact(juan);

        addressBook.AddContact(sue);
        addressBook.AddContact(deanna);



        List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
            "deanna2000@gmail.com",
            "freedomaintnotfree@yahoo.com"
        };

        emails.Insert(1, "not.in.addressbook@email.com");
        emails.Insert(2, "im.also.not.in.thebook@oops.com");


        foreach (string email in emails)
        {
            try {
            Contact contact = addressBook.GetByEmail(email);
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name: {contact.FullName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.Address}");
            }
            catch (KeyNotFoundException exception) {
                Console.WriteLine($@"Sorry! Couldn't find {email} in the Address Book.");
            }
        }
    }
}
}