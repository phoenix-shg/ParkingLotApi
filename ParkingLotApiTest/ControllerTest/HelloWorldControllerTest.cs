using System.Threading.Tasks;
using ParkingLotApi;
using Xunit;

namespace ParkingLotApiTest.ControllerTest
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using Newtonsoft.Json;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
    using System.Net.Http;
    using System.Net;
    using System.Text;
    using ParkingLotApi.Models;
    using Microsoft.AspNetCore.Components.Routing;

    public class HelloWorldControllerTest
    {
        public HelloWorldControllerTest()
        {
        }

        [Fact]
        public async Task Should_get_hello_world()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var allCompaniesResponse = await client.GetAsync("/Hello");
            var responseBody = await allCompaniesResponse.Content.ReadAsStringAsync();

            Assert.Equal("Hello World", responseBody);
        }

        [Fact]
        public async void Should_add_new_parkinglot_successfully()
        {
            //given
            var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateClient();
            var parkinglot = new ParkingLot(name: "SLB",capacity:15,location:"ChuangXinDaSha");
            var parkinglotJson = JsonConvert.SerializeObject(parkinglot);
            var postBody = new StringContent(parkinglotJson, Encoding.UTF8, "application/json");

            //when
            var response = await httpClient.PostAsync("/ParkingLot", postBody);
            //then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            var createdParkingLot = JsonConvert.DeserializeObject<ParkingLot>(responseBody);
            Assert.Equal("SLB", createdParkingLot.Name);
        }
    }
}