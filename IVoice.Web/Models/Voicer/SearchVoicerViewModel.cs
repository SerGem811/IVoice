using IVoice.Database;
using IVoice.Helpers.Extensions;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using static IVoice.Helpers.Constants;

namespace IVoice.Models.Voicer
{
    public class SearchVoicerViewModel : BaseModel
    {
        public string FreeSearch { get; set; }

        public string DateOfBirth { get; set; }
        public int? GenderId { get; set; }
        public int? CountryId { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public List<int> OccupationId { get; set; }
        public string RelationshipStatus { get; set; }
        public List<int> InterestHobbyId { get; set; }

        public int? UserIpId { get; set; }

        public SelectList GenderList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList OccupationProfessionList { get; set; }
        public SelectList HobbyList { get; set; }


        public List<VoicerModel> VoicersListResult { get; set; }
        public SearchFormType SearchFormType { get; set; }


        public string ConnectedListId { get; set; }

        #region Derived from SearchFormType
        public string SearchButton
        {
            get
            {
                if (SearchFormType == SearchFormType.SPREAD)
                    return "Spread";
                else return "Search";
            }
        }
        #endregion

        public Expression<Func<Database.User, bool>> GetFilter(List<int> BlockedUsersList)
        {
            Expression<Func<Database.User, bool>> filter = x => !BlockedUsersList.Contains(x.Id) && x.Active;

            if (!string.IsNullOrEmpty(FreeSearch))
            {
                FreeSearch = FreeSearch.ToUpper();
                filter = filter.And(x => x.Nickname.ToUpper().Contains(FreeSearch) || x.Gender.Gender1.ToUpper().Contains(FreeSearch) || x.Country.Name.ToUpper().Contains(FreeSearch)
                                        || x.Region.ToUpper().Contains(FreeSearch) || x.Language.ToUpper().Contains(FreeSearch)
                                        || x.RelationshipStatus.ToUpper().Contains(FreeSearch));
            }
            else if (!string.IsNullOrEmpty(ConnectedListId) && ConnectedListId.Count() > 1)
            {
                var SelectedVoicerList = ConnectedListId.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToList();
                filter = filter.And(x => SelectedVoicerList.Contains(x.Id));
            }
            else
            {
                if (!string.IsNullOrEmpty(DateOfBirth))
                    filter = filter.And(x => x.BirthDate == DateOfBirth);
                if (GenderId != null && GenderId > 0)
                    filter = filter.And(x => x.GenderId == GenderId);
                if (CountryId != null && CountryId > 0)
                    filter = filter.And(x => x.CountryId == CountryId);
                if (!OccupationId.IsEmpty())
                    filter = filter.And(x => x.UsersOccupationsUsers.Any(y => OccupationId.Contains(y.UsersOccupationsId)));
                if (!InterestHobbyId.IsEmpty())
                    filter = filter.And(x => x.UsersHobbyUsers.Any(y => InterestHobbyId.Contains(y.UsersHobbyId)));
                if (!string.IsNullOrEmpty(Region))
                    filter = filter.And(x => x.Region.ToUpper().Contains(Region.ToUpper()));
                if (!string.IsNullOrEmpty(Language))
                    filter = filter.And(x => x.Language.ToUpper().Contains(Language.ToUpper()));
                if (!string.IsNullOrEmpty(RelationshipStatus))
                    filter = filter.And(x => x.RelationshipStatus.ToUpper().Contains(RelationshipStatus.ToUpper()));
            }

            return filter;
        }

        public Expression<Func<Database.UsersIP, bool>> GetFilterForIP(List<int> BlockedUsersList)
        {
            Expression<Func<Database.UsersIP, bool>> filter = x => !BlockedUsersList.Contains(x.Id) && x.User.Active;

            if (!string.IsNullOrEmpty(FreeSearch))
            {
                FreeSearch = FreeSearch.ToUpper();
                filter = filter.And(x => x.User.Nickname.ToUpper().Contains(FreeSearch) || x.User.Gender.Gender1.ToUpper().Contains(FreeSearch) || x.User.Country.Name.ToUpper().Contains(FreeSearch)
                                        || x.User.Region.ToUpper().Contains(FreeSearch) || x.User.Language.ToUpper().Contains(FreeSearch)
                                        || x.User.RelationshipStatus.ToUpper().Contains(FreeSearch));
            }
            else if (!string.IsNullOrEmpty(ConnectedListId) && ConnectedListId.Count() > 1)
            {
                var SelectedVoicerList = ConnectedListId.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToList();
                filter = filter.And(x => SelectedVoicerList.Contains(x.Id));
            }
            else
            {
                if (!string.IsNullOrEmpty(DateOfBirth))
                {
                    //DateTime dt = Convert.ToDateTime(DateOfBirth);
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().BirthDate == DateOfBirth);
                }
                if (GenderId != null && GenderId > 0)
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().GenderId == GenderId);
                if (CountryId != null && CountryId > 0)
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().CountryId == CountryId);
                if (OccupationId != null && OccupationId.Count > 0)
                {
                    var val = string.Join(", ", OccupationId);
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().OccupationByComma.Contains(val));
                }
                if (InterestHobbyId != null && InterestHobbyId.Count > 0)
                {
                    var val = string.Join(", ", InterestHobbyId);
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().HobbiesByComma.Contains(val));
                }
                if (!string.IsNullOrEmpty(Region))
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().Region.ToUpper().Contains(Region.ToUpper()));
                if (!string.IsNullOrEmpty(Language))
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().Language.ToUpper().Contains(Language.ToUpper()));
                if (!string.IsNullOrEmpty(RelationshipStatus))
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().RelationshipStatus.ToUpper().Contains(RelationshipStatus.ToUpper()));
            }

            return filter;
        }
    }
}
