//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblBolum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblBolum()
        {
            this.TblOgr = new HashSet<TblOgr>();
        }
    
        public int BolumID { get; set; }
        public int BolumFakulte { get; set; }
        public string BolumAd { get; set; }
        public int BolumUcret { get; set; }
    
        public virtual TblFakulte TblFakulte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOgr> TblOgr { get; set; }
    }
}