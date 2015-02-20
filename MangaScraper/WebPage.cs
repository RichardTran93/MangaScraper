using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

/// <summary>
/// Summary description for Class1
/// </summary>
public class WebPage
{
    public WebPage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string getHTML(string url)
    {
        HttpWebRequest request;
        HttpWebResponse response;
        string html = "";
        try
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (Exception err)
        {
            System.Diagnostics.Debug.Write(err);
            MessageBox.Show(Convert.ToString(err));
            return "fail";
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
            html = readStream.ReadToEnd();

            response.Close();
            readStream.Close();
        }
        return html;
    }

    public string extractJPGFromHTML(string html)
    {
        // string[] split = Regex.Split(html,"<img src=\"");//get the URL but contains ""
        int index = html.IndexOf("img src=\"");//get first instance of img src=" at where i is
        html = html.Substring(index + 9); // 9 is for each character of img src="
        index = html.IndexOf("\""); // remove second " at the end of jpg url
        html = html.Substring(0, index - 1);
        return html;
    }
    public string getNextURL(string html)
    {
        string htmlBackup = html;
        int index = html.IndexOf("return next_page();"); // get next page url

        html = html.Substring(0, index); // 45 to get rid of the html, goes straight to the url

        index = html.LastIndexOf("a href=\"");
        html = html.Substring(index + 8); // get rid of a href="
        index = html.IndexOf("\"");
        html = html.Substring(0, index);

        if (html == "javascript:void(0);")//if end of chapter, get next chapter
            html = getNextChapter(htmlBackup);

        return html;
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
