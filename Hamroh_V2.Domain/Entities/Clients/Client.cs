using Hamroh_V2.Domain.Enums;
using System;

namespace Hamroh_V2.Domain.Entities.Clients
{
    public class Client
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime DeletedAt { get; private set; }
        public ItemState State { get; private set; }
        public DateTime UpdatedAt { get;  set; }

        public void Update()
        {
            UpdatedAt = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Create()
        {
            CreatedAt = DateTime.Now;
            State = ItemState.Created;
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;
            State = ItemState.Deleted;
        }
    }
}
