using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using SystemMonitoring.Model;

namespace SystemMonitoring.BusinessLogic
{

    
    class PostData
    {

        public static string SendFileToServer(string fileFullPath)
        {
            FileInfo fi = new FileInfo(@fileFullPath);
            string fileName = fi.Name;
            byte[] fileContents = File.ReadAllBytes(fi.FullName);
            Console.WriteLine(fi.Directory + "DIRECTORY");
            Uri webService = new Uri("http://localhost:6080/RestfulFileUploadExample/rest/files/upload");

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, webService);
            requestMessage.Headers.ExpectContinue = false;

            MultipartFormDataContent multiPartContent = new MultipartFormDataContent();
            ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
            byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");
            multiPartContent.Add(byteArrayContent, "file", fileName);
            requestMessage.Content = multiPartContent;

            HttpClient httpClient = new HttpClient();
            try
            {
                Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
                HttpResponseMessage httpResponse = httpRequest.Result;
                HttpStatusCode statusCode = httpResponse.StatusCode;
                HttpContent responseContent = httpResponse.Content;

                if (responseContent != null)
                {
                    Task<String> stringContentsTask = responseContent.ReadAsStringAsync();
                    String stringContents = stringContentsTask.Result;
                    Console.WriteLine(stringContents);
                    return stringContents;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


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
                case "image":
                    url = apiUrl.image;
                    break;
                case "screenshot":
                    url = apiUrl.screenshot;
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
