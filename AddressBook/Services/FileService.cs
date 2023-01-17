namespace AddressBook.Services;

internal class FileService
{
    public string FilePath { get; set; } = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}.\content.json";

    public string ReadFromFile()
    {
        try
        {
            using var sr = new StreamReader(FilePath);
            return sr.ReadToEnd();
        }
        catch { return string.Empty; }

    }

    public void SaveToFile(string content)
    {
        try
        {
            using var sw = new StreamWriter(FilePath);
            sw.WriteLine(content);
        }
        catch { }
    }

}


