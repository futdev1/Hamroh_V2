using Hamroh_V2.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamroh_V2.Domain.Entities.DriverAds
{
    public class DriverAd
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Qayerdan { get; set; }
        [Required]
        public string Qayerga { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Summa { get; set; }

        public string Amenities { get; set; }

        public string Comment { get; set; }

        [ForeignKey("Driver")]
        public long DriverId { get; set; }

        public ItemState State { get; set; }


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
