using AddressBook.Interfaces;
using AddressBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace AddressBook.Services;

internal class Menu
{

    public List<Contact> contacts = new List<Contact>();
    public FileService file = new FileService();

    //public string FilePath { get; set; } = null!;

    public string FilePath { get; set; } = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}.\content.json";


    public void OptionsMenu()
    {
        

        Console.Clear();
        Console.WriteLine("Welcome to the Address Book");
        Console.WriteLine("1. Create a new contact");
        Console.WriteLine("2. Show all contacts");
        Console.WriteLine("3. Show a specific contact");
        Console.WriteLine("4. Delete a specefic contact");
        Console.WriteLine("Select one of the options above: ");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1": OptionOne(); break;
            case "2": OptionTwo(); break;
            case "3": OptionThree(); break;
            case "4": OptionFour(); break;
        }
    }

    private void OptionOne()
    {
        Console.Clear();
        Console.WriteLine("1. Create a new contact");

        var contact = new Contact();

        Console.Write("Enter Firstname: ");
            contact.FirstName = Console.ReadLine() ?? null!;
        Console.Write("Enter Lastname: ");
            contact.LastName = Console.ReadLine() ?? null!;
        Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine() ?? null!;
        Console.Write("Enter Phone number: ");
            contact.Phone = Console.ReadLine() ?? null!;
        Console.Write("Enter Streetname: ");
            contact.StreetName = Console.ReadLine() ?? null!;
        Console.Write("Enter Postalcode: ");
            contact.PostalCode = Console.ReadLine() ?? null!;
        Console.Write("Enter City: ");
            contact.City = Console.ReadLine() ?? null!;


        contacts.Add(contact);

        file.SaveToFile(JsonConvert.SerializeObject(contacts));
    }




    private void OptionTwo()
    {
        if (contacts.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Your address book is empty. Press any key to continue.");
            Console.ReadKey();
            return;
        }
        Console.Clear();
        Console.WriteLine("Here are the current people in your address book:\n");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact.DisplayName);
        }
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }



    private void OptionThree(/*string FirstName*/)
    {
        Console.Clear();
        Console.WriteLine("3. Show one contact");

        //var contact = contacts.FirstOrDefault(c => c.FirstName == FirstName);
        //if (contact == null)
        //{
        //    Console.WriteLine("Contact not found");
        //}
        //else
        //{
        //    Console.WriteLine($"Contact: {contact.FirstName}, {contact.LastName}, {contact.Email}, {contact.Phone}, {contact.StreetName} , {contact.City}, {contact.PostalCode}");
        //}


        //var contactService = new ContactService();
        //var contact = ContactService.Get(x => x.Id == Guid.Parse("ccb186fc-e462-4002-b3c0-e4b56774bc54"));
        //Console.WriteLine(contact.FirstName);

        Console.ReadLine();
    }

 

    private void OptionFour(/*Contact contact*/)
    {
        Console.Clear();
        Console.WriteLine("4. Remove a specific contact");


        //Console.WriteLine("Enter the first name of the person you would like to remove.");
        //string firstName = Console.ReadLine();
        //Contact contact = Contact.FirstOrDefault(x => x.FirstName.ToLower() == FirstName.ToLower());

        //if (contact == null)
        //{
        //    Console.WriteLine("That person could not be found. Press any key to continue");
        //    Console.ReadKey();
        //    return;
        //}
        //Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
        //Contact(contact);

        //if (Console.ReadKey().Key == ConsoleKey.Y)
        //{
        //    Contacts.Remove(Contact);
        //    Console.WriteLine("Person removed. Press any key to continue.");
        //    Console.ReadKey();
        //}
    }
}
