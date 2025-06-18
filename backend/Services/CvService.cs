using backend.Data;
using backend.Data.Mappers;
using backend.Data.Models;
using backend.Data.Requests;
using backend.Endpoints;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class CvService(AppDbContext context) : ICvService
{
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users.OrderBy(u => u.Name).ToListAsync();
    }

    // TODO: Oppgave 1
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        // TODO: Oppgave 2
        return await context.Experiences.OrderBy(e => e.EndDate).ToListAsync();
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        // TODO: Oppgave 2
    return await context.Experiences.FindAsync(id);
    }

    public async Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type)
    {
        // TODO: Oppgave 3
        return await context.Experiences.Where(e => e.Type == type).ToListAsync();
    }

    // TODO: Oppgave 4 ny metode (husk å legge den til i interfacet)
    public async Task<IEnumerable<User>> GetUsersWithDesiredSkills(IEnumerable<string> skills)
    {
        // var users = await context.Users.Where(e => e.Skills.Split(";").Intersect(skills).Any()).ToListAsync()
        var users = await context.Users.ToListAsync();
        return users.Where(e => e.Skills.Split(";").Intersect(skills).Any());

    }
}
