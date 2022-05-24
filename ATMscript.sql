USE [master]
GO
/****** Object:  Database [AtmDB]    Script Date: 5/24/2022 6:28:48 PM ******/
CREATE DATABASE [AtmDB] ON  PRIMARY 
( NAME = N'AtmDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\AtmDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AtmDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\AtmDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AtmDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AtmDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AtmDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AtmDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AtmDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AtmDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AtmDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AtmDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AtmDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AtmDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AtmDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AtmDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AtmDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AtmDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AtmDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AtmDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AtmDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AtmDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AtmDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AtmDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AtmDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AtmDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AtmDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AtmDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AtmDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AtmDB] SET  MULTI_USER 
GO
ALTER DATABASE [AtmDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AtmDB] SET DB_CHAINING OFF 
GO
USE [AtmDB]
GO
/****** Object:  Table [dbo].[bank]    Script Date: 5/24/2022 6:28:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bank](
	[balance] [int] NULL,
	[bid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credentials]    Script Date: 5/24/2022 6:28:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credentials](
	[Name] [varchar](50) NOT NULL,
	[Pin] [int] NOT NULL,
 CONSTRAINT [PK_Credentials_1] PRIMARY KEY CLUSTERED 
(
	[Pin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AtmDB] SET  READ_WRITE 
GO
