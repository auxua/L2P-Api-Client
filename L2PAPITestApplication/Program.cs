using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
            string url = L2PAPIClientPortable.AuthenticationManager.StartAuthenticationProcessAsync().Result;
            
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
                L2PAPIClientPortable.AuthenticationManager.CheckAuthenticationProgressAsync();

                done = (L2PAPIClientPortable.AuthenticationManager.getState() == L2PAPIClientPortable.AuthenticationManager.AuthenticationState.ACTIVE);

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

            
            Console.WriteLine("Press Enter to start Test");
            Stopwatch watch = new Stopwatch();
            Console.ReadLine();

            // Test started
            watch.Start();

            // get List of Course Rooms
            var courses = L2PAPIClientPortable.api.Calls.L2PviewAllCourseInfoByCurrentSemester().Result;
            IEnumerable<string> cids = courses.dataset.Select((x) => x.uniqueid);

            Console.WriteLine("Got Courses");

            ConcurrentBag<L2PAPIClientPortable.DataModel.L2PWhatsNewDataType> newStuff = new ConcurrentBag<L2PAPIClientPortable.DataModel.L2PWhatsNewDataType>();

            //List<L2PAPIClient.DataModel.L2PWhatsNewDataType> newStuff = new List<L2PAPIClient.DataModel.L2PWhatsNewDataType>();

            //Parallel.ForEach(string cid in cids)
            //foreach (string cid in cids)
            Parallel.ForEach(cids, (cid) =>
            {
                try
                {
                    var result = L2PAPIClientPortable.api.Calls.L2PwhatsNewAsync(cid).Result;
                    Console.WriteLine("Got Data for " + cid);
                    if (result.status)
                        newStuff.Add(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message + " -- " + ex.StackTrace);
                }
            });
            


            watch.Stop();

            Console.WriteLine("Test completed ("+newStuff.Count+" items) with Time: " + (watch.ElapsedMilliseconds/1000.0));

            //var pdf = L2PAPIClient.api.Calls.L2PdownloadFile("15ws-45645", "|/ws15/15ws-45645/Lists/StructuredMaterials/MidtermSolutions.pdf", "test.pdf").Result;


			/*
            System.IO.Stream ms = L2PAPIClient.api.Calls.L2PdownloadFile("15ws-45645", "|/ws15/15ws-45645/Lists/StructuredMaterials/MidtermSolutions.pdf", "test.pdf").Result;

            var fstream = System.IO.File.Create("D:\\test.pdf");
            ms.CopyTo(fstream);
            fstream.Close();*/

            //string s = System.Text.Encoding.Unicode.GetString(t);
            //var answerCall = await GetAsync(endpoint);

            Console.ReadLine();
        }

    }
}
