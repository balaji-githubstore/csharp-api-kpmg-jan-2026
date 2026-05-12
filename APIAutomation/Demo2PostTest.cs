using KPMG.APIAutomation.Support;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.APIAutomation
{
    public class Demo2PostTest
    {
        [Test]
        public void AddValidPetTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(@"{
                  ""id"": 706,
                  ""category"": {
                    ""id"": 0,
                    ""name"": ""string""
                  },
                  ""name"": ""doggie-706"",
                  ""photoUrls"": [
                    ""https://petstore.swagger.io/#/pet/addPet""
                  ],
                  ""tags"": [
                    {
                      ""id"": 0,
                      ""name"": ""string""
                    }
                  ],
                  ""status"": ""available""
                }");

            
            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);

            var petResponse = JsonConvert.DeserializeObject<Pet>(response.Content);
            Console.WriteLine(petResponse);

            Console.WriteLine(petResponse.Id);
            Console.WriteLine(petResponse.Name);

        }
    }
}
