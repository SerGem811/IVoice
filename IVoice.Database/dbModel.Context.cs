﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EOneEntities : DbContext
    {
        public EOneEntities()
            : base("name=EOneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<ForumAnswer> ForumAnswers { get; set; }
        public virtual DbSet<ForumAnswersAttach> ForumAnswersAttaches { get; set; }
        public virtual DbSet<ForumAnswerVote> ForumAnswerVotes { get; set; }
        public virtual DbSet<ForumTopic> ForumTopics { get; set; }
        public virtual DbSet<ForumTopicsView> ForumTopicsViews { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<IPTag> IPTags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersActivity> UsersActivities { get; set; }
        public virtual DbSet<UsersAttachment> UsersAttachments { get; set; }
        public virtual DbSet<UsersAttachmentsAlbum> UsersAttachmentsAlbums { get; set; }
        public virtual DbSet<UsersConnection> UsersConnections { get; set; }
        public virtual DbSet<UsersCPMBalance> UsersCPMBalances { get; set; }
        public virtual DbSet<UsersHobby> UsersHobbies { get; set; }
        public virtual DbSet<UsersHobbyUser> UsersHobbyUsers { get; set; }
        public virtual DbSet<UsersIP> UsersIPs { get; set; }
        public virtual DbSet<UsersIPAd> UsersIPAds { get; set; }
        public virtual DbSet<UsersIPComment> UsersIPComments { get; set; }
        public virtual DbSet<UsersIPEPPoint> UsersIPEPPoints { get; set; }
        public virtual DbSet<UsersIPFilter> UsersIPFilters { get; set; }
        public virtual DbSet<UsersIPLike> UsersIPLikes { get; set; }
        public virtual DbSet<UsersIPSpread> UsersIPSpreads { get; set; }
        public virtual DbSet<UsersIPSurf> UsersIPSurfs { get; set; }
        public virtual DbSet<UsersIPTag> UsersIPTags { get; set; }
        public virtual DbSet<UsersOccupation> UsersOccupations { get; set; }
        public virtual DbSet<UsersOccupationsUser> UsersOccupationsUsers { get; set; }
        public virtual DbSet<UsersPayment> UsersPayments { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }
        public virtual DbSet<Whisper> Whispers { get; set; }
        public virtual DbSet<WhisperAttachment> WhisperAttachments { get; set; }
    }
}
