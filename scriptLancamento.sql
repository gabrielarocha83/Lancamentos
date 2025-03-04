USE [Lancamento]
GO
/****** Object:  Table [dbo].[Lancamentos]    Script Date: 06/01/2025 18:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lancamentos](
	[Id] [varchar](50) NOT NULL,
	[Valor] [decimal](14, 2) NULL,
	[Tipo] [varchar](10) NULL,
	[Data] [datetime] NULL,
 CONSTRAINT [PK_Lancamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
