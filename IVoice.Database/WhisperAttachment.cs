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
    
    public partial class WhisperAttachment : IVoice.Helpers.IEntityBase
    {
        public int Id { get; set; }
        public Nullable<int> WhisperId { get; set; }
        public int UserAttachmentId { get; set; }
    
        public virtual UsersAttachment UsersAttachment { get; set; }
        public virtual Whisper Whisper { get; set; }
    }
}
