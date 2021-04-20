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
    public class AccionesController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Acciones
        public IQueryable<Accion> GetAccions()
        {
            return db.Accions;
        }

        // GET: api/Acciones/5
        [ResponseType(typeof(Accion))]
        public IHttpActionResult GetAccion(int id)
        {
            Accion accion = db.Accions.Find(id);
            if (accion == null)
            {
                return NotFound();
            }

            return Ok(accion);
        }

        // PUT: api/Acciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccion(int id, Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accion.Codigo)
            {
                return BadRequest();
            }

            db.Entry(accion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionExists(id))
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

        // POST: api/Acciones
        [ResponseType(typeof(Accion))]
        public IHttpActionResult PostAccion(Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accions.Add(accion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accion.Codigo }, accion);
        }

        // DELETE: api/Acciones/5
        [ResponseType(typeof(Accion))]
        public IHttpActionResult DeleteAccion(int id)
        {
            Accion accion = db.Accions.Find(id);
            if (accion == null)
            {
                return NotFound();
            }

            db.Accions.Remove(accion);
            db.SaveChanges();

            return Ok(accion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccionExists(int id)
        {
            return db.Accions.Count(e => e.Codigo == id) > 0;
        }
    }
}