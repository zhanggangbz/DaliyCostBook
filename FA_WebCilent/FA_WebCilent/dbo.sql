-- ----------------------------
-- Table structure for DB_FA_COST_ITEM
-- ----------------------------
DROP TABLE [dbo].[DB_FA_COST_ITEM]
GO
CREATE TABLE [dbo].[DB_FA_COST_ITEM] (
[I_Id] nvarchar(255) NOT NULL ,
[I_CDate] datetime NULL ,
[I_Money] float(53) NOT NULL ,
[I_BankCord] int NOT NULL ,
[I_Remark] nvarchar(255) NOT NULL ,
[F_U_Id] nvarchar(255) NOT NULL ,
[F_Y_Id] nvarchar(255) NOT NULL ,
[I_Location] varchar(512) NULL 
)


GO

-- ----------------------------
-- Table structure for DB_FA_COST_TYPE
-- ----------------------------
DROP TABLE [dbo].[DB_FA_COST_TYPE]
GO
CREATE TABLE [dbo].[DB_FA_COST_TYPE] (
[Y_Id] nvarchar(255) NOT NULL ,
[Y_Name] nvarchar(255) NOT NULL ,
[Y_IsIncome] int NULL ,
[F_U_Id] nvarchar(255) NOT NULL ,
[P_Y_Id] nvarchar(255) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for DB_FA_USER
-- ----------------------------
DROP TABLE [dbo].[DB_FA_USER]
GO
CREATE TABLE [dbo].[DB_FA_USER] (
[U_Id] nvarchar(255) NOT NULL ,
[U_Name] nvarchar(255) NOT NULL ,
[U_PassWord] nvarchar(255) NOT NULL ,
[U_NickName] varchar(255) NULL 
)


GO

-- ----------------------------
-- Indexes structure for table DB_FA_COST_ITEM
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table DB_FA_COST_ITEM
-- ----------------------------
ALTER TABLE [dbo].[DB_FA_COST_ITEM] ADD PRIMARY KEY ([I_Id])
GO

-- ----------------------------
-- Indexes structure for table DB_FA_COST_TYPE
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table DB_FA_COST_TYPE
-- ----------------------------
ALTER TABLE [dbo].[DB_FA_COST_TYPE] ADD PRIMARY KEY ([Y_Id])
GO

-- ----------------------------
-- Indexes structure for table DB_FA_USER
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table DB_FA_USER
-- ----------------------------
ALTER TABLE [dbo].[DB_FA_USER] ADD PRIMARY KEY ([U_Id])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[DB_FA_COST_ITEM]
-- ----------------------------
ALTER TABLE [dbo].[DB_FA_COST_ITEM] ADD FOREIGN KEY ([F_U_Id]) REFERENCES [dbo].[DB_FA_USER] ([U_Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[DB_FA_COST_ITEM] ADD FOREIGN KEY ([F_Y_Id]) REFERENCES [dbo].[DB_FA_COST_TYPE] ([Y_Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[DB_FA_COST_TYPE]
-- ----------------------------
ALTER TABLE [dbo].[DB_FA_COST_TYPE] ADD FOREIGN KEY ([F_U_Id]) REFERENCES [dbo].[DB_FA_USER] ([U_Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
