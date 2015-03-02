using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
/* Richard Tran
 * Manga Scraper
 * WebPage.cs
 * 02/2015
 * https://github.com/RichardTran93/MangaScraper
 */
/// <summary>
/// Summary description for Class1
/// </summary>
public class WebPage
{
    double downloadSize = 0;
    int completedCount = 0;
    public WebPage()
    {
        
    }

    public double getDownloadSize()
    {
        return downloadSize;
    }
    public int getCompletedCount()
    {
        return completedCount;
    }
    public void reset()
    {
        downloadSize = 0;
        completedCount = 0;
    }
    public async void downloadJPG(string jpgURL, string series, string chapter, string page, int downloadCount, bool folders)
    {
        string direct = "";
        int size = 0;
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
                size = Convert.ToInt32(webClient.ResponseHeaders["Content-Length"]);
                downloadSize += size / 1024;
                //System.Diagnostics.Debug.Write(downloadSize + "\n");
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
    public string getDomain(string url)
    {
        //www.mangahere.co
        int index = url.IndexOf(".");
        url = url.Substring(index+1);
        //mangahere.co
        index = url.IndexOf(".");
        url = url.Substring(0, index);
        //mangahere
        return url;
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
            //MessageBox.Show(Convert.ToString(err));
            return "fail";
        }
        // checks if shit worked or not
        if (response.StatusCode == HttpStatusCode.OK)
        {

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            readStream = new StreamReader(receiveStream);
            html = readStream.ReadToEnd();

            response.Close();
            readStream.Close();
        }
        return html;
    }

}
