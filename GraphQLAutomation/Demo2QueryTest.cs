using GraphQLAutomation.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLAutomation
{
    public class Demo2QueryTest
    {
        [Test]
        public async Task SimpleQueryTest()
        {
            //var option = new RestClientOptions("");
            //var client = new RestClient(option)
            var client = new RestClient(baseUrl: "https://hasura.io/learn/graphql");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", @"Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9FWTJSVGM1UlVOR05qSXhSRUV5TURJNFFUWXdNekZETWtReU1EQXdSVUV4UVVRM05EazFNQSJ9.eyJodHRwczovL2hhc3VyYS5pby9qd3QvY2xhaW1zIjp7IngtaGFzdXJhLWRlZmF1bHQtcm9sZSI6InVzZXIiLCJ4LWhhc3VyYS1hbGxvd2VkLXJvbGVzIjpbInVzZXIiXSwieC1oYXN1cmEtdXNlci1pZCI6ImF1dGgwfDZhMDVmNWY5MWM1MmFiMDVmZTRjNWI5ZCJ9LCJuaWNrbmFtZSI6ImRiYWxhLmNsb3VkIiwibmFtZSI6ImRiYWxhLmNsb3VkQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci8zMDJlODBkMjgxMzAxYmYxMjdhZWZjMDlhOWM2YjRiNj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRiLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDI2LTA1LTE0VDE2OjE5OjA2LjI2NFoiLCJpc3MiOiJodHRwczovL2dyYXBocWwtdHV0b3JpYWxzLmF1dGgwLmNvbS8iLCJhdWQiOiJQMzhxbkZvMWxGQVFKcnprdW4tLXdFenFsalZOR2NXVyIsInN1YiI6ImF1dGgwfDZhMDVmNWY5MWM1MmFiMDVmZTRjNWI5ZCIsImlhdCI6MTc3ODgyMDE5MiwiZXhwIjoxNzc4ODU2MTkyLCJzaWQiOiI1QzREcG43NTJQWTdtNWRCWnZiU25PTXVvX29NRklhdiIsImF0X2hhc2giOiIycnNybWJCOFpSSUlWNi1rLTdxRjdBIiwibm9uY2UiOiI0cmx0eDE2Znk4flFBa2U0VDBPN2VmenloOE50aENkdCJ9.puUMrBo1YMYo_T9GeqEgdoqlmanQagLXL6mHdn_VzFRpBBAXfFt9bgnjRWrrytA_uQF-L1e8VhL0nopdPHicEQZfkQ7vIE8J6mAO6_cCRFv3Di9GtI5a0W-uIflhTIBjZLK7YG5ioiMTqv32XMGcWS1JdsTAuvr2pa4ufZ8koZwb6ZMXTZdM_Myz85fML-DcTpTGMJ26TkMI9pRiRbsMXCoTbmXLaCwUf-A8R_W0RRHP5qdJ_MtpWCyC_rjFWUqctD0c0NimV9TsHQUnAfymUXXQmHkwMjo8ZNc0FXxV5TfBuTr5LwIbKuJcC0965HKNdDk6GKEZgiixTBDrGf-3rw");

            var body = new { 
                query= @"query {
                          users (limit:1) {
                            id
                            name
                          }
                        }" 
            };

            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);

            //deserialize to runtime object. No suggestion comes
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            Console.WriteLine(jsonResponse["data"]["users"][0]["id"]);
            Console.WriteLine(jsonResponse["data"]["users"][0]["name"]);

            //deserialize to C# model
            var rootObj = JsonConvert.DeserializeObject<Root>(response.Content);

            Console.WriteLine(rootObj.Data.Users.Count);
            Console.WriteLine(rootObj.Data.Users[0].Id);
            Console.WriteLine(rootObj.Data.Users[0].Name);
        }
    }
}
