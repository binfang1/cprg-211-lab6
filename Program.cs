using Lab6;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // Instantiate new Event with number 1 and location Calgary
        Event e = new Event(1, "Calgary");

        // Serialize to JSON and write to event.json
        string jsonString = JsonSerializer.Serialize(e);
        using (StreamWriter sw = new StreamWriter("event.json"))
        {
            sw.Write(jsonString);
        }

        // Read from event.json and deserialize
        string readJsonString = "";
        using (StreamReader sr = new StreamReader("event.json"))
        {
            readJsonString = sr.ReadToEnd();
        }
        Event e2 = JsonSerializer.Deserialize<Event>(jsonString);
        Console.WriteLine(e2);

        ReadFromFile();
    }

    private static void ReadFromFile()
    {
        // Write "Hackathon" to event.json
        using (StreamWriter sw = new StreamWriter("event.json"))
        {
            sw.Write("Hackathon");
        }
        Console.WriteLine("In Word: Hackathon");
        using (FileStream fs = File.OpenRead("event.json"))
        {
            // Seek to beginning with offset 0
            fs.Seek(0, SeekOrigin.Begin);
            Console.WriteLine($"The First Character is: \"{(char)fs.ReadByte()}\"");

            // Calculate middle offset and seek to length / 2 - offset to get middle
            int offset = fs.Length % 2 == 0 ? 1 : 0;
            fs.Seek(fs.Length / 2 - offset, SeekOrigin.Begin);
            Console.WriteLine($"The Middle Character is: \"{(char)fs.ReadByte()}\"");

            // Seek to end and offset -1 for last value
            fs.Seek(-1, SeekOrigin.End);
            Console.WriteLine($"The Last Character is: \"{(char)fs.ReadByte()}\"");
        }
    }


}
