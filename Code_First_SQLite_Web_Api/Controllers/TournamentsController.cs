using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Code_First_SQLite_Web_Api.Dal;
using Code_First_SQLite_Web_Api.Models;

namespace Code_First_SQLite_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly TutorielContext _context;

        public TournamentsController(TutorielContext context)
        {
            _context = context;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
            return await _context.Tournaments.ToListAsync();
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // PUT: api/Tournaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {
            if (id != tournament.TournamentID)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tournaments
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TournamentExists(tournament.TournamentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTournament", new { id = tournament.TournamentID }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tournament>> DeleteTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return tournament;
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.TournamentID == id);
        }
    }
}
