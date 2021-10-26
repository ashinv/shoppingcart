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
    public class BillAddressTablesController : ApiController
    {
        private grocerydbEntities db = new grocerydbEntities();

        // GET: api/BillAddressTables
        public IQueryable<BillAddressTable> GetBillAddressTables()
        {
            return db.BillAddressTables;
        }

        // GET: api/BillAddressTables/5
        [ResponseType(typeof(BillAddressTable))]
        public IHttpActionResult GetBillAddressTable(decimal id)
        {
            BillAddressTable billAddressTable = db.BillAddressTables.Find(id);
            if (billAddressTable == null)
            {
                return NotFound();
            }

            return Ok(billAddressTable);
        }

        // PUT: api/BillAddressTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBillAddressTable(decimal id, BillAddressTable billAddressTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billAddressTable.CusID)
            {
                return BadRequest();
            }

            db.Entry(billAddressTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillAddressTableExists(id))
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

        // POST: api/BillAddressTables
        [ResponseType(typeof(BillAddressTable))]
        public IHttpActionResult PostBillAddressTable(BillAddressTable billAddressTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BillAddressTables.Add(billAddressTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BillAddressTableExists(billAddressTable.CusID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = billAddressTable.CusID }, billAddressTable);
        }

        // DELETE: api/BillAddressTables/5
        [ResponseType(typeof(BillAddressTable))]
        public IHttpActionResult DeleteBillAddressTable(decimal id)
        {
            BillAddressTable billAddressTable = db.BillAddressTables.Find(id);
            if (billAddressTable == null)
            {
                return NotFound();
            }

            db.BillAddressTables.Remove(billAddressTable);
            db.SaveChanges();

            return Ok(billAddressTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BillAddressTableExists(decimal id)
        {
            return db.BillAddressTables.Count(e => e.CusID == id) > 0;
        }
    }
}