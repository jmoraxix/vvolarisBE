using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using vvolarisBE;

namespace vvolarisBE.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class RolUsuariosController : ApiController
    {
        private vvolarisbdEntities db = new vvolarisbdEntities();

        // GET: api/Rolusuarios

        public IQueryable<Usuario> GetUsuarios()
        {

            return db.Usuarios;
        }

        // POST: api/Rolusuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(string usuarioid, int rolid)
        {
            Usuario usuario = db.Usuarios.Where(Usuario => Usuario.UsuarioID.Equals(usuarioid)).FirstOrDefault();
            Rol rol = db.Rols.Where(Rol => Rol.Codigo.Equals(rolid)).FirstOrDefault();

            usuario.Rols.Add(rol);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuarioExists(usuario.UsuarioID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.UsuarioID }, rol);
        }

        // DELETE: api/Rolusuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(string usuarioid, int rolid)
        {
            Usuario usuario = db.Usuarios.Where(Usuario => Usuario.UsuarioID.Equals(usuarioid)).FirstOrDefault();
            Rol rol = db.Rols.Where(Rol => Rol.Codigo.Equals(rolid)).FirstOrDefault();
            if (usuario == null && rol == null)
            {
                return NotFound();
            }

            usuario.Rols.Remove(rol);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(string id)
        {
            return db.Usuarios.Count(e => e.UsuarioID == id) > 0;
        }
    }
}