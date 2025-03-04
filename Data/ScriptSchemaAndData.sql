-- Script Date: 4/03/2025 12:58 PM  - ErikEJ.SqlCeScripting version 3.5.2.95
-- Database information:
-- Database: E:\Managed-Files\Projects\Xtensible\DeployJricaStudio\JricaStudioWebApi\Data\JaysLashes.db
-- ServerVersion: 3.40.0
-- DatabaseSize: 216 KB
-- Created: 4/03/2025 9:24 AM

-- User Table information:
-- Number of tables: 16
-- __EFMigrationsHistory: -1 row(s)
-- Admins: -1 row(s)
-- AppointmentProducts: -1 row(s)
-- Appointments: -1 row(s)
-- AppointmentServices: -1 row(s)
-- BlockOutDates: -1 row(s)
-- BusinessHours: -1 row(s)
-- ImageUploads: -1 row(s)
-- Policies: -1 row(s)
-- ProductCategories: -1 row(s)
-- Products: -1 row(s)
-- ProductShowcases: -1 row(s)
-- ServiceCategories: -1 row(s)
-- Services: -1 row(s)
-- ServicesShowcases: -1 row(s)
-- Users: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Users] (
  [Id] text NOT NULL
, [FirstName] text NOT NULL
, [LastName] text NOT NULL
, [Email] text NULL
, [Phone] text NULL
, [DOB] text NOT NULL
, [WearsContanctLenses] bigint NOT NULL
, [HasHadEyeProblems4Weeks] bigint NOT NULL
, [HasAllergies] bigint NOT NULL
, [HasSensitiveSkin] bigint NOT NULL
, [IsWaiverAcknowledged] bigint NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_Users_1] PRIMARY KEY ([Id])
);
CREATE TABLE [ServiceCategories] (
  [Id] text NOT NULL
, [Name] text NOT NULL
, CONSTRAINT [sqlite_autoindex_ServiceCategories_1] PRIMARY KEY ([Id])
);
CREATE TABLE [ProductCategories] (
  [Id] text NOT NULL
, [Name] text NOT NULL
, CONSTRAINT [sqlite_autoindex_ProductCategories_1] PRIMARY KEY ([Id])
);
CREATE TABLE [Policies] (
  [Id] text NOT NULL
, [PolicyTitle] text NOT NULL
, [PolicyArticle] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_Policies_1] PRIMARY KEY ([Id])
);
CREATE TABLE [ImageUploads] (
  [Id] text NOT NULL
, [FileName] text NOT NULL
, [StoredFileName] text NOT NULL
, [ContentType] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_ImageUploads_1] PRIMARY KEY ([Id])
);
CREATE TABLE [Products] (
  [Id] text NOT NULL
, [Name] text NOT NULL
, [Description] text NOT NULL
, [Price] text NOT NULL
, [Quantity] bigint NOT NULL
, [ProductCategoryId] text NOT NULL
, [ImageUploadId] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_Products_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_Products_0_0] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategories] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_Products_1_0] FOREIGN KEY ([ImageUploadId]) REFERENCES [ImageUploads] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [ProductShowcases] (
  [Id] text NOT NULL
, [ProductId] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_ProductShowcases_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_ProductShowcases_0_0] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [Services] (
  [Id] text NOT NULL
, [Name] text NOT NULL
, [Description] text NOT NULL
, [Duration] text NOT NULL
, [Price] text NOT NULL
, [ServiceCategoryId] text NOT NULL
, [ImageUploadId] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_Services_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_Services_0_0] FOREIGN KEY ([ImageUploadId]) REFERENCES [ImageUploads] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [ServicesShowcases] (
  [Id] text NOT NULL
, [ServiceId] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_ServicesShowcases_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_ServicesShowcases_0_0] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [BusinessHours] (
  [Id] text NOT NULL
, [Day] bigint NOT NULL
, [OpenTime] text NULL
, [CloseTime] text NULL
, [LocalTimeOffset] text NOT NULL
, [IsDisabled] bigint NOT NULL
, [AfterHoursGraceRange] bigint NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_BusinessHours_1] PRIMARY KEY ([Id])
);
CREATE TABLE [BlockOutDates] (
  [Id] text NOT NULL
, [Date] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, [EndTime] text DEFAULT ('00:00:00') NOT NULL
, [StartTime] text DEFAULT ('00:00:00') NOT NULL
, CONSTRAINT [sqlite_autoindex_BlockOutDates_1] PRIMARY KEY ([Id])
);
CREATE TABLE [Appointments] (
  [Id] text NOT NULL
, [UserId] text NOT NULL
, [StartTime] text NULL
, [EndTime] text NULL
, [HasHadEyelashExtentions] bigint NOT NULL
, [IsSampleSetComplete] bigint NOT NULL
, [IsDepositPaid] bigint NOT NULL
, [SampleSetCompleted] text NULL
, [Status] bigint NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_Appointments_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_Appointments_0_0] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE SET NULL ON UPDATE NO ACTION
);
CREATE TABLE [AppointmentServices] (
  [Id] text NOT NULL
, [AppointmentId] text NOT NULL
, [ServiceId] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_AppointmentServices_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_AppointmentServices_0_0] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
, CONSTRAINT [FK_AppointmentServices_1_0] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [AppointmentProducts] (
  [Id] text NOT NULL
, [AppointmentId] text NOT NULL
, [ProductId] text NOT NULL
, [Quantity] bigint NOT NULL
, CONSTRAINT [sqlite_autoindex_AppointmentProducts_1] PRIMARY KEY ([Id])
, CONSTRAINT [FK_AppointmentProducts_0_0] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
, CONSTRAINT [FK_AppointmentProducts_1_0] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [Admins] (
  [Id] text NOT NULL
, [Username] text NOT NULL
, [Password] text NOT NULL
, [FirstName] text NOT NULL
, [LastName] text NOT NULL
, [Phone] text NOT NULL
, [AdminKey] text NOT NULL
, [ResetKey] text NOT NULL
, [ResetKeySent] text NOT NULL
, [Created] text NOT NULL
, [Updated] text NULL
, CONSTRAINT [sqlite_autoindex_Admins_1] PRIMARY KEY ([Id])
);
CREATE TABLE [__EFMigrationsHistory] (
  [MigrationId] text NOT NULL
, [ProductVersion] text NOT NULL
, CONSTRAINT [sqlite_autoindex___EFMigrationsHistory_1] PRIMARY KEY ([MigrationId])
);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'06D73F9C-A28A-4F6B-BEFE-81273ACDC495','sl6thhscQYDaOWqQy6r5DizdyzZZ4tri1ed0a5J58/A=','hM5YOwSg0WotcGTeOY96pEO1YXOhqxxv+qEwX9316ww=',NULL,NULL,'2025-03-03',0,0,0,0,0,'2025-03-03 02:02:54.3935572',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'0A9B1FD3-368F-45F5-A877-8E36CAB0B274','iSTuxWI2OeFmWHZKZYDJLkZctpXHpLgOetW3YCnlg1k=','eUMhb40+yqdK8kI884B/qgM1UDMpMcJR6rUj9D8AZ3Q=',NULL,NULL,'2025-02-08',0,0,0,0,0,'2025-02-08 01:31:32.8498381',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'0B8C5D2D-D1BD-4BC9-BF4D-96A503E6D2E9','UamjxtLjslh6d9np+hrqbzoGcEZvudhvZvHkQOviBN8=','GvWQlXHWjCbCXe+F3o87XFN+wK9UkbfWhYfY2R/fXB0=','MZTvpOwcQ6qgIFuU3XD3RyHZ+59DQ+JxvJDIMbKyCf3qe0QosPo1tdnLvfZ++glk','Z5P2S0QdRmNDdR2wTAFl79vtV1ein41tfjeIDwDJ3uI=','1970-01-25',1,0,0,0,1,'2025-01-25 00:49:01.2799503',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'124796BF-E8BD-4247-8AFD-EBBE2D3B473B','hltMBvks8RkkphvsOfS7zPLWMK6e4QZISVD42/vho8M=','7tAHmdDlwh1FYle7SkHzarLN5j86XombnbaBVYz+sZ4=',NULL,NULL,'2025-02-28',0,0,0,0,0,'2025-02-28 00:33:59.2792747',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'31AD3655-5F08-472E-BDB7-C67C8A48C842','+JC9Xs7aQ2BC6b1ot6alOpqXVkcT6B3fm/m2Cdlloo4=','YrvNMPaNSfjghEpH/svDwiJr7SgyheZQGoJT17lhffQ=',NULL,NULL,'2025-03-03',0,0,0,0,0,'2025-03-03 23:31:12.9392471',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'32A60FD5-6031-40E5-A3BC-0DD82CA16525','ugrhepKz69dq62jbLmUXKSXwlKOOhZ/4RcYZzM4JEg0=','Pdje0fmv3WV0v9j1aWJBDpVHMBKSr7v6Sk5DXBw5wvc=',NULL,NULL,'2025-03-01',0,0,0,0,0,'2025-03-01 11:34:43.9498445',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'32C86785-363D-4ADE-B78D-49F2333CC583','RI/nKSBPcLfdPUM5qSXfeaUESeUS/ePSCFpU+M0MY8Q=','4ijFDNHFKssgamY78oFFwpoZ60d/CrQ1CLKBw75CD1g=',NULL,NULL,'2025-02-01',0,0,0,0,0,'2025-02-01 02:43:00.3191534',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'388B7556-90BD-4B7B-849C-0609E676F9A3','sDs/rP66r31+OwTnM0+IHRIrb0J6X0Dq0Bdea7i+0Ls=','ikEh8yutdEqhGuyv02mGBrAof5Oe8seEEdE1GVsQmgQ=','KedJn8DwkEQnNbCb6sWuZbklU87IjajuyA/Xybeq50zSeTp/HeOpifwPGGEBEpPv','0WnvVNQtqpQ2vo3r9MZvCzKuOqRfUq1bGddIGkry1CE=','1994-04-05',0,0,0,0,1,'2025-02-05 02:44:42.2459582',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'47A71C8E-8D1D-43C7-A9B4-9A6F332DE245','eCoUc8eyiBVwljg1xI9EAssdAx0i2UvdOKU1JD4Dh+M=','1xUV6tu/fnYvmq3GHt386+6XiNGg75A2JfXCMmvqmq8=',NULL,NULL,'2025-01-27',0,0,0,0,0,'2025-01-27 10:12:37.3307737',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'5170E598-916D-4B46-A83A-A29323DC2F9F','KT15ZObXSAu7rFBMBJoVOckAjLCNBEtmgmJwtMRD/hA=','bHrofZglpswwC5J0RatmXZuCJLKrJYwm17SOQQJJUVo=',NULL,NULL,'2025-02-11',0,0,0,0,0,'2025-02-11 10:08:56.5493715',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'55F4CB44-B05A-4075-BBD1-C4B6BDC4AB37','0VTLbcjPUAvLfhsRrUef8cruVcIamq16KrcD2YUP0OU=','L3mDdoUnfCLRBgFnD5B1FTEkuDUlNl1Rem9KPqCANt8=',NULL,NULL,'2025-02-16',0,0,0,0,0,'2025-02-16 09:19:17.4039503',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'599BEC58-26E7-4A06-BE90-19205CA0BAE0','VLL4xDUalKssfZrlERexxMrvrdM8m3sndwl2M7mMKpE=','q+Cv1RzOSAWWEnAGPQzTHFfduywh5ZZESfiuKKG7pM4=',NULL,NULL,'2025-01-24',0,0,0,0,0,'2025-01-24 04:29:12.5263125',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'5AD645C7-7190-411D-8DBB-58E65DCCE966','h1xUSo5U8U1IADYiafINAuwI5V4SWqtt0HDvlPPdzSw=','MXyusiuKMmyxpcI2e4mHYMiJ9FRd+gg18GeabgFZBgA=',NULL,NULL,'2025-03-01',0,0,0,0,0,'2025-03-01 11:33:50.1885795',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'5FDAA259-D047-466F-A69F-5CD6BC47830E','cxmf+gJMfNv6o2MNhqDA6dMOxH8lOc/q/hr3lrqQAmM=','q7cCLjckYNqfdSSyBce9pIAYsnhlEhfhRNWxYET21vc=',NULL,NULL,'2025-01-20',0,0,0,0,0,'2025-01-20 09:40:22.8208202',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'6199C08B-AFA2-42EF-B6C6-266D569BB127','5Hf+Ts51/c8NdGuB3zX64oarZJs6kOhpjw7Ou99Ok2s=','zwVgraWSij5zYKp/T7HzwGmetAMmMZpyC4wFBis99Vc=',NULL,NULL,'2025-01-23',0,0,0,0,0,'2025-01-23 02:35:30.7518321',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'64145C63-D302-4395-A665-1D3B7621C5F6','MjTQWyGLcTKm0E0+mqqm20FQVItzZthV4KujHcw4A/M=','2WylqNNsc20+QjP55NxgRNLF/NTPsZm+LYPpPE3OVTQ=',NULL,NULL,'2025-02-15',0,0,0,0,0,'2025-02-15 04:15:06.4423979',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'64C04230-9110-4746-86E3-21857D23EC7B','36muveduEY5XIfNzcMeGpA8/ht3q6eoBwy9F8TqOapI=','tFKuLjlvqh6gmX0jPAzf1EiAxjt/8qys55X066Vl4Ks=',NULL,NULL,'2025-01-23',0,0,0,0,0,'2025-01-23 00:30:01.5417868',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'6579BE8A-5129-4162-A80B-25A2BA28BD03','boi7f6XesX8/ubqtY7oLqfs+H14lQ+ipURhiIA4yqNk=','t9YfyA9MklbavvCVCS1QtZk06i9NlNxajSJuVynT2CM=',NULL,NULL,'2025-02-12',0,0,0,0,0,'2025-02-12 18:58:42.3970746',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'6B0BAFFE-0327-4C37-A098-F98B43016D4B','ZvNI2VIVYnU0VBKKniTFK49Ke1J4wJRfFEzOTNDSFKk=','eCkZWmEB+NNs78wiM1hT2qcAXZylJAYeH18LTisImxs=',NULL,NULL,'2025-02-27',0,0,0,0,0,'2025-02-27 21:48:03.2231587',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'6B52517F-6D00-4929-883F-C139468055AD','ShGYP/YsqfZnWvUqH2iyLBnf/aTPKt5f3ge+aWWjvTU=','4rrgzORhFNBGPn3Vb7XYmKzmyssE345BjTIr0OA99Tg=','MRnTQsQZTcuK0vcT/4Pk8e+Qp0xCipgYEKUOTPnrGIw+GQis04M7Ct88aPuqMvgK','G0ie7Kfgx2kWDrMwKDt3KO+1ACRtjeXtH8VZpL/9pKM=','1989-07-09',0,0,0,0,1,'2025-02-05 02:49:57.0209605',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'737F2689-37E0-4935-8607-D2466345EC87','Lgk1ZaKgXztQsPQlbDZUzYOez9zeCnlLboRsxvhe4jU=','JhtM9fhzTg5BZ6M2+peycvdF7s8oOhp0mQFwV0byRsI=',NULL,NULL,'2025-01-29',0,0,0,0,0,'2025-01-29 06:44:28.4217157',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'74669E23-EEA2-43EA-95BB-82BEE2178ABC','LE5dPF92c98A+bYze7JDxA3xzn8YbDpt5Q/i1xEGdLM=','ch8eun8h4Q6PT+mkPq6z//OUgYTaxObqVK4dwG/hpdY=',NULL,NULL,'2025-02-21',0,0,0,0,0,'2025-02-21 01:48:13.4000517',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'77FCC84D-E269-4CB8-BB99-22567A66D5C2','0xsbCNZ4kNci6S1bhCFFrj9fidpDrp10FLgYwmoEYQs=','hRF3jRqSdk0mrb5A+jOeKPAnk1ipupzRT4e3+jPPuC0=',NULL,NULL,'2025-02-05',0,0,0,0,0,'2025-02-05 02:46:35.438527',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'8425448C-E447-4182-83D5-E2D065C18B65','OXpxU/UPB+ZOspoIRYpJdoI4tjOcZaM8Ou1splHjz+o=','uvWYoXFItEA9/X2t+aMP2FWToQ+7JuekPVMQSeAiGc4=','dcBh/zIU5jI/IvmmqiLzhrcjNdIyl1YGIdSKd5nqxYpwn35AW5B4Zf0RFd/S7pzM','cuA2F1q5xbHSkRvA3T7PzCT6mfXdm2muPMT5+yuduRw=','1994-03-22',0,0,0,0,1,'2025-03-02 00:47:21.1570795',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'8DAD0075-274D-4904-A55B-3A7277974984','1TgnRhKwFqIkeAndepO2oXqYnHuN4NKVVQpIMJBjkGg=','RKtddrUzgEmDOY3XTwkDYNyJ2P/o6yBRk774lARfMT8=','GinnUCWsyd7BURjP1XSxMh5IeVPIg2P2ImwPhEEF83es4mP3oNJrvGV3PHAlomTk','ZC0y8C/WdirPW24uaSv3ui3M+Y4A5DxbWSJ+7cRdfZM=','1995-06-05',0,0,0,1,1,'2025-02-10 07:53:28.8790179',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'96DA912B-41C3-4F79-9C09-A759485CAAE5','ViGFVWKD7jZytdluPnEC+q7x7NBuKit2omPIQFKSu+o=','IZwc5t5fREoIgp676RdVIYOIe0Wx96GAXBsp1tuTruQ=',NULL,NULL,'2025-03-03',0,0,0,0,0,'2025-03-03 00:46:28.1918873',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'9DA83043-B8A2-43D5-8087-C8A9FAAB1946','kefZDDf018U6xESshHLAgtje/+QNC9SUxUdK+1aSfQo=','Mbw/VGLlmWxmOiJuaEEEkyVnRrA8mkG/DJEV1SrF/B8=',NULL,NULL,'2025-02-11',0,0,0,0,0,'2025-02-11 10:06:07.2166962',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'A26D4BEC-7F4B-4613-B121-80408B653818','l3c+Dt0nlGdQeffbIDj3t0xoolskC+Q02KS/V+z9VqE=','Brr9alr7C0MeCBgZZDCZnZktyEjVoDMhr8kr1Y7UynI=',NULL,NULL,'2025-02-10',0,0,0,0,0,'2025-02-10 06:37:07.9237897',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'A37DD9CA-9624-4A51-BD13-D863445A9A03','7yUOB2G1LKgUJTKd1qWnMl9fqETwqLuHDdlGqtXYo3M=','laLQun7nG5JsoDJQ8erIFSbVOyUqsB6f26xa8F0Mz2A=',NULL,NULL,'2025-03-03',0,0,0,0,0,'2025-03-03 22:32:18.8945811',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'A6928D66-5055-4B2E-9299-8B09B026A8A0','cIou/45VZDVg54up8LT6tonkdZ6wXJbCaGpmLOrgEys=','WsmY6XaXpDaff6SanXIgy6rkN3PteED7fxZ8dn4XIBE=',NULL,NULL,'2025-01-31',0,0,0,0,0,'2025-01-31 04:04:49.1243469',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'A7596D6E-3563-4F69-98DE-42E64970CFFA','yMnorY7/FKvtiziWaBcaCuJ8WObzJYUlkck/6pRwWHs=','2WPjiW28j2bhWHQO3AxkTmiXyuNrlXeeQT4uwkG4QdI=','paGCv02qdTR4NIlTS2Wk+2dxLlbXyI6qSnY4yzYisqea2eVddSyLGBMOYd/W3LQ1','mKUbabAeTkkiE6iZ92sC0gz8RtlyUQsrX82X1wjE7Y4=','0001-01-01',0,0,0,0,1,'2025-03-01 11:54:46.0290144',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'AD139CF7-9DDD-412E-84AC-27CE9F33893A','GX4j6Jk0RTYNIUTXR0cfXsiRbqoVjkGl+4i0CYubh3M=','6xwAKANP0Nj8R/ZjiBpg9Q5PPCb7UUR0Sj7kzNS9DOQ=','2BZSfGqskLwkNn1Lvp2HS+UENXq3uee4gG5vP2Aj7Oi8SlDfI4lHxBEVq+HbnfMo','yC4wLXYYstb6VjKc1piLj3D54aSKaZk5xHg8NgtOk6U=','1993-02-14',1,0,0,0,1,'2025-01-20 09:18:32.2975563',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'AD28DA13-5F89-498F-A493-C38EAB979B88','UBtQP3Y6JwOcWNHdSudILOwlBaWQUxB1aneDgGaqvAY=','JrSwx+f5XZmjz/kSQ5Tdzj57estHtMPDo1SDtpwhilE=',NULL,NULL,'2025-02-14',0,0,0,0,0,'2025-02-14 01:43:49.1568936',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'AD29A5DA-ED07-4904-A60E-072D66EBD379','Uh3qsHAtCi/A30s3Nq3qSn+t8ueb6xYe4nutiq5ZhfQ=','lXoQ/SbZYXLOMn7G/GcwEVFszefeC2WA4B80dFVqDLw=',NULL,NULL,'2025-02-03',0,0,0,0,0,'2025-02-03 01:58:20.0735161',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'B3BA6619-DB61-4EA4-AEA2-A39A3C32127E','ZnWzk9NpBz/E6kqc/5OEXi8DZQfDtMrX+69PsX5gEfE=','OZbYUu3UHYIBTJ3Mu0VCEWkZUCQHvf88XD++m8I/RTw=',NULL,NULL,'2025-01-21',0,0,0,0,0,'2025-01-21 02:17:21.1611116',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'B7759E29-2C18-400B-9A17-72AD3FC0C870','b610kSSc6Jr0PHVtzDZPhi2UIDn2vVuFfsTaBoz2pcU=','eWDAk8AP4d+650PXlJmL7s8Rofxat8OzKVriuLdMQQ8=',NULL,NULL,'2025-02-09',0,0,0,0,0,'2025-02-09 09:47:11.5584206',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'B7A6580C-396A-4104-A204-9086929CBFD5','giiYVi57BLrDtsFNNTpGj5IjjuG0eRSN92qAWs+yv5o=','jnWtaScrcRQEN/V4u97vVk8njikhjgncv2QXBUUP3oI=',NULL,NULL,'2025-02-03',0,0,0,0,0,'2025-02-03 11:32:08.7178438',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'BADFF6F4-1BF7-4408-A0C5-EAD67F9A08B2','bZ0D7WxeE8+Ik9lGVLJccLqxYW+737yn5tcV9nhBsk8=','bkhQnIel0kZbiiEckG2qq5HdYDE7oQLoLaG2Ay9mqTk=',NULL,NULL,'2025-02-19',0,0,0,0,0,'2025-02-19 06:45:20.9126653',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'BB22F52E-B60C-48EF-A43F-49F2E006E722','3fPgxoSvvWpgvRfnepw28rzgOD2jRyya6htVnqXxh1w=','dosMQYIlVir9GnHn2uL0c+1JB20NaRDZDKgmTgM2TT4=',NULL,NULL,'2025-03-02',0,0,0,0,0,'2025-03-02 02:22:59.6498468',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'C2B5091F-56D6-4BE0-9AE2-8802C4AAD918','pDbxRo1v6CFL1IS9ZfBpuYWlb9UCIxFQO477wQ3d6YM=','1+l9ufhmIOyTETWiRP2KoTUEKnL0dLoJ+i/xesj0hZc=',NULL,NULL,'2025-01-22',0,0,0,0,0,'2025-01-22 12:29:49.1411237',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'CA54F6EF-5FC7-4877-8291-817FE4C6A7FD','DlzECIwwm+S08xfv4R5ObYqzHLXiKr1PGVE3FBCxEys=','pk4XMnXpEF8125jqcJJWiYi7hlzYgD2P2QinKQ4XbDM=',NULL,NULL,'2025-02-12',0,0,0,0,0,'2025-02-12 09:52:09.5823509',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'CB29F7A5-BB8F-437E-BF26-7FB738D0A480','VgkIV6hHj/bzkHf0kqtcm1dw+9XK5CS0x+q2Kfv0Yro=','+u9kTP8lR/BWCwq7+KLmbHL7rPJgD480WNhbVAdrYfc=',NULL,NULL,'2025-03-03',0,0,0,0,0,'2025-03-03 02:51:33.1167727',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'CD1CE45C-7AC0-42D6-9A1C-9EAC59D3B4FD','usMzsxq8831bA0QB68iHL9/NeZqxQlPF+4FzR52XwPk=','zIeeG1gT7sfom0xRXZ4iUt/u1WA45WV21x+H/QuLS+U=',NULL,NULL,'2025-01-24',0,0,0,0,0,'2025-01-24 04:45:26.9748763',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'D600DAA6-8310-4790-A601-D35C0F2A26FB','rAeHH/DcRoxn5prgqKxppOsUty/NviTHZi+lu4oauHY=','a1rguJJe6h2XGjkSYkeNnKNxMmM7oG8cxxQzH9EReF8=',NULL,NULL,'2025-02-18',0,0,0,0,0,'2025-02-18 05:11:06.2336124',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'E5E14A1B-D5D8-48BB-AAB6-A91CBE296A48','F5XI/e+VkAhvSmGe5ICLykVbaIZodoRSGndnqqzS73U=','u7TQirTj4h49DJ0mNF+Js1s0Ls7zF6j8hq4D7mJVKSc=',NULL,NULL,'2025-02-10',0,0,0,0,0,'2025-02-10 06:58:58.922254',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'E63734D4-A308-4785-ACEC-E477FA5CC1A4','t+ev8XsK1i6z/Y2ySW+LLM2c4cmcXX2b0C+LHpaOvx8=','FKIO4xSTsxZSsquK4jKLOLgtxEAqNdUPIK/aywUi92E=',NULL,NULL,'2025-03-02',0,0,0,0,0,'2025-03-02 01:58:10.9324297',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'E6DBC350-1B2F-4C2D-8089-726A21F9EF66','CszAKg63JrvgvEhTit/lPcns920lFZTwWt7vB/WwVI0=','c1GwH3jEtGL3VdOn5Fn5gQ+SQ75vhutQQ0QLr/mhUG0=',NULL,NULL,'2025-02-01',0,0,0,0,0,'2025-02-01 10:26:23.4275981',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'E8C264FD-57C2-4037-8556-3D66802EC20C','Puew78zkrBCQUpHibX4lRw3aK1zFhwXDf8upUv7+/Hk=','dpUdwYigfdD89tqPRT42J1C7HpF8FbN2I2ExdB8/93w=',NULL,NULL,'2025-02-05',0,0,0,0,0,'2025-02-05 02:24:31.1492378',NULL);
INSERT INTO [Users] ([Id],[FirstName],[LastName],[Email],[Phone],[DOB],[WearsContanctLenses],[HasHadEyeProblems4Weeks],[HasAllergies],[HasSensitiveSkin],[IsWaiverAcknowledged],[Created],[Updated]) VALUES (
'F879F157-2BDE-48EF-ABF5-07655CBC23E1','CKP6oiCbCOFM+wRSVKL8Ml8xhQ7ZVn/zf7izGHyh08s=','OIMmx16T5IMbqSqYoWCev0pKHNGrI6GUfO6zNQ4/3W0=',NULL,NULL,'2025-01-27',0,0,0,0,0,'2025-01-27 04:41:59.3733626',NULL);
INSERT INTO [ServiceCategories] ([Id],[Name]) VALUES (
'2FC5E7E5-8263-4D54-B531-BE29A990249B','Lash Full Set');
INSERT INTO [ServiceCategories] ([Id],[Name]) VALUES (
'4BDD5175-A59E-4CEF-89AB-8F84C9AB2A8B','Lash Infill');
INSERT INTO [ProductCategories] ([Id],[Name]) VALUES (
'2460334E-1EFF-4E07-88E3-840DB6A49F83','Bundle');
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'12083513-D677-4C80-B4E1-663A5EFE861D','TestImage2','bdoiftgs.rax','image','2025-03-03 23:47:54.4547828',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'179C7307-69FD-4FE1-AC15-B7DDDF5CA7C4','TestImage4','e1uaxcux.m1n','image','2025-03-03 23:47:54.4547881',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'1CAA5D93-2E9E-430A-8D49-B966274285D2','Eyelash kit.jpg','d4zk4zr5.1su','image/jpeg','2025-01-22 04:25:38.0874491',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'20C81532-37F9-4B58-B583-C3D1C50B8571','TestImage5','k3u5m2si.spe','image','2025-03-03 23:47:54.4547896',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'257F9C7C-5EF7-46D9-9476-8F310741B31A','3DFullSet.jpg','vorjsyxf.oaq','image/jpeg','2025-01-20 07:37:30.3838357',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'2757AAD8-CAFC-4D31-B3F5-F9D03B0D320F','TestImage3','bqkge5do.iss','image','2025-03-03 23:47:54.454784',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'33B27C60-53B5-45C1-A98D-66168BF89667','IMG_6087.jpeg','jjvhtggk.xyv','image/jpeg','2025-03-02 01:21:24.0181639',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'35B79C9F-25C7-4987-A74D-D6370E2F1B5F','TestImage2','oz1c3ma1.kd1','image','2025-03-03 23:47:54.4548408',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'3C9B8E19-B924-420F-9C6D-8C348B72EC56','TestImage0','jvkwqnf2.mre','image','2025-03-03 23:47:54.4548354',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'50CED4A5-AF31-489E-840B-E33AABCA814A','TestImage0','2njo3fl0.43m','image','2025-03-03 23:47:54.4547765',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'5474364A-A628-45AB-809E-2C70737A3986','TestImage6','tmbf3kzl.zwn','image','2025-03-03 23:47:54.4547911',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'6B8C4270-BC27-413E-83D7-8A68EB2869A5','temp_image_CD9CA048-A5C8-4D88-B232-860B9A655274.webp','lpzcrkl1.t3w','image/webp','2025-03-01 11:38:43.3601652',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'752D2923-AB54-42AB-944C-074D26740A63','TestImage1','ohtn2czj.s4o','image','2025-03-03 23:47:54.4548369',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'892CF801-8A68-4C81-8635-441DC81A0FF9','TestImage1','4fchlbk2.rya','image','2025-03-03 23:47:54.4547814',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'915295A6-E48F-431B-ACED-ADCBABCDC229','TestImage7','wcf3svy4.jnn','image','2025-03-03 23:47:54.4547922',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'9AA8AB3E-82B7-42A5-97BA-CF46540D548E','TestImage9','yuyzgysh.wjy','image','2025-03-03 23:47:54.4547945',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'BF7CBCD1-3A49-47A6-AA68-56100A5713FF','TestImage8','ynyhyfjf.yym','image','2025-03-03 23:47:54.4547934',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'D82B2772-EEF8-4137-9E07-53B3B65D63CB','TestImage3','ttt312ik.ffr','image','2025-03-03 23:47:54.4548418',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'EF9BF176-2A92-4712-BA84-89C54751BC30','9991bc7fb2e86f025c47b60fbff35dc5.jpg','sh0yiq2a.kxj','image/jpeg','2025-01-20 07:28:47.7489955',NULL);
INSERT INTO [ImageUploads] ([Id],[FileName],[StoredFileName],[ContentType],[Created],[Updated]) VALUES (
'FBC2A056-D154-4368-A7E9-AF6A562BD772','wispy volume.jpg','xnuchhpj.ycp','image/jpeg','2025-01-20 08:13:55.9598328',NULL);
INSERT INTO [Products] ([Id],[Name],[Description],[Price],[Quantity],[ProductCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'7F0F84F7-9B8A-4B6F-A8AE-4724F2CA82AA','After care Bundle','Our special After Car Kit Bundle Includes Cleanser, Eyelash Brush, Mascara Wand, Scrunchie and Loyalty Cards with exclusive discounts. ','25.0',6,'2460334E-1EFF-4E07-88E3-840DB6A49F83','1CAA5D93-2E9E-430A-8D49-B966274285D2','2025-01-22 04:25:39.012803',NULL);
INSERT INTO [ProductShowcases] ([Id],[ProductId],[Created],[Updated]) VALUES (
'342BC519-1B35-4398-8419-F53311A6166C','7F0F84F7-9B8A-4B6F-A8AE-4724F2CA82AA','2025-01-22 04:25:47.9152229',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'19A32315-D1AE-467A-948B-FAC57CC829BD','Wispy Volume Full Set','Wispy Volume Set is a liberating fusion of spike lashes and volume lashes, giving you a remarkably light and naturally voluminous look that empowers your beauty.','02:00:00','110.0','2FC5E7E5-8263-4D54-B531-BE29A990249B','FBC2A056-D154-4368-A7E9-AF6A562BD772','2025-01-20 08:13:58.3657114',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'5BF0F270-5549-45B2-AB3C-16910BCE0655','Express Fill','This service is available to existing clients seeking a refresh within 5-9 days of their previous appointment. It is not available to new clients.','01:00:00','50.0','4BDD5175-A59E-4CEF-89AB-8F84C9AB2A8B','33B27C60-53B5-45C1-A98D-66168BF89667','2025-03-02 01:21:24.1090914',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','Wet and Wispy Full Set','An elevated mascara look, this set empowers you with a 1:1 ratio of all spike extensions to natural lash. Choose this set if you''re looking for a perfect everyday look that isn''t too heavy or bold.','02:00:00','115.0','2FC5E7E5-8263-4D54-B531-BE29A990249B','6B8C4270-BC27-413E-83D7-8A68EB2869A5','2025-01-20 08:25:42.487518',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'ED6344D6-5AF9-4934-B9D0-28293915D13A','3D Full Set','3D refers to a 3:1 ratio of Volume Lashes to Natural lashes, resulting in a medium to thick volume appearance, contingent upon the quantity of natural lashes present.','02:00:00','100.0','2FC5E7E5-8263-4D54-B531-BE29A990249B','257F9C7C-5EF7-46D9-9476-8F310741B31A','2025-01-20 07:37:30.571119',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'F9CCE807-9FA4-4635-9C2B-304B73FE5DF9','Regular Fill','This fill service is exclusively available to existing clients who have reached the 2-3 week mark. Outgrown lashes are removed and replaced to refill and rebalance your lash set. Lashes must be 40% full after removing outgrowns to be considered a fill.','02:00:00','70.0','4BDD5175-A59E-4CEF-89AB-8F84C9AB2A8B','33B27C60-53B5-45C1-A98D-66168BF89667','2025-03-02 01:29:41.9057435',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'FC443B00-074F-4585-AA87-4ABBB32E9159','Extended Fill','This fill is only offered to current clients who are at their 3-4 week mark. Lashes must be 30% full after removing outgrowns to be considered a fill.','02:00:00','85.0','4BDD5175-A59E-4CEF-89AB-8F84C9AB2A8B','33B27C60-53B5-45C1-A98D-66168BF89667','2025-03-02 01:46:22.9307815',NULL);
INSERT INTO [Services] ([Id],[Name],[Description],[Duration],[Price],[ServiceCategoryId],[ImageUploadId],[Created],[Updated]) VALUES (
'FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','5D Full Set','5D is defined as a 5:1 ratio of Volume lashes to Natural lashes. 5D will empower you to unlock a voluminous and luscious look. If you aspire to full and thick Volume, this is the set that will elevate you.','02:00:00','100.0','2FC5E7E5-8263-4D54-B531-BE29A990249B','EF9BF176-2A92-4712-BA84-89C54751BC30','2025-01-20 07:28:47.8168067',NULL);
INSERT INTO [ServicesShowcases] ([Id],[ServiceId],[Created],[Updated]) VALUES (
'446242CF-08A5-40E6-B721-46A41C9D937E','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-01-20 07:38:18.2140721',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'073CADAA-7B29-4B2E-B7E6-EC871C361ECB',4,'23:00:00','02:00:00','10:00:00',0,0,'2025-01-20 09:30:40.849923',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'0A260822-8383-4DA8-8B43-965D09710CE2',3,'23:00:00','07:00:00','10:00:00',0,0,'2025-01-20 09:30:40.8294754',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'132C6FD7-A897-460B-B702-19B2B207E018',5,'23:00:00','07:00:00','10:00:00',0,0,'2025-01-20 09:30:40.8683327',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'33AE186C-24B2-4F0B-BA7E-67FE35FABCC2',6,'00:00:00','05:00:00','10:00:00',0,0,'2025-01-20 09:30:40.8853875',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'5FEF7A10-35D0-4FE5-85E3-B24EAE432ED1',1,'23:00:00','07:00:00','10:00:00',0,0,'2025-01-20 09:30:40.3918668',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'DBA714F2-9378-4A85-BA59-D6E3C2463E59',2,'23:00:00','07:00:00','10:00:00',0,0,'2025-01-20 09:30:40.8114906',NULL);
INSERT INTO [BusinessHours] ([Id],[Day],[OpenTime],[CloseTime],[LocalTimeOffset],[IsDisabled],[AfterHoursGraceRange],[Created],[Updated]) VALUES (
'ED5CAEBA-2D87-464A-8289-2C77E9C7C6D4',0,'01:00:00','04:00:00','10:00:00',1,0,'2025-01-20 09:30:39.989913',NULL);
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'05998F2D-C26F-4DF6-9B19-8F648558D431','2025-03-04','2025-03-02 02:16:31.7167145',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'0EBB75F0-B86A-4CBE-9F58-77084DD5339B','2025-01-27','2025-01-21 02:14:03.7078157',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'1B50C5DE-C71E-4CF7-9159-1D8B1DD0E867','2025-03-24','2025-03-03 22:41:21.6122956',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'1DB04670-7CB7-4F73-AEC4-DEC279C52D97','2025-03-03','2025-03-02 02:16:22.0433889',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'26A9BD0F-F587-4BF8-AC29-78F368312721','2025-03-07','2025-03-03 23:47:54.4549287',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'2E6F82E1-1042-447F-B510-BB62C5F294EF','2025-03-09','2025-03-03 23:47:54.4549298',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'3BB25A4E-C0B1-4FE5-A5BE-DDD434466C6D','2025-01-29','2025-01-20 09:31:11.5999432',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'4553CC8B-1463-4FCB-BBE9-A1937E847EB9','2025-03-27','2025-03-03 22:42:01.2851998',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'4880411C-65AF-4A21-A21A-6D5E40ACB6DB','2025-03-21','2025-03-03 22:56:47.4019185',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'5407EF4C-307C-47E7-B4C7-7BE377876082','2025-03-25','2025-03-03 22:41:36.0066563',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'5CC8D2B6-6510-4B95-8349-8595C784A651','2025-03-02','2025-03-01 12:00:23.1869384',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'6505A745-6247-4D37-AF9A-38355AE99AB6','2025-03-05','2025-03-02 02:16:54.449605',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'97AB2988-1E28-41D2-A207-05280B73C64F','2025-03-05','2025-03-03 23:47:54.4549262',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'9B176FA1-1A01-4F7D-906D-D97805E80FBB','2025-03-28','2025-03-03 22:42:06.7994341',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'A0EBD504-2C8B-485B-A48C-E023F2936A49','2025-01-28','2025-01-21 02:14:21.477266',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'B2E634B7-1F9A-46A4-870E-A1356C7D5FD0','2025-03-26','2025-03-03 22:41:51.1014665',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'B52D8893-F0E8-4FCA-BB95-42B031A49B47','2025-04-08','2025-03-03 22:55:46.5671556',NULL,'00:00:00','00:00:00');
INSERT INTO [BlockOutDates] ([Id],[Date],[Created],[Updated],[EndTime],[StartTime]) VALUES (
'F9E56AAE-4B23-4332-856A-D1F0310180DB','2025-03-07','2025-03-02 02:16:44.6224617',NULL,'00:00:00','00:00:00');
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'06CEC1CD-DC95-49CD-943A-83CE86F817C2','E6DBC350-1B2F-4C2D-8089-726A21F9EF66',NULL,NULL,0,0,0,NULL,10,'2025-02-01 10:26:25.3221553',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'07850020-C542-4298-817B-22D0BE5EFA5B','B7A6580C-396A-4104-A204-9086929CBFD5',NULL,NULL,0,0,0,NULL,10,'2025-02-03 11:32:09.1395609',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'09560F59-6F16-48BE-8975-572D92204227','6B0BAFFE-0327-4C37-A098-F98B43016D4B',NULL,NULL,0,0,0,NULL,10,'2025-02-27 21:48:05.0002626',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'1D6F470D-D780-442C-9C8E-17801212912A','F879F157-2BDE-48EF-ABF5-07655CBC23E1',NULL,NULL,0,0,0,NULL,10,'2025-01-27 04:41:59.8480665',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'1F4AB331-72D8-4054-922F-360634977398','BB22F52E-B60C-48EF-A43F-49F2E006E722','2025-06-02 23:00:00','2025-06-03 01:00:00',0,0,0,NULL,10,'2025-03-02 02:23:00.3081655',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'23D4D387-CE59-4222-BB35-621F816295D8','77FCC84D-E269-4CB8-BB99-22567A66D5C2',NULL,NULL,0,0,0,NULL,10,'2025-02-05 02:46:35.5708062',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'2A20B460-7298-41E4-9C7E-4B5AD45A3A3E','AD139CF7-9DDD-412E-84AC-27CE9F33893A',NULL,NULL,0,0,0,NULL,30,'2025-02-18 01:03:52.4170744',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'347C5328-76C3-4649-954F-F70E03DB2B26','6199C08B-AFA2-42EF-B6C6-266D569BB127',NULL,NULL,0,0,0,NULL,10,'2025-01-23 02:35:30.9224211',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'3A7DEF90-87C7-4071-A066-D65F0C94D08F','96DA912B-41C3-4F79-9C09-A759485CAAE5',NULL,NULL,0,0,0,NULL,10,'2025-03-03 00:46:28.893465',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'3CEAF4A3-2D43-4441-8251-F4658B99CAC8','BADFF6F4-1BF7-4408-A0C5-EAD67F9A08B2',NULL,NULL,0,0,0,NULL,10,'2025-02-19 06:45:21.4561155',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'3F540D49-8AD8-4BAE-9EE5-3E1307741018','E5E14A1B-D5D8-48BB-AAB6-A91CBE296A48','2025-02-10 23:00:00','2025-02-11 01:00:00',0,0,0,NULL,10,'2025-02-10 06:58:59.9802027',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'486211B8-1D56-4548-8C90-4A4076778A4E','6B52517F-6D00-4929-883F-C139468055AD','2025-06-02 23:00:00','2025-06-03 01:00:00',0,0,0,NULL,10,'2025-03-01 12:13:50.1026033',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'4AED34FB-3CB3-4135-8AA7-8940BB92F370','B3BA6619-DB61-4EA4-AEA2-A39A3C32127E',NULL,NULL,0,0,0,NULL,10,'2025-01-21 02:17:21.9779251',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'540E1FE4-2743-4594-AE44-CFDA5BBC8F20','BB22F52E-B60C-48EF-A43F-49F2E006E722','2025-03-05 23:00:00.1220385','2025-03-06 01:00:00.1220385',0,0,0,NULL,10,'2025-03-02 02:24:05.4282209',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'59455502-3766-4EFA-AE4C-A9B39AEE7467','55F4CB44-B05A-4075-BBD1-C4B6BDC4AB37',NULL,NULL,0,0,0,NULL,10,'2025-02-16 09:19:17.8424426',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'5C25783C-BEC0-4A0D-A506-CE522A012F36','A7596D6E-3563-4F69-98DE-42E64970CFFA','2025-03-07 15:00:00','2025-03-07 17:00:00',0,0,0,NULL,60,'2025-03-01 11:54:46.1827204',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'5E5A47C5-34BF-4B79-A200-3E1059D1981E','E8C264FD-57C2-4037-8556-3D66802EC20C',NULL,NULL,0,0,0,NULL,10,'2025-02-05 02:24:32.9481091',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'60293BDF-6E61-43E9-BBE5-E37614985786','5FDAA259-D047-466F-A69F-5CD6BC47830E',NULL,NULL,0,0,0,NULL,10,'2025-01-21 02:37:27.5120219',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'6297B1E6-E920-4370-85E8-1FB606E4227C','5170E598-916D-4B46-A83A-A29323DC2F9F',NULL,NULL,0,0,0,NULL,10,'2025-02-11 10:08:57.7241095',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'62AEFD71-EB5B-40A9-BFF3-9FEDE9B8F6B9','0B8C5D2D-D1BD-4BC9-BF4D-96A503E6D2E9',NULL,NULL,1,0,0,NULL,30,'2025-01-25 00:49:01.8290883',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'638B46E2-3995-4C20-9229-C464E4914B50','CB29F7A5-BB8F-437E-BF26-7FB738D0A480',NULL,NULL,0,0,0,NULL,10,'2025-03-03 02:51:34.748347',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'6A320040-8AE4-443B-8057-BE50204F361C','8425448C-E447-4182-83D5-E2D065C18B65','2025-03-05 10:00:00','2025-03-05 12:00:00',1,0,0,NULL,60,'2025-03-02 00:55:27.3681784',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'734B4185-700D-4DD4-9AEB-DEC0FB706115','388B7556-90BD-4B7B-849C-0609E676F9A3','2025-02-05 03:00:00','2025-02-05 05:00:00',1,0,0,NULL,80,'2025-02-05 02:44:42.3880168',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'770B6C55-5592-4615-B2A0-2FD2FBABA533','C2B5091F-56D6-4BE0-9AE2-8802C4AAD918','2025-02-03 23:00:00','2025-02-04 01:00:00',0,0,0,NULL,10,'2025-01-22 12:29:49.628733',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'7884394B-8C53-40CC-9151-18C2E1EE1625','47A71C8E-8D1D-43C7-A9B4-9A6F332DE245',NULL,NULL,0,0,0,NULL,10,'2025-01-27 10:12:39.0843171',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'85952B44-0D8B-4F2B-91F4-723D069936D5','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-01-23 23:00:00','2025-01-24 01:00:00',0,0,0,NULL,80,'2025-01-22 05:58:27.6498056',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'8651263B-5B38-46F2-BDD2-DAB5C6B787AD','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-03-05 23:00:00','2025-03-06 01:00:00',0,0,0,NULL,10,'2025-03-03 22:52:36.6910484',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'888FC77D-38DC-4E23-ACB6-EF3034FAC6BA','8425448C-E447-4182-83D5-E2D065C18B65','2025-05-03 00:00:00','2025-05-03 02:00:00',1,0,0,NULL,80,'2025-03-02 00:47:21.481498',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'8A92FA79-BBCB-411C-A218-612C98433A04','8DAD0075-274D-4904-A55B-3A7277974984','2025-02-10 23:00:00','2025-02-11 01:00:00',1,0,0,NULL,70,'2025-02-10 07:53:29.7136153',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'8F00BA5F-804B-4567-ADBE-FC331CF37549','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-01-22 00:00:00','2025-01-22 02:00:00',0,0,0,NULL,80,'2025-01-20 07:28:06.0441447',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'91444FEB-8FCF-4A02-99CB-D2DE866E5A7D','31AD3655-5F08-472E-BDB7-C67C8A48C842',NULL,NULL,0,0,0,NULL,10,'2025-03-03 23:31:13.3484021',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'95C89ADD-BD60-4F03-AA08-767AB7360ED6','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-02-19 00:00:00','2025-02-19 02:00:00',0,0,0,NULL,80,'2025-02-18 00:10:38.713052',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'99828066-ACFF-4E63-8FCF-2E28100A9672','D600DAA6-8310-4790-A601-D35C0F2A26FB',NULL,NULL,0,0,0,NULL,10,'2025-02-18 05:11:08.2218677',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'998BFC2F-9C83-454F-9987-2333C05C6D05','AD139CF7-9DDD-412E-84AC-27CE9F33893A',NULL,NULL,0,0,0,NULL,30,'2025-01-21 02:17:12.1656387',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'9DD5B425-5CC2-4399-83FA-E252BFF2FB67','64145C63-D302-4395-A665-1D3B7621C5F6',NULL,NULL,0,0,0,NULL,10,'2025-02-15 04:15:08.6313719',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'A201F58C-500D-44ED-8966-7A49C0288A4A','6579BE8A-5129-4162-A80B-25A2BA28BD03',NULL,NULL,0,0,0,NULL,10,'2025-02-12 18:58:44.0110528',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'A9AD79CA-ADD3-4EBD-BB12-EA7A7F2AA7E5','64C04230-9110-4746-86E3-21857D23EC7B',NULL,NULL,0,0,0,NULL,10,'2025-01-23 00:30:02.7505753',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'AC8461F4-1DA3-46A7-8942-1C0D21A8E3AB','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-01-20 23:00:00','2025-01-21 01:00:00',0,0,0,NULL,80,'2025-01-20 09:18:32.8163763',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'C313D426-370A-4C42-A4A3-6D3C42E6244C','737F2689-37E0-4935-8607-D2466345EC87',NULL,NULL,0,0,0,NULL,10,'2025-01-29 06:44:29.0446906',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','AD29A5DA-ED07-4904-A60E-072D66EBD379','2025-02-27 23:00:00','2025-02-28 01:00:00',0,0,0,NULL,10,'2025-02-03 01:58:21.0489422',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'CEE5D909-B830-4093-8051-96C9D204E5C5','5AD645C7-7190-411D-8DBB-58E65DCCE966',NULL,NULL,0,0,0,NULL,10,'2025-03-01 11:33:50.7267289',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'D0B79C63-EA28-4BAC-AD36-F69112F2730E','32A60FD5-6031-40E5-A3BC-0DD82CA16525',NULL,NULL,0,0,0,NULL,10,'2025-03-01 11:34:45.6258084',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'D19D5792-64EA-460A-8891-8DB25841EFE7','32C86785-363D-4ADE-B78D-49F2333CC583',NULL,NULL,0,0,0,NULL,10,'2025-02-01 02:43:00.8803847',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'D3008A75-A314-4D7A-BEC4-9B0BC9CB8384','599BEC58-26E7-4A06-BE90-19205CA0BAE0',NULL,NULL,0,0,0,NULL,10,'2025-01-24 04:29:14.1359738',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'D5B0D983-5EAA-42F5-869F-A39A2E8FB339','06D73F9C-A28A-4F6B-BEFE-81273ACDC495',NULL,NULL,0,0,0,NULL,10,'2025-03-03 02:02:54.8268647',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'DD288370-2208-4D70-9724-D54BDA630F28','B7759E29-2C18-400B-9A17-72AD3FC0C870',NULL,NULL,0,0,0,NULL,10,'2025-02-09 09:47:12.3507857',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'DEFE9225-8F91-47AB-A51E-BEF2D4D721CA','6B52517F-6D00-4929-883F-C139468055AD','2025-06-03 01:00:00','2025-06-03 03:00:00',0,0,0,NULL,10,'2025-03-02 02:20:50.8666414',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'E0BA774B-A194-4297-863E-BF6CD143DD91','E63734D4-A308-4785-ACEC-E477FA5CC1A4',NULL,NULL,0,0,0,NULL,10,'2025-03-02 01:58:11.2178428',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'E13454F0-E733-431E-856B-10107650818B','A37DD9CA-9624-4A51-BD13-D863445A9A03',NULL,NULL,0,0,0,NULL,10,'2025-03-03 22:32:19.9502568',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'E2385CCE-1CAF-4922-9EEC-20D5716B9F84','CD1CE45C-7AC0-42D6-9A1C-9EAC59D3B4FD',NULL,NULL,0,0,0,NULL,10,'2025-01-24 04:45:28.7123581',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'F4C4F9E0-C78D-4D2C-872F-4F888EBCE1D3','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-03-05 02:00:00','2025-03-05 04:00:00',0,0,0,NULL,80,'2025-03-01 12:30:00.6271191',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'F73C3F73-D044-4B41-9471-238AA876E442','AD139CF7-9DDD-412E-84AC-27CE9F33893A','2025-01-23 23:00:00','2025-01-24 01:00:00',0,0,0,NULL,30,'2025-01-22 12:47:49.1176183',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'FB4DA13D-870D-4859-9A8F-F6E14C1A110A','6B52517F-6D00-4929-883F-C139468055AD','2025-04-03 00:00:00','2025-04-03 02:00:00',1,0,0,NULL,80,'2025-02-05 02:49:57.244057',NULL);
INSERT INTO [Appointments] ([Id],[UserId],[StartTime],[EndTime],[HasHadEyelashExtentions],[IsSampleSetComplete],[IsDepositPaid],[SampleSetCompleted],[Status],[Created],[Updated]) VALUES (
'FCA85E55-A3F0-4866-A5E4-14CE0DC4CD44','A26D4BEC-7F4B-4613-B121-80408B653818',NULL,NULL,0,0,0,NULL,10,'2025-02-10 06:37:09.6549437',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'0973824C-A7E6-4959-B742-9D0059306433','85952B44-0D8B-4F2B-91F4-723D069936D5','FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','2025-01-22 05:59:17.172579',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'0AB04C21-C1DD-4376-9251-254766ABF5ED','486211B8-1D56-4548-8C90-4A4076778A4E','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-02 02:19:46.5857565',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'0D64C0FE-381B-4F4B-875B-9501F0DFE9D4','6297B1E6-E920-4370-85E8-1FB606E4227C','19A32315-D1AE-467A-948B-FAC57CC829BD','2025-02-11 10:09:52.0433084',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'0D8543C5-C38C-4751-9720-2BC1D68E6CE7','8F00BA5F-804B-4567-ADBE-FC331CF37549','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-01-21 02:18:38.1084209',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'14AB3264-85AC-45E1-8607-47FCD46A10E1','DEFE9225-8F91-47AB-A51E-BEF2D4D721CA','FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','2025-03-03 22:57:26.9005048',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'1509F7F8-9553-41BA-99BA-8D9618463E83','8651263B-5B38-46F2-BDD2-DAB5C6B787AD','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-03 22:52:41.2165369',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'15C06FDD-2796-4063-AD05-FFC756251209','5C25783C-BEC0-4A0D-A506-CE522A012F36','FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','2025-03-01 11:54:46.2236945',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'1AB7AB7A-61E9-4177-88A3-AB0AB8A6A25D','734B4185-700D-4DD4-9AEB-DEC0FB706115','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-05 02:44:49.6407157',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'1E69A22B-3AA3-40B6-9B43-5CC4984EADBA','6A320040-8AE4-443B-8057-BE50204F361C','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-02 00:55:38.0244021',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'20F87436-3F13-40DA-8D2F-BBA9244BC62A','888FC77D-38DC-4E23-ACB6-EF3034FAC6BA','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-02 00:47:52.1478129',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'377FBCF6-AA9D-4A85-8DA5-1538EEC7EB21','6297B1E6-E920-4370-85E8-1FB606E4227C','19A32315-D1AE-467A-948B-FAC57CC829BD','2025-02-11 10:10:00.1471972',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'4365997A-B7DD-45E2-B0B2-4509450A38CF','2A20B460-7298-41E4-9C7E-4B5AD45A3A3E','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-18 01:03:58.2961705',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'4466718E-A513-49BA-8342-D407A5EB4CAE','F73C3F73-D044-4B41-9471-238AA876E442','19A32315-D1AE-467A-948B-FAC57CC829BD','2025-01-23 00:18:18.5777932',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'59C60A12-C6FE-400A-8A16-46A7AADFC34B','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:14:01.7879355',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'64990EEA-2CDE-40CA-8E12-6AFA1DA17069','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:14:36.9817345',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'74E60256-AADB-4C6C-8D37-18D381D37ADE','62AEFD71-EB5B-40A9-BFF3-9FEDE9B8F6B9','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-18 00:15:35.5734546',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'76314A56-64F6-4190-BD3F-16DA2BA22F90','FB4DA13D-870D-4859-9A8F-F6E14C1A110A','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-03-01 12:04:16.0072369',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'783B40CC-4626-4569-A098-95BB27E36821','F4C4F9E0-C78D-4D2C-872F-4F888EBCE1D3','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-01 12:30:02.334098',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'78848853-26B8-4E2D-B6A5-39F4B5124B3A','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:15:13.4227994',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'941FE807-C8E7-49AA-A7B1-3664F192BDA3','8A92FA79-BBCB-411C-A218-612C98433A04','FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','2025-02-10 08:29:33.8634273',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'9C265BDC-6F0D-4379-8B8B-7BF8A30E7396','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:13:54.3985069',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'A1B7D7FF-A3D7-4FA4-BCFA-BCE0F267469B','60293BDF-6E61-43E9-BBE5-E37614985786','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-02 01:10:51.9797704',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'A3DFB0AA-0293-4375-82BE-1BFF88AFF08C','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:14:11.3349166',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'A65B472D-C123-4823-8BC7-E45F1C163D02','3F540D49-8AD8-4BAE-9EE5-3E1307741018','FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','2025-02-10 06:59:43.6615161',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'A9D0F804-A162-44AA-BC6E-D252415B9CB3','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:14:33.2393007',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'AF5EAEBE-4DFB-46BA-A564-986E8DCBD74C','540E1FE4-2743-4594-AE44-CFDA5BBC8F20','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-03 22:49:00.7030469',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'B984D3B7-2E1B-4EF9-95F4-D131058B129D','1F4AB331-72D8-4054-922F-360634977398','98C4E6BB-0E3E-4FB9-B263-FE0E7BF3AC77','2025-03-02 02:23:18.5512772',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'D46C0EEB-3E92-42EB-9ABC-DB8AAFD683E3','998BFC2F-9C83-454F-9987-2333C05C6D05','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-01-21 02:17:16.5897599',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'D775DC4C-162F-4BBA-A300-58B8E6973370','95C89ADD-BD60-4F03-AA08-767AB7360ED6','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-18 00:10:43.0823311',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'E7A7FEC5-DD8C-4E28-9A05-77F2CAE8637B','770B6C55-5592-4615-B2A0-2FD2FBABA533','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-01-22 12:33:44.0614373',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'EF2202D9-D6ED-48C8-BF5C-DBF841AF4462','AC8461F4-1DA3-46A7-8942-1C0D21A8E3AB','FFE2CDAE-EE3B-4575-BE9F-C81DF0A66E88','2025-01-20 09:33:56.0471121',NULL);
INSERT INTO [AppointmentServices] ([Id],[AppointmentId],[ServiceId],[Created],[Updated]) VALUES (
'FBE2A197-EF5D-4C4C-9484-D9F7AE4A57B4','CC53E8A9-7CA5-4F39-9973-940A8D7D8F59','ED6344D6-5AF9-4934-B9D0-28293915D13A','2025-02-27 05:14:35.3911622',NULL);
INSERT INTO [AppointmentProducts] ([Id],[AppointmentId],[ProductId],[Quantity]) VALUES (
'5C6244B2-219C-41EE-90B2-05C7E418C924','6297B1E6-E920-4370-85E8-1FB606E4227C','7F0F84F7-9B8A-4B6F-A8AE-4724F2CA82AA',18);
INSERT INTO [Admins] ([Id],[Username],[Password],[FirstName],[LastName],[Phone],[AdminKey],[ResetKey],[ResetKeySent],[Created],[Updated]) VALUES (
'ACD39C44-EF8F-408E-990D-FD9E78CED37B','jricastudio@gmail.com','$2a$11$BdjcXAcJF/Dcq.5gjvE.BOF.6pEP74V7YTTHQe/lXldgp/RYtFjT6','Jayrica','Cunanan','0422453888','7DCE5A50-21AA-4346-B059-A95DD8D497D7','00000000-0000-0000-0000-000000000000','0001-01-01 00:00:00','2025-01-20 07:00:44.0237551','2025-03-04 01:21:56.3280005');
INSERT INTO [__EFMigrationsHistory] ([MigrationId],[ProductVersion]) VALUES (
'20250124003244_init','8.0.11');
INSERT INTO [__EFMigrationsHistory] ([MigrationId],[ProductVersion]) VALUES (
'20250303234756_add time to blockout Date Table','8.0.11');
CREATE INDEX [Products_IX_Products_ProductCategoryId] ON [Products] ([ProductCategoryId] ASC);
CREATE INDEX [Products_IX_Products_ImageUploadId] ON [Products] ([ImageUploadId] ASC);
CREATE INDEX [ProductShowcases_IX_ProductShowcases_ProductId] ON [ProductShowcases] ([ProductId] ASC);
CREATE INDEX [Services_IX_Services_ImageUploadId] ON [Services] ([ImageUploadId] ASC);
CREATE INDEX [ServicesShowcases_IX_ServicesShowcases_ServiceId] ON [ServicesShowcases] ([ServiceId] ASC);
CREATE INDEX [Appointments_IX_Appointments_UserId] ON [Appointments] ([UserId] ASC);
CREATE INDEX [AppointmentServices_IX_AppointmentServices_ServiceId] ON [AppointmentServices] ([ServiceId] ASC);
CREATE INDEX [AppointmentServices_IX_AppointmentServices_AppointmentId] ON [AppointmentServices] ([AppointmentId] ASC);
CREATE INDEX [AppointmentProducts_IX_AppointmentProducts_ProductId] ON [AppointmentProducts] ([ProductId] ASC);
CREATE INDEX [AppointmentProducts_IX_AppointmentProducts_AppointmentId] ON [AppointmentProducts] ([AppointmentId] ASC);
CREATE TRIGGER [fki_Products_ProductCategoryId_ProductCategories_Id] BEFORE Insert ON [Products] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Products violates foreign key constraint FK_Products_0_0') WHERE (SELECT Id FROM ProductCategories WHERE  Id = NEW.ProductCategoryId) IS NULL; END;
CREATE TRIGGER [fku_Products_ProductCategoryId_ProductCategories_Id] BEFORE Update ON [Products] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Products violates foreign key constraint FK_Products_0_0') WHERE (SELECT Id FROM ProductCategories WHERE  Id = NEW.ProductCategoryId) IS NULL; END;
CREATE TRIGGER [fki_Products_ImageUploadId_ImageUploads_Id] BEFORE Insert ON [Products] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Products violates foreign key constraint FK_Products_1_0') WHERE (SELECT Id FROM ImageUploads WHERE  Id = NEW.ImageUploadId) IS NULL; END;
CREATE TRIGGER [fku_Products_ImageUploadId_ImageUploads_Id] BEFORE Update ON [Products] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Products violates foreign key constraint FK_Products_1_0') WHERE (SELECT Id FROM ImageUploads WHERE  Id = NEW.ImageUploadId) IS NULL; END;
CREATE TRIGGER [fki_ProductShowcases_ProductId_Products_Id] BEFORE Insert ON [ProductShowcases] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table ProductShowcases violates foreign key constraint FK_ProductShowcases_0_0') WHERE (SELECT Id FROM Products WHERE  Id = NEW.ProductId) IS NULL; END;
CREATE TRIGGER [fku_ProductShowcases_ProductId_Products_Id] BEFORE Update ON [ProductShowcases] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table ProductShowcases violates foreign key constraint FK_ProductShowcases_0_0') WHERE (SELECT Id FROM Products WHERE  Id = NEW.ProductId) IS NULL; END;
CREATE TRIGGER [fki_Services_ImageUploadId_ImageUploads_Id] BEFORE Insert ON [Services] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Services violates foreign key constraint FK_Services_0_0') WHERE (SELECT Id FROM ImageUploads WHERE  Id = NEW.ImageUploadId) IS NULL; END;
CREATE TRIGGER [fku_Services_ImageUploadId_ImageUploads_Id] BEFORE Update ON [Services] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Services violates foreign key constraint FK_Services_0_0') WHERE (SELECT Id FROM ImageUploads WHERE  Id = NEW.ImageUploadId) IS NULL; END;
CREATE TRIGGER [fki_ServicesShowcases_ServiceId_Services_Id] BEFORE Insert ON [ServicesShowcases] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table ServicesShowcases violates foreign key constraint FK_ServicesShowcases_0_0') WHERE (SELECT Id FROM Services WHERE  Id = NEW.ServiceId) IS NULL; END;
CREATE TRIGGER [fku_ServicesShowcases_ServiceId_Services_Id] BEFORE Update ON [ServicesShowcases] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table ServicesShowcases violates foreign key constraint FK_ServicesShowcases_0_0') WHERE (SELECT Id FROM Services WHERE  Id = NEW.ServiceId) IS NULL; END;
CREATE TRIGGER [fki_Appointments_UserId_Users_Id] BEFORE Insert ON [Appointments] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Appointments violates foreign key constraint FK_Appointments_0_0') WHERE (SELECT Id FROM Users WHERE  Id = NEW.UserId) IS NULL; END;
CREATE TRIGGER [fku_Appointments_UserId_Users_Id] BEFORE Update ON [Appointments] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Appointments violates foreign key constraint FK_Appointments_0_0') WHERE (SELECT Id FROM Users WHERE  Id = NEW.UserId) IS NULL; END;
CREATE TRIGGER [fki_AppointmentServices_ServiceId_Services_Id] BEFORE Insert ON [AppointmentServices] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table AppointmentServices violates foreign key constraint FK_AppointmentServices_0_0') WHERE (SELECT Id FROM Services WHERE  Id = NEW.ServiceId) IS NULL; END;
CREATE TRIGGER [fku_AppointmentServices_ServiceId_Services_Id] BEFORE Update ON [AppointmentServices] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table AppointmentServices violates foreign key constraint FK_AppointmentServices_0_0') WHERE (SELECT Id FROM Services WHERE  Id = NEW.ServiceId) IS NULL; END;
CREATE TRIGGER [fki_AppointmentServices_AppointmentId_Appointments_Id] BEFORE Insert ON [AppointmentServices] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table AppointmentServices violates foreign key constraint FK_AppointmentServices_1_0') WHERE (SELECT Id FROM Appointments WHERE  Id = NEW.AppointmentId) IS NULL; END;
CREATE TRIGGER [fku_AppointmentServices_AppointmentId_Appointments_Id] BEFORE Update ON [AppointmentServices] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table AppointmentServices violates foreign key constraint FK_AppointmentServices_1_0') WHERE (SELECT Id FROM Appointments WHERE  Id = NEW.AppointmentId) IS NULL; END;
CREATE TRIGGER [fki_AppointmentProducts_ProductId_Products_Id] BEFORE Insert ON [AppointmentProducts] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table AppointmentProducts violates foreign key constraint FK_AppointmentProducts_0_0') WHERE (SELECT Id FROM Products WHERE  Id = NEW.ProductId) IS NULL; END;
CREATE TRIGGER [fku_AppointmentProducts_ProductId_Products_Id] BEFORE Update ON [AppointmentProducts] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table AppointmentProducts violates foreign key constraint FK_AppointmentProducts_0_0') WHERE (SELECT Id FROM Products WHERE  Id = NEW.ProductId) IS NULL; END;
CREATE TRIGGER [fki_AppointmentProducts_AppointmentId_Appointments_Id] BEFORE Insert ON [AppointmentProducts] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table AppointmentProducts violates foreign key constraint FK_AppointmentProducts_1_0') WHERE (SELECT Id FROM Appointments WHERE  Id = NEW.AppointmentId) IS NULL; END;
CREATE TRIGGER [fku_AppointmentProducts_AppointmentId_Appointments_Id] BEFORE Update ON [AppointmentProducts] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table AppointmentProducts violates foreign key constraint FK_AppointmentProducts_1_0') WHERE (SELECT Id FROM Appointments WHERE  Id = NEW.AppointmentId) IS NULL; END;
COMMIT;

