delete from [QuestionItem];
delete from [Answer];
delete from [QuestionList];
delete from [Question];
delete from [QuestionType];

delete from [Inspection];
delete from [Commission];
delete from [Customer];
delete from [Employee];
delete from [Person];
delete from [Location];
delete from [Region];
delete from [Function];



begin /* Regions */
SET IDENTITY_INSERT [Region] ON;
insert into [Region] ([Id], [Guid], [RegionName]) values (1, NEWID(), 'Brabant');
insert into [Region] ([Id], [Guid], [RegionName]) values (2, NEWID(), 'Limburg');
insert into [Region] ([Id], [Guid], [RegionName]) values (3, NEWID(), 'Utrecht');
insert into [Region] ([Id], [Guid], [RegionName]) values (4, NEWID(), 'Flevoland');
insert into [Region] ([Id], [Guid], [RegionName]) values (5, NEWID(), 'Noord-Holland');
insert into [Region] ([Id], [Guid], [RegionName]) values (13, NEWID(), 'Noord-Brabant');
insert into [Region] ([Id], [Guid], [RegionName]) values (6, NEWID(), 'Zuid-Holland');
insert into [Region] ([Id], [Guid], [RegionName]) values (7, NEWID(), 'Zeeland');
insert into [Region] ([Id], [Guid], [RegionName]) values (8, NEWID(), 'Gelderland');
insert into [Region] ([Id], [Guid], [RegionName]) values (9, NEWID(), 'Overijssel');
insert into [Region] ([Id], [Guid], [RegionName]) values (10, NEWID(), 'Drenthe');
insert into [Region] ([Id], [Guid], [RegionName]) values (11, NEWID(), 'Friesland');
insert into [Region] ([Id], [Guid], [RegionName]) values (12, NEWID(), 'Groningen');
SET IDENTITY_INSERT [Region] OFF;
end

begin /* Functions */
SET IDENTITY_INSERT [Function] ON;
insert into [Function] ([Id], [Guid], [Name]) values (1, NEWID(), 'Manager');
insert into [Function] ([Id], [Guid], [Name]) values (2, NEWID(), 'Inspecteur');
SET IDENTITY_INSERT [Function] OFF;
end

begin /* QuestionTypes */
SET IDENTITY_INSERT [QuestionType] ON;
insert into [QuestionType] ([Id], [Guid], [Name]) values (1, NEWID(), 'Boolean');
insert into [QuestionType] ([Id], [Guid], [Name]) values (2, NEWID(), 'Open');
insert into [QuestionType] ([Id], [Guid], [Name]) values (3, NEWID(), 'Count');
SET IDENTITY_INSERT [QuestionType] OFF;
end

