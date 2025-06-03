using AddressBookApp.Application.Interfaces;
using AddressBookApp.Domain.Entities;
using System.Text.Json;

namespace AddressBookApp.Infrastructure.Services;

public class JsonContactService : IContactService
{
    private readonly string _filePath = Path.Combine("Infrastructure", "Data", "fakedatabase.json");
    private List<Contact> LoadContacts()
    {
        if (!File.Exists(_filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            SaveContacts(new List<Contact>
        {
            new() { Id = 1, Name = "Ash Ketchum", Phone = "555-0001", AddressLines = ["Pallet Town", "Kanto"] },
            new() { Id = 2, Name = "Misty", Phone = "555-0002", AddressLines = ["Cerulean City", "Kanto"] },
            new() { Id = 3, Name = "Brock", Phone = "555-0003", AddressLines = ["Pewter City", "Kanto"] },
            new() { Id = 4, Name = "Pikachu", Phone = "555-0004", AddressLines = ["Ash's Backpack", "Everywhere"] },
            new() { Id = 5, Name = "Team Rocket", Phone = "555-0005", AddressLines = ["Hot Air Balloon", "Sky"] },
            new() { Id = 6, Name = "Professor Oak", Phone = "555-0006", AddressLines = ["Laboratory", "Pallet Town"] },
            new() { Id = 7, Name = "Gary Oak", Phone = "555-0007", AddressLines = ["Somewhere Better", "Rival Road"] },
            new() { Id = 8, Name = "May", Phone = "555-0008", AddressLines = ["Petalburg City", "Hoenn"] },
            new() { Id = 9, Name = "Dawn", Phone = "555-0009", AddressLines = ["Twinleaf Town", "Sinnoh"] },
            new() { Id = 10, Name = "Cynthia", Phone = "555-0010", AddressLines = ["Celestic Town", "Sinnoh"] }
        });
        }

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Contact>>(json) ?? new();
    }

    private void SaveContacts(List<Contact> contacts) =>
        File.WriteAllText(_filePath, JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true }));

    public IEnumerable<Contact> GetAll(string? phrase)
    {
        var contacts = LoadContacts();
        if (phrase != null)
        {
            if (phrase == "")
            {
                throw new ArgumentException("phrase cannot be empty");
            }
            contacts = contacts
                .Where(c => c.Name.Contains(phrase, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        return contacts.OrderBy(c => c.Name);
    }

    public Contact? GetById(int id)
    {
        return LoadContacts().FirstOrDefault(c => c.Id == id);
    }

    public bool Delete(int id)
    {
        var contacts = LoadContacts();
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            return false;
        }
        contacts.Remove(contact);
        SaveContacts(contacts);
        return true;
    }
}