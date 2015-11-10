using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ConferenceRegistration.Models;
using SampleConferenceRegistration.Models;
using System.Collections;

namespace SampleConferenceRegistration.Controllers
{
    public class Conferences0Controller : ApiController
    {
        private ConferenceRegistrationContext db = new ConferenceRegistrationContext();

        // GET: api/Conferences
        //public IQueryable<Conference> GetConferences()
        public IEnumerable<Conference> GetConferences()
        {
            return new List<Conference>
            {
                new Conference {
                    ConferenceId = 1,
                    Name = "Chicago",
                    Location = "Chicago",
                    StartDate = Convert.ToDateTime("4/1/2016"),
                    EndDate = Convert.ToDateTime("4/5/2016"),
                    Description = "Conference in Chicago"
                },
                new Conference {
                    ConferenceId = 2,
                    Name = "Chicago",
                    Location = "Chicago",
                    StartDate = Convert.ToDateTime("4/1/2016"),
                    EndDate = Convert.ToDateTime("4/5/2016"),
                    Description = "Conference in Chicago"
                }

            };
            //return db.Conferences;
        }

        // GET: api/Conferences/5
        [ResponseType(typeof(Conference))]
        public async Task<IHttpActionResult> GetConference(long id)
        {
            Conference conference = await db.Conferences.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }

            return Ok(conference);
        }

        // PUT: api/Conferences/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConference(long id, Conference conference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conference.ConferenceId)
            {
                return BadRequest();
            }

            db.Entry(conference).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Conferences
        [ResponseType(typeof(Conference))]
        public async Task<IHttpActionResult> PostConference(Conference conference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conferences.Add(conference);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = conference.ConferenceId }, conference);
        }

        // DELETE: api/Conferences/5
        [ResponseType(typeof(Conference))]
        public async Task<IHttpActionResult> DeleteConference(long id)
        {
            Conference conference = await db.Conferences.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }

            db.Conferences.Remove(conference);
            await db.SaveChangesAsync();

            return Ok(conference);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConferenceExists(long id)
        {
            return db.Conferences.Count(e => e.ConferenceId == id) > 0;
        }
    }
}