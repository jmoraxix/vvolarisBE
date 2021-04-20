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
    public class ReservacionesController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Reservaciones
        public IQueryable<Reservacion> GetReservacions()
        {
            return db.Reservacions;
        }

        // GET: api/Reservaciones/5
        [ResponseType(typeof(Reservacion))]
        public IHttpActionResult GetReservacion(string id)
        {
            Reservacion reservacion = db.Reservacions.Find(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return Ok(reservacion);
        }

        // PUT: api/Reservaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservacion(string id, Reservacion reservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservacion.Consecutivo)
            {
                return BadRequest();
            }

            db.Entry(reservacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionExists(id))
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

        // POST: api/Reservaciones
        [ResponseType(typeof(Reservacion))]
        public IHttpActionResult PostReservacion(Reservacion reservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservacions.Add(reservacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReservacionExists(reservacion.Consecutivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservacion.Consecutivo }, reservacion);
        }

        // DELETE: api/Reservaciones/5
        [ResponseType(typeof(Reservacion))]
        public IHttpActionResult DeleteReservacion(string id)
        {
            Reservacion reservacion = db.Reservacions.Find(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            db.Reservacions.Remove(reservacion);
            db.SaveChanges();

            return Ok(reservacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservacionExists(string id)
        {
            return db.Reservacions.Count(e => e.Consecutivo == id) > 0;
        }
    }
}