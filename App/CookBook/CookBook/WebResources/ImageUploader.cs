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

namespace CookBook.WebResources
{
    /// <summary>
    /// Uses webClient to upload images to the server.
    /// NOTE: Not working because of incompatibility issues with the server.
    /// </summary>
    public class ImageUploader : FileUploader
    {
        private WebClient webClient;

        public void Dispose()
        {
            webClient.Dispose();
        }

        public void InitializeClient()
        {
            webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            // Credentials should normally be removed. The user is set up to have access only to this folder and can therefore be left in.
            webClient.Credentials = new NetworkCredential("cookbook@blancos.ch", "WokuDasEi");
            webClient.Headers.Add(HttpRequestHeader.ContentType, "image/png");
        }

        public void LogResult()
        {
            throw new NotImplementedException();
        }

        public void UploadFile(String file)
        {
            webClient.UploadFile(@"ftp://www.blancos.ch/cookbook", "STOR", file);
        }
    }
}