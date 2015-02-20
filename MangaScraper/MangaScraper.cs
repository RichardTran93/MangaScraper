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
            statusLabel.Text = status;//set textbox to current status
        }
        
        private async void downloadJPG(string jpgURL, string series, string chapter, string page)
        {
            string direct = "";
            if (folders)
            {
                System.IO.Directory.CreateDirectory(series + "/" + chapter);//creates directory if not exists
                direct = series + "/" + chapter + "/" + page + ".jpg";//sets in series/chapter/page.jpg format
            }
            else
            {
                System.IO.Directory.CreateDirectory(series);
                direct = series + "/" + downloadCount + ".jpg";//else just series/page.jpg
            }

            /*download the file, but since it's async, open tons of threads and start downloads 
             * for multiple jpgs at once. Completed count only increments when the file 
             * completely finishes downloading
             */
            while (true)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Proxy = null;//stupid thing takes eons to try to get IE (yes IE) proxy settings before downloading
                    await webClient.DownloadFileTaskAsync(new Uri(jpgURL), direct);//waits for it to finish before incrementing completedCount
                    completedCount++;
                    break;
                }
                catch (Exception e)//if download fails, try again
                {
                    System.Diagnostics.Debug.Write(e);
                    continue;
                }
            }
        } 

        /*this method sets the display of the UI to the current series name/chapter/page number*/
        private void refreshCount(string series, string chapter, string page)
        {
            downloadCount++;
            seriesLabel.Text = "Series: " + series;
            chapterLabel.Text = "Chapter: " + chapter;
            pageLabel.Text = "Page: " + page;
            statusLabel.Text = Convert.ToString("Downloaded " + downloadCount + " pages so far" + " \ncompleted: " + completedCount);
            
            Application.DoEvents();
        }

        /*when get manga button is clicked, extract url from the textbox
         * then extract the html, then get the jpg link from the html and
         * download everything
         */
        private void getJPGButton_Click(object sender, EventArgs e)
        {
            string url = urlBox.Text;//gets the url from the box
            MangaHere mangaHere = new MangaHere();
            WebPage client = new WebPage();
            string html = "";
            string series, chapter, page, extracted = "";
            while (true) // loop until can't find anymore urls
            {
                
                    html = client.getHTML(url);//get raw html
                    
                    //pull series/chapter/page from html
                    series = mangaHere.getSeriesName(html);
                    chapter = mangaHere.getChapter(html);
                    page = mangaHere.getPage(html);     
               
                    
                    extracted = client.extractJPGFromHTML(html);//gets the jpg url 

                    //actually download the jpg
                    downloadJPG(extracted, series, chapter, page);

                    //prep for next url to get
                    url = client.getNextURL(html);
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
                    refreshCount(series,chapter,page);//sets UI to updated chapter/page number
            }
 
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopRequest = true;
            Application.DoEvents();//magical method that stops everything
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
