using KPMG.APIAutomation.Support;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KPMG.APIAutomation
{
    public class Demo1GetTest
    {
        [Test]
        public void FindValidPetByIdTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Get);

            request.AddUrlSegment("petId", 105);

            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);

            //convert fron stream json to object
            dynamic petResponse = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(petResponse);
            Console.WriteLine(petResponse.id);
            Console.WriteLine(petResponse.category.id);

            Assert.That(Convert.ToInt32(petResponse.id), Is.EqualTo(105));
            //assert the name - doggie-105
            Assert.That(Convert.ToString(petResponse.name), Is.EqualTo("doggie-105"));

        }
        [Test]
        [TestCase("sold")]
        [TestCase("available")]
        public void FindPetByStatusTest(string status)
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/findByStatus", Method.Get);
            request.AddQueryParameter("status", status);

            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);

            dynamic petArrayResponse = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(petArrayResponse[0].status);

            //use foreach and assert each status to be sold
            foreach(var item in petArrayResponse)
            {
                Assert.That(Convert.ToString(item.status), Is.EqualTo(status));
            }
        }

        /// <summary>
        /// Deserialize to Pet Object 
        /// </summary>
        [Test]
        public void FindValidPetById2Test()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Get);

            request.AddUrlSegment("petId", 105);

            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);

            var petResponse = JsonConvert.DeserializeObject<Pet>(response.Content);
            Console.WriteLine(petResponse);

            Console.WriteLine(petResponse.Id);
            Console.WriteLine(petResponse.Category.Id);

        }
        /// <summary>
        /// Deserialize to List<Pet> Object 
        /// </summary>
        [TestCase("available")]
        public void FindPetByStatus2Test(string status)
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/findByStatus", Method.Get);
            request.AddQueryParameter("status", status);

            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);

            var petArrayResponse = JsonConvert.DeserializeObject<List<Pet>>(response.Content);
            Console.WriteLine(petArrayResponse[0].Status);

            //use foreach and assert each status to be sold
            foreach (var item in petArrayResponse)
            {
                Assert.That(Convert.ToString(item.Status), Is.EqualTo(status));
            }
        }
    }
}
