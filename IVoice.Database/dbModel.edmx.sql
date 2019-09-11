
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2019 12:52:14
-- Generated from EDMX file: D:\Works\65.EOne\01.Source\IVoice\IVoice.Database\dbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [eone];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Categories_Features]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_Categories_Features];
GO
IF OBJECT_ID(N'[dbo].[FK_Categories_ForumTopics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_Categories_ForumTopics];
GO
IF OBJECT_ID(N'[dbo].[FK_Categories_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_Categories_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Categories_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_Categories_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswers_ForumTopics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumAnswers] DROP CONSTRAINT [FK_ForumAnswers_ForumTopics];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswers_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumAnswers] DROP CONSTRAINT [FK_ForumAnswers_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswersAttach_ForumAnswers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumAnswersAttach] DROP CONSTRAINT [FK_ForumAnswersAttach_ForumAnswers];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswersAttach_UsersAttachments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumAnswersAttach] DROP CONSTRAINT [FK_ForumAnswersAttach_UsersAttachments];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswersViews_ForumTopics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopicsViews] DROP CONSTRAINT [FK_ForumAnswersViews_ForumTopics];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswersViews_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopicsViews] DROP CONSTRAINT [FK_ForumAnswersViews_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswerVotes_ForumAnswers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumAnswerVotes] DROP CONSTRAINT [FK_ForumAnswerVotes_ForumAnswers];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumAnswerVotes_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumAnswerVotes] DROP CONSTRAINT [FK_ForumAnswerVotes_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumTopics_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopics] DROP CONSTRAINT [FK_ForumTopics_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumTopics_ForumAnswers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopics] DROP CONSTRAINT [FK_ForumTopics_ForumAnswers];
GO
IF OBJECT_ID(N'[dbo].[FK_ForumTopics_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopics] DROP CONSTRAINT [FK_ForumTopics_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserIPSpreads_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPSpreads] DROP CONSTRAINT [FK_UserIPSpreads_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserIPSpreads_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPSpreads] DROP CONSTRAINT [FK_UserIPSpreads_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserIPSpreads_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPSpreads] DROP CONSTRAINT [FK_UserIPSpreads_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UserIPTags_IPTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPTags] DROP CONSTRAINT [FK_UserIPTags_IPTag];
GO
IF OBJECT_ID(N'[dbo].[FK_UserIPTags_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPTags] DROP CONSTRAINT [FK_UserIPTags_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Countries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Countries];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Genders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Genders];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_UsersRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_UsersRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersActivity_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersActivity] DROP CONSTRAINT [FK_UsersActivity_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersActivity_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersActivity] DROP CONSTRAINT [FK_UsersActivity_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersAttachments_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersAttachments] DROP CONSTRAINT [FK_UsersAttachments_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersAttachments_UsersAttachmentsAlbums]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersAttachments] DROP CONSTRAINT [FK_UsersAttachments_UsersAttachmentsAlbums];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersAttachmentsAlbums_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersAttachmentsAlbums] DROP CONSTRAINT [FK_UsersAttachmentsAlbums_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersAttachmentsAlbums_UsersAttachmentsAlbums]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersAttachmentsAlbums] DROP CONSTRAINT [FK_UsersAttachmentsAlbums_UsersAttachmentsAlbums];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersConnections_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersConnections] DROP CONSTRAINT [FK_UsersConnections_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersConnections_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersConnections] DROP CONSTRAINT [FK_UsersConnections_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersCPMBalance_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersCPMBalance] DROP CONSTRAINT [FK_UsersCPMBalance_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersCPMBalance_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersCPMBalance] DROP CONSTRAINT [FK_UsersCPMBalance_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersCPMBalance_UsersPayments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersCPMBalance] DROP CONSTRAINT [FK_UsersCPMBalance_UsersPayments];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersEPPoints_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPEPPoints] DROP CONSTRAINT [FK_UsersEPPoints_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersEPPoints_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPEPPoints] DROP CONSTRAINT [FK_UsersEPPoints_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersHobbyUsers_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersHobbyUsers] DROP CONSTRAINT [FK_UsersHobbyUsers_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersHobbyUsers_UsersHobby]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersHobbyUsers] DROP CONSTRAINT [FK_UsersHobbyUsers_UsersHobby];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIP_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIP] DROP CONSTRAINT [FK_UsersIP_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIP_Features]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIP] DROP CONSTRAINT [FK_UsersIP_Features];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIP_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIP] DROP CONSTRAINT [FK_UsersIP_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIP_UsersAttachments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIP] DROP CONSTRAINT [FK_UsersIP_UsersAttachments];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPAds_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPAds] DROP CONSTRAINT [FK_UsersIPAds_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPComments_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPComments] DROP CONSTRAINT [FK_UsersIPComments_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPComments_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPComments] DROP CONSTRAINT [FK_UsersIPComments_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPComments_UsersIPComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPComments] DROP CONSTRAINT [FK_UsersIPComments_UsersIPComments];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPFilter_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPFilter] DROP CONSTRAINT [FK_UsersIPFilter_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPLikes_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPLikes] DROP CONSTRAINT [FK_UsersIPLikes_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPLikes_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPLikes] DROP CONSTRAINT [FK_UsersIPLikes_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPSurf_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPSurf] DROP CONSTRAINT [FK_UsersIPSurf_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersIPSurf_UsersIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersIPSurf] DROP CONSTRAINT [FK_UsersIPSurf_UsersIP];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersOccupationsUsers_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersOccupationsUsers] DROP CONSTRAINT [FK_UsersOccupationsUsers_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersOccupationsUsers_UsersOccupations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersOccupationsUsers] DROP CONSTRAINT [FK_UsersOccupationsUsers_UsersOccupations];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersPayments_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersPayments] DROP CONSTRAINT [FK_UsersPayments_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Whisper_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Whisper] DROP CONSTRAINT [FK_Whisper_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Whisper_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Whisper] DROP CONSTRAINT [FK_Whisper_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_WhisperAttachments_UsersAttachments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WhisperAttachments] DROP CONSTRAINT [FK_WhisperAttachments_UsersAttachments];
GO
IF OBJECT_ID(N'[dbo].[FK_WhisperAttachments_Whisper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WhisperAttachments] DROP CONSTRAINT [FK_WhisperAttachments_Whisper];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Features]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Features];
GO
IF OBJECT_ID(N'[dbo].[ForumAnswers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumAnswers];
GO
IF OBJECT_ID(N'[dbo].[ForumAnswersAttach]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumAnswersAttach];
GO
IF OBJECT_ID(N'[dbo].[ForumAnswerVotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumAnswerVotes];
GO
IF OBJECT_ID(N'[dbo].[ForumTopics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumTopics];
GO
IF OBJECT_ID(N'[dbo].[ForumTopicsViews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumTopicsViews];
GO
IF OBJECT_ID(N'[dbo].[Genders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genders];
GO
IF OBJECT_ID(N'[dbo].[IPTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IPTag];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UsersActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersActivity];
GO
IF OBJECT_ID(N'[dbo].[UsersAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersAttachments];
GO
IF OBJECT_ID(N'[dbo].[UsersAttachmentsAlbums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersAttachmentsAlbums];
GO
IF OBJECT_ID(N'[dbo].[UsersConnections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersConnections];
GO
IF OBJECT_ID(N'[dbo].[UsersCPMBalance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersCPMBalance];
GO
IF OBJECT_ID(N'[dbo].[UsersHobby]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersHobby];
GO
IF OBJECT_ID(N'[dbo].[UsersHobbyUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersHobbyUsers];
GO
IF OBJECT_ID(N'[dbo].[UsersIP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIP];
GO
IF OBJECT_ID(N'[dbo].[UsersIPAds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPAds];
GO
IF OBJECT_ID(N'[dbo].[UsersIPComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPComments];
GO
IF OBJECT_ID(N'[dbo].[UsersIPEPPoints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPEPPoints];
GO
IF OBJECT_ID(N'[dbo].[UsersIPFilter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPFilter];
GO
IF OBJECT_ID(N'[dbo].[UsersIPLikes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPLikes];
GO
IF OBJECT_ID(N'[dbo].[UsersIPSpreads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPSpreads];
GO
IF OBJECT_ID(N'[dbo].[UsersIPSurf]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPSurf];
GO
IF OBJECT_ID(N'[dbo].[UsersIPTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersIPTags];
GO
IF OBJECT_ID(N'[dbo].[UsersOccupations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersOccupations];
GO
IF OBJECT_ID(N'[dbo].[UsersOccupationsUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersOccupationsUsers];
GO
IF OBJECT_ID(N'[dbo].[UsersPayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersPayments];
GO
IF OBJECT_ID(N'[dbo].[UsersRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersRoles];
GO
IF OBJECT_ID(N'[dbo].[Whisper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Whisper];
GO
IF OBJECT_ID(N'[dbo].[WhisperAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WhisperAttachments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeatureId] int  NULL,
    [Name] varchar(512)  NOT NULL,
    [OnlyForum] bit  NOT NULL,
    [ImagePath] varchar(512)  NULL,
    [Description] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [UserIdCreate] int  NULL,
    [Topics] int  NOT NULL,
    [Posts] int  NOT NULL,
    [LastUserId] int  NULL,
    [LastTopicId] int  NULL,
    [LastDate] datetime  NULL,
    [Enabled] bit  NOT NULL,
    [ForIP] bit  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NOT NULL,
    [Name] varchar(512)  NOT NULL
);
GO

-- Creating table 'Features'
CREATE TABLE [dbo].[Features] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(512)  NOT NULL,
    [ImagePath] varchar(512)  NOT NULL,
    [Enabled] bit  NOT NULL,
    [Order] int  NOT NULL,
    [Public] bit  NOT NULL,
    [ViewType] varchar(50)  NOT NULL,
    [ForIP] bit  NOT NULL,
    [ProfileName] varchar(512)  NOT NULL,
    [ProfileImagePath] varchar(512)  NOT NULL,
    [ProfileUse] bit  NOT NULL
);
GO

-- Creating table 'ForumAnswers'
CREATE TABLE [dbo].[ForumAnswers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TopicId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Answer] nvarchar(max)  NOT NULL,
    [AnswerDate] datetime  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'ForumAnswersAttaches'
CREATE TABLE [dbo].[ForumAnswersAttaches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AnswerId] int  NULL,
    [UserAttachmentId] int  NOT NULL
);
GO

-- Creating table 'ForumAnswerVotes'
CREATE TABLE [dbo].[ForumAnswerVotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AnswerId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Vote] varchar(512)  NOT NULL,
    [Points] int  NOT NULL,
    [VoteDate] datetime  NOT NULL
);
GO

-- Creating table 'ForumTopics'
CREATE TABLE [dbo].[ForumTopics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [CategoryId] int  NOT NULL,
    [AnswerId] int  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [Views] int  NOT NULL,
    [Replies] int  NOT NULL,
    [Active] bit  NOT NULL,
    [LastReplyDate] datetime  NOT NULL
);
GO

-- Creating table 'ForumTopicsViews'
CREATE TABLE [dbo].[ForumTopicsViews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [TopicId] int  NOT NULL,
    [Ip] varchar(50)  NOT NULL
);
GO

-- Creating table 'Genders'
CREATE TABLE [dbo].[Genders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gender1] varchar(50)  NULL
);
GO

-- Creating table 'IPTags'
CREATE TABLE [dbo].[IPTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tag] varchar(512)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [GenderId] int  NULL,
    [CountryId] int  NULL,
    [CurrentUserIPDI] int  NULL,
    [Email] varchar(512)  NOT NULL,
    [Nickname] varchar(512)  NOT NULL,
    [ActiveWhisper] bit  NOT NULL,
    [ActiveVoicerUpdates] bit  NOT NULL,
    [ActiveIPFeeds] bit  NOT NULL,
    [FirstName] varchar(512)  NOT NULL,
    [LastName] varchar(512)  NOT NULL,
    [Password] varchar(512)  NOT NULL,
    [Active] bit  NOT NULL,
    [DateRegister] datetime  NOT NULL,
    [DateDeactivate] datetime  NULL,
    [BirthDate] varchar(50)  NULL,
    [RelationshipStatus] varchar(1024)  NULL,
    [Region] varchar(1024)  NULL,
    [Language] varchar(1024)  NULL,
    [BirthDatePublic] bit  NOT NULL,
    [GenderPublic] bit  NOT NULL,
    [CountryPublic] bit  NOT NULL,
    [RegionPublic] bit  NOT NULL,
    [LanguagePublic] bit  NOT NULL,
    [OccupationPublic] bit  NOT NULL,
    [RelationshipStatusPublic] bit  NOT NULL,
    [InterestHobbyPublic] bit  NOT NULL,
    [CheckCode] uniqueidentifier  NOT NULL,
    [DateValidCheckCode] datetime  NOT NULL,
    [TotalForumPosts] int  NOT NULL,
    [ImageURL] varchar(512)  NOT NULL,
    [SecretQuestion] nvarchar(max)  NOT NULL,
    [SecretAnswer] nvarchar(max)  NOT NULL,
    [OnlyAdult] bit  NOT NULL,
    [IsAdult] bit  NOT NULL,
    [FavouriteMusic] varchar(1024)  NULL,
    [FavouriteGames] varchar(1024)  NULL,
    [FavouriteSports] varchar(1024)  NULL,
    [FavouriteVehicle] varchar(1024)  NULL,
    [FavouriteTV] varchar(1024)  NULL,
    [FavouriteRestaurant] varchar(1024)  NULL,
    [FavouriteFilm] varchar(1024)  NULL,
    [FavouriteBrand] varchar(1024)  NULL,
    [FavouriteOther] nvarchar(max)  NULL,
    [FavouriteAboutYou] nvarchar(max)  NULL,
    [FavouriteMusicPublic] bit  NOT NULL,
    [FavouriteGamesPublic] bit  NOT NULL,
    [FavouriteSportsPublic] bit  NOT NULL,
    [FavouriteVehiclePublic] bit  NOT NULL,
    [FavouriteTVPublic] bit  NOT NULL,
    [FavouriteRestaurantPublic] bit  NOT NULL,
    [FavouriteFilmPublic] bit  NOT NULL,
    [FavouriteBrandPublic] bit  NOT NULL,
    [FavouriteOtherPublic] bit  NOT NULL,
    [FavouriteAboutYoupublic] bit  NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [EPPoints] int  NOT NULL,
    [CPMPoints] decimal(18,2)  NOT NULL,
    [FullAdActiveUntil] datetime  NULL,
    [isPublic] bit  NOT NULL,
    [ActiveGallery] bit  NOT NULL,
    [ActiveVoicer] bit  NOT NULL,
    [ActiveSpread] bit  NOT NULL
);
GO

-- Creating table 'UsersActivities'
CREATE TABLE [dbo].[UsersActivities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersIPId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Type] varchar(50)  NULL,
    [Date] datetime  NOT NULL,
    [RowText] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersAttachments'
CREATE TABLE [dbo].[UsersAttachments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UserAttachAlbumId] int  NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL,
    [FileName] varchar(512)  NOT NULL,
    [Visibity] varchar(50)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [UniqueId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UsersAttachmentsAlbums'
CREATE TABLE [dbo].[UsersAttachmentsAlbums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NULL,
    [UserId] int  NOT NULL,
    [Name] varchar(512)  NOT NULL,
    [Visibility] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Active] bit  NOT NULL,
    [Cover] varchar(255)  NULL
);
GO

-- Creating table 'UsersConnections'
CREATE TABLE [dbo].[UsersConnections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ConnectedUserId] int  NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [DateConnected] datetime  NOT NULL,
    [DateRequest] datetime  NOT NULL
);
GO

-- Creating table 'UsersCPMBalances'
CREATE TABLE [dbo].[UsersCPMBalances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UsersPaymentsId] int  NULL,
    [UsersIPId] int  NULL,
    [CPMPoints] decimal(18,2)  NOT NULL,
    [Data] datetime  NOT NULL
);
GO

-- Creating table 'UsersHobbies'
CREATE TABLE [dbo].[UsersHobbies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HobbyName] varchar(512)  NULL
);
GO

-- Creating table 'UsersHobbyUsers'
CREATE TABLE [dbo].[UsersHobbyUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UsersHobbyId] int  NOT NULL
);
GO

-- Creating table 'UsersIPs'
CREATE TABLE [dbo].[UsersIPs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeatureId] int  NOT NULL,
    [CategoryId] int  NULL,
    [UserId] int  NOT NULL,
    [UserAttachmentId] int  NOT NULL,
    [Name] varchar(512)  NOT NULL,
    [DateAdd] datetime  NOT NULL,
    [BodyHtml] nvarchar(max)  NOT NULL,
    [BodyStyle] nvarchar(max)  NULL,
    [AdultOnly] bit  NOT NULL,
    [Public] bit  NOT NULL,
    [route] varchar(512)  NOT NULL,
    [Views] int  NOT NULL,
    [Comments] int  NOT NULL,
    [Likes] int  NOT NULL,
    [Dislikes] int  NOT NULL,
    [Surfs] int  NOT NULL,
    [EPPoints] int  NOT NULL
);
GO

-- Creating table 'UsersIPAds'
CREATE TABLE [dbo].[UsersIPAds] (
    [Id] int  NOT NULL,
    [TotalClicks] int  NOT NULL,
    [MaxClicks] int  NOT NULL,
    [ClickValue] decimal(18,2)  NOT NULL,
    [Active] bit  NOT NULL,
    [Data] datetime  NOT NULL,
    [Views] int  NOT NULL,
    [GenderId] int  NULL,
    [CountryId] int  NULL,
    [OcupationId] int  NULL,
    [InterestId] int  NULL,
    [DateBirth] varchar(50)  NULL,
    [Region] varchar(512)  NULL,
    [Language] varchar(512)  NULL,
    [RelationShipStatus] varchar(512)  NULL,
    [Position] int  NOT NULL
);
GO

-- Creating table 'UsersIPComments'
CREATE TABLE [dbo].[UsersIPComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UsersIPId] int  NOT NULL,
    [ParentId] int  NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [Pos] int  NOT NULL
);
GO

-- Creating table 'UsersIPEPPoints'
CREATE TABLE [dbo].[UsersIPEPPoints] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UsersIPId] int  NOT NULL,
    [EPPoints] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'UsersIPFilters'
CREATE TABLE [dbo].[UsersIPFilters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersIPId] int  NOT NULL,
    [GenderId] int  NULL,
    [CountryId] int  NULL,
    [BirthDate] varchar(1024)  NULL,
    [RelationshipStatus] varchar(1024)  NULL,
    [Region] varchar(1024)  NULL,
    [Language] varchar(1024)  NULL,
    [OccupationByComma] nvarchar(max)  NULL,
    [HobbiesByComma] nvarchar(max)  NULL
);
GO

-- Creating table 'UsersIPLikes'
CREATE TABLE [dbo].[UsersIPLikes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersIPId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [Row] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersIPSpreads'
CREATE TABLE [dbo].[UsersIPSpreads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UserIpId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [UserSentId] int  NOT NULL
);
GO

-- Creating table 'UsersIPSurfs'
CREATE TABLE [dbo].[UsersIPSurfs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersIPId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'UsersIPTags'
CREATE TABLE [dbo].[UsersIPTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserIPId] int  NOT NULL,
    [IPTagId] int  NOT NULL
);
GO

-- Creating table 'UsersOccupations'
CREATE TABLE [dbo].[UsersOccupations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Occupation] varchar(512)  NOT NULL,
    [OrderBy] int  NOT NULL
);
GO

-- Creating table 'UsersOccupationsUsers'
CREATE TABLE [dbo].[UsersOccupationsUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UsersOccupationsId] int  NOT NULL
);
GO

-- Creating table 'UsersPayments'
CREATE TABLE [dbo].[UsersPayments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [TotalCPM] decimal(18,2)  NOT NULL,
    [TotalPayed] decimal(18,2)  NOT NULL,
    [PaymentCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersRoles'
CREATE TABLE [dbo].[UsersRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Role] varchar(250)  NOT NULL,
    [RoleLevel] int  NOT NULL
);
GO

-- Creating table 'Whispers'
CREATE TABLE [dbo].[Whispers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [UserSenderId] int  NOT NULL,
    [UserReceiverId] int  NOT NULL,
    [DeleteSender] bit  NOT NULL,
    [DeleteReceiver] bit  NOT NULL,
    [ReadSender] bit  NOT NULL,
    [ReadReceiver] bit  NOT NULL,
    [DateSent] datetime  NOT NULL
);
GO

-- Creating table 'WhisperAttachments'
CREATE TABLE [dbo].[WhisperAttachments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WhisperId] int  NULL,
    [UserAttachmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Features'
ALTER TABLE [dbo].[Features]
ADD CONSTRAINT [PK_Features]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumAnswers'
ALTER TABLE [dbo].[ForumAnswers]
ADD CONSTRAINT [PK_ForumAnswers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumAnswersAttaches'
ALTER TABLE [dbo].[ForumAnswersAttaches]
ADD CONSTRAINT [PK_ForumAnswersAttaches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumAnswerVotes'
ALTER TABLE [dbo].[ForumAnswerVotes]
ADD CONSTRAINT [PK_ForumAnswerVotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumTopics'
ALTER TABLE [dbo].[ForumTopics]
ADD CONSTRAINT [PK_ForumTopics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumTopicsViews'
ALTER TABLE [dbo].[ForumTopicsViews]
ADD CONSTRAINT [PK_ForumTopicsViews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Genders'
ALTER TABLE [dbo].[Genders]
ADD CONSTRAINT [PK_Genders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IPTags'
ALTER TABLE [dbo].[IPTags]
ADD CONSTRAINT [PK_IPTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersActivities'
ALTER TABLE [dbo].[UsersActivities]
ADD CONSTRAINT [PK_UsersActivities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersAttachments'
ALTER TABLE [dbo].[UsersAttachments]
ADD CONSTRAINT [PK_UsersAttachments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersAttachmentsAlbums'
ALTER TABLE [dbo].[UsersAttachmentsAlbums]
ADD CONSTRAINT [PK_UsersAttachmentsAlbums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersConnections'
ALTER TABLE [dbo].[UsersConnections]
ADD CONSTRAINT [PK_UsersConnections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersCPMBalances'
ALTER TABLE [dbo].[UsersCPMBalances]
ADD CONSTRAINT [PK_UsersCPMBalances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersHobbies'
ALTER TABLE [dbo].[UsersHobbies]
ADD CONSTRAINT [PK_UsersHobbies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersHobbyUsers'
ALTER TABLE [dbo].[UsersHobbyUsers]
ADD CONSTRAINT [PK_UsersHobbyUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPs'
ALTER TABLE [dbo].[UsersIPs]
ADD CONSTRAINT [PK_UsersIPs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPAds'
ALTER TABLE [dbo].[UsersIPAds]
ADD CONSTRAINT [PK_UsersIPAds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPComments'
ALTER TABLE [dbo].[UsersIPComments]
ADD CONSTRAINT [PK_UsersIPComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPEPPoints'
ALTER TABLE [dbo].[UsersIPEPPoints]
ADD CONSTRAINT [PK_UsersIPEPPoints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPFilters'
ALTER TABLE [dbo].[UsersIPFilters]
ADD CONSTRAINT [PK_UsersIPFilters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPLikes'
ALTER TABLE [dbo].[UsersIPLikes]
ADD CONSTRAINT [PK_UsersIPLikes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPSpreads'
ALTER TABLE [dbo].[UsersIPSpreads]
ADD CONSTRAINT [PK_UsersIPSpreads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPSurfs'
ALTER TABLE [dbo].[UsersIPSurfs]
ADD CONSTRAINT [PK_UsersIPSurfs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersIPTags'
ALTER TABLE [dbo].[UsersIPTags]
ADD CONSTRAINT [PK_UsersIPTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersOccupations'
ALTER TABLE [dbo].[UsersOccupations]
ADD CONSTRAINT [PK_UsersOccupations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersOccupationsUsers'
ALTER TABLE [dbo].[UsersOccupationsUsers]
ADD CONSTRAINT [PK_UsersOccupationsUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersPayments'
ALTER TABLE [dbo].[UsersPayments]
ADD CONSTRAINT [PK_UsersPayments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersRoles'
ALTER TABLE [dbo].[UsersRoles]
ADD CONSTRAINT [PK_UsersRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Whispers'
ALTER TABLE [dbo].[Whispers]
ADD CONSTRAINT [PK_Whispers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WhisperAttachments'
ALTER TABLE [dbo].[WhisperAttachments]
ADD CONSTRAINT [PK_WhisperAttachments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FeatureId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Categories_Features]
    FOREIGN KEY ([FeatureId])
    REFERENCES [dbo].[Features]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Features'
CREATE INDEX [IX_FK_Categories_Features]
ON [dbo].[Categories]
    ([FeatureId]);
GO

-- Creating foreign key on [LastTopicId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Categories_ForumTopics]
    FOREIGN KEY ([LastTopicId])
    REFERENCES [dbo].[ForumTopics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_ForumTopics'
CREATE INDEX [IX_FK_Categories_ForumTopics]
ON [dbo].[Categories]
    ([LastTopicId]);
GO

-- Creating foreign key on [UserIdCreate] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Categories_Users]
    FOREIGN KEY ([UserIdCreate])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Users'
CREATE INDEX [IX_FK_Categories_Users]
ON [dbo].[Categories]
    ([UserIdCreate]);
GO

-- Creating foreign key on [LastUserId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Categories_Users1]
    FOREIGN KEY ([LastUserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Users1'
CREATE INDEX [IX_FK_Categories_Users1]
ON [dbo].[Categories]
    ([LastUserId]);
GO

-- Creating foreign key on [CategoryId] in table 'ForumTopics'
ALTER TABLE [dbo].[ForumTopics]
ADD CONSTRAINT [FK_ForumTopics_Categories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumTopics_Categories'
CREATE INDEX [IX_FK_ForumTopics_Categories]
ON [dbo].[ForumTopics]
    ([CategoryId]);
GO

-- Creating foreign key on [CategoryId] in table 'UsersIPs'
ALTER TABLE [dbo].[UsersIPs]
ADD CONSTRAINT [FK_UsersIP_Categories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIP_Categories'
CREATE INDEX [IX_FK_UsersIP_Categories]
ON [dbo].[UsersIPs]
    ([CategoryId]);
GO

-- Creating foreign key on [CountryId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Countries]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Countries'
CREATE INDEX [IX_FK_Users_Countries]
ON [dbo].[Users]
    ([CountryId]);
GO

-- Creating foreign key on [FeatureId] in table 'UsersIPs'
ALTER TABLE [dbo].[UsersIPs]
ADD CONSTRAINT [FK_UsersIP_Features]
    FOREIGN KEY ([FeatureId])
    REFERENCES [dbo].[Features]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIP_Features'
CREATE INDEX [IX_FK_UsersIP_Features]
ON [dbo].[UsersIPs]
    ([FeatureId]);
GO

-- Creating foreign key on [TopicId] in table 'ForumAnswers'
ALTER TABLE [dbo].[ForumAnswers]
ADD CONSTRAINT [FK_ForumAnswers_ForumTopics]
    FOREIGN KEY ([TopicId])
    REFERENCES [dbo].[ForumTopics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswers_ForumTopics'
CREATE INDEX [IX_FK_ForumAnswers_ForumTopics]
ON [dbo].[ForumAnswers]
    ([TopicId]);
GO

-- Creating foreign key on [UserId] in table 'ForumAnswers'
ALTER TABLE [dbo].[ForumAnswers]
ADD CONSTRAINT [FK_ForumAnswers_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswers_Users'
CREATE INDEX [IX_FK_ForumAnswers_Users]
ON [dbo].[ForumAnswers]
    ([UserId]);
GO

-- Creating foreign key on [AnswerId] in table 'ForumAnswersAttaches'
ALTER TABLE [dbo].[ForumAnswersAttaches]
ADD CONSTRAINT [FK_ForumAnswersAttach_ForumAnswers]
    FOREIGN KEY ([AnswerId])
    REFERENCES [dbo].[ForumAnswers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswersAttach_ForumAnswers'
CREATE INDEX [IX_FK_ForumAnswersAttach_ForumAnswers]
ON [dbo].[ForumAnswersAttaches]
    ([AnswerId]);
GO

-- Creating foreign key on [AnswerId] in table 'ForumAnswerVotes'
ALTER TABLE [dbo].[ForumAnswerVotes]
ADD CONSTRAINT [FK_ForumAnswerVotes_ForumAnswers]
    FOREIGN KEY ([AnswerId])
    REFERENCES [dbo].[ForumAnswers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswerVotes_ForumAnswers'
CREATE INDEX [IX_FK_ForumAnswerVotes_ForumAnswers]
ON [dbo].[ForumAnswerVotes]
    ([AnswerId]);
GO

-- Creating foreign key on [AnswerId] in table 'ForumTopics'
ALTER TABLE [dbo].[ForumTopics]
ADD CONSTRAINT [FK_ForumTopics_ForumAnswers]
    FOREIGN KEY ([AnswerId])
    REFERENCES [dbo].[ForumAnswers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumTopics_ForumAnswers'
CREATE INDEX [IX_FK_ForumTopics_ForumAnswers]
ON [dbo].[ForumTopics]
    ([AnswerId]);
GO

-- Creating foreign key on [UserAttachmentId] in table 'ForumAnswersAttaches'
ALTER TABLE [dbo].[ForumAnswersAttaches]
ADD CONSTRAINT [FK_ForumAnswersAttach_UsersAttachments]
    FOREIGN KEY ([UserAttachmentId])
    REFERENCES [dbo].[UsersAttachments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswersAttach_UsersAttachments'
CREATE INDEX [IX_FK_ForumAnswersAttach_UsersAttachments]
ON [dbo].[ForumAnswersAttaches]
    ([UserAttachmentId]);
GO

-- Creating foreign key on [UserId] in table 'ForumAnswerVotes'
ALTER TABLE [dbo].[ForumAnswerVotes]
ADD CONSTRAINT [FK_ForumAnswerVotes_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswerVotes_Users'
CREATE INDEX [IX_FK_ForumAnswerVotes_Users]
ON [dbo].[ForumAnswerVotes]
    ([UserId]);
GO

-- Creating foreign key on [TopicId] in table 'ForumTopicsViews'
ALTER TABLE [dbo].[ForumTopicsViews]
ADD CONSTRAINT [FK_ForumAnswersViews_ForumTopics]
    FOREIGN KEY ([TopicId])
    REFERENCES [dbo].[ForumTopics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswersViews_ForumTopics'
CREATE INDEX [IX_FK_ForumAnswersViews_ForumTopics]
ON [dbo].[ForumTopicsViews]
    ([TopicId]);
GO

-- Creating foreign key on [UserId] in table 'ForumTopics'
ALTER TABLE [dbo].[ForumTopics]
ADD CONSTRAINT [FK_ForumTopics_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumTopics_Users'
CREATE INDEX [IX_FK_ForumTopics_Users]
ON [dbo].[ForumTopics]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ForumTopicsViews'
ALTER TABLE [dbo].[ForumTopicsViews]
ADD CONSTRAINT [FK_ForumAnswersViews_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForumAnswersViews_Users'
CREATE INDEX [IX_FK_ForumAnswersViews_Users]
ON [dbo].[ForumTopicsViews]
    ([UserId]);
GO

-- Creating foreign key on [GenderId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Genders]
    FOREIGN KEY ([GenderId])
    REFERENCES [dbo].[Genders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Genders'
CREATE INDEX [IX_FK_Users_Genders]
ON [dbo].[Users]
    ([GenderId]);
GO

-- Creating foreign key on [IPTagId] in table 'UsersIPTags'
ALTER TABLE [dbo].[UsersIPTags]
ADD CONSTRAINT [FK_UserIPTags_IPTag]
    FOREIGN KEY ([IPTagId])
    REFERENCES [dbo].[IPTags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserIPTags_IPTag'
CREATE INDEX [IX_FK_UserIPTags_IPTag]
ON [dbo].[UsersIPTags]
    ([IPTagId]);
GO

-- Creating foreign key on [UserId] in table 'UsersIPSpreads'
ALTER TABLE [dbo].[UsersIPSpreads]
ADD CONSTRAINT [FK_UserIPSpreads_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserIPSpreads_Users'
CREATE INDEX [IX_FK_UserIPSpreads_Users]
ON [dbo].[UsersIPSpreads]
    ([UserId]);
GO

-- Creating foreign key on [UserSentId] in table 'UsersIPSpreads'
ALTER TABLE [dbo].[UsersIPSpreads]
ADD CONSTRAINT [FK_UserIPSpreads_Users1]
    FOREIGN KEY ([UserSentId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserIPSpreads_Users1'
CREATE INDEX [IX_FK_UserIPSpreads_Users1]
ON [dbo].[UsersIPSpreads]
    ([UserSentId]);
GO

-- Creating foreign key on [CurrentUserIPDI] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_UsersIP]
    FOREIGN KEY ([CurrentUserIPDI])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_UsersIP'
CREATE INDEX [IX_FK_Users_UsersIP]
ON [dbo].[Users]
    ([CurrentUserIPDI]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_UsersRoles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[UsersRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_UsersRoles'
CREATE INDEX [IX_FK_Users_UsersRoles]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'UsersActivities'
ALTER TABLE [dbo].[UsersActivities]
ADD CONSTRAINT [FK_UsersActivity_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersActivity_Users'
CREATE INDEX [IX_FK_UsersActivity_Users]
ON [dbo].[UsersActivities]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersAttachments'
ALTER TABLE [dbo].[UsersAttachments]
ADD CONSTRAINT [FK_UsersAttachments_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersAttachments_Users'
CREATE INDEX [IX_FK_UsersAttachments_Users]
ON [dbo].[UsersAttachments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersAttachmentsAlbums'
ALTER TABLE [dbo].[UsersAttachmentsAlbums]
ADD CONSTRAINT [FK_UsersAttachmentsAlbums_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersAttachmentsAlbums_Users'
CREATE INDEX [IX_FK_UsersAttachmentsAlbums_Users]
ON [dbo].[UsersAttachmentsAlbums]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersConnections'
ALTER TABLE [dbo].[UsersConnections]
ADD CONSTRAINT [FK_UsersConnections_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersConnections_Users'
CREATE INDEX [IX_FK_UsersConnections_Users]
ON [dbo].[UsersConnections]
    ([UserId]);
GO

-- Creating foreign key on [ConnectedUserId] in table 'UsersConnections'
ALTER TABLE [dbo].[UsersConnections]
ADD CONSTRAINT [FK_UsersConnections_Users1]
    FOREIGN KEY ([ConnectedUserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersConnections_Users1'
CREATE INDEX [IX_FK_UsersConnections_Users1]
ON [dbo].[UsersConnections]
    ([ConnectedUserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersCPMBalances'
ALTER TABLE [dbo].[UsersCPMBalances]
ADD CONSTRAINT [FK_UsersCPMBalance_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersCPMBalance_Users'
CREATE INDEX [IX_FK_UsersCPMBalance_Users]
ON [dbo].[UsersCPMBalances]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersIPEPPoints'
ALTER TABLE [dbo].[UsersIPEPPoints]
ADD CONSTRAINT [FK_UsersEPPoints_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersEPPoints_Users'
CREATE INDEX [IX_FK_UsersEPPoints_Users]
ON [dbo].[UsersIPEPPoints]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersHobbyUsers'
ALTER TABLE [dbo].[UsersHobbyUsers]
ADD CONSTRAINT [FK_UsersHobbyUsers_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersHobbyUsers_Users'
CREATE INDEX [IX_FK_UsersHobbyUsers_Users]
ON [dbo].[UsersHobbyUsers]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersIPs'
ALTER TABLE [dbo].[UsersIPs]
ADD CONSTRAINT [FK_UsersIP_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIP_Users'
CREATE INDEX [IX_FK_UsersIP_Users]
ON [dbo].[UsersIPs]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersIPComments'
ALTER TABLE [dbo].[UsersIPComments]
ADD CONSTRAINT [FK_UsersIPComments_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPComments_Users'
CREATE INDEX [IX_FK_UsersIPComments_Users]
ON [dbo].[UsersIPComments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersIPLikes'
ALTER TABLE [dbo].[UsersIPLikes]
ADD CONSTRAINT [FK_UsersIPLikes_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPLikes_Users'
CREATE INDEX [IX_FK_UsersIPLikes_Users]
ON [dbo].[UsersIPLikes]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersIPSurfs'
ALTER TABLE [dbo].[UsersIPSurfs]
ADD CONSTRAINT [FK_UsersIPSurf_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPSurf_Users'
CREATE INDEX [IX_FK_UsersIPSurf_Users]
ON [dbo].[UsersIPSurfs]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersOccupationsUsers'
ALTER TABLE [dbo].[UsersOccupationsUsers]
ADD CONSTRAINT [FK_UsersOccupationsUsers_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersOccupationsUsers_Users'
CREATE INDEX [IX_FK_UsersOccupationsUsers_Users]
ON [dbo].[UsersOccupationsUsers]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UsersPayments'
ALTER TABLE [dbo].[UsersPayments]
ADD CONSTRAINT [FK_UsersPayments_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersPayments_Users'
CREATE INDEX [IX_FK_UsersPayments_Users]
ON [dbo].[UsersPayments]
    ([UserId]);
GO

-- Creating foreign key on [UserReceiverId] in table 'Whispers'
ALTER TABLE [dbo].[Whispers]
ADD CONSTRAINT [FK_Whisper_Users]
    FOREIGN KEY ([UserReceiverId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Whisper_Users'
CREATE INDEX [IX_FK_Whisper_Users]
ON [dbo].[Whispers]
    ([UserReceiverId]);
GO

-- Creating foreign key on [UserSenderId] in table 'Whispers'
ALTER TABLE [dbo].[Whispers]
ADD CONSTRAINT [FK_Whisper_Users1]
    FOREIGN KEY ([UserSenderId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Whisper_Users1'
CREATE INDEX [IX_FK_Whisper_Users1]
ON [dbo].[Whispers]
    ([UserSenderId]);
GO

-- Creating foreign key on [UsersIPId] in table 'UsersActivities'
ALTER TABLE [dbo].[UsersActivities]
ADD CONSTRAINT [FK_UsersActivity_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersActivity_UsersIP'
CREATE INDEX [IX_FK_UsersActivity_UsersIP]
ON [dbo].[UsersActivities]
    ([UsersIPId]);
GO

-- Creating foreign key on [UserAttachAlbumId] in table 'UsersAttachments'
ALTER TABLE [dbo].[UsersAttachments]
ADD CONSTRAINT [FK_UsersAttachments_UsersAttachmentsAlbums]
    FOREIGN KEY ([UserAttachAlbumId])
    REFERENCES [dbo].[UsersAttachmentsAlbums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersAttachments_UsersAttachmentsAlbums'
CREATE INDEX [IX_FK_UsersAttachments_UsersAttachmentsAlbums]
ON [dbo].[UsersAttachments]
    ([UserAttachAlbumId]);
GO

-- Creating foreign key on [UserAttachmentId] in table 'UsersIPs'
ALTER TABLE [dbo].[UsersIPs]
ADD CONSTRAINT [FK_UsersIP_UsersAttachments]
    FOREIGN KEY ([UserAttachmentId])
    REFERENCES [dbo].[UsersAttachments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIP_UsersAttachments'
CREATE INDEX [IX_FK_UsersIP_UsersAttachments]
ON [dbo].[UsersIPs]
    ([UserAttachmentId]);
GO

-- Creating foreign key on [UserAttachmentId] in table 'WhisperAttachments'
ALTER TABLE [dbo].[WhisperAttachments]
ADD CONSTRAINT [FK_WhisperAttachments_UsersAttachments]
    FOREIGN KEY ([UserAttachmentId])
    REFERENCES [dbo].[UsersAttachments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WhisperAttachments_UsersAttachments'
CREATE INDEX [IX_FK_WhisperAttachments_UsersAttachments]
ON [dbo].[WhisperAttachments]
    ([UserAttachmentId]);
GO

-- Creating foreign key on [ParentId] in table 'UsersAttachmentsAlbums'
ALTER TABLE [dbo].[UsersAttachmentsAlbums]
ADD CONSTRAINT [FK_UsersAttachmentsAlbums_UsersAttachmentsAlbums]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[UsersAttachmentsAlbums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersAttachmentsAlbums_UsersAttachmentsAlbums'
CREATE INDEX [IX_FK_UsersAttachmentsAlbums_UsersAttachmentsAlbums]
ON [dbo].[UsersAttachmentsAlbums]
    ([ParentId]);
GO

-- Creating foreign key on [UsersIPId] in table 'UsersCPMBalances'
ALTER TABLE [dbo].[UsersCPMBalances]
ADD CONSTRAINT [FK_UsersCPMBalance_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersCPMBalance_UsersIP'
CREATE INDEX [IX_FK_UsersCPMBalance_UsersIP]
ON [dbo].[UsersCPMBalances]
    ([UsersIPId]);
GO

-- Creating foreign key on [UsersPaymentsId] in table 'UsersCPMBalances'
ALTER TABLE [dbo].[UsersCPMBalances]
ADD CONSTRAINT [FK_UsersCPMBalance_UsersPayments]
    FOREIGN KEY ([UsersPaymentsId])
    REFERENCES [dbo].[UsersPayments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersCPMBalance_UsersPayments'
CREATE INDEX [IX_FK_UsersCPMBalance_UsersPayments]
ON [dbo].[UsersCPMBalances]
    ([UsersPaymentsId]);
GO

-- Creating foreign key on [UsersHobbyId] in table 'UsersHobbyUsers'
ALTER TABLE [dbo].[UsersHobbyUsers]
ADD CONSTRAINT [FK_UsersHobbyUsers_UsersHobby]
    FOREIGN KEY ([UsersHobbyId])
    REFERENCES [dbo].[UsersHobbies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersHobbyUsers_UsersHobby'
CREATE INDEX [IX_FK_UsersHobbyUsers_UsersHobby]
ON [dbo].[UsersHobbyUsers]
    ([UsersHobbyId]);
GO

-- Creating foreign key on [UserIpId] in table 'UsersIPSpreads'
ALTER TABLE [dbo].[UsersIPSpreads]
ADD CONSTRAINT [FK_UserIPSpreads_UsersIP]
    FOREIGN KEY ([UserIpId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserIPSpreads_UsersIP'
CREATE INDEX [IX_FK_UserIPSpreads_UsersIP]
ON [dbo].[UsersIPSpreads]
    ([UserIpId]);
GO

-- Creating foreign key on [UserIPId] in table 'UsersIPTags'
ALTER TABLE [dbo].[UsersIPTags]
ADD CONSTRAINT [FK_UserIPTags_UsersIP]
    FOREIGN KEY ([UserIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserIPTags_UsersIP'
CREATE INDEX [IX_FK_UserIPTags_UsersIP]
ON [dbo].[UsersIPTags]
    ([UserIPId]);
GO

-- Creating foreign key on [UsersIPId] in table 'UsersIPEPPoints'
ALTER TABLE [dbo].[UsersIPEPPoints]
ADD CONSTRAINT [FK_UsersEPPoints_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersEPPoints_UsersIP'
CREATE INDEX [IX_FK_UsersEPPoints_UsersIP]
ON [dbo].[UsersIPEPPoints]
    ([UsersIPId]);
GO

-- Creating foreign key on [Id] in table 'UsersIPAds'
ALTER TABLE [dbo].[UsersIPAds]
ADD CONSTRAINT [FK_UsersIPAds_UsersIP]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UsersIPId] in table 'UsersIPComments'
ALTER TABLE [dbo].[UsersIPComments]
ADD CONSTRAINT [FK_UsersIPComments_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPComments_UsersIP'
CREATE INDEX [IX_FK_UsersIPComments_UsersIP]
ON [dbo].[UsersIPComments]
    ([UsersIPId]);
GO

-- Creating foreign key on [UsersIPId] in table 'UsersIPFilters'
ALTER TABLE [dbo].[UsersIPFilters]
ADD CONSTRAINT [FK_UsersIPFilter_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPFilter_UsersIP'
CREATE INDEX [IX_FK_UsersIPFilter_UsersIP]
ON [dbo].[UsersIPFilters]
    ([UsersIPId]);
GO

-- Creating foreign key on [UsersIPId] in table 'UsersIPLikes'
ALTER TABLE [dbo].[UsersIPLikes]
ADD CONSTRAINT [FK_UsersIPLikes_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPLikes_UsersIP'
CREATE INDEX [IX_FK_UsersIPLikes_UsersIP]
ON [dbo].[UsersIPLikes]
    ([UsersIPId]);
GO

-- Creating foreign key on [UsersIPId] in table 'UsersIPSurfs'
ALTER TABLE [dbo].[UsersIPSurfs]
ADD CONSTRAINT [FK_UsersIPSurf_UsersIP]
    FOREIGN KEY ([UsersIPId])
    REFERENCES [dbo].[UsersIPs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPSurf_UsersIP'
CREATE INDEX [IX_FK_UsersIPSurf_UsersIP]
ON [dbo].[UsersIPSurfs]
    ([UsersIPId]);
GO

-- Creating foreign key on [ParentId] in table 'UsersIPComments'
ALTER TABLE [dbo].[UsersIPComments]
ADD CONSTRAINT [FK_UsersIPComments_UsersIPComments]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[UsersIPComments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersIPComments_UsersIPComments'
CREATE INDEX [IX_FK_UsersIPComments_UsersIPComments]
ON [dbo].[UsersIPComments]
    ([ParentId]);
GO

-- Creating foreign key on [UsersOccupationsId] in table 'UsersOccupationsUsers'
ALTER TABLE [dbo].[UsersOccupationsUsers]
ADD CONSTRAINT [FK_UsersOccupationsUsers_UsersOccupations]
    FOREIGN KEY ([UsersOccupationsId])
    REFERENCES [dbo].[UsersOccupations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersOccupationsUsers_UsersOccupations'
CREATE INDEX [IX_FK_UsersOccupationsUsers_UsersOccupations]
ON [dbo].[UsersOccupationsUsers]
    ([UsersOccupationsId]);
GO

-- Creating foreign key on [WhisperId] in table 'WhisperAttachments'
ALTER TABLE [dbo].[WhisperAttachments]
ADD CONSTRAINT [FK_WhisperAttachments_Whisper]
    FOREIGN KEY ([WhisperId])
    REFERENCES [dbo].[Whispers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WhisperAttachments_Whisper'
CREATE INDEX [IX_FK_WhisperAttachments_Whisper]
ON [dbo].[WhisperAttachments]
    ([WhisperId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------