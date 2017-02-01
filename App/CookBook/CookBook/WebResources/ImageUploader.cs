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