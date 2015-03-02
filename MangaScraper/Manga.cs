using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaScraper
{
    public interface Manga
    {
        List<string> getMangaNames();
        List<string> getMangaLinks();
        bool checkMainPage(string html);
        string getFirstPage(string html);
        string extractJPGFromHTML(string html);
        string getNextURL(string html);
        string getSeriesName(string html);
        string getChapter(string html);
        string getPage(string html);
        string getNextChapter(string html);
        void setMangaList(string html);
    }
}
