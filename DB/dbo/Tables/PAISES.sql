CREATE TABLE [dbo].[PAISES] (
    [id_pais] INT            IDENTITY (1, 1) NOT NULL,
    [pais]    NVARCHAR (160) NOT NULL,
    CONSTRAINT [PK_PAISES] PRIMARY KEY CLUSTERED ([id_pais] ASC)
);



