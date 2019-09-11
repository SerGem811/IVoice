//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IVoice.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feature : IVoice.Helpers.IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feature()
        {
            this.Categories = new HashSet<Category>();
            this.UsersIPs = new HashSet<UsersIP>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool Enabled { get; set; }
        public int Order { get; set; }
        public bool Public { get; set; }
        public string ViewType { get; set; }
        public bool ForIP { get; set; }
        public string ProfileName { get; set; }
        public string ProfileImagePath { get; set; }
        public bool ProfileUse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIP> UsersIPs { get; set; }
    }
}
