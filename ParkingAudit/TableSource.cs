using System;
using System.IO;
using Foundation;
using SQLite.Net;
using SQLite.Net.Interop;
using UIKit;

namespace ParkingAudit
{
    public class TableSource : UITableViewSource
    {
        
        string[] TableItems;
        string CellIdentifier = "TableCell";

        public TableSource(string[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIAlertController okAlertController = UIAlertController.Create("Row Selected", TableItems[indexPath.Row], UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            SQLHelper helper = new SQLHelper();
      
            string selecteditem = TableItems[indexPath.Row].ToString();
            //add the new audit to the db
            helper.AddParkingSpotAudit(selecteditem.Substring(0, selecteditem.IndexOf(' ')));

            //deselect
            tableView.DeselectRow(indexPath, true);


            Click();

        }

        public event EventHandler ButtonClicked;

        public void Click()
        {
            if (ButtonClicked != null)
                ButtonClicked.Invoke(this, new EventArgs());
        }
    }
}
