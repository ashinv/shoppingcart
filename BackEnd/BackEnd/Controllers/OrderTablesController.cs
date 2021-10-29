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
    public class OrderTablesController : ApiController
    {
        private groceryDBEntities db = new groceryDBEntities();

        // GET: api/OrderTables
        public IQueryable<OrderTable> GetOrderTables()
        {
            return db.OrderTables;
        }

        // GET: api/OrderTables/5
        [ResponseType(typeof(OrderTable))]
        public IHttpActionResult GetOrderTable(decimal id)
        {
            OrderTable orderTable = db.OrderTables.Find(id);
            if (orderTable == null)
            {
                return NotFound();
            }

            return Ok(orderTable);
        }

        // PUT: api/OrderTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderTable(decimal id, OrderTable orderTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderTable.OrderId)
            {
                return BadRequest();
            }

            db.Entry(orderTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTableExists(id))
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

        // POST: api/OrderTables
        [ResponseType(typeof(OrderTable))]
        public IHttpActionResult PostOrderTable(OrderTable orderTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderTables.Add(orderTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderTable.OrderId }, orderTable);
        }

        // DELETE: api/OrderTables/5
        [ResponseType(typeof(OrderTable))]
        public IHttpActionResult DeleteOrderTable(decimal id)
        {
            OrderTable orderTable = db.OrderTables.Find(id);
            if (orderTable == null)
            {
                return NotFound();
            }

            db.OrderTables.Remove(orderTable);
            db.SaveChanges();

            return Ok(orderTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderTableExists(decimal id)
        {
            return db.OrderTables.Count(e => e.OrderId == id) > 0;
        }
    }
}