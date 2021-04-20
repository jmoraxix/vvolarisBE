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
    public class ConsecutivosController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Consecutivos
        public IQueryable<Consecutivo> GetConsecutivoes()
        {
            return db.Consecutivoes;
        }

        // GET: api/Consecutivos/5
        [ResponseType(typeof(Consecutivo))]
        public IHttpActionResult GetConsecutivo(int id)
        {
            Consecutivo consecutivo = db.Consecutivoes.Find(id);
            if (consecutivo == null)
            {
                return NotFound();
            }

            return Ok(consecutivo);
        }

        // PUT: api/Consecutivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsecutivo(int id, Consecutivo consecutivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consecutivo.Codigo)
            {
                return BadRequest();
            }

            db.Entry(consecutivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsecutivoExists(id))
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

        // POST: api/Consecutivos
        [ResponseType(typeof(Consecutivo))]
        public IHttpActionResult PostConsecutivo(Consecutivo consecutivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consecutivoes.Add(consecutivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consecutivo.Codigo }, consecutivo);
        }

        // DELETE: api/Consecutivos/5
        [ResponseType(typeof(Consecutivo))]
        public IHttpActionResult DeleteConsecutivo(int id)
        {
            Consecutivo consecutivo = db.Consecutivoes.Find(id);
            if (consecutivo == null)
            {
                return NotFound();
            }

            db.Consecutivoes.Remove(consecutivo);
            db.SaveChanges();

            return Ok(consecutivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsecutivoExists(int id)
        {
            return db.Consecutivoes.Count(e => e.Codigo == id) > 0;
        }
    }
}