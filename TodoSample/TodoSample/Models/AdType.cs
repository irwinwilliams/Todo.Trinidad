//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoSample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdType
    {
        public AdType()
        {
            this.Ads = new HashSet<Ad>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    
        public virtual ICollection<Ad> Ads { get; set; }
    }
}
