using System;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Interop;

namespace ParkingAudit
{
    public class SQLHelper
    {
        public SQLHelper()
        {
            CreateDB();

        }
        public SQLiteConnection conn;

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }

        public  void CreateDB()
        {

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(),System.IO.Path.Combine(folder, "parking.db"));
            conn.CreateTable<ParkingSpot>();
            conn.CreateTable<SpotAudit>();

        }
        public TableQuery<ParkingSpot> GetParkingSpots()
        {

            TableQuery<ParkingSpot> spots = conn.Table<ParkingSpot>();
            return spots;
        }

        public  void AddParkingSpot( string spot)
        {
            try
            {

           
                var db = conn;
           
                ParkingSpot p = new ParkingSpot();
                p.Id = spot;
                db.Insert(p);
            }
            catch (Exception ex)
            {
                //already in db
            }

        }

        public  void DeleteParkingSpot( string spot)
        {
            var db = conn;
            var existingItem = db.Get<ParkingSpot>(spot);
            if (existingItem != null)
            {
                db.Delete(existingItem);
            }
          

        }

        public int GetParkingSpotAuditCount(string spot)
        {
            var db = conn;
           // var existingItem = db.Get<SpotAudit>(spot);

            var auditData = from s in db.Table<SpotAudit>()
                        where s.ParkingSpot.Equals(spot)
                        select s;
           return auditData.Count();

        }

        public void AddParkingSpotAudit( string spot)
        {
            var db = conn;
       
          
                SpotAudit p = new SpotAudit(DateTime.Now);
                p.ParkingSpot = spot;
                db.Insert(p);

        }

        public void DeleteParkingSpotAudit( string id)
        {
            var db = conn;
            var existingItem = db.Get<SpotAudit>(id);
            if (existingItem != null)
            {
                db.Delete(existingItem);
            }
        }
    }
}