// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2008 Novell, Inc.
//
// Authors:
//	Andreia Gaita (shana@jitted.com)
//

using System;
using Gdk;
using Gtk;


namespace Mono.WebKit
{
	internal class EmbedWidget : Gtk.Window
	{
		static GLib.GType gtype;
		IntPtr handle;
		Widget webview;
		ScrolledWindow window;

		public EmbedWidget (IntPtr handle, Adjustment h, Adjustment v) : base (Gtk.WindowType.Toplevel)
		{
			this.handle = handle;
			window = new Gtk.ScrolledWindow (h, v);
		}

		public void Init ()
		{
			this.ParentWindow = Gdk.Window.ForeignNewForDisplay (Gdk.Display.Default, (uint)handle.ToInt32 ());
			Gdk.Color col = new Gdk.Color();
			Gdk.Color.Parse("White", ref col);
			this.ModifyBg (Gtk.StateType.Normal, col);

//			this.ButtonPressEvent += delegate (object sender, ButtonPressEventArgs e) {
//				DebugHelper.WriteLine ("ButtonPress");
//			};
//
//			this.FocusInEvent += delegate (object sender, FocusInEventArgs e) {
//				DebugHelper.WriteLine ("FocusInEvent");
//			};
//

//			((Widget)this).WidgetEvent += delegate (object sender, WidgetEventArgs e) {
//				DebugHelper.WriteLine ("WidgetEvent " + e.Event.Type);
//				while (Gtk.Application.EventsPending ())
//					Gtk.Application.RunIteration ();
//			};
		}

		protected override void OnRealized ()
		{
			DebugHelper.WriteLine ("OnRealized");

			SetFlag (WidgetFlags.Realized);
			Gdk.WindowAttr attributes = new WindowAttr();

			attributes.WindowType = Gdk.WindowType.Toplevel;
			attributes.X = this.Allocation.X;
			attributes.Y = this.Allocation.Y;
			attributes.Width = this.Allocation.Width;
			attributes.Height = this.Allocation.Height;
			attributes.Wclass = WindowClass.InputOutput;
			attributes.Visual = this.Visual;
			attributes.Colormap = this.Colormap;
			attributes.EventMask = (int)this.Events;

			attributes.EventMask |= (int)(Gdk.EventMask.AllEventsMask);

			this.GdkWindow = new Gdk.Window(this.ParentWindow, attributes,
			                                (Gdk.WindowAttributesType.X |
			                                 Gdk.WindowAttributesType.Y |
			                                 Gdk.WindowAttributesType.Visual |
			                                 Gdk.WindowAttributesType.Colormap));
			this.GdkWindow.UserData = this.Handle;
			this.Style.Attach (this.GdkWindow);
			this.Style.SetBackground (this.GdkWindow, StateType.Normal);

			ParentWindow.Events = (Gdk.EventMask) (GdkEventMask.StructureNotifyMask | GdkEventMask.SubstructureNotifyMask);
		}


		protected override void OnMapped ()
		{
			DebugHelper.WriteLine ("OnMapped");
			base.OnMapped ();
			GdkWindow.Show ();
		}

		protected override void OnUnmapped ()
		{
			DebugHelper.WriteLine ("OnUnmapped");
			base.OnUnmapped ();
			GdkWindow.Hide ();
		}

		protected override void OnUnrealized ()
		{
			DebugHelper.WriteLine ("OnUnrealized");
			base.OnUnrealized ();

		}
/*
		protected override void OnSizeAllocated (Rectangle allocation)
		{
			DebugHelper.DumpCallers ();
			DebugHelper.WriteLine ("OnSizeAllocated");

			if (webview != null && (WidgetFlags & WidgetFlags.Realized) != 0) {

				GdkWindow.MoveResize (allocation);
				webview.SizeAllocate (allocation);
			}
			base.OnSizeAllocated (allocation);
		}
*/
		protected override void OnAdded (Widget webview)
		{
			this.webview = webview;
			this.window.Add (webview);
			base.OnAdded (window);
		}




		public static new GLib.GType Type {
			get {
				if (gtype == GLib.GType.Invalid)
					gtype = RegisterGType (typeof (Widget));
				return gtype;
			}
		}
	}
}
