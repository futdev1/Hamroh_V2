using Hamroh_V2.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hamroh_V2.Domain.Entities.ClientAds
{
    public class ClientAd
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Qayerdan { get; set; }

        [Required]
        public string Qayerga { get; set; }

        [Required]
        public int PeopleCount { get; set; }

        [Required]
        public string Summa { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Comment { get; set; }

        [Required]
        public long ClientId { get; set; }

        public ItemState State { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime DeletedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }

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
