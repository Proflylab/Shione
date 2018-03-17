using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Shione
{
    // Implements the manual sorting of items by columns.
    public partial class frmMain : Form
    {
        int listcount = 0;
        //Thread listRecent; bool listRecentIsRun = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private string downloadURL(string url)
        {
            try
            {
                WebClient _IE = new WebClient();
                _IE.Encoding = Encoding.Default;
                _IE.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                return _IE.DownloadString(url).Replace("\"", "");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ex.Message.ToString();
            }
        }
        private void shioneLoad(string filter, bool FilterBy = false)
        {
            /*
              FilterBy
              false = Fansub & Anime
              true = ID
            */
            //Math.Ceiling(10.1)
            /*
              hash = 1
              name/ep = 2
              type/ep = 3
              anime.id = 4
              anime.name = 5
              anime.alias = 6
              anime.description = 7
              anime.myanimelist = 8
              fansub = 10
              facebook = 12
            */

            var cache = true;
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1")) { File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1", downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=100&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=1")); } //for not found file
            var _recentcache = Regex.Matches(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1"), "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),");
            var _url = downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=1&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=1");
            var _recent = Regex.Matches(_url, "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),");

            if (_recentcache.Count == 0)
            {
                MessageBox.Show("1#" + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1"));
                clearCache();
                this.Text = "Shione - TAFASU Fansub Community";
                listDetails.Items.Clear();
                this.Cursor = Cursors.Default;
                listDetails.Cursor = Cursors.Default;
                toolBtnGO.Enabled = true;
                txtSearch.Enabled = true;
                listDetails.Enabled = true;
                return;
            }
            if (_recent.Count == 0)
            {
                MessageBox.Show("2#" + _url);
                clearCache();
                this.Text = "Shione - TAFASU Fansub Community";
                listDetails.Items.Clear();
                this.Cursor = Cursors.Default;
                listDetails.Cursor = Cursors.Default;
                toolBtnGO.Enabled = true;
                txtSearch.Enabled = true;
                listDetails.Enabled = true;
                return;
            }
            var _hashsv = _recent[0].Groups[1].ToString();
            var _hashcl = _recentcache[0].Groups[1].ToString();

            if (!_hashsv.Contains(_hashcl)) { cache = false; }

            var stopwatch = Stopwatch.StartNew();

            for (int i = 1; i <= 23; i++)
            {
                if (cache)
                {
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString()))
                    {
                        var _url1 = downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=100&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=" + i.ToString());
                        if (Regex.Matches(_url1, "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),").Count != 0)
                        {
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString(), _url1);
                        }
                        else
                        {
                            MessageBox.Show("3#" + _url1);
                            clearCache();
                            this.Text = "Shione - TAFASU Fansub Community";
                            listDetails.Items.Clear();
                            this.Cursor = Cursors.Default;
                            listDetails.Cursor = Cursors.Default;
                            toolBtnGO.Enabled = true;
                            txtSearch.Enabled = true;
                            listDetails.Enabled = true;
                            return;
                        }
                    }// if not found file cache
                }
                else
                {
                    var _url2 = downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=100&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=" + i.ToString());
                    if (Regex.Matches(_url2, "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),").Count != 0)
                    {
                        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString(), _url2);
                    }
                    else
                    {
                        MessageBox.Show("4#" + _url2);
                        clearCache();
                        this.Text = "Shione - TAFASU Fansub Community";
                        listDetails.Items.Clear();
                        this.Cursor = Cursors.Default;
                        listDetails.Cursor = Cursors.Default;
                        toolBtnGO.Enabled = true;
                        txtSearch.Enabled = true;
                        listDetails.Enabled = true;
                        return;
                    }
                }

                var _datacache = Regex.Matches(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString()), "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),");
                for (int j = 0; j < _datacache.Count; j++)
                {

                    if (FilterBy)
                    {
                        //By Fansub
                        if (filter.Contains("{filter_fansub}"))
                        {
                            if (DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[4].ToString()).ToLower() == Regex.Match(filter.ToLower(), "(.*?){filter_fansub}").Groups[1].Value && DecodeEncodedNonAsciiCharacters(DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString())).ToLower() == Regex.Match(filter.ToLower(), "{filter_fansub}(.*)").Groups[1].Value)
                            {
                                listDetails.Items.Add(new ListViewItem(new string[] { _datacache[j].Groups[4].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[1].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[8].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[12].ToString()) }));
                            }
                        }
                        else
                        {
                            //By ID
                            if (DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[4].ToString()).ToLower() == filter.ToLower())
                            {
                                listDetails.Items.Add(new ListViewItem(new string[] { _datacache[j].Groups[4].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[1].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[8].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[12].ToString()) }));
                            }
                        }
                    }
                    else
                    {
                        if (DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()).ToLower().Contains(filter.ToLower()) || DecodeEncodedNonAsciiCharacters(DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString())).ToLower().Contains(filter.ToLower()))
                        {
                            listDetails.Items.Add(new ListViewItem(new string[] { _datacache[j].Groups[4].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[1].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[8].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[12].ToString()) }));
                        }
                    }
                    //listDetails.Items.Add(new ListViewItem(new string[] { "", DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[4].ToString(), _datacache[j].Groups[1].ToString(), "" }));
                    //var remaining = str2sec(elapsed) * ((100 - perc) / perc);
                    var perc = Math.Floor(((float)i / 23) * 100);
                    var remaining = stopwatch.Elapsed.Seconds * ((100 - perc) / perc);
                    this.Text = Math.Floor(((float)i / 23) * 100) + "% File Total (" + listDetails.Items.Count.ToString() + ") " + TimeSpan.FromSeconds(remaining).ToString(@"hh\:mm\:ss");
                }
            }

            this.Cursor = Cursors.Default;
            listDetails.Cursor = Cursors.Default;
            toolBtnGO.Enabled = true;
            txtSearch.Enabled = true;
            listDetails.Enabled = true;

            //listRecentIsRun = false;
        }

        private void threadshioneLoad(string filter, bool FilterBy = false)
        {
            /*
              FilterBy
              false = Fansub & Anime
              true = ID
            */
            //Math.Ceiling(10.1)
            /*
              hash = 1
              name/ep = 2
              type/ep = 3
              anime.id = 4
              anime.name = 5
              anime.alias = 6
              anime.description = 7
              anime.myanimelist = 8
              fansub = 10
              facebook = 12
            */
            var cache = true;
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1")) { File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1", downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=100&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=1")); } //for not found file
            var _recentcache = Regex.Matches(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\1"), "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),");
            var _recent = Regex.Matches(downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=1&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=1"), "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),");
            var _hashsv = _recent[0].Groups[1].ToString();
            var _hashcl = _recentcache[0].Groups[1].ToString();

            if (!_hashsv.Contains(_hashcl)) { cache = false; }

            for (int i = 1; i <= 23; i++)
            {
                if (cache)
                {
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString())) { File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString(), downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=100&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=" + i.ToString())); }// if not found file cache
                }
                else
                {
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString(), downloadURL("https://www.tafasu.com/api/v1/anime/recent?limit=100&fields=hash,name,type,anime.id,anime.name,anime.alias,anime.description,anime.myanimelist,fansub&page=" + i.ToString()));
                }

                var _datacache = Regex.Matches(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\" + i.ToString()), "hash:(.*?),name:(.*?),type:(.*?),anime:{id:(.*?),name:(.*?),alias:(.*?),description:(.*?),myanimelist:(.*?)},fansub:\\[{id:(.*?),name:(.*?),(.*?),facebook:(.*?),");
                if (_datacache.ToString().Contains("The remote server returned an error: (508) unused."))
                {
                    MessageBox.Show("");
                }
                for (int j = 0; j < _datacache.Count; j++)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        if (FilterBy)
                        {
                            //By Fansub
                            if (filter.Contains("{filter_fansub}"))
                            {
                                if (DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[4].ToString()).ToLower() == Regex.Match(filter.ToLower(), "(.*?){filter_fansub}").Groups[1].Value && DecodeEncodedNonAsciiCharacters(DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString())).ToLower() == Regex.Match(filter.ToLower(), "{filter_fansub}(.*)").Groups[1].Value)
                                {
                                    listDetails.Items.Add(new ListViewItem(new string[] { _datacache[j].Groups[4].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[1].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[8].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[12].ToString()) }));
                                }
                            }
                            else
                            {
                                //By ID
                                if (DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[4].ToString()).ToLower() == filter.ToLower())
                                {
                                    listDetails.Items.Add(new ListViewItem(new string[] { _datacache[j].Groups[4].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[1].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[8].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[12].ToString()) }));
                                }
                            }
                        }
                        else
                        {
                            if (DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()).ToLower().Contains(filter.ToLower()) || DecodeEncodedNonAsciiCharacters(DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString())).ToLower().Contains(filter.ToLower()))
                            {
                                listDetails.Items.Add(new ListViewItem(new string[] { _datacache[j].Groups[4].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[1].ToString(), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[8].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[12].ToString()) }));
                            }
                        }
                        //listDetails.Items.Add(new ListViewItem(new string[] { "", DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[10].ToString()), DecodeEncodedNonAsciiCharacters(_datacache[j].Groups[5].ToString()) + " " + _datacache[j].Groups[2].ToString(), _datacache[j].Groups[4].ToString(), _datacache[j].Groups[1].ToString(), "" }));
                        this.Text = "File Total (" + listDetails.Items.Count.ToString() + ")";
                    }));
                }
            }
            Invoke(new MethodInvoker(delegate
            {
                this.Cursor = Cursors.Default;
                listDetails.Cursor = Cursors.Default;
                toolBtnGO.Enabled = true;
                txtSearch.Enabled = true;
                listDetails.Enabled = true;
            }));
            //listRecentIsRun = false;
        }

        private string EncodeNonAsciiCharacters(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    string encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private string DecodeEncodedNonAsciiCharacters(string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m =>
                {
                    return ((char)int.Parse(m.Groups["Value"].Value, System.Globalization.NumberStyles.HexNumber)).ToString();
                }).Replace(@"\", "");
        }

        private string decodeURL(string url)
        {
            return url.Replace("&lt;", "<").Replace("&amp;", "&").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "'");
        }
        private void createCache()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\");
            }
        }
        private void clearCache(bool msg = false)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\"))
            {
                string _total = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\").Count().ToString();
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shione\cache\", true);
                if (msg) { MessageBox.Show("ClearCache (" + _total + " files)", "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            ((ToolStripDropDownMenu)dbtnSettings.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)cmsSettings.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)cmsInfo.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)cmsFilter.DropDown).ShowImageMargin = false;
            //Console.WriteLine(decodeURL("https://app.koofr.net/content/links/94ff0318-0c83-4288-9347-9b7e9f1366c0/files/get/%5BDAI-TAKU&amp;LSP&amp;ZouL-FS%5D%20Shakunetsu%20no%20Takkyuu%20Musume%20-%2011%20%5B720p%5D.mp4?path="));
        }

        private void toolBtnGO_Click(object sender, EventArgs e)
        {
            createCache();
            this.Text = "Please wait...";
            this.Cursor = Cursors.WaitCursor;
            listDetails.Cursor = Cursors.WaitCursor;
            toolBtnGO.Enabled = false;
            txtSearch.Enabled = false;
            listDetails.Enabled = false;
            listDetails.Items.Clear();
            listDetails.Sorting = SortOrder.None;
            listDetails.BeginUpdate();
            shioneLoad(txtSearch.Text);
            listDetails.EndUpdate();
            /*
            listRecent = new Thread(() => threadshioneLoad(txtSearch.Text));
            listRecent.Start();
            listRecentIsRun = true;
            */
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (listRecentIsRun)
            {
                //listRecent.Abort();
            }
            */
        }

        private void listDetails_DoubleClick(object sender, EventArgs e)
        {
            //Console.WriteLine(listDetails.Items[listDetails.FocusedItem.Index].SubItems[3].Text);
            Process.Start(@"C:\Program Files (x86)\Internet Download Manager\IDMan.exe", "/d " + decodeURL(Regex.Match(downloadURL("https://www.tafasu.com/api/v1/watch/" + listDetails.Items[listDetails.FocusedItem.Index].SubItems[3].Text + "?fields=stream"), "koofr,url:(.*?)}").Groups[1].Value.Replace(@"\", "") + "force\""));
        }

        private void cmsWithIDM_Click(object sender, EventArgs e)
        {
            listDetails.Enabled = false;
            if (listcount > 0)
            {
                Process.Start(@"C:\Program Files (x86)\Internet Download Manager\IDMan.exe");
                foreach (ListViewItem anichecked in listDetails.SelectedItems)
                {
                    Process.Start(@"C:\Program Files (x86)\Internet Download Manager\IDMan.exe", "/a /n /d " + decodeURL(Regex.Match(downloadURL("https://www.tafasu.com/api/v1/watch/" + anichecked.SubItems[3].Text + "?fields=stream"), "koofr,url:(.*?)}").Groups[1].Value.Replace(@"\", "") + "force\""));
                }
            }
            listDetails.Enabled = true;
        }

        private void cmsInformation_Opening(object sender, CancelEventArgs e)
        {
            listcount = 0;
            foreach (ListViewItem anichecked in listDetails.SelectedItems)
            {
                /*
                if (!Regex.Match(downloadURL("https://www.tafasu.com/api/v1/watch/" + anichecked.SubItems[3].Text + "?fields=stream"), "url:(.*?)}").Groups[1].Value.Contains("koofr"))
                {
                */
                listcount += 1;
                //Console.WriteLine(anichecked.SubItems[3].Text);
                //}
                //Console.WriteLine(Regex.Match(downloadURL("https://www.tafasu.com/api/v1/watch/" + anichecked.SubItems[3].Text + "?fields=stream"), "url:(.*?)}").Groups[1].Value);
                //Console.WriteLine(anichecked.SubItems[3].Text);
            }
            //Console.WriteLine(count);
            if (listcount > 0)
            {
                cmsTafasu.Text = "Go to link tafasu.com/watch?v=" + listDetails.Items[listDetails.FocusedItem.Index].SubItems[3].Text;
                cmsWithIDM.Text = "Download Queue (" + listcount.ToString() + " selected) to IDM";
            }
            else
            {
                cmsTafasu.Text = "Go to link tafasu.com";
                cmsWithIDM.Text = "Download Queue (0 selected) to IDM";
            }
        }
        private void listDetails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listDetails.Sorting == SortOrder.Ascending)
            {
                listDetails.Sorting = SortOrder.Descending;
                listDetails.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Descending);
            }
            else
            {
                listDetails.Sorting = SortOrder.Ascending;
                listDetails.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void cmsIDM_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                Process.Start(@"C:\Program Files (x86)\Internet Download Manager\IDMan.exe", "/d " + decodeURL(Regex.Match(downloadURL("https://www.tafasu.com/api/v1/watch/" + listDetails.Items[listDetails.FocusedItem.Index].SubItems[3].Text + "?fields=stream"), "koofr,url:(.*?)}").Groups[1].Value.Replace(@"\", "") + "force\""));
            }
        }

        private void cmsTafasu_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                Process.Start("https://www.tafasu.com/watch?v=" + listDetails.Items[listDetails.FocusedItem.Index].SubItems[3].Text);
            }
        }

        private void cmsFilterID_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                createCache();
                this.Text = "Please wait...";
                this.Cursor = Cursors.WaitCursor;
                listDetails.Cursor = Cursors.WaitCursor;
                toolBtnGO.Enabled = false;
                txtSearch.Enabled = false;
                listDetails.Enabled = false;
                string ID = listDetails.Items[listDetails.FocusedItem.Index].SubItems[0].Text;
                listDetails.Items.Clear();
                listDetails.Sorting = SortOrder.Ascending;
                listDetails.BeginUpdate();
                shioneLoad(ID, true);
                listDetails.EndUpdate();
                /*
                listRecent = new Thread(() => threadshioneLoad(ID, true));
                listRecent.Start();
                listRecentIsRun = true;
                */
            }
        }

        private void cmsFilterFansub_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                createCache();
                this.Text = "Please wait...";
                this.Cursor = Cursors.WaitCursor;
                listDetails.Cursor = Cursors.WaitCursor;
                listDetails.Enabled = false;
                string ID = listDetails.Items[listDetails.FocusedItem.Index].SubItems[0].Text;
                string Fansub = listDetails.Items[listDetails.FocusedItem.Index].SubItems[1].Text;
                listDetails.Items.Clear();
                listDetails.Sorting = SortOrder.Ascending;
                listDetails.BeginUpdate();
                shioneLoad(ID + "{filter_fansub}" + Fansub, true);
                listDetails.EndUpdate();
                /*
                listRecent = new Thread(() => threadshioneLoad(ID + "{filter_fansub}" + Fansub, true));
                listRecent.Start();
                listRecentIsRun = true;
                */
            }
        }

        private void cmsMAL_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                if (listDetails.Items[listDetails.FocusedItem.Index].SubItems[4].Text.ToLower().Contains("myanimelist.net"))
                {
                    Process.Start(listDetails.Items[listDetails.FocusedItem.Index].SubItems[4].Text);
                }
            }
        }

        private void cmsFacebook_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                if (listDetails.Items[listDetails.FocusedItem.Index].SubItems[5].Text.ToLower().Contains("facebook.com"))
                {
                    Process.Start(listDetails.Items[listDetails.FocusedItem.Index].SubItems[5].Text);
                }
            }
        }

        private void tafasuTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listcount > 0)
            {
                Process.Start(DecodeEncodedNonAsciiCharacters(Regex.Match(downloadURL("https://www.tafasu.com/api/v1/anime?id=" + listDetails.Items[listDetails.FocusedItem.Index].SubItems[0].Text), "board:(.*?),").Groups[1].Value));
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                createCache();
                this.Text = "Please wait...";
                this.Cursor = Cursors.WaitCursor;
                listDetails.Cursor = Cursors.WaitCursor;
                toolBtnGO.Enabled = false;
                txtSearch.Enabled = false;
                listDetails.Enabled = false;
                listDetails.Items.Clear();
                listDetails.Sorting = SortOrder.None;
                listDetails.BeginUpdate();
                shioneLoad(txtSearch.Text);
                listDetails.EndUpdate();
                /*
                listRecent = new Thread(() => threadshioneLoad(txtSearch.Text));
                listRecent.Start();
                listRecentIsRun = true;

                */
            }
        }

        private void listDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)1)
            {
                foreach (ListViewItem anichecked in listDetails.Items)
                {
                    anichecked.Selected = true;
                }
            }
        }

        private void cmdGotoPage_Click(object sender, EventArgs e)
        {
            Process.Start("http://fb.com/konayukifs");
        }

        private void cmsClearCache_Click(object sender, EventArgs e)
        {
            clearCache(true);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wwwwwwwwwwwwww");
        }
    }
    public class ListViewItemComparer : IComparer
    {
        SortOrder _sortBy;
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column, SortOrder sortBy)
        {
            col = column;
            _sortBy = sortBy;
        }
        public int Compare(object x, object y)
        {
            if (_sortBy == SortOrder.Ascending)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            else
            {
                return -String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }
    }
}