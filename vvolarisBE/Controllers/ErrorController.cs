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
    public class ErrorController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Error
        public IQueryable<Error> GetErrors()
        {
            return db.Errors;
        }

        // GET: api/Error/5
        [ResponseType(typeof(Error))]
        public IHttpActionResult GetError(int id)
        {
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return NotFound();
            }

            return Ok(error);
        }

        // PUT: api/Error/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutError(int id, Error error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != error.Codigo)
            {
                return BadRequest();
            }

            db.Entry(error).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(id))
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

        // POST: api/Error
        [ResponseType(typeof(Error))]
        public IHttpActionResult PostError(Error error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Errors.Add(error);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = error.Codigo }, error);
        }

        // DELETE: api/Error/5
        [ResponseType(typeof(Error))]
        public IHttpActionResult DeleteError(int id)
        {
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return NotFound();
            }

            db.Errors.Remove(error);
            db.SaveChanges();

            return Ok(error);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ErrorExists(int id)
        {
            return db.Errors.Count(e => e.Codigo == id) > 0;
        }
    }
}