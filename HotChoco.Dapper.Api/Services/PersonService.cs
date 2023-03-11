using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using HotChoco.Dapper.Api.Models;

namespace HotChoco.Dapper.Api.Services
{
    public class PersonService: IPersonService
    {
        private readonly IConfiguration _configuration;

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("MyWorldDbConnection"));
            }
        }
        public PersonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PersonModel GetFirst()
        {

            using (var conn = Connection)
            {
                var query = "Select top 1 * from Persons";
                var person = conn.Query<PersonModel>(query).FirstOrDefault();
                return person;
            }
        }

        public List<PersonModel> GetAll()
        {
            using (var conn = Connection)
            {
                var query = "Select * from Persons";
                var persons = conn.Query<PersonModel>(query).ToList();
                return persons;
            }
        }

        public List<PersonModel> FilterByFirstName(string firstName)
        {
            using(var conn = Connection)
            {
                var query = "Select * from Persons where FirstName = @firstName";
                var persons = conn.Query<PersonModel>(query, new { firstName }).ToList();
                return persons;
            }
        }

        public List<PersonModel> GetPersonAddress()
        {
            using (var conn = Connection)
            {
                var query = @"
                            Select * From Persons

                            Select * From PersonAddress
                            ";

                var result = conn.QueryMultiple(query);
                var persons = result.Read<PersonModel>().ToList();
                var address = result.Read<PersonAddressModel>().ToList();
                foreach (var person in persons)
                {
                    person.Address = address.Where(_ => _.PersonId == person.ID).ToList();
                }
                return persons;
            }
        }

        public int SavePerson(PersonModel person)
        {
            using(var conn = Connection)
            {
                var command = @"INSERT INTO Persons(LastName, FirstName, Age)
                                VALUES (@LastName, @FirstName, @Age)";

                var saved = conn.Execute(command, param: person);
                return saved;
            }
        }
    }

    
}
