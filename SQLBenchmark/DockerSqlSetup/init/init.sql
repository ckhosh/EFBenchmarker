USE master;

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'SQLBenchmark')
BEGIN
	PRINT 'SQLBenchmark DB already exists'
	
END
ELSE
BEGIN
PRINT 'Creating SQLBenchmark DB'
CREATE DATABASE [SQLBenchmark];
END

go
USE [SQLBenchmark]
go

IF OBJECT_ID('dbo.Books') IS NULL
BEGIN

PRINT 'Creating Books table and inserting books'

/****** Object:  Table [dbo].[Books]    Script Date: 12/13/2024 2:04:04 PM ******/
SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Author] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ExtraColumnA] [nvarchar](max) NULL,
	[ExtraColumnB] [nvarchar](max) NULL,
	[ExtraColumnC] [nvarchar](max) NULL,
	[ExtraColumnD] [nvarchar](max) NULL,
	[ExtraColumnE] [nvarchar](max) NULL,
	[ExtraColumnF] [nvarchar](max) NULL,
	[ExtraColumnG] [nvarchar](max) NULL,
	[ExtraColumnH] [nvarchar](max) NULL,
	[ExtraColumnI] [nvarchar](max) NULL,
	[ExtraColumnJ] [nvarchar](max) NULL,
	[ExtraColumnK] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


INSERT INTO dbo.Books ([Title], [Author], [Price])
VALUES
( N'The Catcher in the Rye', N'F. Scott Fitzgerald', 7.99 ),
( N'Pride and Prejudice', N'Jane Austen', 11.99 ),
( N'Pride and Prejudice', N'Jane Austen', 9.99 ),
( N'1984', N'George Orwell', 9.99 ),
( N'The Catcher in the Rye', N'J.D. Salinger', 10.99 ),
( N'To Kill a Mockingbird', N'Harper Lee', 9.99 ),
( N'Pride and Prejudice', N'J.D. Salinger', 10.99 ),
( N'Pride and Prejudice', N'Jane Austen', 7.99 ),
( N'1984', N'J.D. Salinger', 8.99 ),
(  N'To Kill a Mockingbird', N'Harper Lee', 11.99 ),
(  N'The Great Gatsby', N'Jane Austen', 9.99 ),
(  N'Pride and Prejudice', N'George Orwell', 7.99 ),
(  N'To Kill a Mockingbird', N'F. Scott Fitzgerald', 11.99 ),
(  N'Pride and Prejudice', N'J.D. Salinger', 11.99 ),
(  N'Pride and Prejudice', N'J.D. Salinger', 8.99 ),
(  N'To Kill a Mockingbird', N'F. Scott Fitzgerald', 9.99 ),
(  N'To Kill a Mockingbird', N'Jane Austen', 9.99 ),
(  N'The Catcher in the Rye', N'George Orwell', 9.99 ),
(  N'To Kill a Mockingbird', N'F. Scott Fitzgerald', 8.99 ),
(  N'The Catcher in the Rye', N'George Orwell', 10.99 ),
(  N'Pride and Prejudice', N'F. Scott Fitzgerald', 7.99 ),
(  N'To Kill a Mockingbird', N'George Orwell', 10.99 ),
(  N'The Catcher in the Rye', N'George Orwell', 10.99 ),
(  N'Pride and Prejudice', N'J.D. Salinger', 9.99 ),
(  N'To Kill a Mockingbird', N'J.D. Salinger', 7.99 ),
(  N'The Catcher in the Rye', N'J.D. Salinger', 11.99 ),
(  N'The Catcher in the Rye', N'J.D. Salinger', 11.99 ),
(  N'Pride and Prejudice', N'F. Scott Fitzgerald', 11.99 ),
(  N'To Kill a Mockingbird', N'F. Scott Fitzgerald', 8.99 ),
(  N'The Great Gatsby', N'George Orwell', 7.99 ),
(  N'Pride and Prejudice', N'Jane Austen', 10.99 ),
(  N'The Great Gatsby', N'F. Scott Fitzgerald', 11.99 ),
(  N'Pride and Prejudice', N'George Orwell', 10.99 ),
(  N'Pride and Prejudice', N'Harper Lee', 11.99 ),
(  N'The Catcher in the Rye', N'Jane Austen', 10.99 ),
(  N'The Catcher in the Rye', N'Harper Lee', 9.99 ),
(  N'To Kill a Mockingbird', N'Jane Austen', 7.99 ),
(  N'1984', N'F. Scott Fitzgerald', 9.99 ),
(  N'The Catcher in the Rye', N'J.D. Salinger', 11.99 ),
(  N'The Great Gatsby', N'F. Scott Fitzgerald', 7.99 ),
(  N'To Kill a Mockingbird', N'J.D. Salinger', 11.99 ),
(  N'To Kill a Mockingbird', N'J.D. Salinger', 8.99 ),
(  N'Pride and Prejudice', N'George Orwell', 10.99 ),
(  N'The Great Gatsby', N'F. Scott Fitzgerald', 10.99 ),
(  N'1984', N'F. Scott Fitzgerald', 9.99 ),
(  N'The Catcher in the Rye', N'Jane Austen', 9.99 ),
(  N'1984', N'Harper Lee', 10.99 ),
(  N'The Catcher in the Rye', N'Jane Austen', 9.99 ),
(  N'The Catcher in the Rye', N'George Orwell', 9.99 ),
(  N'1984', N'George Orwell', 7.99 )
END;

USE master;