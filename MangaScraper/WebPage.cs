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
