USE [master]
GO
CREATE DATABASe [BtgTesteTecnico]
GO
USE [BtgTesteTecnico]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE SEQUENCE [dbo].[SequenciaCodigoPedido] 
 AS [int]
 START WITH 1000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Email] [varchar](254) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[DataAtualizacao] [datetime2](7) NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoItens]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItens](
	[Id] [uniqueidentifier] NOT NULL,
	[PedidoId] [uniqueidentifier] NOT NULL,
	[ProdutoId] [uniqueidentifier] NOT NULL,
	[ProdutoNome] [varchar](250) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[ValorUnitario] [decimal](18, 2) NOT NULL,
	[ProdutoImagem] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PedidoItens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [int] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[PedidoStatus] [int] NOT NULL,
	[DataAtualizacao] [datetime2](7) NULL,
	[DataProcessamento] [datetime2](7) NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 27/10/2024 14:55:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](300) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[DataAtualizacao] [datetime2](7) NULL,
	[Imagem] [varchar](250) NOT NULL,
	[QuantidadeEstoque] [int] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241023232700_Initial', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241024030630_Initial', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241024163809_DataCadastroAtualizacao', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241024165855_AdicionadoProdutos', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241024173326_adicionando-pedido-pedidoitem-e-relacionamentos', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241025161518_AjustePedidoEndereco', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241027003131_AdicionadoDataProcessamento', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241027032023_alterandoNomePedidoItens', N'8.0.10')
GO

INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'fcf62226-9566-42cc-8359-0174a111da36', N'Mouse Sem Fio', N'Tecnologia 2.4 GHz: Conexão estável e sem interferências.', 1, CAST(25.90 AS Decimal(18, 2)), CAST(N'2024-10-25T10:11:27.2633333' AS DateTime2), CAST(N'2024-10-27T12:25:56.6672321' AS DateTime2), N'https://m.media-amazon.com/images/I/41LjiU4hROL._AC_SL1000_.jpg', 9)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'57598b4b-dfc4-44fe-b6c7-1c2f007e4a08', N'Notebook Acer Aspire5', N'Processador AMD Ryzen 7 5700U com 8 núcleos', 1, CAST(2849.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:11:48.2300000' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/51T-6cdhyaL._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'187e4cdf-89e0-414f-8623-33f0b4384fbc', N'Echo Dot 5ª geração', N'O ECHO DOT COM O MELHOR SOM JÁ LANÇADO - Curta uma experiência sonora ainda melhor em comparação às versões anteriores do Echo Dot com Alexa e ouça vocais mais nítidos, graves mais potentes e um som vibrante em qualquer ambiente.', 1, CAST(429.00 AS Decimal(18, 2)), CAST(N'2024-10-24T22:20:06.7866667' AS DateTime2), CAST(N'2024-10-27T12:25:31.6124098' AS DateTime2), N'https://m.media-amazon.com/images/I/617-HLllfZL._AC_SL1000_.jpg', 9)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'6a0d66fc-d4d8-4553-816d-53786c464619', N'Epson EcoTank L4255', N'Menor custo de impressão: Imprima até 4.500 páginas em preto e 7.500 páginas coloridas com cada kit de tintas de reposição original', 1, CAST(1059.90 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8700000' AS DateTime2), CAST(N'2024-10-27T01:54:09.8556290' AS DateTime2), N'https://m.media-amazon.com/images/I/51T-6cdhyaL._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'8378bc59-b750-40b2-a45f-54899e873352', N'Apple iPhone 15 Pro Max (256 GB)', N'FORJADO EM TITÂNIO — O iPhone 15 Pro Max tem design robusto e leve em titânio aeroespacial. Na parte de trás, vidro matte texturizado e, na frente, Ceramic Shield mais resistente que qualquer vidro de smartphone. Ele também é durão contra respingos, água e poeira', 1, CAST(11509.00 AS Decimal(18, 2)), CAST(N'2024-10-24T22:20:06.7833333' AS DateTime2), CAST(N'2024-10-27T11:18:01.1396730' AS DateTime2), N'https://m.media-amazon.com/images/I/81fO2C9cYjL._AC_SL1500_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'faa2d7f1-10b0-4f89-bb25-66f904361302', N'Luminária G RGB Colorida', N'Combinação de iluminação e som de alta qualidade: a luminária G oferece tanto a função de iluminação como uma caixa de som integrada, permitindo reproduzir música, podcasts e outros áudios com qualidade.', 1, CAST(48.27 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8700000' AS DateTime2), CAST(N'2024-10-27T01:54:09.8553317' AS DateTime2), N'https://m.media-amazon.com/images/I/41Ltg8fYR5L._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'b5288d77-c0c1-4fb3-87b5-6c41f501ca9e', N'Apple iPhone 16 Pro (256 GB)', N'COM A BELEZA DO TITÂNIO — O iPhone 16 Pro tem uma estrutura leve e robusta em titânio, uma tela Super Retina XDR maior, de 6,3 polegadas, e a parte frontal é em Ceramic Shield de última geração, duas vezes mais resistente que qualquer vidro de smartphone.', 1, CAST(11299.00 AS Decimal(18, 2)), CAST(N'2024-10-24T21:24:53.6500000' AS DateTime2), CAST(N'2024-10-27T12:25:31.6130722' AS DateTime2), N'https://m.media-amazon.com/images/I/51op-XCMoDL._AC_SL1000_.jpg', 9)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'03c0c93b-1a5b-4ab0-a295-7b74c18c6d3d', N'Fechadura Digital', N'Aviso sonoro de violação, alta temperatura e bateria fraca', 1, CAST(329.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8666667' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/51R13R8zlmL._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'a7ad06f7-ed34-4877-bdd9-86eb9c4e43aa', N'WAP COMBATE TURBO 2600', N'Verifique a voltagem antes de comprar o produto para certificar-se de que corresponde à da sua região', 1, CAST(932.00 AS Decimal(18, 2)), CAST(N'2024-10-24T22:20:06.7866667' AS DateTime2), CAST(N'2024-10-26T23:18:43.4010150' AS DateTime2), N'https://m.media-amazon.com/images/I/61W74LgiT8L._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'aa115f67-a202-4e3b-b5d0-915924746563', N'Nintendo Switch Oled', N'TELA OLED DE 7 POLEGADAS. Aproveite a qualidade deste incrível console que possui tela OLED de 7 polegadas. Desfrute de cores vivas e contraste nítido com uma tela que acentua as cores.', 1, CAST(2800.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8666667' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/61f5q+MwHdL._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'c03f8c67-a80e-45de-8db3-b925604103a7', N'Apple iPhone 14 Pro Max', N'FORJADO EM TITÂNIO — O iPhone 15 Pro Max tem design robusto e leve em titânio aeroespacial. Na parte de trás, vidro matte texturizado e, na frente, Ceramic Shield mais resistente que qualquer vidro de smartphone. Ele também é durão contra respingos, água e poeira', 1, CAST(11509.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8666667' AS DateTime2), CAST(N'2024-10-27T12:25:31.6130862' AS DateTime2), N'https://m.media-amazon.com/images/I/81fO2C9cYjL._AC_SL1500_.jpg', 9)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'26179e96-912e-4d39-94e9-bba7c884ccf7', N'Lavadora de Alta Pressão Wap', N'Verifique a voltagem antes de comprar o produto para certificar-se de que corresponde à da sua região', 1, CAST(509.90 AS Decimal(18, 2)), CAST(N'2024-10-25T10:11:27.2733333' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/711W3v-nNpL._AC_SL1500_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'cedafdf2-2438-463a-bf24-c9cf777a5ab4', N'Echo Dot 4ª geração', N'O ECHO DOT COM O MELHOR SOM JÁ LANÇADO - Curta uma experiência sonora ainda melhor em comparação às versões anteriores do Echo Dot com Alexa e ouça vocais mais nítidos, graves mais potentes e um som vibrante em qualquer ambiente.', 1, CAST(429.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:11:27.2733333' AS DateTime2), CAST(N'2024-10-27T12:25:56.6672085' AS DateTime2), N'https://m.media-amazon.com/images/I/617-HLllfZL._AC_SL1000_.jpg', 8)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'e2d5a014-25be-42fb-85e4-d0aef95b553f', N'MacBook Pro (2024)', N'COM A POTÊNCIA DOS CHIPS M3 PRO OU M3 MAX – O chip M3 Pro da Apple, com CPU de até 12 núcleos e GPU de até 18 núcleos com traçado de raios acelerado por hardware, oferece desempenho impressionante em tarefas pesadas, como manipular imagens panorâmicas enormes e compilar milhões de linhas de código', 1, CAST(15999.98 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8700000' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/41SfOYCho8L._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'8468cc4a-dbb2-468e-a5b1-db4a082eaf62', N'Controle Nintendo Switch', N'Inclui: Controle Nintendo Switch Pro O controle Nintendo Switch Pro oferece mais opções para aproveitar os seus jogos favoritos do Nintendo Switch.', 1, CAST(359.00 AS Decimal(18, 2)), CAST(N'2024-10-24T22:20:29.5633333' AS DateTime2), CAST(N'2024-10-27T12:25:31.6130950' AS DateTime2), N'https://m.media-amazon.com/images/I/51uPCyw9BIL._AC_SL1000_.jpg', 9)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'91c69891-9c67-42a4-9849-e698b9781543', N'Nintendo Switch Oled', N'TELA OLED DE 7 POLEGADAS. Aproveite a qualidade deste incrível console que possui tela OLED de 7 polegadas. Desfrute de cores vivas e contraste nítido com uma tela que acentua as cores.', 1, CAST(2800.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:11:27.2733333' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/61f5q+MwHdL._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'01fbcea3-2384-4892-a69b-f8630f4f8de2', N'Fritadeira Air Fryer 4.5L Family', N'Capacidade de 3,5 litros, cesto espaçoso para acomodar os alimentos', 1, CAST(265.00 AS Decimal(18, 2)), CAST(N'2024-10-25T10:12:17.8700000' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/61ZMYiB4IvL._AC_SL1000_.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [DataAtualizacao], [Imagem], [QuantidadeEstoque]) VALUES (N'3e97fbe5-e9f8-4f07-ac20-f9c2cb2f067c', N'Nintendo Switch Oled Zelda', N'TELA OLED DE 7 POLEGADAS. Aproveite a qualidade deste incrível console que possui tela OLED de 7 polegadas. Desfrute de cores vivas e contraste nítido com uma tela que acentua as cores.', 1, CAST(2800.00 AS Decimal(18, 2)), CAST(N'2024-10-24T22:20:06.7866667' AS DateTime2), NULL, N'https://m.media-amazon.com/images/I/61f5q+MwHdL._AC_SL1000_.jpg', 10)
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DataCadastro]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT (NEXT VALUE FOR [SequenciaCodigoPedido]) FOR [Codigo]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PedidoItens]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItens_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
GO
ALTER TABLE [dbo].[PedidoItens] CHECK CONSTRAINT [FK_PedidoItens_Pedidos_PedidoId]
GO
ALTER TABLE [dbo].[PedidoItens]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItens_Produtos_ProdutoId] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produtos] ([Id])
GO
ALTER TABLE [dbo].[PedidoItens] CHECK CONSTRAINT [FK_PedidoItens_Produtos_ProdutoId]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes_ClienteId]
GO

