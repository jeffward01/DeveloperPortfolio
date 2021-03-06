USE [master]
GO
/****** Object:  Database [PortfolioContext]    Script Date: 7/24/2017 8:01:20 AM ******/
CREATE DATABASE [PortfolioContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PortfolioContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PortfolioContext.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PortfolioContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PortfolioContext_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PortfolioContext] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PortfolioContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PortfolioContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PortfolioContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PortfolioContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PortfolioContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PortfolioContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [PortfolioContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PortfolioContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PortfolioContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PortfolioContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PortfolioContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PortfolioContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PortfolioContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PortfolioContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PortfolioContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PortfolioContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PortfolioContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PortfolioContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PortfolioContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PortfolioContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PortfolioContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PortfolioContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PortfolioContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PortfolioContext] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PortfolioContext] SET  MULTI_USER 
GO
ALTER DATABASE [PortfolioContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PortfolioContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PortfolioContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PortfolioContext] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PortfolioContext] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PortfolioContext]
GO
/****** Object:  User [portUser]    Script Date: 7/24/2017 8:01:21 AM ******/
CREATE USER [portUser] FOR LOGIN [portUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [portUser]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/24/2017 8:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Emails]    Script Date: 7/24/2017 8:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emails](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Emails] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectImages]    Script Date: 7/24/2017 8:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImages](
	[ProjectImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[FeaturedImage] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProjectImages] PRIMARY KEY CLUSTERED 
(
	[ProjectImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 7/24/2017 8:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](max) NULL,
	[ShortDesc] [nvarchar](max) NULL,
	[ProjectSummary] [nvarchar](max) NULL,
	[RepoUrl] [nvarchar](max) NULL,
	[FeaturedProject] [bit] NOT NULL,
	[BlockchainProject] [bit] NOT NULL,
	[ProjectUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectTechnologies]    Script Date: 7/24/2017 8:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTechnologies](
	[ProjectTechnologyId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[TechnologyName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ProjectTechnologies] PRIMARY KEY CLUSTERED 
(
	[ProjectTechnologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_ProjectId]    Script Date: 7/24/2017 8:01:21 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectId] ON [dbo].[ProjectImages]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectId]    Script Date: 7/24/2017 8:01:21 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectId] ON [dbo].[ProjectTechnologies]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProjectImages_dbo.Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectImages] CHECK CONSTRAINT [FK_dbo.ProjectImages_dbo.Projects_ProjectId]
GO
ALTER TABLE [dbo].[ProjectTechnologies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProjectTechnologies_dbo.Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectTechnologies] CHECK CONSTRAINT [FK_dbo.ProjectTechnologies_dbo.Projects_ProjectId]
GO
USE [master]
GO
ALTER DATABASE [PortfolioContext] SET  READ_WRITE 
GO
