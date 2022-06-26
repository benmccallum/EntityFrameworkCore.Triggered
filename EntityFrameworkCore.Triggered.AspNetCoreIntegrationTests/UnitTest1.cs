using Microsoft.AspNetCore.Mvc.Testing;
using StudentManager;

namespace EntityFrameworkCore.Triggered.AspNetCoreIntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            // Arrange
            var application = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => {
                    // ... Configure test services
                });

            var client = application.CreateClient();

            // Act
            for (var i = 0; i < 10; i++)
            {
                var isEven = i % 2 == 0;
                var apiSuffix = isEven ? "update" : "add";

                var resp = await client.PostAsync($"/api/course/{apiSuffix}", new StringContent("yo"));
            }

            // Assert
            // shouldn't have thrown
        }
    }
}