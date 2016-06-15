using System;
using System.Windows.Forms;
using System.Drawing;

namespace tests.simple {

	public class browser : Form {
		public static void Main () {
			Application.Run (new browser ());
		}

		WebBrowser webbrowser;
		public browser () {
			webbrowser = new WebBrowser ();
			webbrowser.Dock = DockStyle.Fill;

			this.Controls.Add (webbrowser);
			webbrowser.Navigate ("http://www.google.com");

		}
	}


}