using System.Linq.Expressions;
using System.Reflection.Metadata;
using backend.Data.Mappers;
using backend.Data.Models;
using backend.Services;

namespace backend.Endpoints;

enum ExperienceType
{
    work,
    education,
    coach,
    hobbyProject,
    voluntary
}

public static class ExperienceEndpoints
{
    public static void MapExperienceEndpoints(this WebApplication app)
    {
        // GET /experiences
        app.MapGet(
                "/experiences",
                async (ICvService cvService) =>
                {
                    // TODO: Oppgave 2
                    var experiences = await cvService.GetAllExperiencesAsync();
                    var experiencesDto = experiences.Select(e => e.ToDto()).ToList();

                    return Results.Ok(experiences);

                }
            )
            .WithName("GetAllExperiences")
            .WithTags("Experiences");

        // GET /experiences/{id}
        app.MapGet(
                "/experiences/{id:guid}",
                async (Guid id, ICvService cvService) =>
                {
                    // TODO: Oppgave 2
                    var experience = await cvService.GetExperienceByIdAsync(id);

                    if (experience == null)
                    {
                        return Results.NotFound("No experience with that ID was found.");
                    }

                    var experienceDto = experience.ToDto();
                    return Results.Ok(experienceDto);
                }
            )
            .WithName("GetExperienceById")
            .WithTags("Experiences");

        // GET /experiences/type/{type}
        app.MapGet(
                "/experiences/type/{type}",
                async (string type, ICvService cvService) =>
                {
                    // TODO: Oppgave 3
                    var experiences = await cvService.GetExperiencesByTypeAsync(type);

                    if (experiences == null || !experiences.Any())
                    {
                        return Results.NotFound("No experiences with the following type found.");
                    }
                    var experiencesDto = experiences.Select(e => e.ToDto()).ToList();

                    return Results.Ok(experiencesDto);
                }
            )
            .WithName("GetExperiencesByType")
            .WithTags("Experiences");
    }
}
