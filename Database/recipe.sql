USE [recipebox]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 3/2/2017 4:45:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categories_recipe]    Script Date: 3/2/2017 4:45:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_recipe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recipe_id] [int] NULL,
	[category_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[recipe]    Script Date: 3/2/2017 4:45:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[ingredients] [varchar](255) NULL,
	[instructions] [varchar](255) NULL,
	[cook_time] [varchar](255) NULL,
	[rating] [int] NULL,
	[url] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id], [name]) VALUES (1, N'Italian')
INSERT [dbo].[categories] ([id], [name]) VALUES (2, N'Dinner')
SET IDENTITY_INSERT [dbo].[categories] OFF
SET IDENTITY_INSERT [dbo].[categories_recipe] ON 

INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (1, 4, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (2, 5, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (3, 6, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (4, 6, 2)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (5, 7, 2)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (6, 8, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (7, 9, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (8, 10, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (9, 11, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (10, 12, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (11, 13, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (13, 15, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (14, 16, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (16, 18, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (17, 19, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (18, 20, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (19, 21, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (20, 22, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (21, 23, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (22, 24, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (23, 25, 2)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (12, 14, 1)
INSERT [dbo].[categories_recipe] ([id], [recipe_id], [category_id]) VALUES (15, 17, 1)
SET IDENTITY_INSERT [dbo].[categories_recipe] OFF
SET IDENTITY_INSERT [dbo].[recipe] ON 

INSERT [dbo].[recipe] ([id], [name], [ingredients], [instructions], [cook_time], [rating], [url]) VALUES (24, N'Spaghetti', N'Noodles, Parsley, Tomato, Chiles', N'Cook the noodles, saute them, cut vegetables', N'30 Minutes', 3, N'https://images.pexels.com/photos/65131/pexels-photo-65131.jpeg?h=350&auto=compress&cs=tinysrgb')
INSERT [dbo].[recipe] ([id], [name], [ingredients], [instructions], [cook_time], [rating], [url]) VALUES (25, N'Chicken Salad', N'Chicken, spinach, pomegranates, oil', N'Grill the chicken, wash the spinach, cut pomegranate', N'45 Minutes', 5, N'https://images.pexels.com/photos/5938/food-salad-healthy-lunch.jpg?h=350&auto=compress&cs=tinysrgb')
INSERT [dbo].[recipe] ([id], [name], [ingredients], [instructions], [cook_time], [rating], [url]) VALUES (23, N'Chicken', N'Chicken  and Spices', N'roast chicken', N'15 Minutes', 1, N'https://images.pexels.com/photos/145804/pexels-photo-145804.jpeg?h=350&auto=compress&cs=tinysrgb')
SET IDENTITY_INSERT [dbo].[recipe] OFF
