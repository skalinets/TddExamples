USE [master]
GO

CREATE DATABASE [TestBlogs] 

go
USE [TestBlogs]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Author] [int] NOT NULL,
	[Summary] [nvarchar](500) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Tags] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Author] FOREIGN KEY([Author])
REFERENCES [dbo].[Author] ([ID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Author]
GO

INSERT INTO dbo.Author --(Name)
SELECT 'Вася Пупкин' UNION ALL 
SELECT 'Коля Козявкин' UNION ALL
SELECT 'Маша Лохматая' 

INSERT INTO dbo.Post --(Author, Summary, Body, Tags)
SELECT 1, 'Первый нах', 'Это самый первый пост, гыгы', 'Жызнь' UNION ALL
SELECT 2, 'Порвали наушники', 'Меня встретили гопники и... см сабж. Печалька :(', 'Ужос' UNION ALL
SELECT 3, 'Превед', 'Всем чмоки в этом чате!', 'А шо такое тег?' UNION ALL
SELECT 1, 'Туса', 'Давайте организуем тусу нашего ресурса! Пишите в личку.', 'Туса'