begin /* customers */
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 1, NEWID(),'6541MD', '68', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 1, NEWID(), 'Breunis de Crom', [Id], [Guid], '06-29746389', 'BreunisdeCrom@superrito.com' from [Location] where [ZipCode] = '6541MD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 1, NEWID(), [Id], [Guid] from person where [Id] = 1;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 2, NEWID(),'9076BM', '9', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 2, NEWID(), 'Jannis Hettema', [Id], [Guid], '06-85962364', 'JannisHettema@teleworm.us' from [Location] where [ZipCode] = '9076BM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 2, NEWID(), [Id], [Guid] from person where [Id] = 2;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 3, NEWID(),'2317SB', '47', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 3, NEWID(), 'Lorna Blok', [Id], [Guid], '06-36917526', 'LornaBlok@gustr.com' from [Location] where [ZipCode] = '2317SB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 3, NEWID(), [Id], [Guid] from person where [Id] = 3;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 4, NEWID(),'6917BH', '185', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 4, NEWID(), 'Thiemo Rinzema', [Id], [Guid], '06-34717296', 'ThiemoRinzema@cuvox.de' from [Location] where [ZipCode] = '6917BH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 4, NEWID(), [Id], [Guid] from person where [Id] = 4;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 5, NEWID(),'7131VL', '26', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 5, NEWID(), 'İlknur Droog', [Id], [Guid], '06-69416315', 'IlknurDroog@dayrep.com' from [Location] where [ZipCode] = '7131VL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 5, NEWID(), [Id], [Guid] from person where [Id] = 5;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 6, NEWID(),'1067ZH', '40', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 6, NEWID(), 'Melania de Nijs', [Id], [Guid], '06-16297244', 'MelaniadeNijs@fleckens.hu' from [Location] where [ZipCode] = '1067ZH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 6, NEWID(), [Id], [Guid] from person where [Id] = 6;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 7, NEWID(),'2271HD', '78', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 7, NEWID(), 'Giancarlo Legierse', [Id], [Guid], '06-89248123', 'GiancarloLegierse@jourrapide.com' from [Location] where [ZipCode] = '2271HD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 7, NEWID(), [Id], [Guid] from person where [Id] = 7;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 8, NEWID(),'2583KB', '137', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 8, NEWID(), 'Amra Çiçek', [Id], [Guid], '06-45449045', 'AmraCicek@jourrapide.com' from [Location] where [ZipCode] = '2583KB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 8, NEWID(), [Id], [Guid] from person where [Id] = 8;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 9, NEWID(),'1314MG', '179', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 9, NEWID(), 'Mex Buma', [Id], [Guid], '06-84630294', 'MexBuma@armyspy.com' from [Location] where [ZipCode] = '1314MG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 9, NEWID(), [Id], [Guid] from person where [Id] = 9;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 10, NEWID(),'7102AT', '128', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 10, NEWID(), 'Harmina Boudewijn', [Id], [Guid], '06-51519383', 'HarminaBoudewijn@cuvox.de' from [Location] where [ZipCode] = '7102AT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 10, NEWID(), [Id], [Guid] from person where [Id] = 10;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 11, NEWID(),'8474CT', '45', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 11, NEWID(), 'Jiska Bergervoet', [Id], [Guid], '06-80424202', 'JiskaBergervoet@armyspy.com' from [Location] where [ZipCode] = '8474CT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 11, NEWID(), [Id], [Guid] from person where [Id] = 11;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 12, NEWID(),'7943TA', '77', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 12, NEWID(), 'Vibeke Bloemen', [Id], [Guid], '06-27750364', 'VibekeBloemen@rhyta.com' from [Location] where [ZipCode] = '7943TA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 12, NEWID(), [Id], [Guid] from person where [Id] = 12;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 13, NEWID(),'1033RR', '76', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 13, NEWID(), 'Annieck Hölzken', [Id], [Guid], '06-55990815', 'AnnieckHolzken@dayrep.com' from [Location] where [ZipCode] = '1033RR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 13, NEWID(), [Id], [Guid] from person where [Id] = 13;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 14, NEWID(),'5035GM', '159', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 14, NEWID(), 'Marsha te Lindert', [Id], [Guid], '06-32329562', 'MarshateLindert@cuvox.de' from [Location] where [ZipCode] = '5035GM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 14, NEWID(), [Id], [Guid] from person where [Id] = 14;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 15, NEWID(),'3813DH', '48', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 15, NEWID(), 'Wessel Kesselaar', [Id], [Guid], '06-86400762', 'WesselKesselaar@fleckens.hu' from [Location] where [ZipCode] = '3813DH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 15, NEWID(), [Id], [Guid] from person where [Id] = 15;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 16, NEWID(),'8443CV', '70', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 16, NEWID(), 'Tian ter Burg', [Id], [Guid], '06-29136272', 'TianterBurg@armyspy.com' from [Location] where [ZipCode] = '8443CV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 16, NEWID(), [Id], [Guid] from person where [Id] = 16;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 17, NEWID(),'2251GC', '162', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 17, NEWID(), 'Enis Mateman', [Id], [Guid], '06-45795607', 'EnisMateman@rhyta.com' from [Location] where [ZipCode] = '2251GC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 17, NEWID(), [Id], [Guid] from person where [Id] = 17;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 18, NEWID(),'1824KM', '68', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 18, NEWID(), 'Darcy Ekelschot', [Id], [Guid], '06-80411999', 'DarcyEkelschot@fleckens.hu' from [Location] where [ZipCode] = '1824KM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 18, NEWID(), [Id], [Guid] from person where [Id] = 18;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 19, NEWID(),'7609DX', '73', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 19, NEWID(), 'Ouafae Gertsen', [Id], [Guid], '06-95409956', 'OuafaeGertsen@rhyta.com' from [Location] where [ZipCode] = '7609DX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 19, NEWID(), [Id], [Guid] from person where [Id] = 19;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 20, NEWID(),'5268GJ', '39', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 20, NEWID(), 'Denian Kuper', [Id], [Guid], '06-57095775', 'DenianKuper@cuvox.de' from [Location] where [ZipCode] = '5268GJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 20, NEWID(), [Id], [Guid] from person where [Id] = 20;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 21, NEWID(),'4751GT', '71', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 21, NEWID(), 'Phoebe Duiveman', [Id], [Guid], '06-47550487', 'PhoebeDuiveman@jourrapide.com' from [Location] where [ZipCode] = '4751GT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 21, NEWID(), [Id], [Guid] from person where [Id] = 21;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 22, NEWID(),'1261GL', '12', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 22, NEWID(), 'Anniko de Bondt', [Id], [Guid], '06-89586998', 'AnnikodeBondt@fleckens.hu' from [Location] where [ZipCode] = '1261GL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 22, NEWID(), [Id], [Guid] from person where [Id] = 22;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 23, NEWID(),'5044CT', '69', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 23, NEWID(), 'Hajer Vorst', [Id], [Guid], '06-22431041', 'HajerVorst@cuvox.de' from [Location] where [ZipCode] = '5044CT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 23, NEWID(), [Id], [Guid] from person where [Id] = 23;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 24, NEWID(),'5251BK', '98', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 24, NEWID(), 'Zeger van de Griendt', [Id], [Guid], '06-44705602', 'ZegervandeGriendt@cuvox.de' from [Location] where [ZipCode] = '5251BK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 24, NEWID(), [Id], [Guid] from person where [Id] = 24;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 25, NEWID(),'3738VM', '96', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 25, NEWID(), 'Buşra Ratering', [Id], [Guid], '06-56368763', 'BusraRatering@teleworm.us' from [Location] where [ZipCode] = '3738VM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 25, NEWID(), [Id], [Guid] from person where [Id] = 25;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 26, NEWID(),'6163TH', '194', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 26, NEWID(), 'Julot Roggen', [Id], [Guid], '06-20809046', 'JulotRoggen@jourrapide.com' from [Location] where [ZipCode] = '6163TH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 26, NEWID(), [Id], [Guid] from person where [Id] = 26;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 27, NEWID(),'1339TC', '80', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 27, NEWID(), 'Onno Schulten', [Id], [Guid], '06-40297685', 'OnnoSchulten@dayrep.com' from [Location] where [ZipCode] = '1339TC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 27, NEWID(), [Id], [Guid] from person where [Id] = 27;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 28, NEWID(),'3336LG', '150', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 28, NEWID(), 'Len Elbertsen', [Id], [Guid], '06-23132826', 'LenElbertsen@einrot.com' from [Location] where [ZipCode] = '3336LG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 28, NEWID(), [Id], [Guid] from person where [Id] = 28;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 29, NEWID(),'5951AG', '145', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 29, NEWID(), 'Dimitri Elsendoorn', [Id], [Guid], '06-33960631', 'DimitriElsendoorn@jourrapide.com' from [Location] where [ZipCode] = '5951AG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 29, NEWID(), [Id], [Guid] from person where [Id] = 29;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 30, NEWID(),'7606AL', '113', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 30, NEWID(), 'Ayfer Adriaensen', [Id], [Guid], '06-90415269', 'AyferAdriaensen@superrito.com' from [Location] where [ZipCode] = '7606AL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 30, NEWID(), [Id], [Guid] from person where [Id] = 30;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 31, NEWID(),'2969AS', '98', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 31, NEWID(), 'Elene van Hees', [Id], [Guid], '06-66467011', 'ElenevanHees@superrito.com' from [Location] where [ZipCode] = '2969AS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 31, NEWID(), [Id], [Guid] from person where [Id] = 31;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 32, NEWID(),'3512NL', '95', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 32, NEWID(), 'Jabir Schipperen', [Id], [Guid], '06-15009355', 'JabirSchipperen@cuvox.de' from [Location] where [ZipCode] = '3512NL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 32, NEWID(), [Id], [Guid] from person where [Id] = 32;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 33, NEWID(),'6543SC', '83', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 33, NEWID(), 'Elon Heijster', [Id], [Guid], '06-93565416', 'ElonHeijster@einrot.com' from [Location] where [ZipCode] = '6543SC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 33, NEWID(), [Id], [Guid] from person where [Id] = 33;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 34, NEWID(),'8409JW', '33', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 34, NEWID(), 'Sterre Balk', [Id], [Guid], '06-99167020', 'SterreBalk@fleckens.hu' from [Location] where [ZipCode] = '8409JW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 34, NEWID(), [Id], [Guid] from person where [Id] = 34;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 35, NEWID(),'5451PJ', '44', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 35, NEWID(), 'Roelofje Thakoer', [Id], [Guid], '06-11503562', 'RoelofjeThakoer@jourrapide.com' from [Location] where [ZipCode] = '5451PJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 35, NEWID(), [Id], [Guid] from person where [Id] = 35;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 36, NEWID(),'7207KK', '90', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 36, NEWID(), 'Rieke van Weert', [Id], [Guid], '06-44251671', 'RiekevanWeert@fleckens.hu' from [Location] where [ZipCode] = '7207KK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 36, NEWID(), [Id], [Guid] from person where [Id] = 36;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 37, NEWID(),'5021LP', '120', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 37, NEWID(), 'Jimmy Bal', [Id], [Guid], '06-49187572', 'JimmyBal@fleckens.hu' from [Location] where [ZipCode] = '5021LP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 37, NEWID(), [Id], [Guid] from person where [Id] = 37;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 38, NEWID(),'3817GA', '109', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 38, NEWID(), 'Medina Alsemgeest', [Id], [Guid], '06-22721939', 'MedinaAlsemgeest@dayrep.com' from [Location] where [ZipCode] = '3817GA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 38, NEWID(), [Id], [Guid] from person where [Id] = 38;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 39, NEWID(),'2114AD', '188', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 39, NEWID(), 'Zine-Eddine Neijenhuis', [Id], [Guid], '06-66580292', 'Zine-EddineNeijenhuis@teleworm.us' from [Location] where [ZipCode] = '2114AD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 39, NEWID(), [Id], [Guid] from person where [Id] = 39;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 40, NEWID(),'2334DA', '55', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 40, NEWID(), 'Bedirhan Lunenborg', [Id], [Guid], '06-54762712', 'BedirhanLunenborg@armyspy.com' from [Location] where [ZipCode] = '2334DA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 40, NEWID(), [Id], [Guid] from person where [Id] = 40;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 41, NEWID(),'5561TR', '199', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 41, NEWID(), 'Denisha Zieltjens', [Id], [Guid], '06-14837471', 'DenishaZieltjens@superrito.com' from [Location] where [ZipCode] = '5561TR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 41, NEWID(), [Id], [Guid] from person where [Id] = 41;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 42, NEWID(),'4401GT', '41', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 42, NEWID(), 'Cheyenne Ebbing', [Id], [Guid], '06-78307851', 'CheyenneEbbing@rhyta.com' from [Location] where [ZipCode] = '4401GT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 42, NEWID(), [Id], [Guid] from person where [Id] = 42;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 43, NEWID(),'6932BP', '97', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 43, NEWID(), 'Erin van Wiggen', [Id], [Guid], '06-52271796', 'ErinvanWiggen@gustr.com' from [Location] where [ZipCode] = '6932BP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 43, NEWID(), [Id], [Guid] from person where [Id] = 43;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 44, NEWID(),'6862GZ', '62', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 44, NEWID(), 'Shenna van Utrecht', [Id], [Guid], '06-44235701', 'ShennavanUtrecht@einrot.com' from [Location] where [ZipCode] = '6862GZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 44, NEWID(), [Id], [Guid] from person where [Id] = 44;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 45, NEWID(),'1601AK', '42', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 45, NEWID(), 'Simon den Oudsten', [Id], [Guid], '06-77198679', 'SimondenOudsten@fleckens.hu' from [Location] where [ZipCode] = '1601AK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 45, NEWID(), [Id], [Guid] from person where [Id] = 45;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 46, NEWID(),'7871TD', '55', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 46, NEWID(), 'Billie Helmons', [Id], [Guid], '06-25636316', 'BillieHelmons@armyspy.com' from [Location] where [ZipCode] = '7871TD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 46, NEWID(), [Id], [Guid] from person where [Id] = 46;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 47, NEWID(),'3014ZV', '145', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 47, NEWID(), 'Tubâ van Tuijl', [Id], [Guid], '06-96826303', 'TubavanTuijl@dayrep.com' from [Location] where [ZipCode] = '3014ZV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 47, NEWID(), [Id], [Guid] from person where [Id] = 47;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 48, NEWID(),'5171AA', '188', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 48, NEWID(), 'Lima Stolwijk', [Id], [Guid], '06-74253276', 'LimaStolwijk@einrot.com' from [Location] where [ZipCode] = '5171AA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 48, NEWID(), [Id], [Guid] from person where [Id] = 48;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 49, NEWID(),'1851XH', '97', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 49, NEWID(), 'Iva Langenkamp', [Id], [Guid], '06-88575292', 'IvaLangenkamp@cuvox.de' from [Location] where [ZipCode] = '1851XH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 49, NEWID(), [Id], [Guid] from person where [Id] = 49;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 50, NEWID(),'5612BE', '126', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 50, NEWID(), 'Bregje van Vlerken', [Id], [Guid], '06-76885973', 'BregjevanVlerken@teleworm.us' from [Location] where [ZipCode] = '5612BE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 50, NEWID(), [Id], [Guid] from person where [Id] = 50;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 51, NEWID(),'3043AJ', '8', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 51, NEWID(), 'Carleen van Helvoirt', [Id], [Guid], '06-97649928', 'CarleenvanHelvoirt@fleckens.hu' from [Location] where [ZipCode] = '3043AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 51, NEWID(), [Id], [Guid] from person where [Id] = 51;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 52, NEWID(),'5056BG', '121', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 52, NEWID(), 'Crystal Klaasse', [Id], [Guid], '06-65876767', 'CrystalKlaasse@einrot.com' from [Location] where [ZipCode] = '5056BG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 52, NEWID(), [Id], [Guid] from person where [Id] = 52;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 53, NEWID(),'2681HR', '178', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 53, NEWID(), 'Shaniqua Rodriguez', [Id], [Guid], '06-69054125', 'ShaniquaRodriguez@armyspy.com' from [Location] where [ZipCode] = '2681HR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 53, NEWID(), [Id], [Guid] from person where [Id] = 53;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 54, NEWID(),'2691ER', '105', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 54, NEWID(), 'Anil van Bree', [Id], [Guid], '06-51778134', 'AnilvanBree@teleworm.us' from [Location] where [ZipCode] = '2691ER';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 54, NEWID(), [Id], [Guid] from person where [Id] = 54;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 55, NEWID(),'7151AM', '51', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 55, NEWID(), 'Aoife van Groesen', [Id], [Guid], '06-51985095', 'AoifevanGroesen@jourrapide.com' from [Location] where [ZipCode] = '7151AM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 55, NEWID(), [Id], [Guid] from person where [Id] = 55;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 56, NEWID(),'3752KJ', '183', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 56, NEWID(), 'Miraç Honkoop', [Id], [Guid], '06-36364210', 'MiracHonkoop@einrot.com' from [Location] where [ZipCode] = '3752KJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 56, NEWID(), [Id], [Guid] from person where [Id] = 56;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 57, NEWID(),'1509ZB', '67', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 57, NEWID(), 'Dienke Leito', [Id], [Guid], '06-26818897', 'DienkeLeito@teleworm.us' from [Location] where [ZipCode] = '1509ZB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 57, NEWID(), [Id], [Guid] from person where [Id] = 57;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 58, NEWID(),'6464AJ', '84', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 58, NEWID(), 'Mounssif Angenent', [Id], [Guid], '06-33172540', 'MounssifAngenent@einrot.com' from [Location] where [ZipCode] = '6464AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 58, NEWID(), [Id], [Guid] from person where [Id] = 58;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 59, NEWID(),'1964HC', '36', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 59, NEWID(), 'Tisha Ploeg', [Id], [Guid], '06-68996567', 'TishaPloeg@fleckens.hu' from [Location] where [ZipCode] = '1964HC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 59, NEWID(), [Id], [Guid] from person where [Id] = 59;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 60, NEWID(),'1911EW', '1940-1945140', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 60, NEWID(), 'Gilano Liebrand', [Id], [Guid], '06-36793210', 'GilanoLiebrand@armyspy.com' from [Location] where [ZipCode] = '1911EW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 60, NEWID(), [Id], [Guid] from person where [Id] = 60;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 61, NEWID(),'1945WX', '162', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 61, NEWID(), 'Kely Weima', [Id], [Guid], '06-69305331', 'KelyWeima@cuvox.de' from [Location] where [ZipCode] = '1945WX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 61, NEWID(), [Id], [Guid] from person where [Id] = 61;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 62, NEWID(),'3772AJ', '92', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 62, NEWID(), 'Phil Bel', [Id], [Guid], '06-21472803', 'PhilBel@einrot.com' from [Location] where [ZipCode] = '3772AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 62, NEWID(), [Id], [Guid] from person where [Id] = 62;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 63, NEWID(),'9033XT', '177', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 63, NEWID(), 'Moises Eversdijk', [Id], [Guid], '06-16902890', 'MoisesEversdijk@teleworm.us' from [Location] where [ZipCode] = '9033XT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 63, NEWID(), [Id], [Guid] from person where [Id] = 63;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 64, NEWID(),'2132AV', '55', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 64, NEWID(), 'Josse de Kok', [Id], [Guid], '06-22170220', 'JossedeKok@superrito.com' from [Location] where [ZipCode] = '2132AV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 64, NEWID(), [Id], [Guid] from person where [Id] = 64;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 65, NEWID(),'1781TG', '79', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 65, NEWID(), 'Jesse Wink', [Id], [Guid], '06-82664818', 'JesseWink@dayrep.com' from [Location] where [ZipCode] = '1781TG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 65, NEWID(), [Id], [Guid] from person where [Id] = 65;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 66, NEWID(),'1188DN', '168', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 66, NEWID(), 'Angelle van Buul', [Id], [Guid], '06-14537021', 'AngellevanBuul@cuvox.de' from [Location] where [ZipCode] = '1188DN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 66, NEWID(), [Id], [Guid] from person where [Id] = 66;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 67, NEWID(),'4101HV', '155', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 67, NEWID(), 'Mirella Potters', [Id], [Guid], '06-73316307', 'MirellaPotters@superrito.com' from [Location] where [ZipCode] = '4101HV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 67, NEWID(), [Id], [Guid] from person where [Id] = 67;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 68, NEWID(),'1617KX', '122', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 68, NEWID(), 'Mücahit Belhaj', [Id], [Guid], '06-81353356', 'MucahitBelhaj@rhyta.com' from [Location] where [ZipCode] = '1617KX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 68, NEWID(), [Id], [Guid] from person where [Id] = 68;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 69, NEWID(),'3743HK', '31', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 69, NEWID(), 'Selwin Roerdink', [Id], [Guid], '06-65035315', 'SelwinRoerdink@gustr.com' from [Location] where [ZipCode] = '3743HK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 69, NEWID(), [Id], [Guid] from person where [Id] = 69;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 70, NEWID(),'4354NJ', '101', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 70, NEWID(), 'Imko van der Hart', [Id], [Guid], '06-32690814', 'ImkovanderHart@rhyta.com' from [Location] where [ZipCode] = '4354NJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 70, NEWID(), [Id], [Guid] from person where [Id] = 70;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 71, NEWID(),'6595CA', '113', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 71, NEWID(), 'Jense Smelt', [Id], [Guid], '06-21511121', 'JenseSmelt@gustr.com' from [Location] where [ZipCode] = '6595CA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 71, NEWID(), [Id], [Guid] from person where [Id] = 71;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 72, NEWID(),'3124XB', '141', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 72, NEWID(), 'Charise van Overdijk', [Id], [Guid], '06-73433701', 'CharisevanOverdijk@gustr.com' from [Location] where [ZipCode] = '3124XB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 72, NEWID(), [Id], [Guid] from person where [Id] = 72;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 73, NEWID(),'6535ZZ', '36', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 73, NEWID(), 'Diaz Theeuwen', [Id], [Guid], '06-23598512', 'DiazTheeuwen@superrito.com' from [Location] where [ZipCode] = '6535ZZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 73, NEWID(), [Id], [Guid] from person where [Id] = 73;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 74, NEWID(),'4872PJ', '34', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 74, NEWID(), 'Halima Verstoep', [Id], [Guid], '06-90409481', 'HalimaVerstoep@armyspy.com' from [Location] where [ZipCode] = '4872PJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 74, NEWID(), [Id], [Guid] from person where [Id] = 74;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 75, NEWID(),'8331LJ', '67', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 75, NEWID(), 'Alicja Hollestelle', [Id], [Guid], '06-76069139', 'AlicjaHollestelle@armyspy.com' from [Location] where [ZipCode] = '8331LJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 75, NEWID(), [Id], [Guid] from person where [Id] = 75;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 76, NEWID(),'4571NB', '79', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 76, NEWID(), 'Bernadine Eggen', [Id], [Guid], '06-37036027', 'BernadineEggen@rhyta.com' from [Location] where [ZipCode] = '4571NB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 76, NEWID(), [Id], [Guid] from person where [Id] = 76;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 77, NEWID(),'2564RL', '141', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 77, NEWID(), 'Carly van Meerkerk', [Id], [Guid], '06-10571616', 'CarlyvanMeerkerk@cuvox.de' from [Location] where [ZipCode] = '2564RL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 77, NEWID(), [Id], [Guid] from person where [Id] = 77;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 78, NEWID(),'6538AD', '60', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 78, NEWID(), 'Steff Steentjes', [Id], [Guid], '06-10970813', 'SteffSteentjes@teleworm.us' from [Location] where [ZipCode] = '6538AD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 78, NEWID(), [Id], [Guid] from person where [Id] = 78;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 79, NEWID(),'3079BP', '110', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 79, NEWID(), 'Wijntje Walraven', [Id], [Guid], '06-74057157', 'WijntjeWalraven@fleckens.hu' from [Location] where [ZipCode] = '3079BP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 79, NEWID(), [Id], [Guid] from person where [Id] = 79;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 80, NEWID(),'2152CG', '52', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 80, NEWID(), 'Machteld van Vuure', [Id], [Guid], '06-92235859', 'MachteldvanVuure@dayrep.com' from [Location] where [ZipCode] = '2152CG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 80, NEWID(), [Id], [Guid] from person where [Id] = 80;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 81, NEWID(),'4613GG', '129', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 81, NEWID(), 'Arnout Weterings', [Id], [Guid], '06-73958157', 'ArnoutWeterings@fleckens.hu' from [Location] where [ZipCode] = '4613GG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 81, NEWID(), [Id], [Guid] from person where [Id] = 81;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 82, NEWID(),'1034ME', '79', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 82, NEWID(), 'Nigel van der Kuijl', [Id], [Guid], '06-20000861', 'NigelvanderKuijl@superrito.com' from [Location] where [ZipCode] = '1034ME';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 82, NEWID(), [Id], [Guid] from person where [Id] = 82;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 83, NEWID(),'3891ZH', '151', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 83, NEWID(), 'Alihan Kemerink', [Id], [Guid], '06-38720977', 'AlihanKemerink@einrot.com' from [Location] where [ZipCode] = '3891ZH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 83, NEWID(), [Id], [Guid] from person where [Id] = 83;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 84, NEWID(),'8326DE', '61', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 84, NEWID(), 'Boi Ankersmit', [Id], [Guid], '06-15130798', 'BoiAnkersmit@teleworm.us' from [Location] where [ZipCode] = '8326DE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 84, NEWID(), [Id], [Guid] from person where [Id] = 84;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 85, NEWID(),'3723EX', '.105', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 85, NEWID(), 'Indra Eskes', [Id], [Guid], '06-75108502', 'IndraEskes@gustr.com' from [Location] where [ZipCode] = '3723EX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 85, NEWID(), [Id], [Guid] from person where [Id] = 85;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 86, NEWID(),'1462KA', '50', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 86, NEWID(), 'Rawien Toetenel', [Id], [Guid], '06-78807696', 'RawienToetenel@rhyta.com' from [Location] where [ZipCode] = '1462KA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 86, NEWID(), [Id], [Guid] from person where [Id] = 86;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 87, NEWID(),'3765CK', '73', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 87, NEWID(), 'Bartosz Santbergen', [Id], [Guid], '06-46592285', 'BartoszSantbergen@superrito.com' from [Location] where [ZipCode] = '3765CK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 87, NEWID(), [Id], [Guid] from person where [Id] = 87;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 88, NEWID(),'2941GV', '117', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 88, NEWID(), 'Leonhard Moerdijk', [Id], [Guid], '06-68723321', 'LeonhardMoerdijk@armyspy.com' from [Location] where [ZipCode] = '2941GV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 88, NEWID(), [Id], [Guid] from person where [Id] = 88;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 89, NEWID(),'1071AS', '165', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 89, NEWID(), 'Marielle Loonstra', [Id], [Guid], '06-92590889', 'MarielleLoonstra@fleckens.hu' from [Location] where [ZipCode] = '1071AS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 89, NEWID(), [Id], [Guid] from person where [Id] = 89;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 90, NEWID(),'3572GK', '96', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 90, NEWID(), 'Sammy Prins', [Id], [Guid], '06-72071336', 'SammyPrins@jourrapide.com' from [Location] where [ZipCode] = '3572GK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 90, NEWID(), [Id], [Guid] from person where [Id] = 90;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 91, NEWID(),'1338BB', '64', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 91, NEWID(), 'Akash Stapper', [Id], [Guid], '06-81664591', 'AkashStapper@dayrep.com' from [Location] where [ZipCode] = '1338BB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 91, NEWID(), [Id], [Guid] from person where [Id] = 91;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 92, NEWID(),'7411CT', '44', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 92, NEWID(), 'Engelbert Bervoets', [Id], [Guid], '06-24734095', 'EngelbertBervoets@superrito.com' from [Location] where [ZipCode] = '7411CT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 92, NEWID(), [Id], [Guid] from person where [Id] = 92;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 93, NEWID(),'6834DG', '31', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 93, NEWID(), 'Hinderikus Lammerse', [Id], [Guid], '06-51246262', 'HinderikusLammerse@einrot.com' from [Location] where [ZipCode] = '6834DG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 93, NEWID(), [Id], [Guid] from person where [Id] = 93;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 94, NEWID(),'4567AZ', '200', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 94, NEWID(), 'Fabrizio Cools', [Id], [Guid], '06-87481644', 'FabrizioCools@rhyta.com' from [Location] where [ZipCode] = '4567AZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 94, NEWID(), [Id], [Guid] from person where [Id] = 94;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 95, NEWID(),'4882DG', '138', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 95, NEWID(), 'Elin Manuela', [Id], [Guid], '06-59405438', 'ElinManuela@teleworm.us' from [Location] where [ZipCode] = '4882DG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 95, NEWID(), [Id], [Guid] from person where [Id] = 95;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 96, NEWID(),'5674TN', '33', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 96, NEWID(), 'Joëy Theunisz', [Id], [Guid], '06-41320970', 'JoeyTheunisz@superrito.com' from [Location] where [ZipCode] = '5674TN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 96, NEWID(), [Id], [Guid] from person where [Id] = 96;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 97, NEWID(),'4761LJ', '108', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 97, NEWID(), 'Sümeyra Goessens', [Id], [Guid], '06-23358477', 'SumeyraGoessens@superrito.com' from [Location] where [ZipCode] = '4761LJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 97, NEWID(), [Id], [Guid] from person where [Id] = 97;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 98, NEWID(),'5504TA', '181', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 98, NEWID(), 'Djuna Egging', [Id], [Guid], '06-84838067', 'DjunaEgging@dayrep.com' from [Location] where [ZipCode] = '5504TA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 98, NEWID(), [Id], [Guid] from person where [Id] = 98;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 99, NEWID(),'8064AH', '109', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 99, NEWID(), 'Florien van der Leij', [Id], [Guid], '06-68619891', 'FlorienvanderLeij@dayrep.com' from [Location] where [ZipCode] = '8064AH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 99, NEWID(), [Id], [Guid] from person where [Id] = 99;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 100, NEWID(),'1115TS', '81', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 100, NEWID(), 'Dani Storms', [Id], [Guid], '06-19217889', 'DaniStorms@cuvox.de' from [Location] where [ZipCode] = '1115TS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 100, NEWID(), [Id], [Guid] from person where [Id] = 100;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 101, NEWID(),'7134ND', '152', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 101, NEWID(), 'Sadaf Deenen', [Id], [Guid], '06-33934903', 'SadafDeenen@cuvox.de' from [Location] where [ZipCode] = '7134ND';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 101, NEWID(), [Id], [Guid] from person where [Id] = 101;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 102, NEWID(),'6221TW', '196', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 102, NEWID(), 'Clayton van der Vlist', [Id], [Guid], '06-33959182', 'ClaytonvanderVlist@cuvox.de' from [Location] where [ZipCode] = '6221TW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 102, NEWID(), [Id], [Guid] from person where [Id] = 102;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 103, NEWID(),'5554PZ', '130', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 103, NEWID(), 'Dorcas van Zweeden', [Id], [Guid], '06-59978360', 'DorcasvanZweeden@fleckens.hu' from [Location] where [ZipCode] = '5554PZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 103, NEWID(), [Id], [Guid] from person where [Id] = 103;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 104, NEWID(),'8625HN', '.70', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 104, NEWID(), 'Jolande Vogel', [Id], [Guid], '06-42101677', 'JolandeVogel@cuvox.de' from [Location] where [ZipCode] = '8625HN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 104, NEWID(), [Id], [Guid] from person where [Id] = 104;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 105, NEWID(),'1398BV', '13', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 105, NEWID(), 'Tako van Hoogdalem', [Id], [Guid], '06-19376798', 'TakovanHoogdalem@cuvox.de' from [Location] where [ZipCode] = '1398BV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 105, NEWID(), [Id], [Guid] from person where [Id] = 105;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 106, NEWID(),'4201EH', '181', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 106, NEWID(), 'Guiliano ten Klooster', [Id], [Guid], '06-44011712', 'GuilianotenKlooster@einrot.com' from [Location] where [ZipCode] = '4201EH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 106, NEWID(), [Id], [Guid] from person where [Id] = 106;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 107, NEWID(),'2841RR', '10', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 107, NEWID(), 'Zeyneb Bloemhof', [Id], [Guid], '06-89071584', 'ZeynebBloemhof@gustr.com' from [Location] where [ZipCode] = '2841RR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 107, NEWID(), [Id], [Guid] from person where [Id] = 107;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 108, NEWID(),'3621CP', '190', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 108, NEWID(), 'Atie Duijndam', [Id], [Guid], '06-82128503', 'AtieDuijndam@fleckens.hu' from [Location] where [ZipCode] = '3621CP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 108, NEWID(), [Id], [Guid] from person where [Id] = 108;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 109, NEWID(),'3121JE', '44', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 109, NEWID(), 'Ajdin Schelhaas', [Id], [Guid], '06-30093860', 'AjdinSchelhaas@einrot.com' from [Location] where [ZipCode] = '3121JE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 109, NEWID(), [Id], [Guid] from person where [Id] = 109;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 110, NEWID(),'1501VN', '147', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 110, NEWID(), 'Antoine de Hek', [Id], [Guid], '06-81281938', 'AntoinedeHek@rhyta.com' from [Location] where [ZipCode] = '1501VN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 110, NEWID(), [Id], [Guid] from person where [Id] = 110;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 111, NEWID(),'3402TT', '135', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 111, NEWID(), 'Rizwan Gielissen', [Id], [Guid], '06-25639367', 'RizwanGielissen@teleworm.us' from [Location] where [ZipCode] = '3402TT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 111, NEWID(), [Id], [Guid] from person where [Id] = 111;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 112, NEWID(),'1971GA', '1945181', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 112, NEWID(), 'Quinte Vendel', [Id], [Guid], '06-52310107', 'QuinteVendel@dayrep.com' from [Location] where [ZipCode] = '1971GA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 112, NEWID(), [Id], [Guid] from person where [Id] = 112;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 113, NEWID(),'7764AS', '51', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 113, NEWID(), 'Cherinda Klerx', [Id], [Guid], '06-90509918', 'CherindaKlerx@superrito.com' from [Location] where [ZipCode] = '7764AS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 113, NEWID(), [Id], [Guid] from person where [Id] = 113;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 114, NEWID(),'1335VG', '191', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 114, NEWID(), 'Casparus Hogendorp', [Id], [Guid], '06-70362920', 'CasparusHogendorp@superrito.com' from [Location] where [ZipCode] = '1335VG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 114, NEWID(), [Id], [Guid] from person where [Id] = 114;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 115, NEWID(),'2396VG', '84', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 115, NEWID(), 'Raya Ophorst', [Id], [Guid], '06-82095420', 'RayaOphorst@rhyta.com' from [Location] where [ZipCode] = '2396VG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 115, NEWID(), [Id], [Guid] from person where [Id] = 115;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 116, NEWID(),'8322CR', '158', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 116, NEWID(), 'Sefer Boomkamp', [Id], [Guid], '06-76833536', 'SeferBoomkamp@cuvox.de' from [Location] where [ZipCode] = '8322CR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 116, NEWID(), [Id], [Guid] from person where [Id] = 116;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 117, NEWID(),'1326ED', '162', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 117, NEWID(), 'Silver van Gulik', [Id], [Guid], '06-70591161', 'SilvervanGulik@rhyta.com' from [Location] where [ZipCode] = '1326ED';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 117, NEWID(), [Id], [Guid] from person where [Id] = 117;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 118, NEWID(),'8926XJ', '63', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 118, NEWID(), 'Sezen Jongenelen', [Id], [Guid], '06-52188476', 'SezenJongenelen@superrito.com' from [Location] where [ZipCode] = '8926XJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 118, NEWID(), [Id], [Guid] from person where [Id] = 118;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 119, NEWID(),'3633ET', '127', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 119, NEWID(), 'Camiel Cobben', [Id], [Guid], '06-81052641', 'CamielCobben@rhyta.com' from [Location] where [ZipCode] = '3633ET';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 119, NEWID(), [Id], [Guid] from person where [Id] = 119;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 120, NEWID(),'6049HK', '181', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 120, NEWID(), 'Maximillian van Doesburg', [Id], [Guid], '06-81177361', 'MaximillianvanDoesburg@teleworm.us' from [Location] where [ZipCode] = '6049HK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 120, NEWID(), [Id], [Guid] from person where [Id] = 120;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 121, NEWID(),'4373AG', '11', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 121, NEWID(), 'Nicky Bleij', [Id], [Guid], '06-77778102', 'NickyBleij@armyspy.com' from [Location] where [ZipCode] = '4373AG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 121, NEWID(), [Id], [Guid] from person where [Id] = 121;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 122, NEWID(),'3331RG', '103', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 122, NEWID(), 'Dionysia Leenaars', [Id], [Guid], '06-62429135', 'DionysiaLeenaars@rhyta.com' from [Location] where [ZipCode] = '3331RG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 122, NEWID(), [Id], [Guid] from person where [Id] = 122;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 123, NEWID(),'1401SZ', '198', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 123, NEWID(), 'Soner Buil', [Id], [Guid], '06-39811960', 'SonerBuil@rhyta.com' from [Location] where [ZipCode] = '1401SZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 123, NEWID(), [Id], [Guid] from person where [Id] = 123;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 124, NEWID(),'5224GE', '173', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 124, NEWID(), 'Indy van Seters', [Id], [Guid], '06-18743054', 'IndyvanSeters@jourrapide.com' from [Location] where [ZipCode] = '5224GE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 124, NEWID(), [Id], [Guid] from person where [Id] = 124;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 125, NEWID(),'2563SV', '70', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 125, NEWID(), 'Ouissam Kool', [Id], [Guid], '06-20334057', 'OuissamKool@fleckens.hu' from [Location] where [ZipCode] = '2563SV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 125, NEWID(), [Id], [Guid] from person where [Id] = 125;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 126, NEWID(),'3421AH', '61', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 126, NEWID(), 'Gerald Kaddouri', [Id], [Guid], '06-65027749', 'GeraldKaddouri@gustr.com' from [Location] where [ZipCode] = '3421AH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 126, NEWID(), [Id], [Guid] from person where [Id] = 126;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 127, NEWID(),'2543AE', '128', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 127, NEWID(), 'Gian Hulsebosch', [Id], [Guid], '06-50965418', 'GianHulsebosch@dayrep.com' from [Location] where [ZipCode] = '2543AE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 127, NEWID(), [Id], [Guid] from person where [Id] = 127;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 128, NEWID(),'3701GA', '42', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 128, NEWID(), 'Annejet Daniëls', [Id], [Guid], '06-17647919', 'AnnejetDaniels@gustr.com' from [Location] where [ZipCode] = '3701GA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 128, NEWID(), [Id], [Guid] from person where [Id] = 128;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 129, NEWID(),'7764AB', '124', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 129, NEWID(), 'Nordin Laven', [Id], [Guid], '06-32913365', 'NordinLaven@teleworm.us' from [Location] where [ZipCode] = '7764AB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 129, NEWID(), [Id], [Guid] from person where [Id] = 129;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 130, NEWID(),'2665GL', '13', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 130, NEWID(), 'Aycan Verstraaten', [Id], [Guid], '06-47860114', 'AycanVerstraaten@rhyta.com' from [Location] where [ZipCode] = '2665GL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 130, NEWID(), [Id], [Guid] from person where [Id] = 130;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 131, NEWID(),'3054RV', '17', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 131, NEWID(), 'Chandni Oosterhof', [Id], [Guid], '06-55401073', 'ChandniOosterhof@fleckens.hu' from [Location] where [ZipCode] = '3054RV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 131, NEWID(), [Id], [Guid] from person where [Id] = 131;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 132, NEWID(),'5017CW', '91', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 132, NEWID(), 'Douglas Boonstra', [Id], [Guid], '06-57554476', 'DouglasBoonstra@teleworm.us' from [Location] where [ZipCode] = '5017CW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 132, NEWID(), [Id], [Guid] from person where [Id] = 132;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 133, NEWID(),'1171AT', '109', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 133, NEWID(), 'Jesca Beldman', [Id], [Guid], '06-22935842', 'JescaBeldman@rhyta.com' from [Location] where [ZipCode] = '1171AT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 133, NEWID(), [Id], [Guid] from person where [Id] = 133;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 134, NEWID(),'3945BE', '90', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 134, NEWID(), 'Barthold Aarnoutse', [Id], [Guid], '06-45919186', 'BartholdAarnoutse@gustr.com' from [Location] where [ZipCode] = '3945BE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 134, NEWID(), [Id], [Guid] from person where [Id] = 134;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 135, NEWID(),'8748CV', '153', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 135, NEWID(), 'Michaël Zwerver', [Id], [Guid], '06-36329293', 'MichaelZwerver@armyspy.com' from [Location] where [ZipCode] = '8748CV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 135, NEWID(), [Id], [Guid] from person where [Id] = 135;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 136, NEWID(),'3525AA', '44', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 136, NEWID(), 'Mahmut Woltjer', [Id], [Guid], '06-49531136', 'MahmutWoltjer@superrito.com' from [Location] where [ZipCode] = '3525AA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 136, NEWID(), [Id], [Guid] from person where [Id] = 136;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 137, NEWID(),'1336AT', '.128', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 137, NEWID(), 'Taner Nederstigt', [Id], [Guid], '06-51931127', 'TanerNederstigt@einrot.com' from [Location] where [ZipCode] = '1336AT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 137, NEWID(), [Id], [Guid] from person where [Id] = 137;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 138, NEWID(),'5343HV', '92', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 138, NEWID(), 'Chelsea de Nijs', [Id], [Guid], '06-18744352', 'ChelseadeNijs@fleckens.hu' from [Location] where [ZipCode] = '5343HV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 138, NEWID(), [Id], [Guid] from person where [Id] = 138;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 139, NEWID(),'1751LE', '44', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 139, NEWID(), 'Kane Hebing', [Id], [Guid], '06-76083363', 'KaneHebing@jourrapide.com' from [Location] where [ZipCode] = '1751LE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 139, NEWID(), [Id], [Guid] from person where [Id] = 139;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 140, NEWID(),'1444AC', '90', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 140, NEWID(), 'Ibtisame van der Hijden', [Id], [Guid], '06-31578305', 'IbtisamevanderHijden@einrot.com' from [Location] where [ZipCode] = '1444AC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 140, NEWID(), [Id], [Guid] from person where [Id] = 140;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 141, NEWID(),'6953AD', '126', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 141, NEWID(), 'Lissa Verbeek', [Id], [Guid], '06-81691727', 'LissaVerbeek@superrito.com' from [Location] where [ZipCode] = '6953AD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 141, NEWID(), [Id], [Guid] from person where [Id] = 141;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 142, NEWID(),'5302VA', '105', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 142, NEWID(), 'Sven van den Boorn', [Id], [Guid], '06-90246771', 'SvenvandenBoorn@gustr.com' from [Location] where [ZipCode] = '5302VA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 142, NEWID(), [Id], [Guid] from person where [Id] = 142;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 143, NEWID(),'7431EM', '184', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 143, NEWID(), 'Elisa van Hilten', [Id], [Guid], '06-29952094', 'ElisavanHilten@jourrapide.com' from [Location] where [ZipCode] = '7431EM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 143, NEWID(), [Id], [Guid] from person where [Id] = 143;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 144, NEWID(),'4351AG', '168', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 144, NEWID(), 'Coenraad Ridderhof', [Id], [Guid], '06-74690791', 'CoenraadRidderhof@fleckens.hu' from [Location] where [ZipCode] = '4351AG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 144, NEWID(), [Id], [Guid] from person where [Id] = 144;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 145, NEWID(),'5046NL', '195', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 145, NEWID(), 'Bosse Oomen', [Id], [Guid], '06-27993250', 'BosseOomen@einrot.com' from [Location] where [ZipCode] = '5046NL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 145, NEWID(), [Id], [Guid] from person where [Id] = 145;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 146, NEWID(),'8162JC', '79', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 146, NEWID(), 'Timur Reuvers', [Id], [Guid], '06-11722780', 'TimurReuvers@armyspy.com' from [Location] where [ZipCode] = '8162JC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 146, NEWID(), [Id], [Guid] from person where [Id] = 146;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 147, NEWID(),'2563AG', '142', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 147, NEWID(), 'Julius Zoutendijk', [Id], [Guid], '06-88075630', 'JuliusZoutendijk@armyspy.com' from [Location] where [ZipCode] = '2563AG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 147, NEWID(), [Id], [Guid] from person where [Id] = 147;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 148, NEWID(),'4707ZA', '31', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 148, NEWID(), 'Kiefer Hölscher', [Id], [Guid], '06-99121724', 'KieferHolscher@armyspy.com' from [Location] where [ZipCode] = '4707ZA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 148, NEWID(), [Id], [Guid] from person where [Id] = 148;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 149, NEWID(),'1141ZW', '100', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 149, NEWID(), 'Laurence van Burgsteden', [Id], [Guid], '06-73092177', 'LaurencevanBurgsteden@jourrapide.com' from [Location] where [ZipCode] = '1141ZW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 149, NEWID(), [Id], [Guid] from person where [Id] = 149;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 150, NEWID(),'3921AJ', '101', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 150, NEWID(), 'Abigaïl Augustijn', [Id], [Guid], '06-53355925', 'AbigailAugustijn@rhyta.com' from [Location] where [ZipCode] = '3921AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 150, NEWID(), [Id], [Guid] from person where [Id] = 150;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 151, NEWID(),'6823MR', '44', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 151, NEWID(), 'Farid Batenburg', [Id], [Guid], '06-44640053', 'FaridBatenburg@rhyta.com' from [Location] where [ZipCode] = '6823MR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 151, NEWID(), [Id], [Guid] from person where [Id] = 151;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 152, NEWID(),'3039LJ', '129', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 152, NEWID(), 'Kajol Bouwknegt', [Id], [Guid], '06-62595347', 'KajolBouwknegt@jourrapide.com' from [Location] where [ZipCode] = '3039LJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 152, NEWID(), [Id], [Guid] from person where [Id] = 152;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 153, NEWID(),'1566LL', '182', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 153, NEWID(), 'Eylem Cats', [Id], [Guid], '06-58126823', 'EylemCats@teleworm.us' from [Location] where [ZipCode] = '1566LL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 153, NEWID(), [Id], [Guid] from person where [Id] = 153;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 154, NEWID(),'2546BH', '200', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 154, NEWID(), 'Duco Boland', [Id], [Guid], '06-35879364', 'DucoBoland@superrito.com' from [Location] where [ZipCode] = '2546BH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 154, NEWID(), [Id], [Guid] from person where [Id] = 154;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 155, NEWID(),'3471GK', '133', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 155, NEWID(), 'Elger Keller', [Id], [Guid], '06-94344903', 'ElgerKeller@dayrep.com' from [Location] where [ZipCode] = '3471GK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 155, NEWID(), [Id], [Guid] from person where [Id] = 155;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 156, NEWID(),'4001CN', '78', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 156, NEWID(), 'Youandi Kluijtmans', [Id], [Guid], '06-90827077', 'YouandiKluijtmans@jourrapide.com' from [Location] where [ZipCode] = '4001CN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 156, NEWID(), [Id], [Guid] from person where [Id] = 156;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 157, NEWID(),'4382JM', '129', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 157, NEWID(), 'Milouda Lok', [Id], [Guid], '06-75062273', 'MiloudaLok@armyspy.com' from [Location] where [ZipCode] = '4382JM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 157, NEWID(), [Id], [Guid] from person where [Id] = 157;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 158, NEWID(),'9861AJ', '70', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 158, NEWID(), 'Georgios Westerkamp', [Id], [Guid], '06-66912181', 'GeorgiosWesterkamp@teleworm.us' from [Location] where [ZipCode] = '9861AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 158, NEWID(), [Id], [Guid] from person where [Id] = 158;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 159, NEWID(),'6538AG', '19', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 159, NEWID(), 'Itske Bergers', [Id], [Guid], '06-26136875', 'ItskeBergers@rhyta.com' from [Location] where [ZipCode] = '6538AG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 159, NEWID(), [Id], [Guid] from person where [Id] = 159;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 160, NEWID(),'5971BX', '57', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 160, NEWID(), 'Arend Lindelauf', [Id], [Guid], '06-46223143', 'ArendLindelauf@einrot.com' from [Location] where [ZipCode] = '5971BX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 160, NEWID(), [Id], [Guid] from person where [Id] = 160;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 161, NEWID(),'7321AX', '10', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 161, NEWID(), 'Tugay Knipscheer', [Id], [Guid], '06-83177598', 'TugayKnipscheer@armyspy.com' from [Location] where [ZipCode] = '7321AX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 161, NEWID(), [Id], [Guid] from person where [Id] = 161;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 162, NEWID(),'7325DW', '90', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 162, NEWID(), 'Charita van Hameren', [Id], [Guid], '06-77840987', 'CharitavanHameren@cuvox.de' from [Location] where [ZipCode] = '7325DW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 162, NEWID(), [Id], [Guid] from person where [Id] = 162;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 163, NEWID(),'2161DS', '17', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 163, NEWID(), 'Deny Wijnbergen', [Id], [Guid], '06-70127045', 'DenyWijnbergen@jourrapide.com' from [Location] where [ZipCode] = '2161DS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 163, NEWID(), [Id], [Guid] from person where [Id] = 163;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 164, NEWID(),'1733EW', '171', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 164, NEWID(), 'Sofieke Parlevliet', [Id], [Guid], '06-44692472', 'SofiekeParlevliet@teleworm.us' from [Location] where [ZipCode] = '1733EW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 164, NEWID(), [Id], [Guid] from person where [Id] = 164;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 165, NEWID(),'2624AW', '31', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 165, NEWID(), 'Kathelijn Zijderveld', [Id], [Guid], '06-55646026', 'KathelijnZijderveld@cuvox.de' from [Location] where [ZipCode] = '2624AW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 165, NEWID(), [Id], [Guid] from person where [Id] = 165;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 166, NEWID(),'4471PE', '72', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 166, NEWID(), 'Owen van Panhuis', [Id], [Guid], '06-29458783', 'OwenvanPanhuis@armyspy.com' from [Location] where [ZipCode] = '4471PE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 166, NEWID(), [Id], [Guid] from person where [Id] = 166;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 167, NEWID(),'3053ZL', '12', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 167, NEWID(), 'Radhika Millenaar', [Id], [Guid], '06-22116564', 'RadhikaMillenaar@dayrep.com' from [Location] where [ZipCode] = '3053ZL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 167, NEWID(), [Id], [Guid] from person where [Id] = 167;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 168, NEWID(),'2103TZ', '66', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 168, NEWID(), 'Abir Meulenbroeks', [Id], [Guid], '06-85376994', 'AbirMeulenbroeks@jourrapide.com' from [Location] where [ZipCode] = '2103TZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 168, NEWID(), [Id], [Guid] from person where [Id] = 168;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 169, NEWID(),'1965TP', '55', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 169, NEWID(), 'Jona de Dood', [Id], [Guid], '06-86891246', 'JonadeDood@einrot.com' from [Location] where [ZipCode] = '1965TP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 169, NEWID(), [Id], [Guid] from person where [Id] = 169;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 170, NEWID(),'4351RK', '168', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 170, NEWID(), 'Thijs Reurink', [Id], [Guid], '06-88970782', 'ThijsReurink@rhyta.com' from [Location] where [ZipCode] = '4351RK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 170, NEWID(), [Id], [Guid] from person where [Id] = 170;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 171, NEWID(),'1503KB', '76', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 171, NEWID(), 'Roelfien Polet', [Id], [Guid], '06-29043231', 'RoelfienPolet@einrot.com' from [Location] where [ZipCode] = '1503KB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 171, NEWID(), [Id], [Guid] from person where [Id] = 171;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 172, NEWID(),'6581JK', '98', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 172, NEWID(), 'Vinay Roelofs', [Id], [Guid], '06-55847603', 'VinayRoelofs@dayrep.com' from [Location] where [ZipCode] = '6581JK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 172, NEWID(), [Id], [Guid] from person where [Id] = 172;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 173, NEWID(),'6562BM', '157', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 173, NEWID(), 'Catherine Hoogland', [Id], [Guid], '06-40498238', 'CatherineHoogland@jourrapide.com' from [Location] where [ZipCode] = '6562BM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 173, NEWID(), [Id], [Guid] from person where [Id] = 173;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 174, NEWID(),'2951BT', '103', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 174, NEWID(), 'Savana Theuws', [Id], [Guid], '06-74062080', 'SavanaTheuws@cuvox.de' from [Location] where [ZipCode] = '2951BT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 174, NEWID(), [Id], [Guid] from person where [Id] = 174;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 175, NEWID(),'5643RN', '63', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 175, NEWID(), 'Cindel Haast', [Id], [Guid], '06-21578744', 'CindelHaast@einrot.com' from [Location] where [ZipCode] = '5643RN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 175, NEWID(), [Id], [Guid] from person where [Id] = 175;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 176, NEWID(),'2266HW', '187', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 176, NEWID(), 'Pieternella Vermeeren', [Id], [Guid], '06-12135168', 'PieternellaVermeeren@fleckens.hu' from [Location] where [ZipCode] = '2266HW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 176, NEWID(), [Id], [Guid] from person where [Id] = 176;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 177, NEWID(),'3927GJ', '21', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 177, NEWID(), 'Floris Schaaphok', [Id], [Guid], '06-36572646', 'FlorisSchaaphok@einrot.com' from [Location] where [ZipCode] = '3927GJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 177, NEWID(), [Id], [Guid] from person where [Id] = 177;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 178, NEWID(),'7783GD', '88', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 178, NEWID(), 'Açelya van Amersfoort', [Id], [Guid], '06-18764325', 'AcelyavanAmersfoort@dayrep.com' from [Location] where [ZipCode] = '7783GD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 178, NEWID(), [Id], [Guid] from person where [Id] = 178;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 179, NEWID(),'2289EG', '198', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 179, NEWID(), 'Oege Groenewegen', [Id], [Guid], '06-11283838', 'OegeGroenewegen@cuvox.de' from [Location] where [ZipCode] = '2289EG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 179, NEWID(), [Id], [Guid] from person where [Id] = 179;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 180, NEWID(),'5704HM', '8', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 180, NEWID(), 'Tülin van Nielen', [Id], [Guid], '06-83232557', 'TulinvanNielen@einrot.com' from [Location] where [ZipCode] = '5704HM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 180, NEWID(), [Id], [Guid] from person where [Id] = 180;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 181, NEWID(),'1326CA', '52', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 181, NEWID(), 'Rob Pigmans', [Id], [Guid], '06-68035031', 'RobPigmans@cuvox.de' from [Location] where [ZipCode] = '1326CA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 181, NEWID(), [Id], [Guid] from person where [Id] = 181;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 182, NEWID(),'3471GV', '181', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 182, NEWID(), 'Sibel Fijneman', [Id], [Guid], '06-24753665', 'SibelFijneman@cuvox.de' from [Location] where [ZipCode] = '3471GV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 182, NEWID(), [Id], [Guid] from person where [Id] = 182;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 183, NEWID(),'4462AS', '7', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 183, NEWID(), 'Hebe de Vreeze', [Id], [Guid], '06-56148376', 'HebedeVreeze@einrot.com' from [Location] where [ZipCode] = '4462AS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 183, NEWID(), [Id], [Guid] from person where [Id] = 183;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 184, NEWID(),'1402TM', '46', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 184, NEWID(), 'Hilligje Drissen', [Id], [Guid], '06-34036112', 'HilligjeDrissen@jourrapide.com' from [Location] where [ZipCode] = '1402TM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 184, NEWID(), [Id], [Guid] from person where [Id] = 184;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 185, NEWID(),'1423RB', '156', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 185, NEWID(), 'Adelina Dries', [Id], [Guid], '06-27294452', 'AdelinaDries@rhyta.com' from [Location] where [ZipCode] = '1423RB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 185, NEWID(), [Id], [Guid] from person where [Id] = 185;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 186, NEWID(),'1060PC', '130', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 186, NEWID(), 'Nawal van Halen', [Id], [Guid], '06-88426063', 'NawalvanHalen@superrito.com' from [Location] where [ZipCode] = '1060PC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 186, NEWID(), [Id], [Guid] from person where [Id] = 186;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 187, NEWID(),'9402HD', '17', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 187, NEWID(), 'Shiela Vogels', [Id], [Guid], '06-51618398', 'ShielaVogels@cuvox.de' from [Location] where [ZipCode] = '9402HD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 187, NEWID(), [Id], [Guid] from person where [Id] = 187;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 188, NEWID(),'2441AV', '93', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 188, NEWID(), 'Alicia Hommes', [Id], [Guid], '06-34580823', 'AliciaHommes@einrot.com' from [Location] where [ZipCode] = '2441AV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 188, NEWID(), [Id], [Guid] from person where [Id] = 188;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 189, NEWID(),'5708DL', '197', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 189, NEWID(), 'Jella de Bekker', [Id], [Guid], '06-85606110', 'JelladeBekker@einrot.com' from [Location] where [ZipCode] = '5708DL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 189, NEWID(), [Id], [Guid] from person where [Id] = 189;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 190, NEWID(),'3081PL', '174', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 190, NEWID(), 'Alexandre Ubbink', [Id], [Guid], '06-90237818', 'AlexandreUbbink@fleckens.hu' from [Location] where [ZipCode] = '3081PL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 190, NEWID(), [Id], [Guid] from person where [Id] = 190;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 191, NEWID(),'3201HE', '165', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 191, NEWID(), 'Wendelina Geerlings', [Id], [Guid], '06-84008797', 'WendelinaGeerlings@fleckens.hu' from [Location] where [ZipCode] = '3201HE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 191, NEWID(), [Id], [Guid] from person where [Id] = 191;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 192, NEWID(),'5403AT', '97', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 192, NEWID(), 'Ming Groenevelt', [Id], [Guid], '06-99368075', 'MingGroenevelt@gustr.com' from [Location] where [ZipCode] = '5403AT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 192, NEWID(), [Id], [Guid] from person where [Id] = 192;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 193, NEWID(),'3072XW', '36', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 193, NEWID(), 'Melvin Jama', [Id], [Guid], '06-17873587', 'MelvinJama@teleworm.us' from [Location] where [ZipCode] = '3072XW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 193, NEWID(), [Id], [Guid] from person where [Id] = 193;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 194, NEWID(),'3582AA', '10', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 194, NEWID(), 'Birgitta Crum', [Id], [Guid], '06-99057287', 'BirgittaCrum@armyspy.com' from [Location] where [ZipCode] = '3582AA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 194, NEWID(), [Id], [Guid] from person where [Id] = 194;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 195, NEWID(),'8251ZA', '157', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 195, NEWID(), 'Jelka Neumann', [Id], [Guid], '06-31124374', 'JelkaNeumann@fleckens.hu' from [Location] where [ZipCode] = '8251ZA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 195, NEWID(), [Id], [Guid] from person where [Id] = 195;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 196, NEWID(),'4645HG', '178', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 196, NEWID(), 'Casandra Schrik', [Id], [Guid], '06-60304762', 'CasandraSchrik@rhyta.com' from [Location] where [ZipCode] = '4645HG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 196, NEWID(), [Id], [Guid] from person where [Id] = 196;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 197, NEWID(),'8506CA', '34', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 197, NEWID(), 'Wick Mols', [Id], [Guid], '06-41024450', 'WickMols@gustr.com' from [Location] where [ZipCode] = '8506CA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 197, NEWID(), [Id], [Guid] from person where [Id] = 197;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 198, NEWID(),'2871NG', '161', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 198, NEWID(), 'Saeed Hoffman', [Id], [Guid], '06-60210298', 'SaeedHoffman@superrito.com' from [Location] where [ZipCode] = '2871NG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 198, NEWID(), [Id], [Guid] from person where [Id] = 198;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 199, NEWID(),'6223BE', '159', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 199, NEWID(), 'Rafael Bierkens', [Id], [Guid], '06-21562638', 'RafaelBierkens@gustr.com' from [Location] where [ZipCode] = '6223BE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 199, NEWID(), [Id], [Guid] from person where [Id] = 199;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 200, NEWID(),'8939EP', '136', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 200, NEWID(), 'Remie Koolmees', [Id], [Guid], '06-80152296', 'RemieKoolmees@dayrep.com' from [Location] where [ZipCode] = '8939EP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 200, NEWID(), [Id], [Guid] from person where [Id] = 200;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 201, NEWID(),'7322HC', '80', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 201, NEWID(), 'Juriën van der Ark', [Id], [Guid], '06-48248176', 'JurienvanderArk@rhyta.com' from [Location] where [ZipCode] = '7322HC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 201, NEWID(), [Id], [Guid] from person where [Id] = 201;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 202, NEWID(),'7314KT', '169', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 202, NEWID(), 'Arnoldina van Cuijk', [Id], [Guid], '06-57806869', 'ArnoldinavanCuijk@cuvox.de' from [Location] where [ZipCode] = '7314KT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 202, NEWID(), [Id], [Guid] from person where [Id] = 202;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 203, NEWID(),'9744JB', '..193', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 203, NEWID(), 'Arsen Twaalfhoven', [Id], [Guid], '06-33030182', 'ArsenTwaalfhoven@fleckens.hu' from [Location] where [ZipCode] = '9744JB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 203, NEWID(), [Id], [Guid] from person where [Id] = 203;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 204, NEWID(),'3971MN', '77', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 204, NEWID(), 'Pippa van Baarle', [Id], [Guid], '06-19676522', 'PippavanBaarle@superrito.com' from [Location] where [ZipCode] = '3971MN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 204, NEWID(), [Id], [Guid] from person where [Id] = 204;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 205, NEWID(),'3515XH', '33', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 205, NEWID(), 'Semra Vrolijk', [Id], [Guid], '06-95926512', 'SemraVrolijk@rhyta.com' from [Location] where [ZipCode] = '3515XH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 205, NEWID(), [Id], [Guid] from person where [Id] = 205;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 206, NEWID(),'5301SR', '150', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 206, NEWID(), 'Geneva Gomes', [Id], [Guid], '06-36702101', 'GenevaGomes@einrot.com' from [Location] where [ZipCode] = '5301SR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 206, NEWID(), [Id], [Guid] from person where [Id] = 206;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 207, NEWID(),'1218EC', '96', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 207, NEWID(), 'Germaine Thijs', [Id], [Guid], '06-33503850', 'GermaineThijs@jourrapide.com' from [Location] where [ZipCode] = '1218EC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 207, NEWID(), [Id], [Guid] from person where [Id] = 207;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 208, NEWID(),'9291AW', '135', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 208, NEWID(), 'Battal Koppen', [Id], [Guid], '06-76868925', 'BattalKoppen@einrot.com' from [Location] where [ZipCode] = '9291AW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 208, NEWID(), [Id], [Guid] from person where [Id] = 208;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 209, NEWID(),'6961TZ', '96', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 209, NEWID(), 'Erik van den Dool', [Id], [Guid], '06-19604148', 'ErikvandenDool@gustr.com' from [Location] where [ZipCode] = '6961TZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 209, NEWID(), [Id], [Guid] from person where [Id] = 209;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 210, NEWID(),'4624BE', '181', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 210, NEWID(), 'Wendelina Nooij', [Id], [Guid], '06-26523167', 'WendelinaNooij@gustr.com' from [Location] where [ZipCode] = '4624BE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 210, NEWID(), [Id], [Guid] from person where [Id] = 210;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 211, NEWID(),'7322CJ', '77', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 211, NEWID(), 'Mesut Konst', [Id], [Guid], '06-73414070', 'MesutKonst@teleworm.us' from [Location] where [ZipCode] = '7322CJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 211, NEWID(), [Id], [Guid] from person where [Id] = 211;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 212, NEWID(),'7101WK', '119', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 212, NEWID(), 'Gezina Schetters', [Id], [Guid], '06-60827904', 'GezinaSchetters@jourrapide.com' from [Location] where [ZipCode] = '7101WK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 212, NEWID(), [Id], [Guid] from person where [Id] = 212;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 213, NEWID(),'2331BC', '24', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 213, NEWID(), 'Brigit Duijm', [Id], [Guid], '06-29959702', 'BrigitDuijm@superrito.com' from [Location] where [ZipCode] = '2331BC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 213, NEWID(), [Id], [Guid] from person where [Id] = 213;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 214, NEWID(),'1077AZ', '71', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 214, NEWID(), 'Gülizar Jager', [Id], [Guid], '06-13135564', 'GulizarJager@rhyta.com' from [Location] where [ZipCode] = '1077AZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 214, NEWID(), [Id], [Guid] from person where [Id] = 214;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 215, NEWID(),'4675CJ', '135', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 215, NEWID(), 'Larry Hoveling', [Id], [Guid], '06-95725704', 'LarryHoveling@teleworm.us' from [Location] where [ZipCode] = '4675CJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 215, NEWID(), [Id], [Guid] from person where [Id] = 215;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 216, NEWID(),'4441BE', '127', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 216, NEWID(), 'Florentius Brands', [Id], [Guid], '06-57431099', 'FlorentiusBrands@cuvox.de' from [Location] where [ZipCode] = '4441BE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 216, NEWID(), [Id], [Guid] from person where [Id] = 216;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 217, NEWID(),'1189VK', '75', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 217, NEWID(), 'Basma van Groningen', [Id], [Guid], '06-36716894', 'BasmavanGroningen@armyspy.com' from [Location] where [ZipCode] = '1189VK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 217, NEWID(), [Id], [Guid] from person where [Id] = 217;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 218, NEWID(),'4815CJ', '75', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 218, NEWID(), 'Reginald van t Oever', [Id], [Guid], '06-90521242', 'ReginaldvantOever@einrot.com' from [Location] where [ZipCode] = '4815CJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 218, NEWID(), [Id], [Guid] from person where [Id] = 218;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 219, NEWID(),'4818LV', '101', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 219, NEWID(), 'Cathleen Mosch', [Id], [Guid], '06-97031389', 'CathleenMosch@jourrapide.com' from [Location] where [ZipCode] = '4818LV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 219, NEWID(), [Id], [Guid] from person where [Id] = 219;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 220, NEWID(),'1815CG', '9', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 220, NEWID(), 'Naomi Bisselink', [Id], [Guid], '06-36948269', 'NaomiBisselink@superrito.com' from [Location] where [ZipCode] = '1815CG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 220, NEWID(), [Id], [Guid] from person where [Id] = 220;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 221, NEWID(),'1432AD', '42', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 221, NEWID(), 'Anwar van Herwaarden', [Id], [Guid], '06-31343488', 'AnwarvanHerwaarden@rhyta.com' from [Location] where [ZipCode] = '1432AD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 221, NEWID(), [Id], [Guid] from person where [Id] = 221;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 222, NEWID(),'3621HS', '35', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 222, NEWID(), 'Douha Karels', [Id], [Guid], '06-47992119', 'DouhaKarels@superrito.com' from [Location] where [ZipCode] = '3621HS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 222, NEWID(), [Id], [Guid] from person where [Id] = 222;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 223, NEWID(),'8855CZ', '54', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 223, NEWID(), 'Hamda van Schalkwijk', [Id], [Guid], '06-48469068', 'HamdavanSchalkwijk@gustr.com' from [Location] where [ZipCode] = '8855CZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 223, NEWID(), [Id], [Guid] from person where [Id] = 223;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 224, NEWID(),'5988NR', '171', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 224, NEWID(), 'Harmannus Marcelis', [Id], [Guid], '06-94812044', 'HarmannusMarcelis@gustr.com' from [Location] where [ZipCode] = '5988NR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 224, NEWID(), [Id], [Guid] from person where [Id] = 224;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 225, NEWID(),'3086WG', '59', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 225, NEWID(), 'Sake ter Borg', [Id], [Guid], '06-94291445', 'SaketerBorg@fleckens.hu' from [Location] where [ZipCode] = '3086WG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 225, NEWID(), [Id], [Guid] from person where [Id] = 225;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 226, NEWID(),'6143BM', '163', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 226, NEWID(), 'Jessica Honkoop', [Id], [Guid], '06-78385298', 'JessicaHonkoop@superrito.com' from [Location] where [ZipCode] = '6143BM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 226, NEWID(), [Id], [Guid] from person where [Id] = 226;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 227, NEWID(),'5614HV', '33', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 227, NEWID(), 'Master Tetteroo', [Id], [Guid], '06-77131210', 'MasterTetteroo@armyspy.com' from [Location] where [ZipCode] = '5614HV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 227, NEWID(), [Id], [Guid] from person where [Id] = 227;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 228, NEWID(),'3721JT', '3', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 228, NEWID(), 'Gerharda Laros', [Id], [Guid], '06-45081366', 'GerhardaLaros@einrot.com' from [Location] where [ZipCode] = '3721JT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 228, NEWID(), [Id], [Guid] from person where [Id] = 228;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 229, NEWID(),'3911XZ', '92', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 229, NEWID(), 'Songul Maria', [Id], [Guid], '06-88811714', 'SongulMaria@cuvox.de' from [Location] where [ZipCode] = '3911XZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 229, NEWID(), [Id], [Guid] from person where [Id] = 229;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 230, NEWID(),'8936AP', '143', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 230, NEWID(), 'Jannes van der Ven', [Id], [Guid], '06-17022483', 'JannesvanderVen@jourrapide.com' from [Location] where [ZipCode] = '8936AP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 230, NEWID(), [Id], [Guid] from person where [Id] = 230;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 231, NEWID(),'9035AZ', '88', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 231, NEWID(), 'Thea Stalenhoef', [Id], [Guid], '06-90996813', 'TheaStalenhoef@cuvox.de' from [Location] where [ZipCode] = '9035AZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 231, NEWID(), [Id], [Guid] from person where [Id] = 231;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 232, NEWID(),'7711KD', '6', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 232, NEWID(), 'Reece Vincken', [Id], [Guid], '06-39466857', 'ReeceVincken@teleworm.us' from [Location] where [ZipCode] = '7711KD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 232, NEWID(), [Id], [Guid] from person where [Id] = 232;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 233, NEWID(),'5807BZ', '47', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 233, NEWID(), 'Arsen van Uffelen', [Id], [Guid], '06-28876119', 'ArsenvanUffelen@fleckens.hu' from [Location] where [ZipCode] = '5807BZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 233, NEWID(), [Id], [Guid] from person where [Id] = 233;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 234, NEWID(),'2225XH', '28', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 234, NEWID(), 'Stoffel Groenenboom', [Id], [Guid], '06-18907197', 'StoffelGroenenboom@dayrep.com' from [Location] where [ZipCode] = '2225XH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 234, NEWID(), [Id], [Guid] from person where [Id] = 234;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 235, NEWID(),'3314CK', '132', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 235, NEWID(), 'Marie-José Matthijssen', [Id], [Guid], '06-65881915', 'Marie-JoseMatthijssen@armyspy.com' from [Location] where [ZipCode] = '3314CK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 235, NEWID(), [Id], [Guid] from person where [Id] = 235;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 236, NEWID(),'5663AH', '181', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 236, NEWID(), 'Nikolas van Tiggelen', [Id], [Guid], '06-87272913', 'NikolasvanTiggelen@armyspy.com' from [Location] where [ZipCode] = '5663AH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 236, NEWID(), [Id], [Guid] from person where [Id] = 236;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 237, NEWID(),'8081DP', '165', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 237, NEWID(), 'Savine Foolen', [Id], [Guid], '06-18966255', 'SavineFoolen@superrito.com' from [Location] where [ZipCode] = '8081DP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 237, NEWID(), [Id], [Guid] from person where [Id] = 237;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 238, NEWID(),'1943LA', '84', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 238, NEWID(), 'Annick Copier', [Id], [Guid], '06-40834249', 'AnnickCopier@fleckens.hu' from [Location] where [ZipCode] = '1943LA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 238, NEWID(), [Id], [Guid] from person where [Id] = 238;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 239, NEWID(),'1826GD', '73', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 239, NEWID(), 'Yasmien Bui', [Id], [Guid], '06-66671455', 'YasmienBui@cuvox.de' from [Location] where [ZipCode] = '1826GD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 239, NEWID(), [Id], [Guid] from person where [Id] = 239;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 240, NEWID(),'5245RG', '161', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 240, NEWID(), 'Xuan Verhaag', [Id], [Guid], '06-31688037', 'XuanVerhaag@teleworm.us' from [Location] where [ZipCode] = '5245RG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 240, NEWID(), [Id], [Guid] from person where [Id] = 240;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 241, NEWID(),'5366AR', '127', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 241, NEWID(), 'Matthew Westgeest', [Id], [Guid], '06-52761106', 'MatthewWestgeest@cuvox.de' from [Location] where [ZipCode] = '5366AR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 241, NEWID(), [Id], [Guid] from person where [Id] = 241;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 242, NEWID(),'5133AX', '166', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 242, NEWID(), 'Fauve Lahaye', [Id], [Guid], '06-58751298', 'FauveLahaye@gustr.com' from [Location] where [ZipCode] = '5133AX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 242, NEWID(), [Id], [Guid] from person where [Id] = 242;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 243, NEWID(),'9725EH', '43', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 243, NEWID(), 'Princess van der Starre', [Id], [Guid], '06-15025594', 'PrincessvanderStarre@rhyta.com' from [Location] where [ZipCode] = '9725EH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 243, NEWID(), [Id], [Guid] from person where [Id] = 243;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 244, NEWID(),'6942LA', '77', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 244, NEWID(), 'Kendrick Kloosterboer', [Id], [Guid], '06-73531690', 'KendrickKloosterboer@superrito.com' from [Location] where [ZipCode] = '6942LA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 244, NEWID(), [Id], [Guid] from person where [Id] = 244;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 245, NEWID(),'3514TL', '16', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 245, NEWID(), 'Quirina Notten', [Id], [Guid], '06-72266743', 'QuirinaNotten@gustr.com' from [Location] where [ZipCode] = '3514TL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 245, NEWID(), [Id], [Guid] from person where [Id] = 245;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 246, NEWID(),'5672HH', '120', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 246, NEWID(), 'Reijer Borgman', [Id], [Guid], '06-61463921', 'ReijerBorgman@fleckens.hu' from [Location] where [ZipCode] = '5672HH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 246, NEWID(), [Id], [Guid] from person where [Id] = 246;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 247, NEWID(),'1011EB', '14', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 247, NEWID(), 'Teun de Maat', [Id], [Guid], '06-25684144', 'TeundeMaat@dayrep.com' from [Location] where [ZipCode] = '1011EB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 247, NEWID(), [Id], [Guid] from person where [Id] = 247;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 248, NEWID(),'4811XM', '48', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 248, NEWID(), 'Esme Harskamp', [Id], [Guid], '06-43261862', 'EsmeHarskamp@armyspy.com' from [Location] where [ZipCode] = '4811XM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 248, NEWID(), [Id], [Guid] from person where [Id] = 248;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 249, NEWID(),'9403MK', '13', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 249, NEWID(), 'Angel Kennis', [Id], [Guid], '06-63036843', 'AngelKennis@armyspy.com' from [Location] where [ZipCode] = '9403MK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 249, NEWID(), [Id], [Guid] from person where [Id] = 249;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 250, NEWID(),'2524PN', '54', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 250, NEWID(), 'Djimmy der Kinderen', [Id], [Guid], '06-44592062', 'DjimmyderKinderen@dayrep.com' from [Location] where [ZipCode] = '2524PN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 250, NEWID(), [Id], [Guid] from person where [Id] = 250;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 251, NEWID(),'5045ZL', '104', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 251, NEWID(), 'Othman Tijs', [Id], [Guid], '06-24712658', 'OthmanTijs@jourrapide.com' from [Location] where [ZipCode] = '5045ZL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 251, NEWID(), [Id], [Guid] from person where [Id] = 251;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 252, NEWID(),'2923XP', '56', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 252, NEWID(), 'Milène Stolwijk', [Id], [Guid], '06-71396842', 'MileneStolwijk@armyspy.com' from [Location] where [ZipCode] = '2923XP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 252, NEWID(), [Id], [Guid] from person where [Id] = 252;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 253, NEWID(),'3981AA', '90', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 253, NEWID(), 'Bibi van Diessen', [Id], [Guid], '06-51305889', 'BibivanDiessen@jourrapide.com' from [Location] where [ZipCode] = '3981AA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 253, NEWID(), [Id], [Guid] from person where [Id] = 253;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 254, NEWID(),'1602KC', '31', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 254, NEWID(), 'Edine Fitters', [Id], [Guid], '06-70962019', 'EdineFitters@jourrapide.com' from [Location] where [ZipCode] = '1602KC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 254, NEWID(), [Id], [Guid] from person where [Id] = 254;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 255, NEWID(),'2625VP', '154', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 255, NEWID(), 'Karla van Sambeek', [Id], [Guid], '06-85789378', 'KarlavanSambeek@fleckens.hu' from [Location] where [ZipCode] = '2625VP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 255, NEWID(), [Id], [Guid] from person where [Id] = 255;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 256, NEWID(),'4225PN', '96', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 256, NEWID(), 'Nirvana Salomé', [Id], [Guid], '06-31325866', 'NirvanaSalome@superrito.com' from [Location] where [ZipCode] = '4225PN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 256, NEWID(), [Id], [Guid] from person where [Id] = 256;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 257, NEWID(),'8316BA', '151', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 257, NEWID(), 'Neo Menke', [Id], [Guid], '06-74253048', 'NeoMenke@cuvox.de' from [Location] where [ZipCode] = '8316BA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 257, NEWID(), [Id], [Guid] from person where [Id] = 257;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 258, NEWID(),'3831AK', '56', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 258, NEWID(), 'Luis ten Cate', [Id], [Guid], '06-63929293', 'LuistenCate@superrito.com' from [Location] where [ZipCode] = '3831AK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 258, NEWID(), [Id], [Guid] from person where [Id] = 258;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 259, NEWID(),'1322AX', '27', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 259, NEWID(), 'Aimy Adan', [Id], [Guid], '06-87721300', 'AimyAdan@gustr.com' from [Location] where [ZipCode] = '1322AX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 259, NEWID(), [Id], [Guid] from person where [Id] = 259;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 260, NEWID(),'6882NS', '82', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 260, NEWID(), 'Jeen de Veld', [Id], [Guid], '06-71812909', 'JeendeVeld@dayrep.com' from [Location] where [ZipCode] = '6882NS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 260, NEWID(), [Id], [Guid] from person where [Id] = 260;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 261, NEWID(),'2719RV', '9', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 261, NEWID(), 'Puk Pos', [Id], [Guid], '06-68678367', 'PukPos@jourrapide.com' from [Location] where [ZipCode] = '2719RV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 261, NEWID(), [Id], [Guid] from person where [Id] = 261;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 262, NEWID(),'9663RZ', '199', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 262, NEWID(), 'Deena van de Vliert', [Id], [Guid], '06-44897188', 'DeenavandeVliert@fleckens.hu' from [Location] where [ZipCode] = '9663RZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 262, NEWID(), [Id], [Guid] from person where [Id] = 262;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 263, NEWID(),'9722LK', '86', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 263, NEWID(), 'Sieger Cordes', [Id], [Guid], '06-35334354', 'SiegerCordes@cuvox.de' from [Location] where [ZipCode] = '9722LK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 263, NEWID(), [Id], [Guid] from person where [Id] = 263;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 264, NEWID(),'8521LT', '2', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 264, NEWID(), 'Delina Kuenen', [Id], [Guid], '06-12356747', 'DelinaKuenen@superrito.com' from [Location] where [ZipCode] = '8521LT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 264, NEWID(), [Id], [Guid] from person where [Id] = 264;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 265, NEWID(),'2201MV', '8', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 265, NEWID(), 'Kiet Hauwert', [Id], [Guid], '06-72109539', 'KietHauwert@dayrep.com' from [Location] where [ZipCode] = '2201MV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 265, NEWID(), [Id], [Guid] from person where [Id] = 265;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 266, NEWID(),'4383SN', '92', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 266, NEWID(), 'Rolf Wolters', [Id], [Guid], '06-12137222', 'RolfWolters@cuvox.de' from [Location] where [ZipCode] = '4383SN';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 266, NEWID(), [Id], [Guid] from person where [Id] = 266;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 267, NEWID(),'1058LZ', '145', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 267, NEWID(), 'Gerritdina Artz', [Id], [Guid], '06-51691078', 'GerritdinaArtz@jourrapide.com' from [Location] where [ZipCode] = '1058LZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 267, NEWID(), [Id], [Guid] from person where [Id] = 267;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 268, NEWID(),'4461NK', '20', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 268, NEWID(), 'Cédric Croonen', [Id], [Guid], '06-14965967', 'CedricCroonen@rhyta.com' from [Location] where [ZipCode] = '4461NK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 268, NEWID(), [Id], [Guid] from person where [Id] = 268;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 269, NEWID(),'1509XP', '183', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 269, NEWID(), 'Ché Wijnand', [Id], [Guid], '06-32607821', 'CheWijnand@superrito.com' from [Location] where [ZipCode] = '1509XP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 269, NEWID(), [Id], [Guid] from person where [Id] = 269;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 270, NEWID(),'6247EM', '162', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 270, NEWID(), 'Biko Stavenuiter', [Id], [Guid], '06-28763801', 'BikoStavenuiter@jourrapide.com' from [Location] where [ZipCode] = '6247EM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 270, NEWID(), [Id], [Guid] from person where [Id] = 270;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 271, NEWID(),'1216MD', '161', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 271, NEWID(), 'Margreet Verduin', [Id], [Guid], '06-79480060', 'MargreetVerduin@superrito.com' from [Location] where [ZipCode] = '1216MD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 271, NEWID(), [Id], [Guid] from person where [Id] = 271;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 272, NEWID(),'1781SG', '194', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 272, NEWID(), 'Nicoline van Milligen', [Id], [Guid], '06-16522308', 'NicolinevanMilligen@einrot.com' from [Location] where [ZipCode] = '1781SG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 272, NEWID(), [Id], [Guid] from person where [Id] = 272;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 273, NEWID(),'2215WD', '60', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 273, NEWID(), 'Panagiotis Stiekema', [Id], [Guid], '06-60023034', 'PanagiotisStiekema@einrot.com' from [Location] where [ZipCode] = '2215WD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 273, NEWID(), [Id], [Guid] from person where [Id] = 273;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 274, NEWID(),'5275JL', '173', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 274, NEWID(), 'Queeny van Glabbeek', [Id], [Guid], '06-14564295', 'QueenyvanGlabbeek@gustr.com' from [Location] where [ZipCode] = '5275JL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 274, NEWID(), [Id], [Guid] from person where [Id] = 274;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 275, NEWID(),'7542NP', '24', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 275, NEWID(), 'Tania Maassen', [Id], [Guid], '06-64504025', 'TaniaMaassen@teleworm.us' from [Location] where [ZipCode] = '7542NP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 275, NEWID(), [Id], [Guid] from person where [Id] = 275;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 276, NEWID(),'3063AL', '14', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 276, NEWID(), 'Anwar de Bok', [Id], [Guid], '06-89378056', 'AnwardeBok@armyspy.com' from [Location] where [ZipCode] = '3063AL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 276, NEWID(), [Id], [Guid] from person where [Id] = 276;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 277, NEWID(),'1782CJ', '93', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 277, NEWID(), 'Joram Ottenhoff', [Id], [Guid], '06-50280999', 'JoramOttenhoff@armyspy.com' from [Location] where [ZipCode] = '1782CJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 277, NEWID(), [Id], [Guid] from person where [Id] = 277;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 278, NEWID(),'3085GB', '23', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 278, NEWID(), 'Ihsane van den Brekel', [Id], [Guid], '06-59131471', 'IhsanevandenBrekel@rhyta.com' from [Location] where [ZipCode] = '3085GB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 278, NEWID(), [Id], [Guid] from person where [Id] = 278;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 279, NEWID(),'7475MS', '104', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 279, NEWID(), 'Erhan Wibier', [Id], [Guid], '06-51821136', 'ErhanWibier@fleckens.hu' from [Location] where [ZipCode] = '7475MS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 279, NEWID(), [Id], [Guid] from person where [Id] = 279;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 280, NEWID(),'8711EG', '69', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 280, NEWID(), 'Edwina Veneberg', [Id], [Guid], '06-96421728', 'EdwinaVeneberg@fleckens.hu' from [Location] where [ZipCode] = '8711EG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 280, NEWID(), [Id], [Guid] from person where [Id] = 280;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 281, NEWID(),'2625RD', '67', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 281, NEWID(), 'Sammy Geerlings', [Id], [Guid], '06-81049255', 'SammyGeerlings@einrot.com' from [Location] where [ZipCode] = '2625RD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 281, NEWID(), [Id], [Guid] from person where [Id] = 281;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 282, NEWID(),'3052CG', '92', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 282, NEWID(), 'Bastiaan Voorn', [Id], [Guid], '06-89699990', 'BastiaanVoorn@teleworm.us' from [Location] where [ZipCode] = '3052CG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 282, NEWID(), [Id], [Guid] from person where [Id] = 282;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 283, NEWID(),'1704SL', '62', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 283, NEWID(), 'Yan Feddema', [Id], [Guid], '06-67736211', 'YanFeddema@superrito.com' from [Location] where [ZipCode] = '1704SL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 283, NEWID(), [Id], [Guid] from person where [Id] = 283;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 284, NEWID(),'5363SW', '50', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 284, NEWID(), 'Figo Verbraeken', [Id], [Guid], '06-81147439', 'FigoVerbraeken@dayrep.com' from [Location] where [ZipCode] = '5363SW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 284, NEWID(), [Id], [Guid] from person where [Id] = 284;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 285, NEWID(),'6707DX', '133', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 285, NEWID(), 'Marlinda Molina', [Id], [Guid], '06-23969302', 'MarlindaMolina@cuvox.de' from [Location] where [ZipCode] = '6707DX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 285, NEWID(), [Id], [Guid] from person where [Id] = 285;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 286, NEWID(),'7902AP', '11', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 286, NEWID(), 'Shira Doelman', [Id], [Guid], '06-63983121', 'ShiraDoelman@rhyta.com' from [Location] where [ZipCode] = '7902AP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 286, NEWID(), [Id], [Guid] from person where [Id] = 286;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 287, NEWID(),'2522KX', '11', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 287, NEWID(), 'Celina van Gelderen', [Id], [Guid], '06-14107270', 'CelinavanGelderen@teleworm.us' from [Location] where [ZipCode] = '2522KX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 287, NEWID(), [Id], [Guid] from person where [Id] = 287;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 288, NEWID(),'2717EC', '49', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 288, NEWID(), 'Joao Geels', [Id], [Guid], '06-54570802', 'JoaoGeels@jourrapide.com' from [Location] where [ZipCode] = '2717EC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 288, NEWID(), [Id], [Guid] from person where [Id] = 288;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 289, NEWID(),'3117NT', '180', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 289, NEWID(), 'Mallory Jongkind', [Id], [Guid], '06-84506230', 'MalloryJongkind@einrot.com' from [Location] where [ZipCode] = '3117NT';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 289, NEWID(), [Id], [Guid] from person where [Id] = 289;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 290, NEWID(),'1132VZ', '.176', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 290, NEWID(), 'Bruno Vaassen', [Id], [Guid], '06-31264032', 'BrunoVaassen@rhyta.com' from [Location] where [ZipCode] = '1132VZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 290, NEWID(), [Id], [Guid] from person where [Id] = 290;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 291, NEWID(),'5684HR', '29', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 291, NEWID(), 'Wilhelmina Verburgt', [Id], [Guid], '06-11735700', 'WilhelminaVerburgt@teleworm.us' from [Location] where [ZipCode] = '5684HR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 291, NEWID(), [Id], [Guid] from person where [Id] = 291;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 292, NEWID(),'2394CP', '193', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 292, NEWID(), 'Diewertje Schuit', [Id], [Guid], '06-41765104', 'DiewertjeSchuit@teleworm.us' from [Location] where [ZipCode] = '2394CP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 292, NEWID(), [Id], [Guid] from person where [Id] = 292;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 293, NEWID(),'3281AX', '48', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 293, NEWID(), 'Hung Verharen', [Id], [Guid], '06-76638384', 'HungVerharen@einrot.com' from [Location] where [ZipCode] = '3281AX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 293, NEWID(), [Id], [Guid] from person where [Id] = 293;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 294, NEWID(),'3021BS', '157', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 294, NEWID(), 'Stijntje Bokhorst', [Id], [Guid], '06-51354841', 'StijntjeBokhorst@gustr.com' from [Location] where [ZipCode] = '3021BS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 294, NEWID(), [Id], [Guid] from person where [Id] = 294;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 295, NEWID(),'7339KB', '78', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 295, NEWID(), 'Isha Bastiaens', [Id], [Guid], '06-37432653', 'IshaBastiaens@armyspy.com' from [Location] where [ZipCode] = '7339KB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 295, NEWID(), [Id], [Guid] from person where [Id] = 295;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 296, NEWID(),'2517VC', '160', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 296, NEWID(), 'Hilbrand Groothedde', [Id], [Guid], '06-36305150', 'HilbrandGroothedde@einrot.com' from [Location] where [ZipCode] = '2517VC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 296, NEWID(), [Id], [Guid] from person where [Id] = 296;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 297, NEWID(),'4207RL', '163', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 297, NEWID(), 'Duane Balfoort', [Id], [Guid], '06-55698832', 'DuaneBalfoort@armyspy.com' from [Location] where [ZipCode] = '4207RL';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 297, NEWID(), [Id], [Guid] from person where [Id] = 297;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 298, NEWID(),'9724LA', '80', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 298, NEWID(), 'Seray Schouwenaar', [Id], [Guid], '06-92872525', 'SeraySchouwenaar@teleworm.us' from [Location] where [ZipCode] = '9724LA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 298, NEWID(), [Id], [Guid] from person where [Id] = 298;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 299, NEWID(),'5981HD', '30', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 299, NEWID(), 'Jerôme Leemans', [Id], [Guid], '06-10044544', 'JeromeLeemans@jourrapide.com' from [Location] where [ZipCode] = '5981HD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 299, NEWID(), [Id], [Guid] from person where [Id] = 299;
SET IDENTITY_INSERT [Customer] OFF
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 300, NEWID(),'2406BK', '182', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 300, NEWID(), 'Vinod Visker', [Id], [Guid], '06-41498967', 'VinodVisker@jourrapide.com' from [Location] where [ZipCode] = '2406BK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Customer] ON
insert into [Customer] ([Id], [Guid], [PersonId], [PersonGuid]) select 300, NEWID(), [Id], [Guid] from person where [Id] = 300;
SET IDENTITY_INSERT [Customer] OFF

