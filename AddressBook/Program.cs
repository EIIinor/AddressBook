using AddressBook.Models;
using AddressBook.Services;
using Newtonsoft.Json;

var menu = new Menu();
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";


while (true)
{
    Console.Clear();
    menu.OptionsMenu();
}