using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaScraper
{
    public interface Manga
    {
        string extractJPGFromHTML(string html);
        string getNextURL(string html);
        string getSeriesName(string html);
        string getChapter(string html);
        string getPage(string html);
        string getNextChapter(string html);
    }
}
