//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd
{
    using System;
    using System.Collections.Generic;
    
    public partial class AddressTable
    {
        public decimal CusID { get; set; }
        public decimal AddressID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public decimal Pincode { get; set; }
        public decimal Phonenumber { get; set; }
    
        public virtual CustomerTable CustomerTable { get; set; }
    }
}