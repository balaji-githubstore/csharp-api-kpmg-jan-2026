using KPMG.APIAutomation.Support;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KPMG.APIAutomation
{
    public class Demo3APIChainingTest
    {
        [Test,Order(1)]
        public void AddValidPetFromJsonTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            //read file
            string jsonStrBody = File.ReadAllText(@"TestData\newpet.json");
            request.AddStringBody(jsonStrBody, DataFormat.Json);

            var response = client.Execute(request);
            var petResponse = JsonConvert.DeserializeObject<Pet>(response.Content);

            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
            Assert.That(petResponse.Id, Is.EqualTo(805));
            Assert.That(petResponse.Name, Is.EqualTo("doggie-805"));
        }

        [Test, Order(2)]
        public void UpdateValidPetFromJsonTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet", Method.Put);

            request.AddHeader("Content-Type", "application/json");

            //read file
            string jsonStrBody = File.ReadAllText(@"TestData\updatepet.json");
            request.AddStringBody(jsonStrBody, DataFormat.Json);

            var response = client.Execute(request);
            var petResponse = JsonConvert.DeserializeObject<Pet>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(petResponse.Id, Is.EqualTo(805));
            Assert.That(petResponse.Name, Is.EqualTo("pet-805"));
        }

        [Test,Order(3)]
        public void FindValidPetByIdTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Get);

            request.AddUrlSegment("petId", 805);

            var response = client.Execute(request);
            var petResponse = JsonConvert.DeserializeObject<Pet>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(petResponse.Id, Is.EqualTo(805));
        }

        [Test, Order(4)]
        public void DeleteValidPetByIdTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Delete);
            request.AddHeader("api_key", "special-key");

            request.AddUrlSegment("petId", 805);

            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test, Order(5)]
        public void DeleteInvalidPetByIdTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Delete);
            request.AddHeader("api_key", "special-key");

            request.AddUrlSegment("petId", 805);

            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test, Order(6)]
        public void FindInalidPetByIdTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Get);

            request.AddUrlSegment("petId", 805);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
