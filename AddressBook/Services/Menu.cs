using AddressBook.Interfaces;
using AddressBook.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AddressBook.Services;

internal class Menu
{

    private List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService();


    public string FilePath { get; set; } = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}.\content.json";

    void PopulateContactList()
    {
        try
        {
            var content = file.ReadFromFile();
            if (!string.IsNullOrEmpty(content))
                contacts = JsonConvert.DeserializeObject<List<Contact>>(content);
        }
        catch { }
    }

    public void OptionsMenu()
    {
        PopulateContactList();

        Console.Clear();
        Console.WriteLine("Welcome to the Address Book");
        Console.WriteLine("1. Create a new contact");
        Console.WriteLine("2. Show all contacts");
        Console.WriteLine("3. Show a specific contact");
        Console.WriteLine("4. Remove a specefic contact");
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
        Console.WriteLine("1. Create a new contact:\n");

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
            Console.WriteLine($"{contact.FirstName} , {contact.LastName}, {contact.Email}");
            Console.WriteLine();
        }
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }



    private void OptionThree()
    {
        Console.Clear();
        Console.WriteLine("3. Show one contact:\n");

        var contact = contacts.FirstOrDefault(contact => contact.FirstName == contact.FirstName);
        if (contact == null)
        {
            Console.WriteLine("Contact not found");
        }
        else
        {
            Console.WriteLine ($"Firstname: {contact.FirstName}");
            Console.WriteLine($"Lastname: {contact.LastName}");
            Console.WriteLine($"Phone number: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.StreetName} , {contact.City}, {contact.PostalCode}");
        }

        Console.WriteLine("\nPress any key to continue.");
        Console.ReadLine();
    }




    private void OptionFour()
    {
        Console.Clear();
        Console.WriteLine("4. Remove a specific contact:\n");

        Console.WriteLine("Enter the first name of the person you would like to remove.");
        string firstName = Console.ReadLine();
        var Contact = contacts.FirstOrDefault(contact => contact.FirstName.ToLower() == firstName.ToLower());

        if (Contact == null)
        {
            Console.WriteLine("That person could not be found. Press any key to continue");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
        if (Console.ReadLine().ToLower() == "y")
        {
            contacts.Remove(Contact);
            Console.WriteLine("Person removed. Press any key to continue.");
            Console.ReadKey();

            file.SaveToFile(JsonConvert.SerializeObject(contacts));
        }
    }
}
