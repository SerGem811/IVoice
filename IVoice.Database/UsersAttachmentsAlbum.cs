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
    
    public partial class UsersAttachmentsAlbum : IVoice.Helpers.IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersAttachmentsAlbum()
        {
            this.UsersAttachments = new HashSet<UsersAttachment>();
            this.UsersAttachmentsAlbums1 = new HashSet<UsersAttachmentsAlbum>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Visibility { get; set; }
        public System.DateTime Created { get; set; }
        public bool Active { get; set; }
        public string Cover { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersAttachment> UsersAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersAttachmentsAlbum> UsersAttachmentsAlbums1 { get; set; }
        public virtual UsersAttachmentsAlbum UsersAttachmentsAlbum1 { get; set; }
    }
}