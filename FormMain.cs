using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;

namespace GetLinks
{
    public partial class FormMain : Form
    {
        private string _parentHost = "http://default.url.com/";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // set start position for controls
            var centerListBoxLinks = new Point(radListViewLinks.Size.Width / 2, radListViewLinks.Size.Height / 2);
            // X and Y offset
            centerListBoxLinks.X += radListViewLinks.Location.X;
            centerListBoxLinks.Y += radListViewLinks.Location.Y;
            // offsert by the center of the waiting bar
            centerListBoxLinks.X -= radWaitingBarLoading.Size.Width / 2;
            centerListBoxLinks.Y -= radWaitingBarLoading.Size.Height / 2;

            radWaitingBarLoading.Location = centerListBoxLinks;

            comboBoxHomePage.Items.AddRange(ConfigurationManager.AppSettings["baseURL"].Split('|'));
        }
        
        private static string GetHtmlFromUrl(string url)
        {
            var html = String.Empty;

            if (String.IsNullOrEmpty(url)) return html;

            var request = (HttpWebRequest) WebRequest.Create(url);

            HttpWebResponse response = null;
            try
            {
                // get the response, to later read the stream
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // get the response stream.
            //Stream responseStream = response.GetResponseStream();
            
            if (response != null)
            {
                // use a stream reader that understands UTF8
                var reader = new StreamReader(response.GetResponseStream(), encoding: Encoding.UTF8);
                html = reader.ReadToEnd();
                // close the reader
                reader.Close();
                response.Close();
            }

            return html; //return html content
        }

        private void buttonGetLinks_Click(object sender, EventArgs e)
        {
            // clear listbox 
            radListViewLinks.Items.Clear();
            
            // validate URL
            const string patternUrl = @"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,()]*";

            var urlParentPage = textBoxParentPage.Text.Trim();
            if (!Regex.IsMatch(urlParentPage, patternUrl, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Please format the base URL correctly", "Error in URL", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var urlParent = new UriBuilder(urlParentPage);
            _parentHost = new UriBuilder(urlParent.Host).ToString();

            // already working asynchronously, exit
            if (backgroundWorkerDownloadingLinks.IsBusy) return;

            // disable the GetLinks buttong
            buttonGetLinks.Enabled = false;
            // show the waiting bar
            radWaitingBarLoading.Visible = !buttonGetLinks.Enabled;
            // start the waiting bar
            radWaitingBarLoading.StartWaiting();
            // show the waiting text
            radWaitingBarLoading.ShowText = true;

            // launch the content fetch
            backgroundWorkerDownloadingLinks.RunWorkerAsync(urlParentPage);
        }

        private void comboBoxHomePage_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxParentPage.Text = comboBoxHomePage.SelectedItem.ToString();
        }

        private void copyToDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // put all links separated by NewLine
            var selectedLinks = String.Join(Environment.NewLine,
                radListViewLinks.SelectedItems.Select(item => item.Value).ToList());

            Clipboard.SetDataObject(selectedLinks);
        }

        private void backgroundWorkerDownloadingLinks_DoWork(object sender, DoWorkEventArgs e)
        {
            // get the parentLink passed in as param
            var parentLink = e.Argument.ToString();

            // get result content of the page
            e.Result = DownloadLinksAsync(parentLink);
        }

        private void backgroundWorkerDownloadingLinks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // stop the waiting bar
            radWaitingBarLoading.StopWaiting();
            // reset the bar back to "zero"
            radWaitingBarLoading.ResetWaiting();
            // hide the waiting text
            radWaitingBarLoading.ShowText = false;
            // enable the GetLinks button back
            buttonGetLinks.Enabled = true;
            // hide the waiting bar
            radWaitingBarLoading.Visible = !buttonGetLinks.Enabled;
            
            if (e.Error != null)
            {
                radListViewLinks.Items.Add("Error: " + e.Error.Message);
            }
            else
            {
                // if nothing in Result, exit
                if (e.Result == null) return;

                var pageContent = e.Result.ToString();
                const string patternA = "<a.*</a>";
                const string patternUrl = @"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,()]*";

                pageContent = pageContent.Replace("\n", String.Empty);
                pageContent = pageContent.Replace("\r", String.Empty);
                pageContent = pageContent.Replace("\t", String.Empty);

                // remove <A> tags from the content
                pageContent = pageContent.Replace("</a>", "</a>" + Environment.NewLine);

                // search for formatted urls and add to listbox control
                foreach (Match m in Regex.Matches(pageContent, patternA, RegexOptions.IgnoreCase))
                {
                    var value = m.Value;
                    if (!value.Contains("http://") && !value.Contains("../"))
                    {
                        value = value.Replace(@"href=""", @"href=""" + _parentHost);
                    }
                    
                    if (Regex.IsMatch(value, patternUrl, RegexOptions.IgnoreCase))
                    {
                        var aLinkName = "-- no detail --";
                        try
                        {
                            var aElement = XElement.Parse(value);
                            aLinkName = aElement.Value;
                        }
                        catch (Exception)
                        {
                            // continue
                        }

                        var link = Regex.Match(value, patternUrl, RegexOptions.IgnoreCase).Value;
                        var itemList = new
                            ListViewDataItem(link, new []
                                {
                                    aLinkName, 
                                    link
                                });
                        itemList.Tag = aLinkName;
                        radListViewLinks.Items.Add(itemList);
                    }
                }
            }
        }

        private static string DownloadLinksAsync(string parentLink)
        {
            // get the content from the web
            return GetHtmlFromUrl(parentLink);
        }

        private void massDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("massdown", radListViewLinks.SelectedItem.Value.ToString());
        }
        
        private void contextMenuStripCopyList_Opening(object sender, CancelEventArgs e)
        {
            if (radListViewLinks.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }

            // hide/show massdownload link
            massDownloadToolStripMenuItem.Visible = (radListViewLinks.SelectedItems.Count == 1);
        }

        private void radListViewLinks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C) // CTRL + C 
            {
                copyToDownloadToolStripMenuItem_Click(sender, e);
            }
        }

        private void radListViewLinks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radListViewLinks.SelectedItem == null) return;

            textBoxParentPage.Text = radListViewLinks.SelectedItem.Value.ToString();
            labelAlbumName.Text = String.Format(
                labelAlbumName.Tag.ToString(), radListViewLinks.SelectedItem.Tag);
            //buttonGetLinks_Click(sender, e);
        }

        private void labelAlbumName_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(labelAlbumName.Text.Replace("=> ", String.Empty));
        }
    }
}
