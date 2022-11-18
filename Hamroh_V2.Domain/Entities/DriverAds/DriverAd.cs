using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Hamroh_V2.Domain.Entities.DriverAds
{
    public class DriverAd
    {
        public long Id { get; set; }
        public string Qayerdan { get; set; }

        public string Qayerga { get; set; }

        public DateTime Date { get; set; }

        public string Summa { get; set; }

        public string Amenities { get; set; }

        public ItemState State { get; set; }

        public IList<Driver> DriverData { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }


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
