using AddressBook.Models;
using AddressBook.Services;
using Newtonsoft.Json;

var menu = new Menu();
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
var contacts = new List<Contact>();
var FileService = new FileService();

PopulateContactList();

while (true)
{
    Console.Clear();
    menu.OptionsMenu();
}


void PopulateContactList()
{
    try
    {
        var content = FileService.ReadFromFile();
        if (!string.IsNullOrEmpty(content))
            contacts = JsonConvert.DeserializeObject<List<Contact>>(content);
    }
    catch { }
}