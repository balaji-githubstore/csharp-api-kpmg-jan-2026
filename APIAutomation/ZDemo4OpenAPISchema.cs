using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using NJsonSchema;

//NJsonSchema - install nuget package

namespace GithubAPIAutomation
{
    public class ZDemo4OpenAPISchema
    {
        [Test]
        public async Task GetPetValidation()
        {
            


            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Get);

            request.AddUrlSegment("petId", 105);

            var response = client.Execute(request);

            // 1. Load the JSON schema (as a string)
            string schemaJson = File.ReadAllText(@"testdata\petshop.json"); // or extract from OpenAPI

            // 2. Parse the schema
            var schema = await JsonSchema.FromJsonAsync(schemaJson);

            // 3. Parse the response body
            JToken responseBody = JToken.Parse(response.Content);

            // 4. Validate
            var errors = schema.Validate(responseBody);

            if (!errors.Any())
                Console.WriteLine("Valid!");
            else
                foreach (var error in errors)
                    Console.WriteLine(error.ToString());

        }

      
    }

}
