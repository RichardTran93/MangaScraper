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
        WebPage client = new WebPage();
        Manga manga = new MangaHere(); // default is MangaHere
        public MangaScraper()
        {
            InitializeComponent();
            radioOrganize1.Checked = true;

        }
        private void displayStatus(string status)
        {
            //statusLabel.Text = status;//set textbox to current status
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

        /*when get manga button is clicked, extract url from the textbox
         * then extract the html, then get the jpg link from the html and
         * download everything
         */
        private void getJPGButton_Click(object sender, EventArgs e)
        {
            
            string html = "";
            string series = "";
            string chapter = "";
            string page = "";
            string extracted = "";
            downloadCount = 0;
            client.reset();
            string url = urlBox.Text;//gets the url from the box
            html = client.getHTML(url);
            switch(client.getDomain(url))
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
            if(url == "")
            {
                MessageBox.Show("Please enter url into the box first!");
                return;
            }
            
            //check if on main page or in some chapter
            if (manga.checkMainPage(html))
                url = manga.getFirstPage(html);
            while (true) // loop until can't find anymore urls
            {
                
                    html = client.getHTML(url);//get raw html
                    if(html == "fail")
                    {
                        MessageBox.Show(url + " is an invalid URL. Please enter another one");
                        return;
                    }
                    //pull series/chapter/page from html
                    
                                
                url = manga.getNextURL(html);
                if (url == "null")
                    break;                               
                series = manga.getSeriesName(html);                                
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

                    if(stopRequest)
                    {
                        MessageBox.Show("Stopped downloading " + series + " after " + Convert.ToString(downloadCount) + " pages");
                        stopRequest = false;
                        return;
                    }
                   
            }
            while(true)//this loop waits for all pages to complete before saying it's finished everything
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
  
    }
}
