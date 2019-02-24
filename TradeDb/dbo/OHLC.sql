CREATE TABLE [dbo].[Ohlc]
(
    [ID]        INT             NOT NULL PRIMARY KEY,
    [MetaDataID]INT             NOT NULL,
    [Open]      NVARCHAR(150)   NULL,
    [High]      NVARCHAR(150)   NULL,
    [Low]       NVARCHAR(150)   NULL,
    [Close]     NVARCHAR(150)   NULL,
    [Volume]    NVARCHAR(150)   NULL,
)
