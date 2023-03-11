using HotChoco.Dapper.Api.Models;
using HotChoco.Dapper.Api.Services;
using HotChocolate;
using HotChocolate.Types;

namespace HotChoco.Dapper.Api.MutationResolver
{
    //GraphQL mutation is a type of operation that allows clients to modify data on the server.
    [ExtendObjectType("Mutation")]
    public class PersonMutationResolver
    {

        public int SavePerson(PersonModel person,[Service] IPersonService personService)
        {
            return personService.SavePerson(person);
        }
    }
}
