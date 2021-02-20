using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace ChromiumBrowserWinForms
{
    public partial class Browser : Form
    {
        public ChromiumWebBrowser chromeBrowser = null;
        private string homeUrl = "https://datorium.eu";

        public Browser()
        {
            InitializeComponent();
            InitializeChromium();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(homeUrl);
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            string url = AddressBar.Text;
            chromeBrowser.Load(url);
        }

        //Homework for Feb 27, 2021
        //1. Add Back and Forward buttons, make sure that they work
        //2. Add Reload button
        //3. Check, if adress does not start with http/www, then request a Google search
        //4. Make sure that when you press enter in the Address Bar, the browser vists your URL
        //5. Your own feature
    }
}
