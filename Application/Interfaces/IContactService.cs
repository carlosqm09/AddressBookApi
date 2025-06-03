using AddressBookApp.Domain.Entities;

namespace AddressBookApp.Application.Interfaces;

public interface IContactService
{
    IEnumerable<Contact> GetAll(string? phrase);
    Contact? GetById(int id);
    bool Delete(int id);
}