using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAMSERVICE.Core.Entities;
using TEAMSERVICE.Infrastructure.Context;

namespace TEAMSERVICE.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly TEAMDbContext _context;

        public TeamController(TEAMDbContext context)
        {
            _context = context;
        }

        // GET: api/team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: api/team/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
                return NotFound();

            return team;
        }

        [Authorize(Roles = "Admin")]
        [Route("CreateTeam")]
        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam([FromBody] Team team)
        {
            team.Id = Guid.NewGuid();
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        // PUT: api/team/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(Guid id, [FromBody] Team updatedTeam)
        {
            if (id != updatedTeam.Id)
                return BadRequest();

            var existingTeam = await _context.Teams.FindAsync(id);
            if (existingTeam == null)
                return NotFound();

            existingTeam.Name = updatedTeam.Name;
            existingTeam.Description = updatedTeam.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/team/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
                return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
