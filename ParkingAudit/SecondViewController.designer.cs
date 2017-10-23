// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ParkingAudit
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cmdAddSpot { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNewSpot { get; set; }

        [Action ("CmdAddSpot_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CmdAddSpot_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (cmdAddSpot != null) {
                cmdAddSpot.Dispose ();
                cmdAddSpot = null;
            }

            if (txtNewSpot != null) {
                txtNewSpot.Dispose ();
                txtNewSpot = null;
            }
        }
    }
}