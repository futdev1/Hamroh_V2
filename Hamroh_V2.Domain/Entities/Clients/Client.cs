using System;

namespace Hamroh_V2.Domain.Entities.Clients
{
    public class Client
    {
        public long Id { get; set; }

        public string Qayerdan { get; set; }

        public string Qayerga { get; set; }

        public DateTime Date { get; set; }

        public int PeopleCount { get; set; }

        public string PhoneNumber { get; set; }

        public string Summa { get; set; }

        public string FirstName { get; set; }

        public string Comment { get; set; }
    }
}
