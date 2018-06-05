using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRonansSearchService
{
    class LoginAndDeserialize
    {
        static string LoginAndDeserializeJson()
        {

            using (var client = new WebClientEx())
            {
                var values = new NameValueCollection
            {
                { "j_username", "[Userame]" },
                { "j_password", "[Password]" },
            };
                Console.WriteLine("Validating username and password....\n");

                // Authenticate
                client.UploadValues("https://tie.interpreterintelligence.com/j_spring_security_check", values);
                Console.WriteLine("Successfully logged in to ii.....");
                Console.WriteLine();
                // Download desired page
                var json = client.DownloadString("https://tie.interpreterintelligence.com:443/api/contact");



                var deserializeWelcome = JsonConvert.DeserializeObject<Json.Status>(json);
                Console.WriteLine("Deserialized Json from Download string method : " + json);
                Console.WriteLine("Deserialized json from Deserialize Object methood : " + deserializeWelcome);


                return json;
            }
        }
    }
}
