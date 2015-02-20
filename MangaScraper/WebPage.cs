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
}
