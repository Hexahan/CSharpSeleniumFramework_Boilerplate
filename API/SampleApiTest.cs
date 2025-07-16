using NUnit.Framework;
using RestSharp;

namespace CSharpSeleniumFramework.API
{
    public class SampleApiTest
    {
        [Test, Category("API")]
        public void VerifyApiStatus()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Get);
            var response = client.Execute(request);

            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.IsTrue(response.Content.Contains("userId"));
        }
    }
}
