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
    public class PaisController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Pais
        public IQueryable<Pai> GetPais()
        {
            return db.Pais;
        }

        // GET: api/Pais/5
        [ResponseType(typeof(Pai))]
        public IHttpActionResult GetPai(string id)
        {
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return NotFound();
            }

            return Ok(pai);
        }

        // PUT: api/Pais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPai(string id, Pai pai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pai.Consecutivo)
            {
                return BadRequest();
            }

            db.Entry(pai).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiExists(id))
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

        // POST: api/Pais
        [ResponseType(typeof(Pai))]
        public IHttpActionResult PostPai(Pai pai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pais.Add(pai);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaiExists(pai.Consecutivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pai.Consecutivo }, pai);
        }

        // DELETE: api/Pais/5
        [ResponseType(typeof(Pai))]
        public IHttpActionResult DeletePai(string id)
        {
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return NotFound();
            }

            db.Pais.Remove(pai);
            db.SaveChanges();

            return Ok(pai);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaiExists(string id)
        {
            return db.Pais.Count(e => e.Consecutivo == id) > 0;
        }
    }
}