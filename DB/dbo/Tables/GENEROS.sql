CREATE TABLE [dbo].[GENEROS] (
    [id_genero] INT            IDENTITY (1, 1) NOT NULL,
    [genero]    NVARCHAR (160) NOT NULL,
    CONSTRAINT [PK_GENEROS] PRIMARY KEY CLUSTERED ([id_genero] ASC)
);



