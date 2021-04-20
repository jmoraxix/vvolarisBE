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
    public class TipoPagoController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/TipoPago
        public IQueryable<TipoPago> GetTipoPagoes()
        {
            return db.TipoPagoes;
        }

        // GET: api/TipoPago/5
        [ResponseType(typeof(TipoPago))]
        public IHttpActionResult GetTipoPago(int id)
        {
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return Ok(tipoPago);
        }

        // PUT: api/TipoPago/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoPago(int id, TipoPago tipoPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoPago.Codigo)
            {
                return BadRequest();
            }

            db.Entry(tipoPago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPagoExists(id))
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

        // POST: api/TipoPago
        [ResponseType(typeof(TipoPago))]
        public IHttpActionResult PostTipoPago(TipoPago tipoPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoPagoes.Add(tipoPago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoPago.Codigo }, tipoPago);
        }

        // DELETE: api/TipoPago/5
        [ResponseType(typeof(TipoPago))]
        public IHttpActionResult DeleteTipoPago(int id)
        {
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            db.TipoPagoes.Remove(tipoPago);
            db.SaveChanges();

            return Ok(tipoPago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoPagoExists(int id)
        {
            return db.TipoPagoes.Count(e => e.Codigo == id) > 0;
        }
    }
}