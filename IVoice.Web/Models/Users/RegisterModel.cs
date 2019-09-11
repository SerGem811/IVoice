using System;
using System.ComponentModel.DataAnnotations;

namespace IVoice.Models.Users
{
    public class RegisterModel : BaseModel
    {
        [Required(ErrorMessage = "Please enter valid phone number")]
        public string _phone { get; set; }
        [Required(ErrorMessage = "Please enter valid first name")]
        public string _first { get; set; }
        [Required(ErrorMessage = "Please enter valid last name")]
        public string _last { get; set; }
        [Required(ErrorMessage = "Please enter valid voicer")]
        public string _voicer { get; set; }
        [Required(ErrorMessage = "Please enter valid email")]
        public string _email { get; set; }
        [Required(ErrorMessage = "Please enter valid password")]
        public string _pwd { get; set; }
        [Required(ErrorMessage = "Please enter valid confirm password")]
        public string _confirm { get; set; }
        [Required(ErrorMessage = "Please agree with terms")]
        public bool _agree { get; set; }
        [Required(ErrorMessage = "Please confirm you are adult")]
        public bool _onlyadult { get; set; }
        [Required(ErrorMessage = "Please enter your security question")]
        public string _question { get; set; }
        [Required(ErrorMessage = "Please enter your security answer")]
        public string _answer { get; set; }

        public bool IsValid()
        {
            if (_pwd != _confirm || string.IsNullOrEmpty(_pwd) || _pwd.Length < 5)
                return false;
            if (_phone == null || _phone.Length < 2)
                return false;
            if (_first == null || _first.Length < 1)
                return false;
            if (_email == null || _email.Length < 2)
                return false;
            if (_voicer == null || _voicer.Length < 1)
                return false;
            if (!_agree)
                return false;
            if (string.IsNullOrEmpty(_question))
                return false;
            if (string.IsNullOrEmpty(_answer))
                return false;
            return true;
        }

        public Database.User ToEntity()
        {
            return new Database.User()
            {
                Active = true,
                FirstName = _first,
                BirthDatePublic = false,
                CountryPublic = false,
                ActiveIPFeeds = true,
                ActiveVoicerUpdates = true,
                ActiveWhisper = true,
                CheckCode = Guid.NewGuid(),
                DateRegister = DateTime.Now,
                DateValidCheckCode = DateTime.Now.AddHours(12),
                Email = _email,
                Nickname = _voicer,
                GenderPublic = false,
                InterestHobbyPublic = false,
                LanguagePublic = false,
                OccupationPublic = false,
                RegionPublic = false,
                RelationshipStatusPublic = false,
                LastName = _last,
                Password = _pwd,
                RoleId = 4,
                SecretQuestion = _question,
                SecretAnswer = _answer,
                TotalForumPosts = 0,
                ImageURL = "/Images/icons/user.png",
                OnlyAdult = _onlyadult,
                Type = "PROFILE",
                EPPoints = 10
            };
        }
    }
}