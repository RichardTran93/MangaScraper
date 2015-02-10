using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPGScraper
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private void displayStatus(string status)
        {
            statusLabel.Text = status;
        }
        private string getChapter(string html)
        {
            //MessageBox.Show("getting shit");
            //System.Diagnostics.Debug.Write(html);
            int index = html.IndexOf("var current_chapter");
            string chapter = html.Substring(index); // remove first "
            index = chapter.IndexOf("\"");
            chapter = chapter.Substring(index + 1); //remove first " c###"
            index = chapter.IndexOf("\"");
            chapter = chapter.Substring(0, index); // remove second " now all that is left is c###
            //System.Diagnostics.Debug.Write(chapter);
            return chapter;
        }
        private string getPage(string html)
        {
            int index = html.IndexOf("var current_page");
            string page = html.Substring(index);
            index = page.IndexOf(" ");//current_page = _20_;
            page = page.Substring(index + 1);
            index = page.IndexOf(" "); // pages are in format _##_ where _ is space
            page = page.Substring(index + 1);// =_20_
            index = page.IndexOf(" ");
            page = page.Substring(index + 1);//20_
            index = page.IndexOf(" ");
            page = page.Substring(0, index);//20
            
           // System.Diagnostics.Debug.Write(page+"\n");
            return page;
        }
        private string getSeriesName(string html)
        {
            int index = html.IndexOf("var series_name");
            string series = html.Substring(index);
            index = series.IndexOf("\"");
            series = series.Substring(index + 1);
            index = series.IndexOf("\"");
            series = series.Substring(0, index);
            return series;
        }
        private void downloadJPG(string jpgURL, string series, string chapter, string page)
        {
            //download jpgs using this
            System.Diagnostics.Debug.Write("Start Client: " + DateTime.Now.ToString() + "\n");
              using(WebClient Client = new WebClient())
              {
                  //System.Diagnostics.Debug.Write(page+"\n");
                  string direct = series + "/" + chapter + "/" + page + ".jpg";
                  displayStatus("Downloading: " + series + " chapter:" + chapter + " page:" + page);
                  System.Diagnostics.Debug.Write(direct + "\n");
                  //System.Diagnostics.Debug.Write(jpgURL + "\n");
                  System.Diagnostics.Debug.Write("Start downloadjpg: " + DateTime.Now.ToString() + "\n");
                System.IO.Directory.CreateDirectory(series);
                System.IO.Directory.CreateDirectory(series + "/" + chapter);
                
                Client.Proxy = null;
                try
                {
                    Client.DownloadFile(jpgURL, direct);
                    System.Diagnostics.Debug.Write("End Stream: " + DateTime.Now.ToString() + "\n");
                }
                  catch(Exception e)
                {
                    System.Diagnostics.Debug.Write(e);
                    downloadJPG(jpgURL, series, chapter, page);
                }
                }
        }

        private string extractJPGFromHTML(string html)
        {
           // string[] split = Regex.Split(html,"<img src=\"");//get the URL but contains ""
            int index = html.IndexOf("img src=\"");//get first instance of img src=" at where i is
            html = html.Substring(index + 9); // 9 is for each character of img src="
            index = html.IndexOf("\""); // remove second " at the end of jpg url
            html = html.Substring(0, index - 1); 
            return html;
        }
        
        private string getNextURL(string html)
        {
            string htmlBackup = html;
            int index = html.IndexOf("return next_page();"); // get next page url

            html = html.Substring(0,index); // 45 to get rid of the html, goes straight to the url
           // System.Diagnostics.Debug.Write(html);
            index = html.LastIndexOf("a href=\"");
            html = html.Substring(index + 8); // get rid of a href="
            index = html.IndexOf("\"");
            html = html.Substring(0, index);
            //System.Diagnostics.Debug.Write(html + "\n");
            if (html == "javascript:void(0);")//if end of chapter, get next chapter
                html = getNextChapter(htmlBackup);
            
            return html;
        }
        private string getNextChapter(string html)
        {
            int index = html.IndexOf("Next Chapter:");//get index of next chapter url
            if (index == -1)
            {
                return "null";
            }
               
            html = html.Substring(index);
            index = html.IndexOf("\"");//start html at first "
            html = html.Substring(index + 1);//get rid of the first "
            index = html.IndexOf("\"");// end html at next "
            html = html.Substring(0, index);

           // System.Diagnostics.Debug.Write("asdfasdf" + html);
            return html;
        }
        private void getJPGButton_Click(object sender, EventArgs e)
        {
            string url = urlBox.Text; // the fucking initial url
           // MessageBox.Show(url);
            while (true) // loop until can't find anymore urls
            {
                //System.Diagnostics.Debug.Write(url + "\n");
                /*get HTML*/
                System.Diagnostics.Debug.Write("Start HTTPWebRequest: " + DateTime.Now.ToString() + "\n");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                System.Diagnostics.Debug.Write("End HTTPWebRequest: " + DateTime.Now.ToString() + "\n");
                // checks if shit worked or not
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    System.Diagnostics.Debug.Write("Start Stream: " + DateTime.Now.ToString() + "\n");
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                   /* if (response.CharacterSet == null)
                    {
                        
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }*/
                    readStream = new StreamReader(receiveStream);
                    string html = readStream.ReadToEnd();
                    System.Diagnostics.Debug.Write("End Stream: " + DateTime.Now.ToString() + "\n");
                    response.Close();
                    readStream.Close();
                    string series = getSeriesName(html);
                    string chapter = getChapter(html);
                    string page = getPage(html);
                    
                    string extracted = extractJPGFromHTML(html);
                    //MessageBox.Show(extracted);
                    downloadJPG(extracted, series, chapter, page);
                    //MessageBox.Show("getting chapter");

                    url = getNextURL(html);
                    if (url == "null")
                    {
                        MessageBox.Show("Finished");
                        return;
                    }
                       

                }

                else // gotta try different url
                {
                    
                }
            }


           
        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
