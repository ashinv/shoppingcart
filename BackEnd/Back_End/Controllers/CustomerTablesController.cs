﻿using System;
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
using Back_End;

namespace Back_End.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerTablesController : ApiController
    {
        private grocerydbEntities db = new grocerydbEntities();

        // GET: api/CustomerTables
        public IQueryable<CustomerTable> GetCustomerTables()
        {
            return db.CustomerTables;
        }

        // GET: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult GetCustomerTable(decimal id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            return Ok(customerTable);
        }

        // PUT: api/CustomerTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerTable(decimal id, CustomerTable customerTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerTable.CusID)
            {
                return BadRequest();
            }

            db.Entry(customerTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTableExists(id))
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

        // POST: api/CustomerTables
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult PostCustomerTable(CustomerTable customerTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerTables.Add(customerTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerTable.CusID }, customerTable);
        }

        // DELETE: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult DeleteCustomerTable(decimal id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            db.CustomerTables.Remove(customerTable);
            db.SaveChanges();

            return Ok(customerTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerTableExists(decimal id)
        {
            return db.CustomerTables.Count(e => e.CusID == id) > 0;
        }
    }
}