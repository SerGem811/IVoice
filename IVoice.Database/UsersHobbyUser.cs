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
    
    public partial class UsersHobbyUser : IVoice.Helpers.IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UsersHobbyId { get; set; }
    
        public virtual User User { get; set; }
        public virtual UsersHobby UsersHobby { get; set; }
    }
}
