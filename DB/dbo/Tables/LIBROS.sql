CREATE TABLE [dbo].[LIBROS] (
    [id_libro]          INT            IDENTITY (1, 1) NOT NULL,
    [titulo]            NVARCHAR (300) NOT NULL,
    [id_genero]         INT            NOT NULL,
    [id_autor]          INT            NOT NULL,
    [precio]            FLOAT (53)     NOT NULL,
    [fecha_publicacion] DATE           NULL,
    [id_idioma]         INT            NOT NULL,
    CONSTRAINT [PK_LIBROS] PRIMARY KEY CLUSTERED ([id_libro] ASC),
    CONSTRAINT [FK_LIBROS_AUTORES] FOREIGN KEY ([id_autor]) REFERENCES [dbo].[AUTORES] ([id_autor]),
    CONSTRAINT [FK_LIBROS_GENEROS] FOREIGN KEY ([id_genero]) REFERENCES [dbo].[GENEROS] ([id_genero]),
    CONSTRAINT [FK_LIBROS_IDIOMAS] FOREIGN KEY ([id_idioma]) REFERENCES [dbo].[IDIOMAS] ([id_idioma])
);



