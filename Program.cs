using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class Pill
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("shape")]
    public string Shape { get; set; } = string.Empty;

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("imprint")]
    public string Imprint { get; set; } = string.Empty;
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load JSON data from file
            string jsonData = File.ReadAllText("pills.json");
            List<Pill> pills = JsonSerializer.Deserialize<List<Pill>>(jsonData) ?? new List<Pill>();

            // Prompt user for pill attributes
            Console.WriteLine("\nEnter pill shape (e.g., round, caplet):");
            string shape = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            Console.WriteLine("Enter pill color (e.g., yellow, orange):");
            string color = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            Console.WriteLine("Enter pill imprint (e.g., A81, I200):");
            string imprint = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            // Search for matching pills
            var matches = pills.FindAll(p =>
                p.Shape.ToLower() == shape &&
                p.Color.ToLower() == color &&
                p.Imprint.ToLower() == imprint
            );

            // Output results
            if (matches.Count > 0)
            {
                Console.WriteLine("\nMatching Pills:");
                foreach (var pill in matches)
                {
                    Console.WriteLine($"- {pill.Name}");
                }
            }
            else
            {
                Console.WriteLine("\nNo matching pills found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}