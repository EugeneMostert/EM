CREATE TABLE [dbo].[MetaInfo]
(
    [ID]            INT             NOT NULL PRIMARY KEY,
    [MetaDataID]    INT             NOT NULL,
    [Information]   NVARCHAR(150)   NULL,
    [Symbol]        NVARCHAR(150)   NULL,
    [LastRefreshed] DateTime        NULL,
    [Interval]      NVARCHAR(150)   NULL,
    [OutputSize]    NVARCHAR(150)   NULL,
    [TimeZone]      NVARCHAR(150)   NULL,
)
