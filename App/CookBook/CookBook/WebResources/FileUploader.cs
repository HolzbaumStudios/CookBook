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

namespace CookBook.WebResources
{
    /// <summary>
    /// Interface for file uploading methods.
    /// </summary>
    interface FileUploader
    {
        void InitializeClient();
        void UploadFile(String file);
        void LogResult();
        void Dispose(); 
    }
}