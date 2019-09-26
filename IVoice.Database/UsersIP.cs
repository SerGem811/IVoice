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
    
    public partial class UsersIP : IVoice.Helpers.IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersIP()
        {
            this.Users = new HashSet<User>();
            this.UsersActivities = new HashSet<UsersActivity>();
            this.UsersCPMBalances = new HashSet<UsersCPMBalance>();
            this.UsersIPSpreads = new HashSet<UsersIPSpread>();
            this.UsersIPTags = new HashSet<UsersIPTag>();
            this.UsersIPEPPoints = new HashSet<UsersIPEPPoint>();
            this.UsersIPComments = new HashSet<UsersIPComment>();
            this.UsersIPFilters = new HashSet<UsersIPFilter>();
            this.UsersIPLikes = new HashSet<UsersIPLike>();
            this.UsersIPSurfs = new HashSet<UsersIPSurf>();
        }
    
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public int UserId { get; set; }
        public int UserAttachmentId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateAdd { get; set; }
        public string BodyHtml { get; set; }
        public string BodyStyle { get; set; }
        public bool AdultOnly { get; set; }
        public bool Public { get; set; }
        public string route { get; set; }
        public int Views { get; set; }
        public int Comments { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Surfs { get; set; }
        public int EPPoints { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Feature Feature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersActivity> UsersActivities { get; set; }
        public virtual UsersAttachment UsersAttachment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersCPMBalance> UsersCPMBalances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPSpread> UsersIPSpreads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPTag> UsersIPTags { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPEPPoint> UsersIPEPPoints { get; set; }
        public virtual UsersIPAd UsersIPAd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPComment> UsersIPComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPFilter> UsersIPFilters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPLike> UsersIPLikes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPSurf> UsersIPSurfs { get; set; }
    }
}
