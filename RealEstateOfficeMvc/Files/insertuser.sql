USE [RealEstateOfficeDB]
GO
SET IDENTITY_INSERT [dbo].[users] ON 
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (1, N'admin', N'8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', N'Jan', N'Kowalski', N'admin@wp.pl', 1)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (2, N'worker', N'87EBA76E7F3164534045BA922E7770FB58BBD14AD732BBF5BA6F11CC56989E6E', N'Jan', N'Pracowity', N'jan.pracowity@wp.pl', 2)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (3, N'klient', N'CBFDA0B7BA2C5C1383702BCFAF0EC82EE4CEE2FBD69BDA593C75E8E953940FCF', N'jan', N'kliencki', N'jan.kliencki@wp.pl', 3)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (4, N'agent', N'D4F0BC5A29DE06B510F9AA428F1EEDBA926012B591FEF7A518E776A7C9BD1824', N'jan', N'agent', N'jan.agent@wp.pl', 2)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (5, N'marcin.ruszczyk', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'Marcin', N'Ruszczyk', N'marcin.ruszczyk@wp.pl', 1)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (6, N'marcin.ruszczyk', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'Marcin', N'Ruszczyk', N'marcin.ruszczyk@wp.pl', 3)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (7, N'marcin.ruszczyk', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'David', N'Ruszczyk', N'marcin.ruszczyk@wp.pl', 3)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (8, N'login', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'mirosłąw', N'kowal', N'mirosław.kowal@wp.pl', 3)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (9, N'marcin.ruszczyk', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'David', N'Ruszczyk', N'marcin.ruszczyk@wp.pl', 2)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (10, N'jankowal', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'David778', N'Ruszczyk', N'marcin.ruszczyk@wp.pl', 1)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (11, N'agata.ruszczyk', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'Agata', N'Ruszczyk', N'agata@wp.pl', 1)
GO
INSERT [dbo].[users] ([Id], [login], [password], [name], [surname], [emailaddress], [usertype]) VALUES (12, N'klient', N'904CC203F5F319AB22F897EFB8FCC573909926199121114B9E024E87BC05AFFA', N'Jann', N'Kliencki', N'klient@klient.pl', 3)
GO
SET IDENTITY_INSERT [dbo].[users] OFF
GO
