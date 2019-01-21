using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using SystemMonitoring.Model;

namespace SystemMonitoring.BusinessLogic
{

    
    class PostData
    {
        public static HttpResponseMessage SendToServer(object obj,string function)
        {

            var json = new JavaScriptSerializer().Serialize(obj);

            Console.WriteLine("Inside POST DATA " + json);
            string url = "";
            ApiUrl apiUrl = new ApiUrl();
            switch(function)
            {
                case "login":
                    url = apiUrl.login;
                    break;
                case "register":
                    url = apiUrl.register;
                    break;
                case "history":
                    url = apiUrl.history;
                    break;
            }
            //switch(function)
            //{
            //    case "checkprn":
            //        url = apiUrl.checkPrn;
            //        break;



            //}
            using (var client = new HttpClient())
            {
                Console.WriteLine("Inside Function");
                var res = client.PostAsync(url,
                  new StringContent(json,
                    Encoding.UTF8, "application/json")
                );

                //var res = client.PostAsync("http://localhost:6080/Jersey-UP-DOWN-Image-File/rest/fileservice/upload/image",
                //  new StringContent(json,
                //    Encoding.UTF8, "application/json")
                //);


                try
                {
                    Console.WriteLine("Inside Try");
                    HttpResponseMessage msg = res.Result.EnsureSuccessStatusCode();
                    
                    Console.WriteLine(".....message..... " + msg);
                    return msg;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Inside Catch");
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
            
        }
    }
}
