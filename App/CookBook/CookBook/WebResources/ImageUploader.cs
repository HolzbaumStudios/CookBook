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
    class ImageUploader : FileUploader
    {
        private WebClient webClient;

        public void Dispose()
        {
            webClient.Dispose();
        }

        public void InitializeClient()
        {
            webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials; //TODO implement credentials
        }

        public void LogResult()
        {
            throw new NotImplementedException();
        }

        public void UploadFile(String file)
        {
            webClient.UploadFile(@"http://www.blancos.ch/home/nicoleu1/cookbook/images", "PUT", file);
        }
    }
}