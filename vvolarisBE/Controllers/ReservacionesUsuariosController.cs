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
    public class ReservacionesUsuariosController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/ReservacionesUsuarios/Admin
        [ResponseType(typeof(Reservacion))]
        public IHttpActionResult GetReservacion(string id)
        {
            List<Reservacion> reservacion = db.Reservacions.Where(Reservacion => Reservacion.UsuarioID.Equals(id)).ToList();
            if (reservacion == null)
            {
                return NotFound();
            }

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