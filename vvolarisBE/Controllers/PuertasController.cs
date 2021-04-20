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
    [System.Web.Http.Cors.EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class PuertasController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Puertas
        public IQueryable<Puerta> GetPuertas()
        {
            return db.Puertas;
        }

        // GET: api/Puertas/5
        [ResponseType(typeof(Puerta))]
        public IHttpActionResult GetPuerta(string id)
        {
            Puerta puerta = db.Puertas.Find(id);
            if (puerta == null)
            {
                return NotFound();
            }

            return Ok(puerta);
        }

        // PUT: api/Puertas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPuerta(string id, Puerta puerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puerta.Consecutivo)
            {
                return BadRequest();
            }

            db.Entry(puerta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuertaExists(id))
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

        // POST: api/Puertas
        [ResponseType(typeof(Puerta))]
        public IHttpActionResult PostPuerta(Puerta puerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Puertas.Add(puerta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PuertaExists(puerta.Consecutivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = puerta.Consecutivo }, puerta);
        }

        // DELETE: api/Puertas/5
        [ResponseType(typeof(Puerta))]
        public IHttpActionResult DeletePuerta(string id)
        {
            Puerta puerta = db.Puertas.Find(id);
            if (puerta == null)
            {
                return NotFound();
            }

            db.Puertas.Remove(puerta);
            db.SaveChanges();

            return Ok(puerta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PuertaExists(string id)
        {
            return db.Puertas.Count(e => e.Consecutivo == id) > 0;
        }
    }
}