using Hamroh_V2.Domain.Entities.Drivers;
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

        public IList<Driver> DriverData { get; set; }
    }
}
