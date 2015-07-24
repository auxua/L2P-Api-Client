using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace L2PAPITestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init the Auth Process
            string url = L2PAPIClient.AuthenticationManager.StartAuthenticationProcessAsync().Result;
            
            // Inform user and start browser
            Console.WriteLine("A Browser will open. Please authenticate this application.");
            Process.Start(url);

            // Wait for authentication
            // so far, not authenticated
            bool done = false;

            while (!done)
            {
                // Just wait 5 seconds - this is the recommended querying time for OAuth by ITC
                Thread.Sleep(5000);
                L2PAPIClient.AuthenticationManager.CheckAuthenticationProgressAsync();

                done = (L2PAPIClient.AuthenticationManager.getState() == L2PAPIClient.AuthenticationManager.AuthenticationState.ACTIVE);

                if (!done)
                {
                    Console.WriteLine("App not authenticated right now...");
                }
                else
                {
                    Console.WriteLine("App authenticated!");
                }
            }
            
            // Now, The application is authenticated - do some work with the API
            /*var answer = L2PAPIClient.api.Calls.L2PViewAllCourseInfoAsync().Result;

            L2PAPIClient.DataModel.L2PAddAnnouncementRequest req = new L2PAPIClient.DataModel.L2PAddAnnouncementRequest();
            req.body = "Testbody";
            req.title = "testtitle";

            var answer2 = L2PAPIClient.api.Calls.L2PAddAnnouncement("15ss-00002", req).Result;*/

            Console.ReadLine();
        }

    }
}
