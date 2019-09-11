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
    
    public partial class UsersAttachment : IVoice.Helpers.IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersAttachment()
        {
            this.ForumAnswersAttaches = new HashSet<ForumAnswersAttach>();
            this.UsersIPs = new HashSet<UsersIP>();
            this.WhisperAttachments = new HashSet<WhisperAttachment>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<int> UserAttachAlbumId { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }
        public string FileName { get; set; }
        public string Visibity { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.Guid UniqueId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumAnswersAttach> ForumAnswersAttaches { get; set; }
        public virtual User User { get; set; }
        public virtual UsersAttachmentsAlbum UsersAttachmentsAlbum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIP> UsersIPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WhisperAttachment> WhisperAttachments { get; set; }
    }
}