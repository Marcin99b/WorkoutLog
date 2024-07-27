using Microsoft.AspNetCore.Mvc;

namespace WorkoutLog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly ExerciseDto[] exercises = [
        new(Guid.NewGuid(), "Pull ups", true),
        new(Guid.NewGuid(), "Push ups", true),
    ];


    [HttpGet]
    public Task<IEnumerable<WorkoutDto>> Get()
    {
        var workouts = new WorkoutDto[] {
            new(Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now), [
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            ]),

            new(Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), [
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            ]),

            new(Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), [
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            new(Guid.NewGuid(), this.exercises[0], 5, 0),
            ])
        };
        return Task.FromResult(workouts.AsEnumerable());
    }
}

public record WorkoutDto(Guid Id, DateOnly Date, WorkoutItemDto[] Items);
public record WorkoutItemDto(Guid Id, ExerciseDto Exercise, int Repetitions, int AdditionalWeight);
public record ExerciseDto(Guid Id, string Name, bool IsBodyweight);
public record BodyweightDto(Guid Id, DateOnly Date, float Kilograms);