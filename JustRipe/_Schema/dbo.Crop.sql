CREATE TABLE [dbo].[Crop] (
    [Id]         INT           NOT NULL,
    [Name]       VARCHAR (255) NOT NULL,
    [Created_At] DATETIME2 (7) DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

