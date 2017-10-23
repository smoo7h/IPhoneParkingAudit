using System;

using UIKit;

namespace ParkingAudit
{
    public partial class SecondViewController : UIViewController
    {
        protected SecondViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void CmdAddSpot_TouchUpInside(UIButton sender)
        {
            SQLHelper helper = new SQLHelper();
            helper.AddParkingSpot(txtNewSpot.Text);

        }
    }
}
