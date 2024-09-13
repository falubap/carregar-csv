USE [EscolasDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS [dbo].[Escolas] 
CREATE TABLE [dbo].[Escolas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dre] [varchar](255) NOT NULL,
	[CodEsc] [int] NOT NULL,
	[TipoEsc] [varchar](255) NOT NULL,
	[Nomes] [varchar](255) NOT NULL,
	[NomEscOfi] [varchar](255) NOT NULL,
	[Ceu] [varchar](255) NULL,
	[Diretoria] [varchar](255) NOT NULL,
	[SubPref] [varchar](255) NOT NULL,
	[Endereco] [varchar](255) NOT NULL,
	[Numero] [varchar](255) NULL,
	[Bairro] [varchar](255) NOT NULL,
	[Cep] [int] NOT NULL,
	[Tel_1] [varchar](255) NULL,
	[Tel_2] [varchar](255) NULL,
	[Fax] [varchar](255) NULL,
	[Situacao] [varchar](255) NOT NULL,
	[CodDist] [int] NOT NULL,
	[Distrito] [varchar](255) NOT NULL,
	[Setor] [int] NOT NULL,
	[CodInep] [int] NULL,
	[Cd_Cie] [varchar](255) NULL,
	[Eh] [varchar](255) NULL,
	[Fx_Etaria] [varchar](255) NULL,
	[Dt_Criacao] [varchar](255) NULL,
	[Ato_Criacao] [varchar](255) NULL,
	[Dom_Criacao] [varchar](255) NULL,
	[Dt_Ini_Conv] [varchar](255) NULL,
	[Dt_Autoriza] [varchar](255) NULL,
	[Dt_Extincao] [varchar](255) NULL,
	[Nome_Ant] [varchar](255) NULL,
	[Rede] [varchar](255) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Data_base] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

