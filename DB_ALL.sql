USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Olympics') 
BEGIN 
DROP DATABASE Olympics
END 
GO 

CREATE DATABASE Olympics
GO 

USE Olympics
GO

CREATE TABLE [User] (
	id_user int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_User] primary key,
	[Name] varchar(100) NOT NULL,
	Birthday date NOT NULL,
	Age int NOT NULL
)
GO
CREATE TABLE Award (
	id_award int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Award] primary key,
	Title varchar(50) NOT NULL,
	[Description] varchar(300)
)
GO

CREATE TABLE User_Award (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_User_Award] primary key,
	id_user int NOT NULL,
	id_award int NOT NULL
)
GO

ALTER TABLE [User_Award] ADD CONSTRAINT [FK_User_Award_TO_User]
FOREIGN KEY ([id_user]) references [User]([id_user])
on delete cascade
on update cascade
GO

ALTER TABLE [User_Award] ADD CONSTRAINT [FK_User_Award_TO_Award]
FOREIGN KEY ([id_award]) references [Award]([id_award])
on delete cascade
on update cascade
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE AddUser 
	@Name varchar(50),
	@Birthday date,
	@Age int
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Birthday]
           ,[Age])
     VALUES
           (@Name, @Birthday, @Age)

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE DeleteUser
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[User]
      WHERE [id_user] = @ID

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByID
	@ID int
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
  FROM [Olympics].[dbo].[User]
  WHERE [id_user] = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByName
	@NAME varchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE @NAME
  Order By Age Desc
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByLetter
	@LETTER char
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE @LETTER + '%'
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByWord
	@WORD varchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE (@WORD+'%'+@WORD)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateUser
	@ID int,
	@NAME varchar(100),
	@BIRTHDAY date,
	@AGE int
AS
BEGIN
	UPDATE Olympics.dbo.[User]
	SET 
	[Name] = @NAME,
	Birthday = @BIRTHDAY,
	Age = @AGE
	WHERE id_user = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddAward 
	@TITLE varchar(50),
	@DESCRIPTION varchar(300)
AS
BEGIN
	INSERT INTO [dbo].[Award]
           ([Title]
           ,[Description])
     VALUES
           (@TITLE,
		   @DESCRIPTION)

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwards]
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
  FROM [Olympics].[dbo].[Award]
END

