﻿using System;
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

namespace MangaScraper
{
    public partial class MangaScraper : Form
    {
        int downloadCount = 0;
        int completedCount = 0;
        bool stopRequest = false;
        bool folders = true;
        
        public MangaScraper()
        {
            InitializeComponent();
            radioOrganize1.Checked = true;
        }

        private void displayStatus(string status)
        {
            statusLabel.Text = status;
        }
        /*private string getChapter(string html)
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
        }*/
        private async void downloadJPG(string jpgURL, string series, string chapter, string page)
        {
            string direct = "";
            if (folders)
            {
                System.IO.Directory.CreateDirectory(series + "/" + chapter);
                direct = series + "/" + chapter + "/" + page + ".jpg";
            }
            else
            {
                System.IO.Directory.CreateDirectory(series);
                direct = series + "/" + downloadCount + ".jpg";
            }
            

            try
            {
                WebClient webClient = new WebClient();
                webClient.Proxy = null;
                //webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                // webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                await webClient.DownloadFileTaskAsync(new Uri(jpgURL), direct);
                completedCount++;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Write(e);
                downloadJPG(jpgURL, series, chapter, page);
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
           
            index = html.LastIndexOf("a href=\"");
            html = html.Substring(index + 8); // get rid of a href="
            index = html.IndexOf("\"");
            html = html.Substring(0, index);
            
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

           
            return html;
        }

        private void refreshCount(string series, string chapter, string page)
        {
            downloadCount++;
            seriesLabel.Text = "Series: " + series;
            chapterLabel.Text = "Chapter: " + chapter;
            pageLabel.Text = "Page: " + page;
            statusLabel.Text = Convert.ToString("Downloaded " + downloadCount + " pages so far" + " \ncompleted: " + completedCount);
            
            Application.DoEvents();
        }
        private void getJPGButton_Click(object sender, EventArgs e)
        {
            string url = urlBox.Text; // the fucking initial url
            downloadCount = 0;
            MangaHere mangaHere = new MangaHere();
            while (true) // loop until can't find anymore urls
            {
                
               // displayStatus("Downloaded: " + Convert.ToString(++downloadCount) + " pages so far");
                
                /*get HTML*/
                HttpWebRequest request;
                HttpWebResponse response;
                try
                { 
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Proxy = null;
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch(Exception err)
                {
                    System.Diagnostics.Debug.Write(err);
                    continue;
                }
                
                
                // checks if shit worked or not
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   
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
                   
                    response.Close();
                    readStream.Close();
                    string series = mangaHere.getSeriesName(html);
                    string chapter = mangaHere.getChapter(html);
                    string page = mangaHere.getPage(html);
                    
                    string extracted = extractJPGFromHTML(html);
                   
                    downloadJPG(extracted, series, chapter, page);
              
                    
                    url = getNextURL(html);
                    if (url == "null")
                    {
                        MessageBox.Show("Finished downloading " + series);
                        return;
                    }
                    if(stopRequest)
                    {
                        MessageBox.Show("Stopped downloading " + series + " after " + Convert.ToString(downloadCount) + " pages");
                        stopRequest = false;
                        return;
                    }

                    refreshCount(series,chapter,page);
                }

                else // gotta try different url
                {
                    
                }
            }


           
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopRequest = true;
            Application.DoEvents();
        }

        private void radioOrganize1_CheckedChanged(object sender, EventArgs e)
        {
            folders = true;
        }

        private void radioOrganize0_CheckedChanged(object sender, EventArgs e)
        {
            folders = false;
        }

     
        

        
    }
}