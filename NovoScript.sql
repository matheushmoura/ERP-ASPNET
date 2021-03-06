USE [master]
GO
/****** Object:  Database [BancoArmarinho]    Script Date: 04/12/2020 18:33:22 ******/
CREATE DATABASE [BancoArmarinho]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancoArmarinho', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BancoArmarinho.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancoArmarinho_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BancoArmarinho_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BancoArmarinho] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancoArmarinho].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancoArmarinho] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancoArmarinho] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancoArmarinho] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancoArmarinho] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancoArmarinho] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancoArmarinho] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BancoArmarinho] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancoArmarinho] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancoArmarinho] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancoArmarinho] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancoArmarinho] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancoArmarinho] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancoArmarinho] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancoArmarinho] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancoArmarinho] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BancoArmarinho] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancoArmarinho] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancoArmarinho] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancoArmarinho] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancoArmarinho] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancoArmarinho] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BancoArmarinho] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancoArmarinho] SET RECOVERY FULL 
GO
ALTER DATABASE [BancoArmarinho] SET  MULTI_USER 
GO
ALTER DATABASE [BancoArmarinho] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancoArmarinho] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancoArmarinho] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancoArmarinho] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancoArmarinho] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BancoArmarinho', N'ON'
GO
ALTER DATABASE [BancoArmarinho] SET QUERY_STORE = OFF
GO
USE [BancoArmarinho]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[documento] [varchar](50) NULL,
	[inscricaoestadual] [varchar](50) NULL,
	[cep] [varchar](50) NULL,
	[cidade] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[endereço] [varchar](50) NULL,
	[pontos] [int] NULL,
	[numero] [int] NULL,
	[complemento] [varchar](100) NULL,
	[bairro] [varchar](50) NULL,
	[situacao] [bit] NULL,
	[telefone] [varchar](15) NULL,
	[telefone2] [varchar](15) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compra]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[data] [date] NULL,
	[valor] [decimal](8, 2) NULL,
	[fornecedor] [int] NULL,
	[observacao] [varchar](100) NULL,
	[Stat] [varchar](50) NULL,
	[Tipo] [int] NULL,
 CONSTRAINT [PK_compra] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compraitens]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compraitens](
	[ccodigo] [int] IDENTITY(1,1) NOT NULL,
	[ccompra] [int] NULL,
	[cquant] [int] NULL,
	[prodcod] [int] NULL,
 CONSTRAINT [PK_compraitens] PRIMARY KEY CLUSTERED 
(
	[ccodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContaPagar]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContaPagar](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](50) NULL,
	[data] [varchar](50) NULL,
	[Valor] [decimal](8, 2) NULL,
 CONSTRAINT [PK_ContaPagar] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fornecedor]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fornecedor](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[cnpj] [varchar](50) NULL,
	[cep] [varchar](10) NULL,
	[endereço] [varchar](50) NULL,
	[cidade] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[numero] [int] NULL,
	[telefone] [varchar](15) NULL,
	[telefone2] [varchar](15) NULL,
	[situacao] [bit] NULL,
 CONSTRAINT [PK_fornecedor] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itensvendidos]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itensvendidos](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[produto] [int] NULL,
	[quantidade] [int] NULL,
	[valor] [decimal](8, 2) NULL,
	[venda_codigo] [int] NULL,
 CONSTRAINT [PK_itensvendidos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produto]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produto](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[fornecedor] [int] NULL,
	[categoria] [int] NULL,
	[quantidade] [int] NULL,
	[preço] [decimal](10, 2) NULL,
	[estoque1] [int] NULL,
	[estoque2] [int] NULL,
 CONSTRAINT [PK_produto] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[senha] [varchar](50) NULL,
	[permissao] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venda]    Script Date: 04/12/2020 18:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venda](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [int] NULL,
	[usuario] [int] NULL,
	[data] [date] NULL,
	[itensvendidos] [int] NULL,
	[total] [decimal](8, 2) NULL,
	[valor] [decimal](8, 2) NULL,
	[desconto] [decimal](8, 2) NULL,
 CONSTRAINT [PK_venda] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[compra]  WITH NOCHECK ADD  CONSTRAINT [FK_compra_fornecedor] FOREIGN KEY([fornecedor])
REFERENCES [dbo].[fornecedor] ([codigo])
GO
ALTER TABLE [dbo].[compra] NOCHECK CONSTRAINT [FK_compra_fornecedor]
GO
ALTER TABLE [dbo].[compraitens]  WITH NOCHECK ADD  CONSTRAINT [FK_compraitens_compra] FOREIGN KEY([ccompra])
REFERENCES [dbo].[compra] ([codigo])
GO
ALTER TABLE [dbo].[compraitens] NOCHECK CONSTRAINT [FK_compraitens_compra]
GO
ALTER TABLE [dbo].[compraitens]  WITH NOCHECK ADD  CONSTRAINT [FK_compraitens_produto] FOREIGN KEY([prodcod])
REFERENCES [dbo].[produto] ([codigo])
GO
ALTER TABLE [dbo].[compraitens] NOCHECK CONSTRAINT [FK_compraitens_produto]
GO
ALTER TABLE [dbo].[itensvendidos]  WITH NOCHECK ADD  CONSTRAINT [FK_itensvendidos_produto] FOREIGN KEY([produto])
REFERENCES [dbo].[produto] ([codigo])
GO
ALTER TABLE [dbo].[itensvendidos] NOCHECK CONSTRAINT [FK_itensvendidos_produto]
GO
ALTER TABLE [dbo].[itensvendidos]  WITH NOCHECK ADD  CONSTRAINT [FK_itensvendidos_venda] FOREIGN KEY([venda_codigo])
REFERENCES [dbo].[venda] ([codigo])
GO
ALTER TABLE [dbo].[itensvendidos] NOCHECK CONSTRAINT [FK_itensvendidos_venda]
GO
ALTER TABLE [dbo].[venda]  WITH NOCHECK ADD  CONSTRAINT [FK_venda_venda] FOREIGN KEY([cliente])
REFERENCES [dbo].[cliente] ([codigo])
GO
ALTER TABLE [dbo].[venda] NOCHECK CONSTRAINT [FK_venda_venda]
GO
USE [master]
GO
ALTER DATABASE [BancoArmarinho] SET  READ_WRITE 
GO
