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
using BackEnd;

namespace BackEnd.Controllers
{
    public class AddressTablesController : ApiController
    {
        private groceryDBEntities db = new groceryDBEntities();

        // GET: api/AddressTables
        public IQueryable<AddressTable> GetAddressTables()
        {
            return db.AddressTables;
        }

        // GET: api/AddressTables/5
        [ResponseType(typeof(AddressTable))]
        public IHttpActionResult GetAddressTable(decimal id)
        {
            AddressTable addressTable = db.AddressTables.Find(id);
            if (addressTable == null)
            {
                return NotFound();
            }

            return Ok(addressTable);
        }

        // PUT: api/AddressTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddressTable(decimal id, AddressTable addressTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addressTable.AddressID)
            {
                return BadRequest();
            }

            db.Entry(addressTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressTableExists(id))
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

        // POST: api/AddressTables
        [ResponseType(typeof(AddressTable))]
        public IHttpActionResult PostAddressTable(AddressTable addressTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddressTables.Add(addressTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = addressTable.AddressID }, addressTable);
        }

        // DELETE: api/AddressTables/5
        [ResponseType(typeof(AddressTable))]
        public IHttpActionResult DeleteAddressTable(decimal id)
        {
            AddressTable addressTable = db.AddressTables.Find(id);
            if (addressTable == null)
            {
                return NotFound();
            }

            db.AddressTables.Remove(addressTable);
            db.SaveChanges();

            return Ok(addressTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressTableExists(decimal id)
        {
            return db.AddressTables.Count(e => e.AddressID == id) > 0;
        }
    }
}