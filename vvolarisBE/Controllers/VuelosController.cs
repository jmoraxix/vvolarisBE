using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using vvolarisBE;

namespace vvolarisBE.Controllers
{
    public class VuelosController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Vuelos
        public IQueryable<Vuelo> GetVueloes()
        {
            return db.Vueloes;
        }

        // GET: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult GetVuelo(string id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            return Ok(vuelo);
        }

        // PUT: api/Vuelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVuelo(string id, Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vuelo.Consecutivo)
            {
                return BadRequest();
            }

            db.Entry(vuelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(id))
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

        // POST: api/Vuelos
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult PostVuelo(Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vueloes.Add(vuelo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VueloExists(vuelo.Consecutivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vuelo.Consecutivo }, vuelo);
        }

        // DELETE: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult DeleteVuelo(string id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            db.Vueloes.Remove(vuelo);
            db.SaveChanges();

            return Ok(vuelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VueloExists(string id)
        {
            return db.Vueloes.Count(e => e.Consecutivo == id) > 0;
        }
    }
}