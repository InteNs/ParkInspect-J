/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

delete from [Customer];
delete from [Person];
delete from [Location];
delete from [Region];


SET IDENTITY_INSERT [Region] ON

insert into [Region] ([Id], [Guid], [RegionName]) values (1, NEWID(), 'Brabant')
insert into [Region] ([Id], [Guid], [RegionName]) values (2, NEWID(), 'Limburg')
insert into [Region] ([Id], [Guid], [RegionName]) values (3, NEWID(), 'Utrecht')
insert into [Region] ([Id], [Guid], [RegionName]) values (4, NEWID(), 'Flevoland')
insert into [Region] ([Id], [Guid], [RegionName]) values (5, NEWID(), 'Noord-Holland')
insert into [Region] ([Id], [Guid], [RegionName]) values (6, NEWID(), 'Zuid-Holland')
insert into [Region] ([Id], [Guid], [RegionName]) values (7, NEWID(), 'Zeeland')
insert into [Region] ([Id], [Guid], [RegionName]) values (8, NEWID(), 'Gelderland')
insert into [Region] ([Id], [Guid], [RegionName]) values (9, NEWID(), 'Overijssel')
insert into [Region] ([Id], [Guid], [RegionName]) values (10, NEWID(), 'Drenthe')
insert into [Region] ([Id], [Guid], [RegionName]) values (11, NEWID(), 'Friesland')
insert into [Region] ([Id], [Guid], [RegionName]) values (12, NEWID(), 'Groningen')

SET IDENTITY_INSERT [Region] OFF
SET IDENTITY_INSERT [Location] ON

insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 1,  NEWID(), '5835NF', 1, [Id], [Guid] from [Region] where [Id] = 1;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 2,  NEWID(), '6649YG', 2, [Id], [Guid] from [Region] where [Id] = 2;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 3,  NEWID(), '4920RY', 3, [Id], [Guid] from [Region] where [Id] = 3;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 4,  NEWID(), '0157JK', 4, [Id], [Guid] from [Region] where [Id] = 4;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 5,  NEWID(), '6583JH', 5, [Id], [Guid] from [Region] where [Id] = 5;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 6,  NEWID(), '4850YY', 6, [Id], [Guid] from [Region] where [Id] = 6;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 7,  NEWID(), '4850BB', 6, [Id], [Guid] from [Region] where [Id] = 7;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 8,  NEWID(), '4472LS', 7, [Id], [Guid] from [Region] where [Id] = 8;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 9,  NEWID(), '4936UH', 8, [Id], [Guid] from [Region] where [Id] = 9;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 10,  NEWID(), '2828UH', 9, [Id], [Guid] from [Region] where [Id] = 10;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 11,  NEWID(), '2828OP', 9, [Id], [Guid] from [Region] where [Id] = 11;
insert into [Location] ([Id], [Guid], [ZipCode], [StreetNumber], [RegionId], [RegionGuid])
	select 12,  NEWID(), '9205GT', 10, [Id], [Guid] from [Region] where [Id] = 12;



SET IDENTITY_INSERT [Location] OFF