USE [master]
GO
/****** Object:  Database [BtgTesteTecnicoRelatorio]    Script Date: 27/10/2024 20:33:25 ******/
CREATE DATABASE [BtgTesteTecnicoRelatorio]
GO
USE  [BtgTesteTecnicoRelatorio]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoItens]    Script Date: 27/10/2024 20:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItens](
	[Id] [uniqueidentifier] NOT NULL,
	[Produto] [varchar](250) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[Preco] [decimal](18, 2) NOT NULL,
	[PedidoId] [uniqueidentifier] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PedidoItens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 27/10/2024 20:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [uniqueidentifier] NOT NULL,
	[CodigoPedido] [int] NOT NULL,
	[NomeCliente] [nvarchar](100) NOT NULL,
	[CodigoCliente] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_PedidoItens_PedidoId]    Script Date: 27/10/2024 20:33:25 ******/
CREATE NONCLUSTERED INDEX [IX_PedidoItens_PedidoId] ON [dbo].[PedidoItens]
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PedidoItens] ADD  DEFAULT ((0.0)) FOR [Total]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [CodigoCliente]
GO
ALTER TABLE [dbo].[PedidoItens]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItens_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
GO
ALTER TABLE [dbo].[PedidoItens] CHECK CONSTRAINT [FK_PedidoItens_Pedidos_PedidoId]
