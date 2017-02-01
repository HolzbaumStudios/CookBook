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
using CookBook.Utils;

namespace CookBook.WebResources
{
    /// <summary>
    /// Uses FTP to upload files to a server. 
    /// </summary>
    public class FtpUploader : FileUploader
    {
        private static readonly String LOGGER_TAG = "CookBook.WebResources.FtpUploader";
        private static CookBookLogger logger = new CookBookLogger(LOGGER_TAG);
        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.blancos.ch/cookbook");
        FtpWebResponse response;

        //Dispose FTP connection
        public void Dispose()
        {
            response.Close();
        }

        public void InitializeClient()
        {
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // Credentials should normally be removed. The user is set up to have access only to this folder and can therefore be left in.
            request.Credentials = new NetworkCredential("cookbook@blancos.ch", "WokuDasEi");
            request.Headers.Add("Content-Type", "image/png");
            request.UseBinary = true;
        }

        public void LogResult()
        {
            response = (FtpWebResponse)request.GetResponse();

            logger.WriteLog(("Upload File Complete, status " + response.StatusDescription), LoggerType.Info);
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