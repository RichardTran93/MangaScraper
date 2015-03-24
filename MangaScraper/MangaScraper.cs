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
/* Richard Tran
 * Manga Scraper
 * MangaScraper.cs
 * 02/2015
 * https://github.com/RichardTran93/MangaScraper
 */
namespace MangaScraper
{
    public partial class MangaScraper : Form
    {
        int downloadCount = 0;
        
        bool stopRequest = false;
        bool folders = true;
        bool tryAgain = false;
        WebPage client = new WebPage();
        Manga manga = new MangaPanda(); // default is MangaPanda
        List<string> mangaList = new List<string>();
        List<string> mangaLinks = new List<string>();
        public MangaScraper()
        {
            InitializeComponent();
            radioOrganize1.Checked = true;
            mangaPandaButton.Checked = true;
        }
        private void displayStatus(string status)
        {
            //statusLabel.Text = status;//set textbox to current status
        }
        
        private void populateMangaListBox()
        {
            mangaListButton.Text = "Getting List of Mangas!";
            mangaListButton.Enabled = false;
            
            if (mangaHereButton.Checked)
            {
                MangaHere manga = new MangaHere();
                manga.setMangaList(client.getHTML("http://www.mangahere.co/mangalist/"));
                mangaList = manga.getMangaNames();
                mangaLinks = manga.getMangaLinks();
            }
            else if (mangaPandaButton.Checked)
            {
                MangaPanda manga = new MangaPanda();
                manga.setMangaList(client.getHTML("http://www.mangapanda.com/alphabetical"));
                mangaList = manga.getMangaNames();
                mangaLinks = manga.getMangaLinks();
            }

            
            mangaListBox.DataSource = mangaList;
            mangaListButton.Enabled = true;
        }

        /*this method sets the display of the UI to the current series name/chapter/page number*/
        private void refreshCount(string series, string chapter, string page)
        {
            seriesLabel.Text = "Series: " + series;
            chapterLabel.Text = "Chapter: " + chapter;
            pageLabel.Text = "Page: " + page;
            //statusLabel.Text = "Downloading";
            completedLabel.Text = "Downloaded " + client.getCompletedCount() + " pages out of " + downloadCount + " pages so far";
            if(client.getDownloadSize() < 1024)//if less than 1MB
                downloadLabel.Text = "Downloaded " + client.getDownloadSize() + "KB total";
            else
                downloadLabel.Text = "Downloaded " + Math.Round(client.getDownloadSize()/1024,1) + "MB total";
            Application.DoEvents();
        }

        private string sanitize(string series)
        {
            string[] illegal = {"/","?","<",">","\\",":","*","|","\""};
            for(int i = 0; i < illegal.Length; i++)
                series = series.Replace(illegal[i]," ");
            return series;
        }
        private void download(string url)
        {
            string html = "";
            string series = "";
            string chapter = "";
            string page = "";
            string extracted = "";
            downloadCount = 0;
            client.reset();
            if(url == "blank")
                url = urlBox.Text;//gets the url from the box
            if (url == "")
            {
                MessageBox.Show("Please enter url into the box first!");
                return;
            }
            html = client.getHTML(url);
            switch (client.getDomain(url))
            {
                case "mangahere":
                    {
                        manga = new MangaHere();
                        break;
                    }
                case "mangapanda":
                    {
                        manga = new MangaPanda();
                        break;
                    }
            }
            

            //check if on main page or in some chapter
            if (manga.checkMainPage(html))
                url = manga.getFirstPage(html);
            while (true) // loop until can't find anymore urls
            {

                html = client.getHTML(url);//get raw html
                if (html == "fail")
                {
                    if(!tryAgain)//prevent one false, if fails again consecutively, fail
                    {
                        tryAgain = true;
                        continue;
                    }
                    MessageBox.Show(url + " is an invalid URL. Please enter another one");
                    return;
                }
                //pull series/chapter/page from html


                url = manga.getNextURL(html);
                if (url == "null")
                    break;
                series = manga.getSeriesName(html);
                series = sanitize(series);//get rid of illegal filename characters
                chapter = manga.getChapter(html);
                page = manga.getPage(html);
                extracted = manga.extractJPGFromHTML(html);



                //actually download the jpg
                client.downloadJPG(extracted, series, chapter, page, downloadCount, folders);
                downloadCount++;
                refreshCount(series, chapter, page);//sets UI to updated chapter/page number

                //prep for next url to get

                if (url == "null")
                    break;

                if (stopRequest)
                {
                    downloadCount = client.getCompletedCount();
                    Application.DoEvents();
                    MessageBox.Show("Stopped downloading " + series + " after " + Convert.ToString(downloadCount) + " pages");
                    stopRequest = false;
                    return;
                }
                tryAgain = true;
                while((downloadCount - client.getCompletedCount()) > 15)//anti-lag
                {
                    refreshCount(series, chapter, page);
                    Application.DoEvents();
                }
            }
            while (true)//this loop waits for all pages to complete before saying it's finished everything
            {
                refreshCount(series, chapter, page);
                if (client.getCompletedCount() == downloadCount)
                {
                    refreshCount(series, chapter, page);
                    MessageBox.Show("Finished downloading " + series);
                    Application.DoEvents();
                    return;
                }
            }
        }

        /*when get manga button is clicked, extract url from the textbox
         * then extract the html, then get the jpg link from the html and
         * download everything
         */
        private void getJPGButton_Click(object sender, EventArgs e)
        {
            download("blank");          
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

        private void githubLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/RichardTran93/MangaScraper");
        }

        private void mangaListButton_Click(object sender, EventArgs e)
        {
            //mangaListBox.Items.Clear();
            populateMangaListBox();
        }

        private void mangaListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int index = this.mangaListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                download(mangaLinks[index]);
            }
        }
      
    }
}
