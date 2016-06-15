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
// Copyright (c) 2016 Hin-Tak Leung
//
// Authors:
//	Andreia Gaita (shana@jitted.com)
//	Hin-Tak Leung (htl10@users.sourceforge.net)
//


using System;
using System.ComponentModel;
using Mono.WebBrowser;
using Mono.WebBrowser.DOM;
using webkit=WebKit;
using System.Windows.Forms;

namespace Mono.WebKit
{
	internal class WebBrowser : IDisposable, IWebBrowser, INavigation
	{
		private IntPtr handle;
		private int width, height;

		internal webkit.WebView webview;
		internal EmbedWidget widget;
		private bool disposed = false;
		private bool initialized = false;
		private static bool started = false;
		private static int widgetCount = 0;
		private static object widgetLock = new object ();

		public WebBrowser()
		{
		}

		~WebBrowser () {
			Dispose (false);
		}

		#region IDisposable Members

		private void Dispose (bool disposing)
		{
			if (!disposed) {
				if (disposing) {
					lock (widgetLock) {
						widgetCount--;
						if (widgetCount == 0) {
							Gtk.Application.Quit ();
						}
					}
				}
				disposed = true;
			}
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		#endregion

		#region IWebBrowser

		/// <summary>
		/// Initialize a browser instance.
		/// </summary>
		/// <param name="handle">
		/// A <see cref="IntPtr"/> to the native window handle of the widget
		/// where the browser engine will draw
		/// </param>
		/// <param name="width">
		/// A <see cref="System.Int32"/>. Initial width
		/// </param>
		/// <param name="height">
		/// A <see cref="System.Int32"/>. Initial height
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool Load (IntPtr handle, int width, int height)
		{
			this.handle = handle;
			this.width = width;
			this.height = height;

			lock (widgetLock) {
				if (!started) {
					Gtk.Application.Init ();
					System.Windows.Forms.Application.Idle += delegate (object sender, EventArgs e) {
						while (Gtk.Application.EventsPending()) {
							Gtk.Application.RunIteration(false);
						}
					};
					started = true;
				}
			}

			while (!initialized) {
				lock (widgetLock) {
					if (!started)
						continue;
					InitializeWindow (null, null);
					widgetCount++;
				}
			}

			return true;
		}

		void InitializeWindow (object _sender, EventArgs ev) {
			Gtk.Adjustment h = new Gtk.Adjustment(0, 0, 0, 0, 0, 0);
			Gtk.Adjustment v = new Gtk.Adjustment(0, 0, 0, 0, 0, 0);
			v.Changed += delegate (object sender, EventArgs e) {
				DebugHelper.WriteLine ("vertical scroll Changed " + v.Value);
			};
			v.ValueChanged += delegate (object sender, EventArgs e) {
				DebugHelper.WriteLine ("vertical scroll ValueChanged " + v.Value);
			};

			widget = new EmbedWidget(handle, h, v);
			widget.Unrealized += delegate {
				Dispose (true);
			};

			widget.Init ();
			webview = new webkit.WebView();

			webview.LoadCommitted += delegate (object o, webkit.LoadCommittedArgs args) {
			};
			webview.LoadProgressChanged += delegate (object o, webkit.LoadProgressChangedArgs args) {
			};

			webview.SetScrollAdjustments (h, v);
			widget.Add (webview);
			widget.ShowAll ();
			initialized = true;
		}


		public void Shutdown ()
		{
			Dispose ();
		}
		public void FocusIn (FocusOption focus)
		{
		}
		public void FocusOut ()
		{
		}
		public void Activate ()
		{
		}
		public void Deactivate ()
		{
		}
		public void Resize (int width, int height)
		{
			DebugHelper.WriteLine ("Resizing to " + widget.Allocation.X + " " + widget.Allocation.Y + " " + width + " " + height);
			widget.Resize (width, height);
		}
		public void Render (byte[] data)
		{
		}
		public void Render (string html)
		{
		}
		public void Render (string html, string uri, string contentType)
		{
		}

		public bool Initialized {
			get { return initialized; }
		}

		public IWindow Window {
			get { return null; }
		}

		public IDocument Document {
			get { return null; }
		}

		public INavigation Navigation {
			get {
				return this;
			}
		}

		public bool Offline {
			get { return false; }
			set { }
		}

		public void ExecuteScript (string s)
		{
			webview.ExecuteScript (s);
		}


		#region Events
		public event NodeEventHandler KeyDown;
		public event NodeEventHandler KeyPress;
		public event NodeEventHandler KeyUp;
		public event NodeEventHandler MouseClick;
		public event NodeEventHandler MouseDoubleClick;
		public event NodeEventHandler MouseDown;
		public event NodeEventHandler MouseEnter;
		public event NodeEventHandler MouseLeave;
		public event NodeEventHandler MouseMove;
		public event NodeEventHandler MouseUp;
		public event EventHandler Focus;
		public event EventHandler Blur;
		public event CreateNewWindowEventHandler CreateNewWindow;
		public event AlertEventHandler Alert;
		public event EventHandler Loaded;
		public event EventHandler Unloaded;
		public event StatusChangedEventHandler StatusChanged;
		public event LoadStartedEventHandler LoadStarted;
		public event LoadCommitedEventHandler LoadCommited;
		public event Mono.WebBrowser.ProgressChangedEventHandler ProgressChanged;
		public event LoadFinishedEventHandler LoadFinished;
		public event SecurityChangedEventHandler SecurityChanged;
		public event ContextMenuEventHandler ContextMenuShown;
		public event NavigationRequestedEventHandler NavigationRequested;

		void OnKeyDown () {
			if (KeyDown != null) {
				KeyDown (this, new NodeEventArgs (null));
			}
		}

		void OnKeyPress () {
			if (KeyPress != null) {
				KeyPress (this, new NodeEventArgs (null));
			}
		}
		void OnKeyUp () {
			if (KeyUp != null) {
				KeyUp (this, new NodeEventArgs (null));
			}
		}
		void OnMouseClick () {
			if (MouseClick != null) {
				MouseClick (this, new NodeEventArgs (null));
			}
		}
		void OnMouseDoubleClick () {
			if (MouseDoubleClick != null) {
				MouseDoubleClick (this, new NodeEventArgs (null));
			}
		}
		void OnMouseDown () {
			if (MouseDown != null) {
				MouseDown (this, new NodeEventArgs (null));
			}
		}
		void OnMouseEnter () {
			if (MouseEnter != null) {
				MouseEnter (this, new NodeEventArgs (null));
			}
		}
		void OnMouseLeave () {
			if (MouseLeave != null) {
				MouseLeave (this, new NodeEventArgs (null));
			}
		}
		void OnMouseMove () {
			if (MouseMove != null) {
				MouseMove (this, new NodeEventArgs (null));
			}
		}
		void OnMouseUp () {
			if (MouseUp != null) {
				MouseUp (this, new NodeEventArgs (null));
			}
		}
		void OnFocus () {
			if (Focus != null) {
				Focus (this, new EventArgs ());
			}
		}
		void OnBlur () {
			if (Blur != null) {
				Blur (this, new EventArgs ());
			}
		}
		void OnCreateNewWindow () {
			if (CreateNewWindow != null) {
				CreateNewWindow (this, new CreateNewWindowEventArgs (false));
			}
		}
		void OnAlert () {
			if (Alert != null) {
				Alert (this, new AlertEventArgs ());
			}
		}
		void OnLoaded () {
			if (Loaded != null) {
				Loaded (this, new EventArgs ());
			}
		}
		void OnUnloaded () {
			if (Unloaded != null) {
				Unloaded (this, new EventArgs ());
			}
		}
		void OnStatusChanged (string message, int status) {
			if (StatusChanged != null) {
				StatusChanged (this, new StatusChangedEventArgs (message, status));
			}
		}
		void OnLoadStarted (string uri, string frameName) {
			if (LoadStarted != null) {
				LoadStarted (this, new LoadStartedEventArgs (uri, frameName));
			}
		}
		void OnLoadCommited (string uri) {
			if (LoadCommited != null) {
				LoadCommited (this, new LoadCommitedEventArgs (uri));
			}
		}
		void OnProgressChanged (int progress, int maxProgress) {
			if (ProgressChanged != null) {
				ProgressChanged (this, new Mono.WebBrowser.ProgressChangedEventArgs (progress, maxProgress));
			}
		}
		void OnLoadFinished () {
			if (LoadFinished != null) {
				LoadFinished (this, new LoadFinishedEventArgs (null));
			}
		}
		void OnSecurityChanged (SecurityLevel state) {
			if (SecurityChanged != null) {
				SecurityChanged (this, new SecurityChangedEventArgs (state));
			}
		}
		void OnContextMenuShown () {
			if (ContextMenuShown != null) {
				ContextMenuShown (this, new ContextMenuEventArgs (0, 0));
			}
		}

		#endregion

		#endregion

		#region INavigation
		public bool CanGoBack {
			get { return webview.CanGoBack ();}
		}

		public bool CanGoForward  {
			get { return webview.CanGoForward ();}
		}

		public bool Back () {
			if (!CanGoBack) return false;
			webview.GoBack ();
			return true;
		}

		public bool Forward () {
			if (!CanGoForward) return false;
			webview.GoForward ();
			return true;
		}

		public void Home () {
		}

		public void Reload () {
			DebugHelper.DumpCallers ();
			DebugHelper.WriteLine ("Reloading...");

			webview.Reload ();
		}

		// TODO: see if it's possible to reload from cache
		public void Reload (ReloadOption option) {
			DebugHelper.DumpCallers ();
			DebugHelper.WriteLine ("Reloading...");

			webview.Reload ();
		}

		public void Stop () {
			webview.StopLoading ();
		}

		/// <summary>
		/// Navigate to the page in the history, by index.
		/// </summary>
		/// <param name="index">
		/// A <see cref="System.Int32"/> representing an absolute index in the
		/// history (that is, > -1 and < history length
		/// </param>
		public void Go (int index) {
			if (index < 0)
				return;


			webkit.WebBackForwardList history = webview.BackForwardList;
			int len = history.ForwardLength + history.BackLength + 1;
			if (index > len) {
				return;
			}
			webkit.WebHistoryItem item = history.GetNthItem (index);
			webview.GoToBackForwardItem (item);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="index">
		/// A <see cref="System.Int32"/> representing an index in the
		/// history, that can be relative or absolute depending on the relative argument
		/// </param>
		/// <param name="relative">
		/// A <see cref="System.Boolean"/> indicating whether the index is relative to
		/// the current place in history or not (i.e., if relative = true, index can be
		/// positive or negative, and index=-1 means load the previous page in the history.
		/// if relative = false, index must be > -1, and index = 0 means load the first
		/// page of the history.
		/// </param>
		public void Go (int index, bool relative) {
			if (!relative)
				Go (index);
			else {
				if (!webview.CanGoBackOrForward (index)) {
					return;
				}
				webview.GoBackOrForward (index);
			}
		}


		/// <summary>
		/// Navigate to an Url. Uses default loading flags, so the page might come
		/// from cache
		/// </summary>
		/// <param name="url">
		/// A <see cref="System.String"/> representing an Url
		/// </param>
		public void Go (string url) {
			webview.Open (url);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="url">
		/// A <see cref="System.String"/> representing an Url.
		/// </param>
		/// <param name="flags">
		/// A <see cref="LoadFlags"/> that control if the page comes from cache or not.
		/// </param>
		public void Go (string url, LoadFlags flags) {
			webview.Open (url);
		}

		public int HistoryCount {
			get {
				webkit.WebBackForwardList history = webview.BackForwardList;
				return history.ForwardLength + history.BackLength + 1;
			}
		}
		#endregion

	}
}
