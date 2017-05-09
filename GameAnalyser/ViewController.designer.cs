// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace GameAnalyser
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextView BodyLabel { get; set; }

		[Outlet]
		AppKit.NSTextView BodyLabel2 { get; set; }

		[Outlet]
		AppKit.NSTextField FileNameLabel { get; set; }

		[Outlet]
		AppKit.NSTextView HeaderDetail { get; set; }

		[Outlet]
		AppKit.NSTextView HeaderLabel { get; set; }

		[Outlet]
		AppKit.NSTextView HeaderLabel2 { get; set; }

		[Outlet]
		AppKit.NSTextField SubVersion { get; set; }

		[Outlet]
		AppKit.NSTextField Version { get; set; }

		[Action ("ClickedButton:")]
		partial void ClickedButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (BodyLabel != null) {
				BodyLabel.Dispose ();
				BodyLabel = null;
			}

			if (BodyLabel2 != null) {
				BodyLabel2.Dispose ();
				BodyLabel2 = null;
			}

			if (FileNameLabel != null) {
				FileNameLabel.Dispose ();
				FileNameLabel = null;
			}

			if (HeaderDetail != null) {
				HeaderDetail.Dispose ();
				HeaderDetail = null;
			}

			if (HeaderLabel != null) {
				HeaderLabel.Dispose ();
				HeaderLabel = null;
			}

			if (HeaderLabel2 != null) {
				HeaderLabel2.Dispose ();
				HeaderLabel2 = null;
			}

			if (Version != null) {
				Version.Dispose ();
				Version = null;
			}

			if (SubVersion != null) {
				SubVersion.Dispose ();
				SubVersion = null;
			}
		}
	}
}
