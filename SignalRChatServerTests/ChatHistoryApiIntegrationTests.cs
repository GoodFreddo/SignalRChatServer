using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SignalRChatServerTests
{
    [TestFixture]
    class ChatHistoryApiIntegrationTests
    {
        HttpClient _client;
        [SetUp]
        public void SetUp()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            var server = new HttpServer(config);
            _client = new HttpClient(server);

        }

        [Test]
        public async Task GetChatHistory_ReturnsSuccess()
        {
            //Arrange
            var url = "http://localhost/api/ChatHistory";
            //var method = HttpMethod.Get;
            //Act
            var response = await _client.GetAsync(url);
            //Assert
            Assert.NotNull(response.Content);
        }
    }
}