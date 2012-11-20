using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vernacular;

namespace VernacularTest.Windows {
    class Program {
        static void Main (string [] args)
        {
            var manager = new ResourceManager("VernacularTest.Windows.Strings", Assembly.GetExecutingAssembly());

            Catalog.Implementation = new ResourceCatalog {
                GetResourceById = id => manager.GetString (id),
            };
            Catalog.ErrorHandler = (exc, text) => {
                Console.WriteLine ("Error: " + exc);
            };

            string english = Catalog.GetString ("Test");
            Console.WriteLine ("English: " + english);

            //Change to French
            Thread.CurrentThread.CurrentCulture = 
                Thread.CurrentThread.CurrentUICulture = new CultureInfo ("fr-FR");

            string french = Catalog.GetString ("Test");
            Console.WriteLine ("French: " + french);

            Console.WriteLine ("Press enter to quit...");
            Console.ReadLine ();
        }
    }
}
