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
using Back_End;

namespace Back_End.Controllers
{
    public class CartTablesController : ApiController
    {
        private grocerydbEntities db = new grocerydbEntities();

        // GET: api/CartTables
        public IQueryable<CartTable> GetCartTables()
        {
            return db.CartTables;
        }

        // GET: api/CartTables/5
        [ResponseType(typeof(CartTable))]
        public IHttpActionResult GetCartTable(decimal id)
        {
            CartTable cartTable = db.CartTables.Find(id);
            if (cartTable == null)
            {
                return NotFound();
            }

            return Ok(cartTable);
        }

        // PUT: api/CartTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartTable(decimal id, CartTable cartTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartTable.CusID)
            {
                return BadRequest();
            }

            db.Entry(cartTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartTableExists(id))
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

        // POST: api/CartTables
        [ResponseType(typeof(CartTable))]
        public IHttpActionResult PostCartTable(CartTable cartTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartTables.Add(cartTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CartTableExists(cartTable.CusID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cartTable.CusID }, cartTable);
        }

        // DELETE: api/CartTables/5
        [ResponseType(typeof(CartTable))]
        public IHttpActionResult DeleteCartTable(decimal id)
        {
            CartTable cartTable = db.CartTables.Find(id);
            if (cartTable == null)
            {
                return NotFound();
            }

            db.CartTables.Remove(cartTable);
            db.SaveChanges();

            return Ok(cartTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartTableExists(decimal id)
        {
            return db.CartTables.Count(e => e.CusID == id) > 0;
        }
    }
}