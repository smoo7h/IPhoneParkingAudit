using System;
using SQLite.Net.Attributes;


namespace ParkingAudit
{
    [Table("SpotAudit")]
    public class SpotAudit
    {
        public SpotAudit(DateTime dateAdded)
        {
            DateAudited = dateAdded;

        }
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }

        [Column("ParkingSpot")]
        public string ParkingSpot { get; set; }

        [Column("Date")]
        public DateTime DateAudited { get; set; }

    }
}
