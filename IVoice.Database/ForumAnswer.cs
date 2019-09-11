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
    
    public partial class ForumAnswer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForumAnswer()
        {
            this.ForumAnswersAttaches = new HashSet<ForumAnswersAttach>();
            this.ForumAnswerVotes = new HashSet<ForumAnswerVote>();
            this.ForumTopics = new HashSet<ForumTopic>();
        }
    
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string Answer { get; set; }
        public System.DateTime AnswerDate { get; set; }
        public bool Active { get; set; }
    
        public virtual ForumTopic ForumTopic { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumAnswersAttach> ForumAnswersAttaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumAnswerVote> ForumAnswerVotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumTopic> ForumTopics { get; set; }
    }
}
