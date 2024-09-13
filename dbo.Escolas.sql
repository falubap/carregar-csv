USE [EscolasDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS [dbo].[Escolas] 
CREATE TABLE [dbo].[Escolas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dre] [varchar](2) NOT NULL,
	[CodEsc] [int] NOT NULL,
	[TipoEsc] [varchar](30) NOT NULL,
	[Nomes] [varchar](80) NOT NULL,
	[NomEscOfi] [varchar](80) NOT NULL,
	[Ceu] [varchar](80) NULL,
	[Diretoria] [varchar](80) NOT NULL,
	[SubPref] [varchar](80) NOT NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Numero] [int] NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cep] [int] NOT NULL,
	[Tel_1] [varchar](10) NULL,
	[Tel_2] [varchar](9) NULL,
	[Fax] [int] NULL,
	[Situacao] [varchar](8) NOT NULL,
	[CodDist] [int] NOT NULL,
	[Distrito] [varchar](80) NOT NULL,
	[Setor] [int] NOT NULL,
	[CodInep] [int] NULL,
	[Cd_Cie] [int] NULL,
	[Eh] [float] NULL,
	[Fx_Etaria] [varchar](80) NULL,
	[Dt_Criacao] [datetime] NULL,
	[Ato_Criacao] [varchar](30) NULL,
	[Dom_Criacao] [datetime] NULL,
	[Dt_Ini_Conv] [varchar](255) NULL,
	[Dt_Autoriza] [varchar](255) NULL,
	[Dt_Extincao] [int] NULL,
	[Nome_Ant] [varchar](100) NULL,
	[Rede] [varchar](1) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Data_base] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

