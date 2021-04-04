/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*PAISES*/
SET IDENTITY_INSERT [dbo].[PAISES] ON;
GO
MERGE INTO [dbo].[PAISES] AS TARGET
USING(VALUES
(1, 'Argentina'),
(2, 'Estados Unidos'),
(3, 'Inglaterra')
) AS SOURCE([id_pais], [pais])
ON TARGET.[id_pais] = SOURCE.[id_pais]
    WHEN NOT MATCHED BY TARGET
    THEN
        INSERT ([id_pais], [pais])
        VALUES ([id_pais], [pais])
    WHEN MATCHED
    THEN
        UPDATE SET [pais] = SOURCE.[pais]
    WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

GO
SET IDENTITY_INSERT [dbo].[PAISES] OFF;
GO

/*AUTORES*/
SET IDENTITY_INSERT [dbo].[AUTORES] ON;
GO
MERGE INTO [dbo].[AUTORES] AS TARGET
USING(VALUES
(1, 'Michael C. Feathers', 2)
) AS SOURCE([id_autor], [nombre_autor], [id_pais])
ON TARGET.[id_autor] = SOURCE.[id_autor]
    WHEN NOT MATCHED BY TARGET
    THEN
        INSERT ([id_autor], [nombre_autor], [id_pais])
        VALUES ([id_autor], [nombre_autor], [id_pais])
    WHEN MATCHED
    THEN
        UPDATE SET [nombre_autor] = SOURCE.[nombre_autor],
                   [id_pais] = SOURCE.[id_pais]
    WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

GO
SET IDENTITY_INSERT [dbo].[AUTORES] OFF;
GO

/*IDIOMAS*/
SET IDENTITY_INSERT [dbo].[IDIOMAS] ON;
GO
MERGE INTO [dbo].[IDIOMAS] AS TARGET
USING(VALUES
(1, 'Inglés'),
(2, 'Español')
) AS SOURCE([id_idioma], [idioma])
ON TARGET.[id_idioma] = SOURCE.[id_idioma]
    WHEN NOT MATCHED BY TARGET
    THEN
        INSERT ([id_idioma], [idioma])
        VALUES ([id_idioma], [idioma])
    WHEN MATCHED
    THEN
        UPDATE SET [idioma] = SOURCE.[idioma]
    WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

GO
SET IDENTITY_INSERT [dbo].[IDIOMAS] OFF;
GO

/*GENEROS*/
SET IDENTITY_INSERT [dbo].[GENEROS] ON;
GO
MERGE INTO [dbo].[GENEROS] AS TARGET
USING(VALUES
(1, 'Programación')
) AS SOURCE([id_genero], [genero])
ON TARGET.[id_genero] = SOURCE.[id_genero]
    WHEN NOT MATCHED BY TARGET
    THEN
        INSERT ([id_genero], [genero])
        VALUES ([id_genero], [genero])
    WHEN MATCHED
    THEN
        UPDATE SET [genero] = SOURCE.[genero]
    WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

GO
SET IDENTITY_INSERT [dbo].[GENEROS] OFF;
GO

/*LIBROS*/
SET IDENTITY_INSERT [dbo].[LIBROS] ON;
GO
MERGE INTO [dbo].[LIBROS] AS TARGET
USING(VALUES
(1, 'Working Effectively with Legacy Code', 1, 1, 7981.50, '2004-09-01', 1)
) AS SOURCE([id_libro], [titulo], [id_genero], [id_autor], [precio], [fecha_publicacion], [id_idioma])
ON TARGET.[id_libro] = SOURCE.[id_libro]
    WHEN NOT MATCHED BY TARGET
    THEN
        INSERT ([id_libro], [titulo], [id_genero], [id_autor], [precio], [fecha_publicacion], [id_idioma])
        VALUES ([id_libro], [titulo], [id_genero], [id_autor], [precio], [fecha_publicacion], [id_idioma])
    WHEN MATCHED
    THEN
        UPDATE SET [titulo] = SOURCE.[titulo],
                   [id_genero] = SOURCE.[id_genero],
                   [id_autor] = SOURCE.[id_autor],
                   [precio] = SOURCE.[precio],
                   [fecha_publicacion] = SOURCE.[fecha_publicacion],
                   [id_idioma] = SOURCE.[id_idioma]
    WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

GO
SET IDENTITY_INSERT [dbo].[LIBROS] OFF;
GO


