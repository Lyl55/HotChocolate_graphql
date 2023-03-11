using System.Collections.Generic;
using HotChoco.Dapper.Api.Models;

namespace HotChoco.Dapper.Api.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public List<PersonAddressModel> Address { get; set; }
    }
}
