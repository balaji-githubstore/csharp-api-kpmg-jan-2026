using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.APIAutomation
{
    public class Demo5Graphql
    {

        public async Task<string> GetHello()
        {
            for(int i = 0;i<=3;i++)
            {
                Console.WriteLine(i);
                await Task.Delay(1000);
            }
            
            return "Hello2";
        }
        [Test]
        public async Task Demo1AsycDemoRun()
        {
            var d= GetHello();
            Console.WriteLine("done with the some coding");
            Console.WriteLine("done with the some coding");
            await d;
        }

        [Test]
        public async Task Demo2QueryTest()
        {

            var client = new RestClient("https://hasura.io/learn/graphql");

            var request = new RestRequest("", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9FWTJSVGM1UlVOR05qSXhSRUV5TURJNFFUWXdNekZETWtReU1EQXdSVUV4UVVRM05EazFNQSJ9.eyJodHRwczovL2hhc3VyYS5pby9qd3QvY2xhaW1zIjp7IngtaGFzdXJhLWRlZmF1bHQtcm9sZSI6InVzZXIiLCJ4LWhhc3VyYS1hbGxvd2VkLXJvbGVzIjpbInVzZXIiXSwieC1oYXN1cmEtdXNlci1pZCI6ImF1dGgwfDZhMDVmNWY5MWM1MmFiMDVmZTRjNWI5ZCJ9LCJuaWNrbmFtZSI6ImRiYWxhLmNsb3VkIiwibmFtZSI6ImRiYWxhLmNsb3VkQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci8zMDJlODBkMjgxMzAxYmYxMjdhZWZjMDlhOWM2YjRiNj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRiLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDI2LTA1LTE0VDE2OjE5OjA2LjI2NFoiLCJpc3MiOiJodHRwczovL2dyYXBocWwtdHV0b3JpYWxzLmF1dGgwLmNvbS8iLCJhdWQiOiJQMzhxbkZvMWxGQVFKcnprdW4tLXdFenFsalZOR2NXVyIsInN1YiI6ImF1dGgwfDZhMDVmNWY5MWM1MmFiMDVmZTRjNWI5ZCIsImlhdCI6MTc3ODc3NTU0NywiZXhwIjoxNzc4ODExNTQ3LCJzaWQiOiI1QzREcG43NTJQWTdtNWRCWnZiU25PTXVvX29NRklhdiIsImF0X2hhc2giOiJYM1NaTTVyTVd2SEVsTGVQdFBESkV3Iiwibm9uY2UiOiJkNWFhZG5HYXJ3YkczZ1Y2UDVTd3ouZFV0M2JhdVg3VCJ9.EwEDqlLJtwfhnPjGuNj3f_nyINRkvrpadmN8tmc4xVy1QOv8Ah9nUBK0vRExc5BpfwAHl8lCZvZkvLAh_bKSswCm2QT5s__hwznzCe82uQ8X2ZO92d6Pim3hUlF7jWfWmkwl4RlqUUMHXRkQE3Ycg029tRWPhtzvLFDW_3JrCXamfuLIoPyXk9Tl5SHrDbasouoXzARd9ffppKovRjeQGZcxJu5QwYA2rozqwWv-8xhz7t21QO3F0RWV7cjxFG2HVb6VEc2W6upQpaAyYZ8f3t63GKrRt8-uFZHnnunEvdEOZkk0yurf7AmTaHt0xKpXEYPScpvp4PpWXDBc2SdM3A");

            var body = new
            {
                query = @"
                    query {
                        users (limit:2){
                            id
                            name
                            todos(limit:1){
                            id
                            }
                        }
                    }"
            };

            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }


        [Test]
        public async Task Demo3MutationTest()
        {

            var client = new RestClient("https://hasura.io/learn/graphql");

            var request = new RestRequest("", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9FWTJSVGM1UlVOR05qSXhSRUV5TURJNFFUWXdNekZETWtReU1EQXdSVUV4UVVRM05EazFNQSJ9.eyJodHRwczovL2hhc3VyYS5pby9qd3QvY2xhaW1zIjp7IngtaGFzdXJhLWRlZmF1bHQtcm9sZSI6InVzZXIiLCJ4LWhhc3VyYS1hbGxvd2VkLXJvbGVzIjpbInVzZXIiXSwieC1oYXN1cmEtdXNlci1pZCI6ImF1dGgwfDZhMDVmNWY5MWM1MmFiMDVmZTRjNWI5ZCJ9LCJuaWNrbmFtZSI6ImRiYWxhLmNsb3VkIiwibmFtZSI6ImRiYWxhLmNsb3VkQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci8zMDJlODBkMjgxMzAxYmYxMjdhZWZjMDlhOWM2YjRiNj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRiLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDI2LTA1LTE0VDE2OjE5OjA2LjI2NFoiLCJpc3MiOiJodHRwczovL2dyYXBocWwtdHV0b3JpYWxzLmF1dGgwLmNvbS8iLCJhdWQiOiJQMzhxbkZvMWxGQVFKcnprdW4tLXdFenFsalZOR2NXVyIsInN1YiI6ImF1dGgwfDZhMDVmNWY5MWM1MmFiMDVmZTRjNWI5ZCIsImlhdCI6MTc3ODc3NTU0NywiZXhwIjoxNzc4ODExNTQ3LCJzaWQiOiI1QzREcG43NTJQWTdtNWRCWnZiU25PTXVvX29NRklhdiIsImF0X2hhc2giOiJYM1NaTTVyTVd2SEVsTGVQdFBESkV3Iiwibm9uY2UiOiJkNWFhZG5HYXJ3YkczZ1Y2UDVTd3ouZFV0M2JhdVg3VCJ9.EwEDqlLJtwfhnPjGuNj3f_nyINRkvrpadmN8tmc4xVy1QOv8Ah9nUBK0vRExc5BpfwAHl8lCZvZkvLAh_bKSswCm2QT5s__hwznzCe82uQ8X2ZO92d6Pim3hUlF7jWfWmkwl4RlqUUMHXRkQE3Ycg029tRWPhtzvLFDW_3JrCXamfuLIoPyXk9Tl5SHrDbasouoXzARd9ffppKovRjeQGZcxJu5QwYA2rozqwWv-8xhz7t21QO3F0RWV7cjxFG2HVb6VEc2W6upQpaAyYZ8f3t63GKrRt8-uFZHnnunEvdEOZkk0yurf7AmTaHt0xKpXEYPScpvp4PpWXDBc2SdM3A");

            var body = new
            {
                query = @"
                   mutation {
                      insert_todos_one(object: {title: ""jack jack jack""}) {
                        id
                        title
                        is_completed
                        user_id
                      }
                    }
                    "
            };

            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);

            Console.WriteLine(response.Content);
        }
    }
}
