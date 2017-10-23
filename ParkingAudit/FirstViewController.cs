using System;
using System.Collections.Generic;
using CoreGraphics;
using SQLite.Net;
using UIKit;

namespace ParkingAudit
{
    public partial class FirstViewController : UIViewController
    {
        protected FirstViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public List<UIButton> buttons;

        public void RefreshView()
        {
            SQLHelper helper = new SQLHelper();

            var table = new UITableView();


            table = new UITableView(View.Bounds); // defaults to Plain style

            TableQuery<ParkingSpot> spots = helper.GetParkingSpots();


            string[] tableItems = new string[spots.Count()];

            for (int i = 0; i < spots.Count(); i++)
            {
                tableItems[i] = spots.ElementAt(i).Id + "    " + helper.GetParkingSpotAuditCount(spots.ElementAt(i).Id); ;
            }

            TableSource source = new TableSource(tableItems);
                source.ButtonClicked += (sender, e) => {
                 // refresh the view when its clicked
                RefreshView();
             };
            table.Source = source;
           
            Add(table);

           
            this.View.Add(table);



            helper.Dispose();

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            RefreshView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
