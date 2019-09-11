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
    
    public partial class User : IVoice.Helpers.IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Categories = new HashSet<Category>();
            this.Categories1 = new HashSet<Category>();
            this.ForumAnswers = new HashSet<ForumAnswer>();
            this.ForumAnswerVotes = new HashSet<ForumAnswerVote>();
            this.ForumTopics = new HashSet<ForumTopic>();
            this.ForumTopicsViews = new HashSet<ForumTopicsView>();
            this.UsersIPSpreads = new HashSet<UsersIPSpread>();
            this.UsersIPSpreads1 = new HashSet<UsersIPSpread>();
            this.UsersActivities = new HashSet<UsersActivity>();
            this.UsersAttachments = new HashSet<UsersAttachment>();
            this.UsersAttachmentsAlbums = new HashSet<UsersAttachmentsAlbum>();
            this.UsersConnections = new HashSet<UsersConnection>();
            this.UsersConnections1 = new HashSet<UsersConnection>();
            this.UsersCPMBalances = new HashSet<UsersCPMBalance>();
            this.UsersIPEPPoints = new HashSet<UsersIPEPPoint>();
            this.UsersHobbyUsers = new HashSet<UsersHobbyUser>();
            this.UsersIPs = new HashSet<UsersIP>();
            this.UsersIPComments = new HashSet<UsersIPComment>();
            this.UsersIPLikes = new HashSet<UsersIPLike>();
            this.UsersIPSurfs = new HashSet<UsersIPSurf>();
            this.UsersOccupationsUsers = new HashSet<UsersOccupationsUser>();
            this.UsersPayments = new HashSet<UsersPayment>();
            this.Whispers = new HashSet<Whisper>();
            this.Whispers1 = new HashSet<Whisper>();
        }
    
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CurrentUserIPDI { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public bool ActiveWhisper { get; set; }
        public bool ActiveVoicerUpdates { get; set; }
        public bool ActiveIPFeeds { get; set; }
        public bool ActiveGallery { get; set; }
        public bool ActiveVoicer { get; set; }
        public bool ActiveSpread { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public System.DateTime DateRegister { get; set; }
        public Nullable<System.DateTime> DateDeactivate { get; set; }
        public string BirthDate { get; set; }
        public string RelationshipStatus { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public bool BirthDatePublic { get; set; }
        public bool GenderPublic { get; set; }
        public bool CountryPublic { get; set; }
        public bool RegionPublic { get; set; }
        public bool LanguagePublic { get; set; }
        public bool OccupationPublic { get; set; }
        public bool RelationshipStatusPublic { get; set; }
        public bool InterestHobbyPublic { get; set; }
        public System.Guid CheckCode { get; set; }
        public System.DateTime DateValidCheckCode { get; set; }
        public int TotalForumPosts { get; set; }
        public string ImageURL { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public bool OnlyAdult { get; set; }
        public bool IsAdult { get; set; }
        public string FavouriteMusic { get; set; }
        public string FavouriteGames { get; set; }
        public string FavouriteSports { get; set; }
        public string FavouriteVehicle { get; set; }
        public string FavouriteTV { get; set; }
        public string FavouriteRestaurant { get; set; }
        public string FavouriteFilm { get; set; }
        public string FavouriteBrand { get; set; }
        public string FavouriteOther { get; set; }
        public string FavouriteAboutYou { get; set; }
        public bool FavouriteMusicPublic { get; set; }
        public bool FavouriteGamesPublic { get; set; }
        public bool FavouriteSportsPublic { get; set; }
        public bool FavouriteVehiclePublic { get; set; }
        public bool FavouriteTVPublic { get; set; }
        public bool FavouriteRestaurantPublic { get; set; }
        public bool FavouriteFilmPublic { get; set; }
        public bool FavouriteBrandPublic { get; set; }
        public bool FavouriteOtherPublic { get; set; }
        public bool FavouriteAboutYoupublic { get; set; }
        public string Type { get; set; }
        public int EPPoints { get; set; }
        public decimal CPMPoints { get; set; }
        public Nullable<System.DateTime> FullAdActiveUntil { get; set; }
        public bool isPublic { get; set; }
        public bool ActiveEP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories1 { get; set; }
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumAnswer> ForumAnswers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumAnswerVote> ForumAnswerVotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumTopic> ForumTopics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumTopicsView> ForumTopicsViews { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPSpread> UsersIPSpreads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPSpread> UsersIPSpreads1 { get; set; }
        public virtual UsersIP UsersIP { get; set; }
        public virtual UsersRole UsersRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersActivity> UsersActivities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersAttachment> UsersAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersAttachmentsAlbum> UsersAttachmentsAlbums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersConnection> UsersConnections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersConnection> UsersConnections1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersCPMBalance> UsersCPMBalances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPEPPoint> UsersIPEPPoints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersHobbyUser> UsersHobbyUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIP> UsersIPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPComment> UsersIPComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPLike> UsersIPLikes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersIPSurf> UsersIPSurfs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersOccupationsUser> UsersOccupationsUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersPayment> UsersPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Whisper> Whispers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Whisper> Whispers1 { get; set; }
    }
}
