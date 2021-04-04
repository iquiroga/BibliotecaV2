CREATE TABLE [dbo].[IDIOMAS] (
    [id_idioma] INT            IDENTITY (1, 1) NOT NULL,
    [idioma]    NVARCHAR (160) NOT NULL,
    CONSTRAINT [PK_IDIOMAS] PRIMARY KEY CLUSTERED ([id_idioma] ASC)
);



