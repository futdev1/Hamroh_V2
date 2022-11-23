using Hamroh_V2.Domain.Enums;
using System;

namespace Hamroh_V2.Domain.Entities.Drivers
{
    public class Driver
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string CarImage { get; set; }

        public string DriverImage { get; set; }

        public string CarName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ItemState State { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.Now;
            State = ItemState.Created;
        }

        public void Update()
        {
            UpdatedAt = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;
            State = ItemState.Deleted;
        }
    }
}
