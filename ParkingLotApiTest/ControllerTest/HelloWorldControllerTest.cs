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

        [Fact]
        public async void Should_delete_sold_parkinglot_successfully()
        {
            //given
            var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateClient();
            var parkinglot = new ParkingLot(name: "SLB", capacity: 15, location: "ChuangXinDaSha");
            var parkinglotJson = JsonConvert.SerializeObject(parkinglot);
            var postBody = new StringContent(parkinglotJson, Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/ParkingLot", postBody);
            var parkinglot2 = new ParkingLot(name: "thoughtworks", capacity: 13, location: "ChuangXinDaSha2");
            var parkinglotJson2 = JsonConvert.SerializeObject(parkinglot2);
            var postBody2 = new StringContent(parkinglotJson2, Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/ParkingLot", postBody2);

            //when
            var response = await httpClient.DeleteAsync("/ParkingLot?name=SLB");
            //then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            var createdParkingLot = JsonConvert.DeserializeObject<ParkingLot>(responseBody);
            Assert.Equal("thoughtworks", createdParkingLot.Name);
        }
    }
}