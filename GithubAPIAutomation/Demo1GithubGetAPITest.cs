using GithubAPIAutomation.Support;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace GithubAPIAutomation
{
    public class Demo1GithubGetAPITest
    {
        [Test]
        public void ListAuthRepoForUserTest()
        {

            string jsonStrBody = File.ReadAllText(@"TestData\secret.json");
            dynamic jsonBody = JsonConvert.DeserializeObject(jsonStrBody);
            string token = Convert.ToString(jsonBody.token);

            var client = new RestClient(baseUrl: "https://api.github.com");
            var request = new RestRequest("user/repos", Method.Get);
            request.AddHeader("Accept", "application/vnd.github+json");
            request.AddHeader("X-GitHub-Api-Version", "2026-03-10");
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            //convert fron stream json to object
            //create a model class - Repo (property like id, node_id, name, full_name, private)
            var repoResponse = JsonConvert.DeserializeObject<List<Repo>>(response.Content);
            Console.WriteLine(repoResponse[0].Id);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }




        /*
         * Make sure create a model class - Repo (property like id, node_id, name, full_name, private)
         * 
         *  Create Demo2APIChainTest.cs
            Create a repository for the authenticated user
            Update a repository
            List repositories for the authenticated user  --> verify the created repo name in the list
            Delete a repository - 200
            Delete a repository - 404
            List repositories for the authenticated user  --> verify the deleted repo name is not the list
            
         */

    }
}
