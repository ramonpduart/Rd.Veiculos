USE [master]
GO
/****** Object:  Database [testes-integrados]    Script Date: 08/03/2024 11:24:10 ******/
CREATE DATABASE [testes-integrados]
GO
ALTER DATABASE [testes-integrados] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testes-integrados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [testes-integrados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [testes-integrados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [testes-integrados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [testes-integrados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [testes-integrados] SET ARITHABORT OFF 
GO
ALTER DATABASE [testes-integrados] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [testes-integrados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [testes-integrados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [testes-integrados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [testes-integrados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [testes-integrados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [testes-integrados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [testes-integrados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [testes-integrados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [testes-integrados] SET  DISABLE_BROKER 
GO
ALTER DATABASE [testes-integrados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [testes-integrados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [testes-integrados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [testes-integrados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [testes-integrados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [testes-integrados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [testes-integrados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [testes-integrados] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [testes-integrados] SET  MULTI_USER 
GO
ALTER DATABASE [testes-integrados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [testes-integrados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [testes-integrados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [testes-integrados] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [testes-integrados] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [testes-integrados] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [testes-integrados] SET QUERY_STORE = OFF
GO
USE [testes-integrados]
GO
/****** Object:  Table [dbo].[veiculo]    Script Date: 08/03/2024 11:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[veiculo](
	[id] [uniqueidentifier] NOT NULL,
	[marca] [varchar](100) NOT NULL,
	[modelo] [varchar](200) NOT NULL,
	[ano_fabricacao] [int] NULL,
	[ano_modelo] [int] NULL,
	[quantidade_lugares] [tinyint] NULL,
	[categoria] [varchar](50) NULL,
	[data_criacao] [datetime] NOT NULL,
	[data_alteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [testes-integrados] SET  READ_WRITE 
GO
