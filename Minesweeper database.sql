USE [master]
GO
/****** Object:  Database [MinesweeperTester]    Script Date: 3/26/2021 8:42:49 PM ******/
CREATE DATABASE [MinesweeperTester]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MinesweeperTester', FILENAME = N'C:\Users\flame\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MinesweeperTester.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MinesweeperTester_log', FILENAME = N'C:\Users\flame\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MinesweeperTester.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MinesweeperTester] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MinesweeperTester].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MinesweeperTester] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MinesweeperTester] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MinesweeperTester] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MinesweeperTester] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MinesweeperTester] SET ARITHABORT ON 
GO
ALTER DATABASE [MinesweeperTester] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MinesweeperTester] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MinesweeperTester] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MinesweeperTester] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MinesweeperTester] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MinesweeperTester] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MinesweeperTester] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MinesweeperTester] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MinesweeperTester] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MinesweeperTester] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MinesweeperTester] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MinesweeperTester] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MinesweeperTester] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MinesweeperTester] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MinesweeperTester] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MinesweeperTester] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MinesweeperTester] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MinesweeperTester] SET RECOVERY FULL 
GO
ALTER DATABASE [MinesweeperTester] SET  MULTI_USER 
GO
ALTER DATABASE [MinesweeperTester] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MinesweeperTester] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MinesweeperTester] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MinesweeperTester] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MinesweeperTester] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MinesweeperTester] SET QUERY_STORE = OFF
GO
USE [MinesweeperTester]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MinesweeperTester]
GO
/****** Object:  Table [dbo].[highScores]    Script Date: 3/26/2021 8:42:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[highScores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[user] [int] NOT NULL,
	[timespan] [bigint] NOT NULL,
	[difficulty] [int] NOT NULL,
	[boardsize] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[savedGames]    Script Date: 3/26/2021 8:42:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[savedGames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[turns] [int] NOT NULL,
	[size] [int] NOT NULL,
	[difficulty] [int] NOT NULL,
	[timer] [int] NOT NULL,
	[jsonData] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 3/26/2021 8:42:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL,
	[sex] [nvarchar](50) NOT NULL,
	[state] [nvarchar](50) NOT NULL,
	[email_address] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[highScores]  WITH CHECK ADD FOREIGN KEY([user])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[savedGames]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[users] ([Id])
GO
USE [master]
GO
ALTER DATABASE [MinesweeperTester] SET  READ_WRITE 
GO
