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
            //src="URL WE WANT HERE" alt="Bleach 616 .....
            Match match = Regex.Match(html, @"(?<=src="")(.*)(?="" alt)");//HAHAHHA REGEX FML
            string jpgURL = match.Groups[1].Value;
            return jpgURL;
        } 
        public string getNextURL(string html)
        {
            //if end of series/not released yet, signal End of series
            if (html.IndexOf("is not released yet") != -1)
            {
                return "null";
            }
            //...document['nl'] = '/bleach/616/2';
            int index = html.IndexOf("document['nl']");
            string url = html.Substring(index);
            //document['nl'] = '/bleach/616/2';
            index = url.IndexOf("'/");
            url = url.Substring(index + 1);
            // /bleach/616/2';
            index = url.IndexOf("'");
            url = url.Substring(0,index);
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
            //document['chapterno'] = 616;
            //why am i doing this to myself
            Match match = Regex.Match(html, @"(?<=document\[\'chapterno\'\] = )(.*)(?=;)");
            string chapter = match.Groups[1].Value;
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
            //mangapanda has no next chapter section, is linked in the next page
            return html;
        }
    }
}
