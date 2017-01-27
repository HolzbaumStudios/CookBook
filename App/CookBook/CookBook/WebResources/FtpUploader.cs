using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;

namespace CookBook.WebResources
{
    public class FtpUploader : FileUploader
    {
        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.blancos.ch/cookbook");
        FtpWebResponse response;



        public void Dispose()
        {
            response.Close();
        }

        public void InitializeClient()
        {
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("cookbook@blancos.ch", "WokuDasEi");
            request.Headers.Add("Content-Type", "image/png");
            request.UseBinary = true;
        }

        public void LogResult()
        {
            response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
        }

        public void UploadFile(string file)
        {
            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(file);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            

            
        }
    }
}