//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Basvurular
    {
        public int id { get; set; }
        public int kullaniciid { get; set; }
        public int isilaniid { get; set; }
        public Nullable<int> cvid { get; set; }
    
        public virtual IsIlani IsIlani { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual KullaniciCv KullaniciCv { get; set; }
    }
}
