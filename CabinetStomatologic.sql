USE [master]
GO
/****** Object:  Database [CabinetStomatologic]    Script Date: 03-Sep-20 10:20:18 PM ******/
CREATE DATABASE [CabinetStomatologic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CabinetStomatologic', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CabinetStomatologic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CabinetStomatologic_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CabinetStomatologic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CabinetStomatologic] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CabinetStomatologic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CabinetStomatologic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET ARITHABORT OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CabinetStomatologic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CabinetStomatologic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CabinetStomatologic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CabinetStomatologic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CabinetStomatologic] SET  MULTI_USER 
GO
ALTER DATABASE [CabinetStomatologic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CabinetStomatologic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CabinetStomatologic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CabinetStomatologic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CabinetStomatologic] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CabinetStomatologic] SET QUERY_STORE = OFF
GO
USE [CabinetStomatologic]
GO
/****** Object:  Table [dbo].[Interventii]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interventii](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Interventie] [varchar](50) NOT NULL,
	[Pret] [money] NOT NULL,
	[Activ] [bit] NOT NULL,
 CONSTRAINT [PK_Interventii] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medici]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medici](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [varchar](50) NOT NULL,
	[Prenume] [varchar](50) NOT NULL,
	[ID_User] [int] NOT NULL,
 CONSTRAINT [PK__Medici__3214EC2773E1586B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacienti]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacienti](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [varchar](50) NOT NULL,
	[Prenume] [varchar](50) NOT NULL,
	[ID_Medic] [int] NOT NULL,
 CONSTRAINT [PK__Pacienti__3214EC27ECB7E8D1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programari]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programari](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataProgramarii] [date] NOT NULL,
	[ID_Medic] [int] NOT NULL,
	[ID_Pacient] [int] NOT NULL,
	[ID_Interventie] [int] NOT NULL,
 CONSTRAINT [PK__Programa__3214EC27B7FF21DF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Medic] [bit] NOT NULL,
	[Admin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Medici]  WITH CHECK ADD  CONSTRAINT [FK__Medici__ID_User__38996AB5] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Medici] CHECK CONSTRAINT [FK__Medici__ID_User__38996AB5]
GO
ALTER TABLE [dbo].[Pacienti]  WITH CHECK ADD  CONSTRAINT [FK__Pacienti__ID_Med__3F466844] FOREIGN KEY([ID_Medic])
REFERENCES [dbo].[Medici] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pacienti] CHECK CONSTRAINT [FK__Pacienti__ID_Med__3F466844]
GO
ALTER TABLE [dbo].[Programari]  WITH CHECK ADD  CONSTRAINT [FK__Programar__ID_In__571DF1D5] FOREIGN KEY([ID_Interventie])
REFERENCES [dbo].[Interventii] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Programari] CHECK CONSTRAINT [FK__Programar__ID_In__571DF1D5]
GO
ALTER TABLE [dbo].[Programari]  WITH CHECK ADD  CONSTRAINT [FK__Programar__ID_Me__5535A963] FOREIGN KEY([ID_Medic])
REFERENCES [dbo].[Medici] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Programari] CHECK CONSTRAINT [FK__Programar__ID_Me__5535A963]
GO
/****** Object:  StoredProcedure [dbo].[AddMedic]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddMedic]

	@nume varchar(50),
	@prenume varchar(50),
	@id_user int

AS
BEGIN

	INSERT INTO Medici(Nume, Prenume, ID_User) VALUES (@nume, @prenume, @id_user);

END
GO
/****** Object:  StoredProcedure [dbo].[AddPacient]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPacient]

	@nume varchar(50),
	@prenume varchar(50),
	@medic varchar(50)


AS
BEGIN

	INSERT INTO Pacienti(Nume, Prenume, ID_Medic) VALUES (@nume, @prenume, (SELECT ID FROM Medici WHERE Medici.ID_User = (SELECT ID FROM Users WHERE Users.UserName = @medic)));

END
GO
/****** Object:  StoredProcedure [dbo].[AddProgramari]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProgramari]

	@date date,
	@medic varchar(50),
	@id_pacient int,
	@id_interventie int

AS
BEGIN

	INSERT INTO Programari(DataProgramarii, ID_Medic, ID_Pacient, ID_Interventie) VALUES (@date, 
	(SELECT ID FROM Medici WHERE Medici.ID_User = (SELECT ID FROM Users WHERE Users.UserName = @medic)), @id_pacient, @id_interventie);

END
GO
/****** Object:  StoredProcedure [dbo].[delMedic]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delMedic]

	@id int

AS
BEGIN 

	DELETE FROM Medici WHERE ID = @id;

END
GO
/****** Object:  StoredProcedure [dbo].[delPacient]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delPacient]

	@id int

AS
BEGIN

	DELETE FROM Pacienti WHERE ID = @id;

END
GO
/****** Object:  StoredProcedure [dbo].[getID]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getID]

	@username varchar(50)

AS
BEGIN
	DECLARE @id int

	SET @id = (Select ID from Users Where UserName=@username);

	Select @id
END
GO
/****** Object:  StoredProcedure [dbo].[getPacienti]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getPacienti]

	@curentuser varchar(50)

AS
BEGIN

	SELECT ID, Nume, Prenume FROM Pacienti 
    WHERE Pacienti.ID_Medic = (SELECT ID FROM Medici WHERE ID_User = (Select ID from Users Where UserName=@curentuser));

END
GO
/****** Object:  StoredProcedure [dbo].[getProgramari]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getProgramari]


AS
BEGIN

							SELECT 
                            Programari.ID AS ID, 
                            Programari.DataProgramarii AS DataProgramarii, 
                            Medici.Nume AS Nume, 
                            Medici.Prenume AS Prenume, 
                            Interventii.Interventie AS Interventie, 
                            Interventii.Pret AS Pret

                            FROM Programari

                            INNER JOIN Medici ON Medici.ID = ID_Medic
                            INNER JOIN Pacienti ON Pacienti.ID = ID_Pacient
                            INNER JOIN Interventii ON Interventii.ID = ID_Interventie;


END
GO
/****** Object:  StoredProcedure [dbo].[InterventiiDel]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InterventiiDel]

	@interventie int

AS
BEGIN

	DELETE FROM Interventii WHERE ID = @interventie;


END
GO
/****** Object:  StoredProcedure [dbo].[isAdmin]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[isAdmin]

	@Username varchar(50)

AS
BEGIN
	Declare @status int

	IF Exists(Select * from Users Where UserName=@Username AND Users.Admin= 1)

	Set @status = 1

	Else

	Set @status = 0

	Select @status
END
GO
/****** Object:  StoredProcedure [dbo].[isUserNameAndEmail]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[isUserNameAndEmail]
	@username varchar(50),
	@email varchar(50)

AS
BEGIN
	Declare @status int

	IF Exists(Select * from Users Where UserName=@username Or Email=@email)

	Set @status = 1

	Else

	Set @status = 0

	Select @status
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
@Username varchar(50),
@Password varchar(50)
AS
Begin
	Declare @status int
	if Exists(Select * from Users Where UserName=@Username AND Password=@Password)

	Set @status = 1

	Else

	Set @status = 0

	Select @status
End
GO
/****** Object:  StoredProcedure [dbo].[NewUser]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewUser]

	@username varchar(50),
	@email varchar(50),
	@password varchar(50),
	@medic bit,
	@admin bit

AS
BEGIN 
	INSERT INTO Users(UserName,Email,Password,Medic,Admin)
	VALUES (@username, @email, @password, @medic, @admin  );

END
GO
/****** Object:  StoredProcedure [dbo].[UserDel]    Script Date: 03-Sep-20 10:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UserDel]
	
	@userDel varchar(50)
AS
BEGIN
	
	DELETE FROM Users WHERE UserName=@userDel

END
GO
USE [master]
GO
ALTER DATABASE [CabinetStomatologic] SET  READ_WRITE 
GO
