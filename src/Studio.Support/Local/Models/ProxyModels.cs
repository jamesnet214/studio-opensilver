using System;
using System.Collections.Generic;
using System.Text;

namespace Studio.Support.Local.Models
{
    public class ArticleResponse
    {
        public int ArticleID { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ViewCount { get; set; }
        public int VoteCount { get; set; }
        public bool IsPublic { get; set; }
        public string ProfileImageUrl { get; set; }
        public ProfileResponse Profile { get; set; }
        public bool IsUpVoteChecked { get; set; }
        public string MenuInfo { get; set; }
        public List<string> Tags { get; set; }
        public List<MenuResponse> Menus { get; set; }
        public string SelectedLanguageCode { get; set; }
        public List<InvitationStatusResponse> Invitations { get; set; }
        public List<ArticleContentResponse> Contents { get; set; }
        public List<string> ArticleThumbnails { get; set; } = new List<string>();
    }

    public class ProfileResponse
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string UniqueID { get; set; }
        public string MainProfileImageUrl { get; set; }
        public List<SocialAccountResponse> SocialAccounts { get; set; }
    }

    public class SocialAccountResponse
    {
        public string URL { get; set; }
        public string Platform { get; set; }
    }

    public class MenuResponse
    {
        public string MenuName { get; set; }
        public int MenuID { get; set; }
    }

    public class InvitationStatusResponse
    {
        public ProfileResponse InviteeUser { get; set; }
    }

    public class ArticleContentResponse
    {
        public string Title { get; set; }
        public int ArticleID { get; set; }
        public int LanguageID { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public string Content { get; set; }
    }

    public class UpdateArticleCreatedDateRequest
    {
        public int ArticleId { get; set; }
        public DateTime NewCreatedDate { get; set; }
        public bool IsPublic { get; set; }
    }

    public class NationalityCount
    {
        public string Nationality { get; set; }
        public int Count { get; set; }
    }
}
