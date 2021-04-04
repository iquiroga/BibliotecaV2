CREATE TABLE [dbo].[AUTORES] (
    [id_autor]     INT            IDENTITY (1, 1) NOT NULL,
    [nombre_autor] NVARCHAR (160) NOT NULL,
    [id_pais]      INT            NULL,
    [anio_nac]     DATE           NULL,
    [anio_def]     DATE           NULL,
    CONSTRAINT [PK_AUTORES] PRIMARY KEY CLUSTERED ([id_autor] ASC),
    CONSTRAINT [FK_AUTORES_PAISES] FOREIGN KEY ([id_pais]) REFERENCES [dbo].[PAISES] ([id_pais])
);



