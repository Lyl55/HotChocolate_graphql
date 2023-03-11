using HotChoco.Dapper.Api.Models;
using System.Collections.Generic;

namespace HotChoco.Dapper.Api.Services
{
    public interface IPersonService
    {
        PersonModel GetFirst();
        List<PersonModel> GetAll();
        List<PersonModel> FilterByFirstName(string firstName);
        List<PersonModel> GetPersonAddress();
        int SavePerson(PersonModel person);
    }
}