end

begin /* Employees */
SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 301, NEWID(), '1181HW', '143', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 301, NEWID(), 'Zenzi Demirel', [Id], [Guid], '06-17211616', 'admin' from [Location] where [ZipCode] = '1181HW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid], [Password]) 
select 301, NEWID(), '1/4/2012', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid], 'password' from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 301;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 302, NEWID(), '1012PH', '156', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 302, NEWID(), 'Mari Corvers', [Id], [Guid], '06-35658251', 'henk' from [Location] where [ZipCode] = '1012PH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid], [Password]) 
select 302, NEWID(), '6/3/2016', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid], 'kees' from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 302;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 303, NEWID(), '6537LR', '66', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 303, NEWID(), 'Bobby Veen', [Id], [Guid], '06-69140818', 'BobbyVeen@gustr.com' from [Location] where [ZipCode] = '6537LR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 303, NEWID(), '12/21/1992', '2/28/1993', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 303;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 304, NEWID(), '1945ND', '162', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 304, NEWID(), 'Yildiz van Veenendaal', [Id], [Guid], '06-85445800', 'YildizvanVeenendaal@cuvox.de' from [Location] where [ZipCode] = '1945ND';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 304, NEWID(), '9/6/2005', '11/11/2009', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 304;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 305, NEWID(), '8265KC', '177', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 305, NEWID(), 'Kimberley Folkers', [Id], [Guid], '06-69253346', 'KimberleyFolkers@einrot.com' from [Location] where [ZipCode] = '8265KC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 305, NEWID(), '3/20/2008', '1/23/2013', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 305;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 306, NEWID(), '9713SZ', '166', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 306, NEWID(), 'Stijn Kabel', [Id], [Guid], '06-38722729', 'StijnKabel@gustr.com' from [Location] where [ZipCode] = '9713SZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 306, NEWID(), '6/18/2009', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 306;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 307, NEWID(), '3116AC', '77', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 307, NEWID(), 'Nash Christenhusz', [Id], [Guid], '06-94029623', 'NashChristenhusz@jourrapide.com' from [Location] where [ZipCode] = '3116AC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 307, NEWID(), '10/26/2000', '7/19/2004', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 307;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 308, NEWID(), '4337EE', '99', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 308, NEWID(), 'Euphemia Buil', [Id], [Guid], '06-22686973', 'EuphemiaBuil@einrot.com' from [Location] where [ZipCode] = '4337EE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 308, NEWID(), '10/24/2003', '12/2/2009', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 308;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 309, NEWID(), '2135TE', '63', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 309, NEWID(), 'Evelien van Schendel', [Id], [Guid], '06-51123374', 'EvelienvanSchendel@cuvox.de' from [Location] where [ZipCode] = '2135TE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 309, NEWID(), '8/20/2003', '12/2/2008', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 309;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 310, NEWID(), '3981LB', '100', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 310, NEWID(), 'Yamina Hogenes', [Id], [Guid], '06-76682594', 'YaminaHogenes@fleckens.hu' from [Location] where [ZipCode] = '3981LB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 310, NEWID(), '7/31/1996', '3/27/2002', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 310;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 311, NEWID(), '7701AJ', '180', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 311, NEWID(), 'Polly van Zantvoort', [Id], [Guid], '06-78418651', 'PollyvanZantvoort@gustr.com' from [Location] where [ZipCode] = '7701AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 311, NEWID(), '1/26/1995', '5/10/2001', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 311;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 312, NEWID(), '3755VG', '174', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 312, NEWID(), 'Abdulkerim Nooren', [Id], [Guid], '06-64842475', 'AbdulkerimNooren@armyspy.com' from [Location] where [ZipCode] = '3755VG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 312, NEWID(), '7/9/2010', '8/8/2012', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 312;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 313, NEWID(), '1068WP', '34', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 313, NEWID(), 'Stefano de Witt', [Id], [Guid], '06-70385146', 'StefanodeWitt@jourrapide.com' from [Location] where [ZipCode] = '1068WP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 313, NEWID(), '12/10/2001', '6/14/2008', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 313;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 314, NEWID(), '5611EZ', '122', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 314, NEWID(), 'Jacob van Asselt', [Id], [Guid], '06-36877791', 'JacobvanAsselt@gustr.com' from [Location] where [ZipCode] = '5611EZ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 314, NEWID(), '1/4/1991', '5/6/1993', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 314;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 315, NEWID(), '2202AJ', '175', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 315, NEWID(), 'Svea Plantinga', [Id], [Guid], '06-83580478', 'SveaPlantinga@fleckens.hu' from [Location] where [ZipCode] = '2202AJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 315, NEWID(), '12/23/2014', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 315;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 316, NEWID(), '8912AM', '88', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 316, NEWID(), 'Selman Idema', [Id], [Guid], '06-19218817', 'SelmanIdema@jourrapide.com' from [Location] where [ZipCode] = '8912AM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 316, NEWID(), '7/4/1990', '12/30/1995', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 316;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 317, NEWID(), '6127EK', '96', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 317, NEWID(), 'Petra Slootweg', [Id], [Guid], '06-97871824', 'PetraSlootweg@gustr.com' from [Location] where [ZipCode] = '6127EK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 317, NEWID(), '8/22/2003', '11/30/2004', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 317;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 318, NEWID(), '2671KB', '93', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 318, NEWID(), 'Rajesh van Lanen', [Id], [Guid], '06-47490400', 'RajeshvanLanen@einrot.com' from [Location] where [ZipCode] = '2671KB';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 318, NEWID(), '4/19/1993', '3/6/1996', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 318;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 319, NEWID(), '1261PD', '141', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 319, NEWID(), 'Menna van Holten', [Id], [Guid], '06-13681893', 'MennavanHolten@jourrapide.com' from [Location] where [ZipCode] = '1261PD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 319, NEWID(), '5/15/1992', '1/28/1999', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 319;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 320, NEWID(), '1521GD', '198', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 320, NEWID(), 'Luis Snijders', [Id], [Guid], '06-93114747', 'LuisSnijders@superrito.com' from [Location] where [ZipCode] = '1521GD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 320, NEWID(), '9/29/2014', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 320;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 321, NEWID(), '2811LW', '8', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 321, NEWID(), 'Sid Elgersma', [Id], [Guid], '06-99472784', 'SidElgersma@gustr.com' from [Location] where [ZipCode] = '2811LW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 321, NEWID(), '3/21/1995', '2/29/2000', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 321;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 322, NEWID(), '6471JX', '89', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 322, NEWID(), 'Harm Bonnema', [Id], [Guid], '06-13623593', 'HarmBonnema@dayrep.com' from [Location] where [ZipCode] = '6471JX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 322, NEWID(), '6/8/2010', '2/27/2011', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 322;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 323, NEWID(), '9402RX', '86', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 323, NEWID(), 'Ching Barendregt', [Id], [Guid], '06-49421879', 'ChingBarendregt@gustr.com' from [Location] where [ZipCode] = '9402RX';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 323, NEWID(), '8/31/2001', '1/1/2002', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 323;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 324, NEWID(), '1769HA', '6', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 324, NEWID(), 'Marcellino Ottenhoff', [Id], [Guid], '06-84774140', 'MarcellinoOttenhoff@teleworm.us' from [Location] where [ZipCode] = '1769HA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 324, NEWID(), '10/7/2003', '6/4/2009', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 324;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 325, NEWID(), '3721CK', '16', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 325, NEWID(), 'Tammy Zwiggelaar', [Id], [Guid], '06-88547938', 'TammyZwiggelaar@dayrep.com' from [Location] where [ZipCode] = '3721CK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 325, NEWID(), '2/4/2004', '4/13/2006', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 325;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 326, NEWID(), '2211AA', '80', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 326, NEWID(), 'Helen Perdok', [Id], [Guid], '06-45834129', 'HelenPerdok@gustr.com' from [Location] where [ZipCode] = '2211AA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 326, NEWID(), '5/29/1991', '5/27/1994', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 326;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 327, NEWID(), '3741BP', '1', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 327, NEWID(), 'Obed Alles', [Id], [Guid], '06-28012635', 'ObedAlles@fleckens.hu' from [Location] where [ZipCode] = '3741BP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 327, NEWID(), '12/7/2012', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 327;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 328, NEWID(), '6741EK', '134', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 328, NEWID(), 'Rene van Westen', [Id], [Guid], '06-46910546', 'RenevanWesten@gustr.com' from [Location] where [ZipCode] = '6741EK';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 328, NEWID(), '8/13/1996', '7/25/2003', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 328;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 329, NEWID(), '9742XA', '178', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 329, NEWID(), 'Shreya de Munck', [Id], [Guid], '06-73645293', 'ShreyadeMunck@armyspy.com' from [Location] where [ZipCode] = '9742XA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 329, NEWID(), '6/9/1994', '9/4/1994', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 329;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 330, NEWID(), '2622EP', '92', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 330, NEWID(), 'Sahin Teerink', [Id], [Guid], '06-26435713', 'SahinTeerink@fleckens.hu' from [Location] where [ZipCode] = '2622EP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 330, NEWID(), '8/3/2015', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 330;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 331, NEWID(), '5045RM', '121', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 331, NEWID(), 'Hendricus van Dop', [Id], [Guid], '06-89113722', 'HendricusvanDop@cuvox.de' from [Location] where [ZipCode] = '5045RM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 331, NEWID(), '5/24/2012', '10/15/2014', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 331;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 332, NEWID(), '9728NJ', '62', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 332, NEWID(), 'Meriem van Berlo', [Id], [Guid], '06-83971296', 'MeriemvanBerlo@fleckens.hu' from [Location] where [ZipCode] = '9728NJ';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 332, NEWID(), '10/14/1993', '3/10/1995', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 332;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 333, NEWID(), '2411CR', '188', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 333, NEWID(), 'Jamey van Weert', [Id], [Guid], '06-60487513', 'JameyvanWeert@teleworm.us' from [Location] where [ZipCode] = '2411CR';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 333, NEWID(), '12/2/2010', '6/3/2013', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 333;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 334, NEWID(), '7591DE', '56', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 334, NEWID(), 'Nazife Lommen', [Id], [Guid], '06-27787663', 'NazifeLommen@gustr.com' from [Location] where [ZipCode] = '7591DE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 334, NEWID(), '8/10/2006', '3/8/2011', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 334;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 335, NEWID(), '4335JC', '155', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 335, NEWID(), 'Fenna Meier', [Id], [Guid], '06-58078695', 'FennaMeier@dayrep.com' from [Location] where [ZipCode] = '4335JC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 335, NEWID(), '7/14/2003', '10/1/2005', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 335;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 336, NEWID(), '6983HG', '189', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 336, NEWID(), 'Randi Kleppe', [Id], [Guid], '06-11360978', 'RandiKleppe@teleworm.us' from [Location] where [ZipCode] = '6983HG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 336, NEWID(), '10/8/2012', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 336;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 337, NEWID(), '5066CS', '71', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 337, NEWID(), 'Antony Vluggen', [Id], [Guid], '06-53634176', 'AntonyVluggen@jourrapide.com' from [Location] where [ZipCode] = '5066CS';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 337, NEWID(), '7/11/2000', '10/10/2005', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 337;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 338, NEWID(), '7462RC', '189', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 338, NEWID(), 'Cheraine van Houtum', [Id], [Guid], '06-37949723', 'CherainevanHoutum@cuvox.de' from [Location] where [ZipCode] = '7462RC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 338, NEWID(), '6/28/1994', '3/10/1997', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 338;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 339, NEWID(), '4388PG', '2', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 339, NEWID(), 'Jace Bhaggoe', [Id], [Guid], '06-24819207', 'JaceBhaggoe@fleckens.hu' from [Location] where [ZipCode] = '4388PG';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 339, NEWID(), '2/12/2016', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 339;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 340, NEWID(), '1333DA', '129', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 340, NEWID(), 'Louka Wiegmans', [Id], [Guid], '06-60348627', 'LoukaWiegmans@rhyta.com' from [Location] where [ZipCode] = '1333DA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 340, NEWID(), '4/12/2016', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 340;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 341, NEWID(), '5932VH', '46', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 341, NEWID(), 'Zeynep Tamboer', [Id], [Guid], '06-19138748', 'ZeynepTamboer@teleworm.us' from [Location] where [ZipCode] = '5932VH';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 341, NEWID(), '6/17/1994', '6/22/1997', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 341;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 342, NEWID(), '4824CA', '149', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 342, NEWID(), 'Dorian van Oostrom', [Id], [Guid], '06-15320499', 'DorianvanOostrom@fleckens.hu' from [Location] where [ZipCode] = '4824CA';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 342, NEWID(), '7/12/2001', '1/26/2005', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 342;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 343, NEWID(), '6444BW', '58', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 343, NEWID(), 'Nona Spanjers', [Id], [Guid], '06-26274825', 'NonaSpanjers@jourrapide.com' from [Location] where [ZipCode] = '6444BW';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 343, NEWID(), '8/8/2006', '1/15/2011', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 343;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 344, NEWID(), '3361TC', '151', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 344, NEWID(), 'Danique Ekelschot', [Id], [Guid], '06-34260014', 'DaniqueEkelschot@fleckens.hu' from [Location] where [ZipCode] = '3361TC';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 344, NEWID(), '4/9/1996', '2/14/1999', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 344;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 345, NEWID(), '7461BM', '113', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 345, NEWID(), 'Chanella Verspeek', [Id], [Guid], '06-45017255', 'ChanellaVerspeek@dayrep.com' from [Location] where [ZipCode] = '7461BM';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 345, NEWID(), '9/24/2012', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 345;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 346, NEWID(), '5622AV', '170', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 346, NEWID(), 'Richano Duin', [Id], [Guid], '06-58189275', 'RichanoDuin@cuvox.de' from [Location] where [ZipCode] = '5622AV';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 346, NEWID(), '4/29/2005', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 346;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 347, NEWID(), '9718JP', '9', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 347, NEWID(), 'Andries Sperling', [Id], [Guid], '06-72503855', 'AndriesSperling@gustr.com' from [Location] where [ZipCode] = '9718JP';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 347, NEWID(), '3/21/2006', '1/1/2014', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 347;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 348, NEWID(), '6004RE', '13', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 348, NEWID(), 'Giovanna Wattel', [Id], [Guid], '06-59251694', 'GiovannaWattel@jourrapide.com' from [Location] where [ZipCode] = '6004RE';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 348, NEWID(), '12/16/2005', '8/7/2009', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 348;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 349, NEWID(), '1951BD', '85', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 349, NEWID(), 'Roosje Beld', [Id], [Guid], '06-90505871', 'RoosjeBeld@gustr.com' from [Location] where [ZipCode] = '1951BD';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 349, NEWID(), '6/12/2013', NULL, [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Inspecteur' where [p].[Id] = 349;
SET IDENTITY_INSERT [Employee] OFF


SET IDENTITY_INSERT [Location] ON
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select 350, NEWID(), '8913ED', '170', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [Person] ON
insert into [Person] ([Id], [Guid], [Name], [LocationId], [LocationGuid], [PhoneNumber], [Email]) select 350, NEWID(), 'Senne van Uden', [Id], [Guid], '06-13327154', 'SennevanUden@cuvox.de' from [Location] where [ZipCode] = '8913ED';
SET IDENTITY_INSERT [Person] OFF
SET IDENTITY_INSERT [Employee] ON
insert into [Employee] ([Id], [Guid], [DateHired], [DateFired], [PersonId], [PersonGuid], [FunctionId], [FunctionGuid]) 
select 350, NEWID(), '10/21/1999', '9/18/2004', [p].[Id], [p].[Guid], [f].[Id], [f].[Guid] from [Person] [p] join [Function] [f] on [f].[Name] = 'Manager' where [p].[Id] = 350;
SET IDENTITY_INSERT [Employee] OFF
end

begin /* Questions */

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 1, NEWID(), [Id], [Guid], 1, 'hoe veel autos stan er geparkeerd?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 2, NEWID(), [Id], [Guid], 1, 'Hoe veel autos staan er dubbl geparkeerd?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 3, NEWID(), [Id], [Guid], 1, 'Zijn er gekkigheden aan de parkeerplaats?', 1 from [QuestionType] [q] where [q].Name = 'Open';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 4, NEWID(), [Id], [Guid], 1, 'Hoveel autos staan er elke dag?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 5, NEWID(), [Id], [Guid], 1, 'Hoeveel autos staan er elke week?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 6, NEWID(), [Id], [Guid], 1, 'Hoeveel autos staan er elke maand?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 7, NEWID(), [Id], [Guid], 1, 'Hoeveel vrachtwagens staan er geparkeerd?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 8, NEWID(), [Id], [Guid], 1, 'Is er een ongeval op de parkeerplaats?', 1 from [QuestionType] [q] where [q].Name = 'Boolean';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 9, NEWID(), [Id], [Guid], 1, 'Is er vandalisme op de parkeerplaats?', 1 from [QuestionType] [q] where [q].Name = 'Boolean';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 10, NEWID(), [Id], [Guid], 1, 'Hoeveel autos staan er geparkeerd zonder nummerplaat?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 11, NEWID(), [Id], [Guid], 1, 'Hoeveel autos staan geparkeerd zonder ticket?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 12, NEWID(), [Id], [Guid], 1, 'Ligt er afval op de parkeerplaats?', 1 from [QuestionType] [q] where [q].Name = 'Boolean';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 1, NEWID(), [Id], [Guid], 2, 'Hoeveel autos staan er geparkeerd?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 3, NEWID(), [Id], [Guid], 2, 'Zijn er opmerkelijkheden aan de parkeerplaats?', 1 from [QuestionType] [q] where [q].Name = 'Open';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 2, NEWID(), [Id], [Guid], 2, 'Hoeveel autos staan er dubbel geparkeerd?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 4, NEWID(), [Id], [Guid], 2, 'Hoeveel autos staan er ele dag?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 10, NEWID(), [Id], [Guid], 2, 'Hoeveel autos staan er geparkeerd zonder kenteken?', 1 from [QuestionType] [q] where [q].Name = 'Count';

insert into [Question] ([Id], [Guid], [QuestionTypeId], [QuestionTypeGuid], [Version], [Description], [IsActive])
select 4, NEWID(), [Id], [Guid], 3, 'Hoeveel autos staan er elke dag?', 1 from [QuestionType] [q] where [q].Name = 'Count';

end

begin /* Commissions */

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (1+400), NEWID(),'2526MX', '129', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 1, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '8/23/2016', '8/26/2016', 'dagelijks tellen voor 3 dagen i.v.m festival'
from Customer c
join Employee e on e.Id = 315
join Location l on l.ZipCode = '2526MX'
where c.Id = '3';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (2+400), NEWID(),'7223DK', '89', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 2, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '1/9/2016', '4/9/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '7223DK'
where c.Id = '4';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (3+400), NEWID(),'6921BA', '173', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 3, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '5/9/2016', '8/9/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '6921BA'
where c.Id = '5';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (4+400), NEWID(),'3781AE', '148', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 4, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '6/9/2016', '9/9/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '3781AE'
where c.Id = '10';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (5+400), NEWID(),'6222SK', '111', [Id], [Guid] from [Region] where [RegionName] = 'Limburg';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 5, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '9/9/2016', '12/9/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 346
join Location l on l.ZipCode = '6222SK'
where c.Id = '26';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (6+400), NEWID(),'4331RS', '133', [Id], [Guid] from [Region] where [RegionName] = 'Zeeland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 6, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '9/19/2016', '9/22/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 339
join Location l on l.ZipCode = '4331RS'
where c.Id = '76';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (7+400), NEWID(),'8381DS', '194', [Id], [Guid] from [Region] where [RegionName] = 'Drenthe';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 7, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '6/10/2016', '9/10/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 346
join Location l on l.ZipCode = '8381DS'
where c.Id = '46';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (8+400), NEWID(),'3774JT', '39', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 8, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '10/17/2016', '10/20/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '3774JT'
where c.Id = '62';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (9+400), NEWID(),'5126CK', '185', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 9, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '10/25/2016', '10/28/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 346
join Location l on l.ZipCode = '5126CK'
where c.Id = '14';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (10+400), NEWID(),'3572VG', '195', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 10, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '10/26/2016', '10/29/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 327
join Location l on l.ZipCode = '3572VG'
where c.Id = '15';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (11+400), NEWID(),'8225NG', '135', [Id], [Guid] from [Region] where [RegionName] = 'Flevoland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 11, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '1/11/2016', '4/11/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 340
join Location l on l.ZipCode = '8225NG'
where c.Id = '91';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (12+400), NEWID(),'9713RB', '121', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 12, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '3/11/2016', '6/11/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 306
join Location l on l.ZipCode = '9713RB'
where c.Id = '203';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (13+400), NEWID(),'7312RL', '107', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 13, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '4/11/2016', '7/11/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '7312RL'
where c.Id = '201';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (14+400), NEWID(),'4811WH', '52', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 14, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '10/11/2016', '11/13/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 346
join Location l on l.ZipCode = '4811WH'
where c.Id = '196';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (15+400), NEWID(),'5623LT', '68', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 15, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '11/14/2016', '11/17/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 346
join Location l on l.ZipCode = '5623LT'
where c.Id = '148';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (16+400), NEWID(),'1441XG', '7', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Brabant';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 16, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '11/16/2016', '11/19/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 349
join Location l on l.ZipCode = '1441XG'
where c.Id = '164';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (17+400), NEWID(),'7664XG', '114', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 17, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '11/29/2016', '2/12/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 345
join Location l on l.ZipCode = '7664XG'
where c.Id = '92';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (18+400), NEWID(),'6661GJ', '66', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 18, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '1/12/2016', '4/12/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '6661GJ'
where c.Id = '78';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (19+400), NEWID(),'3437RC', '145', [Id], [Guid] from [Region] where [RegionName] = 'Utrecht';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 19, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '6/12/2016', '9/12/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 327
join Location l on l.ZipCode = '3437RC'
where c.Id = '85';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (20+400), NEWID(),'1935CB', '31', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 20, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '9/12/2016', '12/12/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 349
join Location l on l.ZipCode = '1935CB'
where c.Id = '82';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (21+400), NEWID(),'9743NB', '56', [Id], [Guid] from [Region] where [RegionName] = 'Groningen';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 21, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '12/15/2016', '12/18/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 306
join Location l on l.ZipCode = '9743NB'
where c.Id = '158';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (22+400), NEWID(),'3232TP', '81', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 22, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '12/26/2016', '12/29/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 330
join Location l on l.ZipCode = '3232TP'
where c.Id = '152';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (23+400), NEWID(),'7491AZ', '121', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 23, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '3/1/2017', '6/1/2017', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 345
join Location l on l.ZipCode = '7491AZ'
where c.Id = '178';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (24+400), NEWID(),'2531TM', '200', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 24, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '10/1/2017', '1/13/2017', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 330
join Location l on l.ZipCode = '2531TM'
where c.Id = '174';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (25+400), NEWID(),'1121JS', '116', [Id], [Guid] from [Region] where [RegionName] = 'Noord-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 25, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '11/1/2017', '1/14/2017', 'Ticket controle'
from Customer c
join Employee e on e.Id = 320
join Location l on l.ZipCode = '1121JS'
where c.Id = '164';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (26+400), NEWID(),'7207JL', '163', [Id], [Guid] from [Region] where [RegionName] = 'Gelderland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 26, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '5/9/2016', '8/9/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 336
join Location l on l.ZipCode = '7207JL'
where c.Id = '173';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (27+400), NEWID(),'8713LM', '138', [Id], [Guid] from [Region] where [RegionName] = 'Friesland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 27, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '6/9/2016', '9/9/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 346
join Location l on l.ZipCode = '8713LM'
where c.Id = '223';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (28+400), NEWID(),'2492ZB', '162', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 28, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '9/9/2016', '12/9/2016', 'Ticket controle'
from Customer c
join Employee e on e.Id = 315
join Location l on l.ZipCode = '2492ZB'
where c.Id = '213';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (29+400), NEWID(),'2181BW', '117', [Id], [Guid] from [Region] where [RegionName] = 'Zuid-Holland';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 29, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '9/19/2016', '9/22/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 315
join Location l on l.ZipCode = '2181BW'
where c.Id = '213';
SET IDENTITY_INSERT [Commission] OFF;

SET IDENTITY_INSERT [Location] ON;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid]) select (30+400), NEWID(),'7421LL', '43', [Id], [Guid] from [Region] where [RegionName] = 'Overijssel';
SET IDENTITY_INSERT [Location] OFF;
SET IDENTITY_INSERT [Commission] ON;
insert into [Commission] ([Id], [Guid], [EmployeeId], [EmployeeGuid], [CustomerId], [CustomerGuid], [LocationId], [LocationGuid], [DateCreated], [DateCompleted], [Description])
select 30, NEWID(), [e].[Id], [e].[Guid], [c].[Id], [c].[Guid], [l].[Id], [l].[Guid], '6/10/2016', '9/10/2016', 'Reguliere Controle'
from Customer c
join Employee e on e.Id = 345
join Location l on l.ZipCode = '7421LL'
where c.Id = '232';
SET IDENTITY_INSERT [Commission] OFF;

