USE [Prueba36]
GO

-- Paises
INSERT INTO [dbo].[Paises]
    ([EcIsoPais]
    ,[EcNombrePais])
VALUES
    ('US', 'Estados Unidos');
Go
-- Insert 2
INSERT INTO [dbo].[Paises]
    ([EcIsoPais]
    ,[EcNombrePais])
VALUES
    ('CA', 'Canad�');
Go
-- Insert 3
INSERT INTO [dbo].[Paises]
    ([EcIsoPais]
    ,[EcNombrePais])
VALUES
    ('MX', 'M�xico');
Go
-- Insert 4
INSERT INTO [dbo].[Paises]
    ([EcIsoPais]
    ,[EcNombrePais])
VALUES
    ('GB', 'Reino Unido');
Go
-- Insert 5
INSERT INTO [dbo].[Paises]
    ([EcIsoPais]
    ,[EcNombrePais])
VALUES
    ('FR', 'Francia');
Go

-- Primer Insert
INSERT INTO [dbo].[EstadosDeConservacion]
    ([ConsId], [ConsNombre], [ConsValoresNumericos])
VALUES
    ('1', 'Peligro', 10)
Go
-- Segundo Insert
INSERT INTO [dbo].[EstadosDeConservacion]
    ([ConsId], [ConsNombre], [ConsValoresNumericos])
VALUES
    ('2', 'Aceptable', 15)
Go
-- Tercer Insert
INSERT INTO [dbo].[EstadosDeConservacion]
    ([ConsId], [ConsNombre], [ConsValoresNumericos])
VALUES
    ('3', '�ptimo', 20)
Go

INSERT INTO [dbo].[Especies]
           ([EsNombreCientifico]
           ,[EsNombreVulgar]
           ,[EsDescripcion]
           ,[EsPesoMinimo]
           ,[EsPesoMaximo]
           ,[EsLongitudMinima]
           ,[EsLongitudMaxima]
		   ,[EstadoDeConservacionId])
     VALUES
           ('Panthera leo', 'Le�n', 'Descripci�n de la Especie', 1.5, 3.5, 10.0, 20.0, '1'),
           ('Elephas maximus', 'Elefante asi�tico)', 'Descripci�n de la Especie', 1.7, 3.8, 11.0, 21.0, '2'),
           ('Canis lupus', 'Lobo gris', 'Descripci�n de la Especie', 1.9, 4.0, 12.0, 22.0, '3'),
           ('Felis catus', 'Gato dom�stico', 'Descripci�n de la Especie', 12.0, 4.2, 13.0, 23.0, '2'),
           ('Ursus arctos', 'Oso pardo', 'Descripci�n de la Especie', 8.2, 4.5, 14.0, 24.0, '1'),
		   ('Pongo abelii', 'Orangut�n de Sumatra', 'Descripci�n de la Especie', 5.2, 4.5, 14.0, 24.0, '2'),
		   ('Gorilla beringei', 'Gorila de monta�a', 'Descripci�n de la Especie', 2.2, 10.5, 14.0, 24.0, '1'),
		   ('Equus ferus caballus', 'Caballo', 'Descripci�n de la Especie', 4.2, 5.5, 14.0, 24.0, '3')
GO


INSERT INTO [dbo].[Usuarios]
           ([UsuarioAlias]
           ,[UsuarioContrasenia])
     VALUES
           ('Juan'
           ,'Juan'),
		   ('admin1'
           ,'Admin.12')
GO

--[UbicacionesGeograficas]
INSERT INTO [dbo].[UbicacionesGeograficas]
    ([Latitud]
    ,[Longitud])
VALUES
    (-30, 40);
Go

INSERT INTO [dbo].[UbicacionesGeograficas]
    ([Latitud]
    ,[Longitud])
VALUES
    (-40, 80);
Go

INSERT INTO [dbo].[UbicacionesGeograficas]
    ([Latitud]
    ,[Longitud])
VALUES
    (-112, 34);
Go

