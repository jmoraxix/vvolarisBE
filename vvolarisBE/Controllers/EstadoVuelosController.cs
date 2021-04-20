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
    public class EstadoVuelosController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/EstadoVuelos
        public IQueryable<EstadoVuelo> GetEstadoVueloes()
        {
            return db.EstadoVueloes;
        }

        // GET: api/EstadoVuelos/5
        [ResponseType(typeof(EstadoVuelo))]
        public IHttpActionResult GetEstadoVuelo(int id)
        {
            EstadoVuelo estadoVuelo = db.EstadoVueloes.Find(id);
            if (estadoVuelo == null)
            {
                return NotFound();
            }

            return Ok(estadoVuelo);
        }

        // PUT: api/EstadoVuelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadoVuelo(int id, EstadoVuelo estadoVuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoVuelo.Codigo)
            {
                return BadRequest();
            }

            db.Entry(estadoVuelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoVueloExists(id))
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

        // POST: api/EstadoVuelos
        [ResponseType(typeof(EstadoVuelo))]
        public IHttpActionResult PostEstadoVuelo(EstadoVuelo estadoVuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadoVueloes.Add(estadoVuelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadoVuelo.Codigo }, estadoVuelo);
        }

        // DELETE: api/EstadoVuelos/5
        [ResponseType(typeof(EstadoVuelo))]
        public IHttpActionResult DeleteEstadoVuelo(int id)
        {
            EstadoVuelo estadoVuelo = db.EstadoVueloes.Find(id);
            if (estadoVuelo == null)
            {
                return NotFound();
            }

            db.EstadoVueloes.Remove(estadoVuelo);
            db.SaveChanges();

            return Ok(estadoVuelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoVueloExists(int id)
        {
            return db.EstadoVueloes.Count(e => e.Codigo == id) > 0;
        }
    }
}