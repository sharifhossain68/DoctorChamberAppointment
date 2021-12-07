USE [master]
GO
/****** Object:  Database [DoctorAppointmentDb]    Script Date: 25-Apr-19 3:23:43 AM ******/
CREATE DATABASE [DoctorAppointmentDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoctorAppointmentDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DoctorAppointmentDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DoctorAppointmentDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DoctorAppointmentDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DoctorAppointmentDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoctorAppointmentDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoctorAppointmentDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoctorAppointmentDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoctorAppointmentDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DoctorAppointmentDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoctorAppointmentDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoctorAppointmentDb] SET  MULTI_USER 
GO
ALTER DATABASE [DoctorAppointmentDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoctorAppointmentDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoctorAppointmentDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoctorAppointmentDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DoctorAppointmentDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DoctorAppointmentDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 25-Apr-19 3:23:43 AM ******/
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
/****** Object:  Table [dbo].[Countries]    Script Date: 25-Apr-19 3:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logins]    Script Date: 25-Apr-19 3:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logins](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsActive] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Logins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registers]    Script Date: 25-Apr-19 3:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Email] [varchar](8000) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ConfirmPassword] [varchar](50) NOT NULL,
	[IsActive] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Registers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25-Apr-19 3:23:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201904192112056_ContriesLoginRegistersRoleAdded', N'DoctorChamberAppointmentMangementSystem.Migrations.Configuration', 0x1F8B0800000000000400E55ADB6EE336107D2FD07F10F4D40259CB4EB0C036907791DA4911343744D97DA7A5B14394A254924AED6FEB433FA9BFD0A1EED6C5B21DDFDA222F16C939339C391C7146F9FBCFBFEC2F739F196F20240DF8D01CF4FAA601DC0D3CCA67433352D30F9FCC2F9FBFFFCEBEF6FCB9F12D5B77A1D7A1249743F355A9F0D2B2A4FB0A3E913D9FBA2290C154F5DCC0B7881758E7FDFE4FD66060014298886518F673C415F5217EC0C751C05D085544D87DE00193E938CE3831AAF1407C90217161688E03570562F44AFC0988AB300C28573E70754FF80CF40F672115F8BD04A9778D8AD4C234AE182568AC036C6A1A84F34011855BB9FC2AC15122E03327C401C25E1621E0BA296112D22D5E16CBD7DD6DFF5CEFD62A04332837922AF037041C5CA4EEB3AAE25B05C1CCDD8B0E4EFCA3771D3B79688E028C8D408F55755D8E98D0EBB60C412F053E33DAC413A9B39C654846FD77668C22A62201430E9112849D194FD18451F75758BC04BF011FF288B1F2A6705B38B73480434F220841A8C5334C97B77AEB9986B52C6E55E573E9BA68E2935BAE2ECE4DE3014D21130639834AFE7370D7F00B70104481F74494028104B8F520E5A8B58E4AFD902945E6E239358D7B32BF033E53AF43137F9AC60D9D83978DA4867CE5148F350A29114183A165E5B655D0622559EE8219E5BBA74A0C7B4244C12421B661492677288A687D1DFC18F4FBEFE7475DF31391F28F40782B347FDC8BE25B79E52AFA065D4EDE8ADECF30A34835B17B8667C82744F26D08FEFF20F7B54F28DB77CE6D4DF89B30FB840E26DEE9A654F847D3FF1C30D02ADFE7BEFDA61734710FA905514F28AD6873B6492D99DCA1D28BD677FCBB159E1A4528EE21B52A0963297EE3895E0273D5401CCC902977646ACAF28E13150EA822C1E026419A4661525222F5F2DC63AD86482F8035F974BC433A790B8AD8FA262B8AF76F171006AF11203E614DEECF1D5DD49A56526C6645A9D55295DAF7240C911AA52A351D319CA4441D7D70362FCCFC04C37265437D965B9B6B42569019546675483DB8A142AA3151644234F9469E5F5BB682562D8ECE145798533DFF45043201FDBBCCE52DCBC6AAA6C2EB37E8082D1DFB0472838BF7674D32EE2B1046447B51370A58E4F38E32710DAC24A334A02513753CDBAA6CABEA61ABE6E24A62AD866CAD8026E775FFD16CD4B3462C5BE4DABC9F155E65C73717715D28F50016A3EB2315B7A0325231BA3E527121292315A327C3A8E5DCBE7F66E5EF8ACDC9D52EDA1A854A248FC5ABB43229C3A4431B67AAC62C751C8ED74A8765CB2A93EBE316254119B018FD2F9EC2F8627480D3A72F5A5B9CBC46B155F1AB9EBCE6F2A20BA57EFA8AD103C7AE7621AD2EC9B5E717D3CA05D44E2F83DDDF4E6AB7C3648969A08BDEA8A76F866974F5829EF33B1B318AFB2D16200BE814A44A6A42F3BC3F38AF7C5B399DEF1C96941E5BEF63C7913F1E50EDE2CEFA75BBF651B9A6E56F44B8AF44FCE093F98FBBFD0670B4AEFA5E7C57ED35A67EAB371BDFD98D6BC2FDB8396CB54B15FB64C72DF0837794FF55815D6A1137817EEA6F815AE9007787F5608C6BE9EEEE08BDDABBDD66E3FB3C13B55BCB215BA17B3917D5EEE7EEDE14D58E66BD43D5D9A44CCE407B8F32B9C50C4D6F12A0FD899DC964DCDC7C5F0BB3093C9EEA462EDA972B3A9B4DF8D9EC1A2AE206674BDFB3113AE9946ED912ADDF346DABFCBF3CF618249D1510FA3F7B38B8FA0A5780666B6EF934C868883B2A5B942DA9B0F41E14F190365742D12971154EBB2065DCA7FF46581427E20978B7FC315261A4AEA4047FC296CA58DB5AAD3FEEFB2EDB6C3F86711763175B4033296E011EF9CF11655E6EF74DC3B96A81D027283DFA6895A37B2C305BE4480F015F132875DF1842E03A71BC801F3204938FDC213A736E6E1BBE5FEF6046DC455630B483740762D9EDF698929920BE4C310A797C440E7BFEFCF33FB63EA066D2260000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201904242059509_RegisterChangByPropertyName', N'DoctorChamberAppointmentMangementSystem.Migrations.Configuration', 0x1F8B0800000000000400E55ADB6EE336107D2FD07F10F4D40259CB4EB0C036907791DA4961343744D97DA7A5B14394A254924AED6FEB433FA9BFD0A1EED6C5961D3BF6A2C88B4572CE0C670EA99951FEFDFB1FFBCBC267C62B0849033E3407BDBE690077038FF2F9D08CD4ECC327F3CBE71F7FB0AF3D7F617CCBD65DE87528C9E5D07C512ABCB42CE9BE804F64CFA7AE086430533D37F02DE205D679BFFF8B351858801026621986FD1471457D881FF071147017421511761778C0643A8E334E8C6ADC131F64485C189AE3C0558118BD107F0AE22A0C03CA950F5CDD113E07FDC3594A057E2F41EA5DA322B5348D2B46091AEB009B9906E13C5044E1562EBF4A709408F8DC097180B0E76508B86E469884748B97C5F2AEBBED9FEBDD5A856006E5465205FE9680838BD47D56557CA72098B97BD1C1897FF4AE63270FCD5180B111E8B1AAAECB11137ADD8E21E8A5C067469B78227596B30CC9A8FFCE8C51C4542460C8215282B033E3319A32EAFE0ECBE7E00FE0431E3156DE146E0BE7560670E851042108B57C82D9EA56279E6958ABE256553E97AE8B263E997075716E1AF7680A9932C81954F29F83BB86DF8083200ABC47A2140824C0C48394A3561795FA21538ACCC5736A1A7764710B7CAE5E8626FE348D1BBA002F1B490DF9CA291E6B145222820643CBCA6DABA0C55AB2DC0673CAF74F9518F68488829784D8852599DC7B5144EBDBC08F41BFFF767ED4353F1229FF0A84B746F3C783289EC82B57D157D8E4E49DE8FD04738A5413FB6778867C4224DF85E0FF0F725FFB84B243DFB92774A6301D9B51E11F517FC797EB7A98A780C15B310E7BBDA08107B85A10F584AE952C0ADB5E2DDDA2B7BFEB45EB3B7E6E85474F118A7B48AD4AC2588ADF78AA97C0423510076FC8943B32356575C7890A075471CE7093204DA3302929917A791560AD874813C09A7C3ABE413A790B8AD8FA262B8AF7EF26200C5E23407CC29ADC9F3BBAA835ADA4D8CC8A52ABA52AB5EF481822354A556A3A623849893AFAE06C5F98F90986E5CA86FA2CB736D784AC2073A8CCEA907A7043855463A2C89468F28D3CBFB66C0DAD5A1C9D29AE30A77AFE8B086402FA7799CB3B968D554D85D76FD0115A3AF609E40617956C4D32EE2B104644FB7B6714B0C8E71BCAC40E58C98DD280964CD4F16CABB2ADAA87AD9A8B2B176B35649D029A9CD7C347B3514F8758B6C8B5793F2BBCCA8E6F2EE236A1D403588C76472A52A9325231DA1DA94848CA48C5E8C9306AF56E3F3CB3F277C5F6E46A176D8D422592C7E2555A999461D2A16370B35637ACDE7B95C9ADEFD2BDDCCB595A59066A4E51D7C6FFBB39857162F40EA74F275A3B9CBC46B1C3C6AE48F4AB38477927D712D2EA925C7B9E985612503B4D06377F3BA96587C912D34017BD524F67866974F5829EF3271B318AFB2D16200BE80CA44A6A42F3BC3F38AF7C5B399DEF1C96941EEBF6B1E3C81F0FA876F1C6FA75B72E4AB9A6E5AF44B82F44FCE493C5CFFBFD0670B4AEFA417C57ED35A67EAB371BDFD8D26BC2FDB83D6CB54B15FB64CF2DF077EF287F57815D691137817EEA9F0E5D5AFABB7B436FBADDDED4BBDD05E19067A296B5BC672BF420E7A2DAFDDCDF9BA2DAD1AC77A8363629934E647B8F32C96286A6370DD0FEC4CE64326E6EBEAD85D9041E4F6D462EDA976B3A9B4DF8D96C07157183B3A5EFD9089D744A776C89D6334DDB2AFF2F8F3D0649E70584FECF1E0EAE4EE10AD06CCD84CF828C86B8A3B245D9920A4BEF40110F697325149D1157E1B40B52C67DFA6F8445F1453C056FC21F221546EA4A4AF0A76CA58D6D5BEBF5C77DDF559BED8730EE62EC630B6826C52DC003FF35A2CCCBEDBE6938572D10FA04A5471FAD72748F05E6CB1CE93EE01D8152F78D2104AE2F8E67F0438660F2813B44DF9CDBDB86EFD75B98137799150CED209B03B1EA767B4CC95C105FA618853C3E22873D7FF1F93F9AA0082AD2260000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (1, N'Bangladesh')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (2, N'India')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (3, N'Pakistan')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (4, N'Singapur')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (5, N'America')
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Doctor')
SET IDENTITY_INSERT [dbo].[Roles] OFF
ALTER TABLE [dbo].[Registers] ADD  DEFAULT ((0)) FOR [CountryId]
GO
ALTER TABLE [dbo].[Registers] ADD  DEFAULT ((0)) FOR [RoleId]
GO
USE [master]
GO
ALTER DATABASE [DoctorAppointmentDb] SET  READ_WRITE 
GO