INSERT INTO [dbo].[UbicacionesGeograficas]
    ([Latitud]
    ,[Longitud])
VALUES
    (-4032, 8022);
Go

INSERT INTO [dbo].[UbicacionesGeograficas]
    ([Latitud]
    ,[Longitud])
VALUES
    (-401, 802);
Go

--Ecosistemas
INSERT INTO [dbo].[Ecosistemas]
    ([EcNombre]
	,[EcUbicacionGeograficaId]
    ,[EcArea]
    ,[EcCaracteristicas]
    ,[PaisId]
	,[EstadoDeConservacionId])
VALUES
    ('Bosque de Con�feras', 1,1500, 'Ecosistema de �rboles de hoja perenne en regiones monta�osas.', 'MX', '2');
Go
-- Insert 2
INSERT INTO [dbo].[Ecosistemas]
    ([EcNombre]
	,[EcUbicacionGeograficaId]
    ,[EcArea]
    ,[EcCaracteristicas]
    ,[PaisId]
	,[EstadoDeConservacionId])
VALUES
    ('Sabana Africana', 2,2000, 'Ecosistema de praderas con �rboles dispersos en �frica.', 'FR', '2');
Go
-- Insert 3
INSERT INTO [dbo].[Ecosistemas]
    ([EcNombre]
	,[EcUbicacionGeograficaId]
    ,[EcArea]
    ,[EcCaracteristicas]
    ,[PaisId]
	,[EstadoDeConservacionId])
VALUES
    ('Arrecife de Coral', 3,300, 'Ecosistema submarino con gran diversidad de vida marina.', 'CA', '1');
Go
-- Insert 4
INSERT INTO [dbo].[Ecosistemas]
    ([EcNombre]
	,[EcUbicacionGeograficaId]
    ,[EcArea]
    ,[EcCaracteristicas]
    ,[PaisId]
	,[EstadoDeConservacionId])
VALUES
    ('Desierto del Sahara',4, 5000, 'Ecosistema des�rtico ubicado en el norte de �frica.', 'GB', '3');
Go
-- Insert 5
INSERT INTO [dbo].[Ecosistemas]
    ([EcNombre]
	,[EcUbicacionGeograficaId]
    ,[EcArea]
    ,[EcCaracteristicas]
    ,[PaisId]
	,[EstadoDeConservacionId])
VALUES
    ('Bosque Lluvioso',5, 3000, 'Ecosistema con alta precipitaci�n y gran biodiversidad.', 'US', '3');
Go

-- Primer registro
INSERT INTO [dbo].[Amenazas] ([AmNombre], [AmGradoPeligrosidad])
VALUES ('Contaminaci�n del agua', 'Alto')
Go
-- Segundo registro
INSERT INTO [dbo].[Amenazas] ([AmNombre], [AmGradoPeligrosidad])
VALUES ('Contaminaci�n del aire', 'Alto'),
('Contaminaci�n del aire', 'Alto'),
('Sobrepesca', 'Medio'),
('Fragmentaci�n del h�bitat', 'Bajo'),
('Desarrollo urbano no sostenible', 'Alto')
Go


INSERT INTO [dbo].[EcosistemaEspecie]
           ([EsNombreCientifico]
           ,[EcNombre]
           ,[Habitan])
     VALUES
           ('Panthera leo','Arrecife de Coral',1),
		   ('Pongo abelii','Desierto del Sahara',0),
		   ('Gorilla beringei','Sabana Africana',1)

GO


INSERT INTO [dbo].[EcosistemaAmenaza]
           ([AmId]
           ,[EcNombre])
     VALUES
           (1,'Arrecife de Coral'),
		   (2,'Bosque Lluvioso'),
		   (3,'Sabana Africana'),
		   (4,'Bosque Lluvioso'),
		   (1,'Sabana Africana')
GO

INSERT INTO [dbo].[EspecieAmenaza]
           ([AmId]
           ,[EcNombre])
     VALUES
           (1
           ,'Equus ferus caballus')
GO