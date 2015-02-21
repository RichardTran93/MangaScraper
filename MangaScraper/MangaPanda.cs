using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/* Richard Tran
 * Manga Scraper
 * MangaPanda.cs
 * 02/2015
 * https://github.com/RichardTran93/MangaScraper
 */
namespace MangaScraper
{
    public class MangaPanda : Manga
    {
        public string extractJPGFromHTML(string html)
        {
            //...div id="imgholder">...src="[img url here]"
            int index = html.IndexOf("div id=\"imgholder");
            string jpgURL = html.Substring(index);
            //div id="imgholder">...src="[img url here]"
            index = jpgURL.IndexOf("src=");
            jpgURL = jpgURL.Substring(index);
            //src="[img url here]"
            index = jpgURL.IndexOf("\"");
            jpgURL = jpgURL.Substring(index + 1);
            //[img url here]"
            index = jpgURL.IndexOf("\"");
            jpgURL = jpgURL.Substring(0, index);
            //[img url here]
            return jpgURL;
        } 
        public string getNextURL(string html)
        {
            if(html.IndexOf("is not released yet") != -1)
            {
                return "null";
            }
            //...<span class="next"><a href="/i-dont-want-this-kind-of-hero/33/2">Next</a>
            int index = html.IndexOf("span class=\"next");
            string url = html.Substring(index);
            //<span class="next"><a href="/i-dont-want-this-kind-of-hero/33/2">Next</a>
            index = url.IndexOf("href=");
            url = url.Substring(index);
            //href="/i-dont-want-this-kind-of-hero/33/2">Next</a>
            index = url.IndexOf("Next");
            url = url.Substring(0, index);
            //href="/i-dont-want-this-kind-of-hero/33/2">
            index = url.IndexOf("\"");
            url = url.Substring(index);
            // /i-dont-want-this-kind-of-hero/33/2">
            index = url.IndexOf("\"");
            url = url.Substring(index + 1);
            // /i-dont-want-this-kind-of-hero/33/2
            index = url.IndexOf("\"");
            url = url.Substring(0, index);
            url = "http://www.mangapanda.com" + url;
            return url;
        }
        public string getSeriesName(string html)
        {
            //...  title="I Don't Want This Kind of Hero Manga">
            int index = html.IndexOf("title=\"");
            string series = html.Substring(index);
            //title=\"I Don't Want This Kind of Hero Manga">
            index = series.IndexOf("\"");
            series = series.Substring(index + 1);
            //I Don't Want This Kind of Hero Manga">
            index = series.IndexOf(" Manga");
            series = series.Substring(0, index);
            //"I Don't Want This Kind of Hero

            return series;
        }

        public string getChapter(string html)
        {
            //...document['chapterno'] = 175;
            int index = html.IndexOf("document['chapterno']");
            string chapter = html.Substring(index);
            //document['chapterno'] = 175;
            index = chapter.IndexOf("=");
            chapter = chapter.Substring(index + 2);
            //175;
            index = chapter.IndexOf(";");
            chapter = chapter.Substring(0, index);
            //175
            return chapter;
        }

        public string getPage(string html)
        {
            //...Read I Don't Want This Kind of Hero 37 Manga Scans Page 1.
            int index = html.IndexOf("Page");
            string page = html.Substring(index + 5);
            //Page 1.
            index = page.IndexOf(".");
            page = page.Substring(0, index);
            return page;
        }

        public string getNextChapter(string html)
        {

            return html;
        }
    }
}
