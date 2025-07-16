using NUnit.Framework;
using RestSharp;

namespace CSharpSeleniumFramework.API
{
    public class QuickApiTest
    {
        [Test, Category("API")]
        public void VerifyApiStatus()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Get);
            var response = client.Execute(request);

            Assert.AreEqual(200, (int)response.StatusCode, "Status code is not 200");
            Assert.IsTrue(response.Content.Contains("\"userId\": 1"), "Response does not contain expected value.");
        }
    }
}