end

begin /* Inspection */

SET IDENTITY_INSERT [Inspection] ON;


insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 1, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 1;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 2, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 2;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 3, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 3;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 4, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 4;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 5, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 5;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 6, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 6;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 7, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 7;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 8, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 8;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 9, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 9;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 10, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 10;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 11, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 11;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 12, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 12;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 13, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 13;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 14, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 14;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 15, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 15;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 16, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 16;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 17, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 17;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 18, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 18;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 19, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 19;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 20, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 20;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 21, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 21;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 22, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 22;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 23, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 23;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 24, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 24;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 25, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 25;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 26, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 26;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 27, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 27;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 28, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 28;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 29, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 29;

insert into [Inspection] ([Id], [Guid], [CommissionId], [CommissionGuid], [DateTimeStart], [DateTimeEnd])
select 30, NEWID(), [Id], [Guid], CONVERT(DATETIME,[DateCreated]), DATEADD(hour, 2, CONVERT(DATETIME,[DateCreated]))
from Commission c where c.Id = 30;


SET IDENTITY_INSERT [Inspection] OFF;
end

begin /* QuestionLists */
SET IDENTITY_INSERT [QuestionList] ON;
insert into [QuestionList] ([Id], [Guid], [Description], [InspectionId], [InspectionGuid])
 values (1, NEWID(), 'reguliere controle', NULL, NULL);
insert into [QuestionList] ([Id], [Guid], [Description], [InspectionId], [InspectionGuid])
 values (2, NEWID(), 'ticket controle', NULL, NULL);
insert into [QuestionList] ([Id], [Guid], [Description], [InspectionId], [InspectionGuid]) 
 select 3, NEWID(), 'ticket controle', [Id], [Guid] from [Inspection] where [Id] = 1;
SET IDENTITY_INSERT [QuestionList] OFF;
end

begin
SET IDENTITY_INSERT Answer ON;

insert into [Answer](Id,Guid,Value) values (1,NEWID(),'Ja');
insert into [QuestionItem](AnswerId,QuestionId,QuestionListId,QuestionVersion,Guid) values (1,9,3,1,NEWID());

SET IDENTITY_INSERT Answer OFF;
end
ALTER DATABASE ParkInspect SET ALLOW_SNAPSHOT_ISOLATION ON