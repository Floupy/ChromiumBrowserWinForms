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
        private string initialURL = "https://datorium.eu";

        public Browser()
        {
            InitializeComponent();
            InitializeChromium();
            InitializeBrowserTabs();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);           
        }

        private void InitializeBrowserTabs()
        {
            BrowserTabs.TabPages.Clear();
            BrowserTabs.TabPages.Add("Tab 1");
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(initialURL);
            // Add it to the form and fill it to the form window.
            BrowserTabs.TabPages[0].Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            NavigateToURL();
        }
        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavigateToURL();
            }
        }

        private void NavigateToURL()
        {
            string googleURL = $"https://www.google.com/search?q=";
            string addressBarUrl = AddressBar.Text;
            bool urlPrefix = 
                addressBarUrl.Contains("https://") || 
                addressBarUrl.Contains("http://") ||
                addressBarUrl.Contains("www.");
            if (urlPrefix)
            {
                chromeBrowser.Load(addressBarUrl);
            }
            else
            {
                chromeBrowser.Load(googleURL + addressBarUrl);
            }  
        }

        private void ButtonAddTab_Click(object sender, EventArgs e)
        {
            var tp = new TabPage();
            tp.Text = "Tab " + Convert.ToString(BrowserTabs.TabPages.Count + 1);

            BrowserTabs.TabPages.Add(tp);            
            chromeBrowser = new ChromiumWebBrowser(initialURL);            
            tp.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }




        //Homework for Feb 25, 2021
        //1. Add Back and Forward buttons, make sure that they work
        //2. Add Reload button
        //3. Check, if adress does not start with http/www, then request a Google search
        //4. Make sure that when you press enter in the Address Bar, the browser vists your URL
        //5. Your own feature
    }
}
