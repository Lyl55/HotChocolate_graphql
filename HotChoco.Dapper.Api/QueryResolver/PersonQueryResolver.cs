using HotChoco.Dapper.Api.Models;
using HotChoco.Dapper.Api.Services;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;


namespace HotChoco.Dapper.Api.QueryResolver
{
    [ExtendObjectType("Query")]
    public class PersonQueryResolver
    {
        public PersonModel GetFirstPerson([Service] IPersonService personService)
        {
            return personService.GetFirst();
        }

        public List<PersonModel> GetAllPerson([Service] IPersonService personService)
        {
            return personService.GetAll();
        }

        public List<PersonModel> FilterByFirstName(string firstName, [Service] IPersonService personService)
        {
            return personService.FilterByFirstName(firstName);
        }

        public List<PersonModel> GetPersonAddress([Service] IPersonService personService)
        {
            return personService.GetPersonAddress();
        }
    }
}
