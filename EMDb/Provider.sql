CREATE TABLE [dbo].[Provider]
(
    [Id] int identity(1,1) primary key, 
    [Key] nvarchar(100) null,
    [Secret] nvarchar(100) null,
    [BaseUrl] nvarchar(250) not null,
    [Schema] nvarchar(50) not null,
    [Port] int null,
    [Path] nvarchar(100) not null,
)
