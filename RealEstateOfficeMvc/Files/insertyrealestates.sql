USE [RealEstateOfficeDB]
GO
SET IDENTITY_INSERT [dbo].[images] OFF
GO
SET IDENTITY_INSERT [dbo].[realestates] ON 
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (1, 0, CAST(125000.00 AS Decimal(10, 2)), 18, N'John', N'McClane', N'Warszawa', N'Szklarska', N'74', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 104)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (3, 3, CAST(10250.00 AS Decimal(10, 2)), 0, N'Marcin', N'Ruszczyk', N'Lublin', N'Szeroka', N'45b', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 20)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (4, 0, CAST(500000.00 AS Decimal(10, 2)), 20, N'Bogdan', N'Kowalski', N'Wrocław', N'Pomorska', N'17', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (5, 2, CAST(700000.00 AS Decimal(10, 2)), 0, N'Marcin', N'Ruszczyk', N'Gdańsk', N'wielkoplska', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1000)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (6, 1, CAST(700000.00 AS Decimal(10, 2)), 3, N'Jan', N'Nowak', N'Gdańsk', N'wyrobka', N'3', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 60)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (7, 3, CAST(100000.00 AS Decimal(10, 2)), 0, N'Jan', N'Garazowy', N'Rumia', N'jakas', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 10)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (8, 2, CAST(700000.00 AS Decimal(10, 2)), 0, N'Jan', N'Ziemski', N'gdańsk', N'jakas', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1000)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (9, 1, CAST(700000.00 AS Decimal(10, 2)), 2, N'Jan', N'Mały', N'Sopot', N'niepodległości', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 40)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (10, 2, CAST(1000000.00 AS Decimal(10, 2)), 0, N'Jan', N'Kowal', N'Pruszcz', N'grunwaldzka', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 120)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (11, 2, CAST(12000000.00 AS Decimal(10, 2)), 0, N'Jan', N'Ziemski', N'Sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 120)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (12, 1, CAST(500000.00 AS Decimal(10, 2)), 2, N'Jan', N'Mieszkalski', N'Sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 50)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (13, 0, CAST(700000.00 AS Decimal(10, 2)), 4, N'Jan', N'Wielki', N'Sopot', N'jakas', N'2', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 120)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (14, 0, CAST(800000.00 AS Decimal(10, 2)), 5, N'Jan', N'Domski', N'sopot', N'jakas', N'4', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 120)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (15, 2, CAST(900000.00 AS Decimal(10, 2)), 0, N'Jan', N'Kowalski', N'sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 120)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (16, 2, CAST(20000000.00 AS Decimal(10, 2)), 0, N'Jan', N'Bogaz', N'Sopot', N'jakas', N'0', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 12000)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (17, 1, CAST(1500000.00 AS Decimal(10, 2)), 6, N'Jan', N'Kowalski', N'Sopot', N'długa', N'100', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (18, 2, CAST(1500000.00 AS Decimal(10, 2)), 0, N'Jan', N'Kowalski', N'Sopot', N'długa', N'999999', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (19, 0, CAST(1500000.00 AS Decimal(10, 2)), 8, N'Jan', N'Bogacz', N'Sopot', N'Niepodległości', N'123', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 350)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (20, 0, CAST(1500000.00 AS Decimal(10, 2)), 6, N'Jan', N'Kowalski', N'Sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (21, 0, CAST(1500000.00 AS Decimal(10, 2)), 8, N'Jan', N'Kowalski', N'Sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (22, 0, CAST(1500000.00 AS Decimal(10, 2)), 8, N'Jan', N'Kowalski', N'Sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (23, 0, CAST(1500000.00 AS Decimal(10, 2)), 8, N'Jan', N'Kowalski', N'Sopot', N'długa', N'1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
INSERT [dbo].[realestates] ([Id], [typeofrealestate], [price], [roomamount], [ownername], [ownersurname], [city], [street], [estateaddress], [creationdate], [modificationdate], [area]) VALUES (24, 4, CAST(1500000.00 AS Decimal(10, 2)), 0, N'Jan', N'Usługowy', N'Sopot', N'długa', N'100', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 100)
GO
SET IDENTITY_INSERT [dbo].[realestates] OFF
GO