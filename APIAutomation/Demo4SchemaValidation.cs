using Newtonsoft.Json.Linq;
using NJsonSchema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.APIAutomation
{
    public class Demo4SchemaValidation
    {
        [Test]
        public async Task GetPetSchemaValidationTest()
        {
            var client = new RestClient(baseUrl: "https://petstore.swagger.io/v2");
            var request = new RestRequest("pet/{petId}", Method.Get);
            request.AddUrlSegment("petId", 707);

            var response = client.Execute(request);

            //parse the schema and validate response against the schema
            var schema= await JsonSchema.FromJsonAsync(File.ReadAllText(@"testdata\petschema.json"));
            var errors = schema.Validate(JToken.Parse(response.Content));

            Console.WriteLine(errors);

            if(errors.Any())
            {
                foreach(var error in errors)
                {
                    Console.WriteLine(error.ToString());
                }
                Assert.Fail("Validation Failed!!");
            }
            else
            {
                Console.WriteLine("valid!");
            }
        }
    }
}
