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
            var resp = await client.PostAsync("/api/course", new StringContent("yo"));

            // Assert
            // shouldn't have thrown
        }
    }
}