using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MangaHere
{
	public MangaHere()
	{
		
	}

    public string getSeriesName(string html)
    {
        int index = html.IndexOf("var series_name");
        string series = html.Substring(index);
        index = series.IndexOf("\"");
        series = series.Substring(index + 1);
        index = series.IndexOf("\"");
        series = series.Substring(0, index);
        return series;
    }

    public string getChapter(string html)
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

    public string getPage(string html)
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

    public string getNextChapter(string html)
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

  
}
