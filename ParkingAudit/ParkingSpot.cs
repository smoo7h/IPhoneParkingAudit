using System;
using SQLite.Net.Attributes;


namespace ParkingAudit
{
    [Table("ParkingSpot")]
    public class ParkingSpot
    {
        [Column("Id"), PrimaryKey]
        public string Id { get; set; }


    }
}


