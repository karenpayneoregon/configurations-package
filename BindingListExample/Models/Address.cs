using System.Collections.Generic;

namespace BindingListExample.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<Person> Residents { get; set; }
        public override string ToString() => Street;

        public Address(int id)
        {
            Id = id;
        }

        public Address()
        {
            
        }

    }
}