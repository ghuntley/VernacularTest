using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using Vernacular;

namespace VernacularTest.Android {
    [Activity (Label = "VernacularTest.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button> (Resource.Id.MyButton);

            button.Click += delegate {
                var manager = new ResourceManager ("VernacularTest.Windows.Strings", Assembly.GetExecutingAssembly ());

                Catalog.Implementation = new AndroidCatalog (Resources, typeof (Resource.String));
                Catalog.ErrorHandler = (exc, text) => {
                    Console.WriteLine ("Error: " + exc);
                };

                string english = Catalog.GetString ("Test");
                Console.WriteLine ("English: " + english);

                //Change to french
                var locale = new Locale ("fr");
                Locale.Default = locale;
                Configuration config = new Configuration ();
                config.Locale = locale;
                ApplicationContext.Resources.UpdateConfiguration (config, null);

                string french = Catalog.GetString ("Test");
                Console.WriteLine ("French: " + french);
            };
        }
    }
}

