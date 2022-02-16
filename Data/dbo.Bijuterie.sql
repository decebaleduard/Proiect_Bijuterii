CREATE TABLE [dbo].[Bijuterie] (
    [ID]    INT             IDENTITY (1, 1) NOT NULL,
    [Tip]   NVARCHAR (MAX)  NULL,
    [Marca] NVARCHAR (MAX)  NULL,
    [Pret]  DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Bijuterie] PRIMARY KEY CLUSTERED ([ID] ASC)
);

