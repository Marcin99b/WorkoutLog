using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using WorkoutLog.WebApi.Controllers;

namespace WorkoutLog.Tests.WebApi;

[TestFixture]
public class WorkoutsControllerTests
{
    [Test]
    public async Task Get_ReturnWorkouts()
    {
        var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/Workouts");
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<WorkoutDto>>();

        result.Should().NotBeNullOrEmpty();
    }
}
