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
    
    public partial class ForumAnswerVote
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public string Vote { get; set; }
        public int Points { get; set; }
        public System.DateTime VoteDate { get; set; }
    
        public virtual ForumAnswer ForumAnswer { get; set; }
        public virtual User User { get; set; }
    }
}
