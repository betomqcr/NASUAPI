CREATE DATABASE NasuN;
GO
USE  NasuN;
GO
CREATE TABLE TiposIdentificacion
(
	id int not null Primary Key identity(1,1),
	Descripcion nvarchar(100) not null,
	CodigoFE int not null,
	Activo bit not null
);
GO
CREATE TABLE Sexo
(
	id int not null Primary Key identity(1,1),
	Descripcion  nvarchar(100) not null,
	Mascota bit not null,
	Activo bit not null
);
GO
CREATE TABLE Paises
(
	id int not null Primary Key identity(1,1),
	Descripcion  nvarchar(100) not null,
	Activo bit not null	
);
GO
CREATE TABLE Provincias
(
	id int not null Primary Key identity(1,1),
	Descripcion  nvarchar(100) not null,
	Activo bit not null,
	IdPais int not null,
	CONSTRAINT fk_Pais_Provincia FOREIGN KEY (IdPais) REFERENCES Paises (Id)
);
GO

CREATE TABLE Cuidades
(
	id int not null Primary Key identity(1,1),
	Descripcion  nvarchar(100) not null,
	Activo bit not null,
	IdProvincia int not null,
	CONSTRAINT fk_Cuidades_Provincias FOREIGN KEY (IdProvincia) REFERENCES Provincias (Id)
);
GO
CREATE TABLE Distritos
(
	id int not null Primary Key identity(1,1),
	Descripcion  nvarchar(100) not null,
	Activo bit not null,
	IdCuidad int not null,
	CONSTRAINT fk_Distritos_Cuidades FOREIGN KEY (IdCuidad) REFERENCES Cuidades (Id)
);
GO
CREATE TABLE Clientes
(
	id int not null Primary Key identity(1,1),
	Nombre nvarchar(200) not null,
	Apellido1 nvarchar(200) not null,
	Apellido2 nvarchar(200) not null,
	Telefono nvarchar(40) not null,
	FechaNac datetime not null,
	IdTipoIdentificacion int not null,
	NumDocumento nvarchar(50) not null,
	Email nvarchar(200) not null,
	IdSexo int not null,
	Activo bit not null,
	Enviado bit not null,
	IdDistrito int not null,
	FechaAlta datetime not null,
	FechaModficacion datetime null,
	UsarMismosDatosFactura bit null,
	CONSTRAINT fk_Clientes_Cuidades FOREIGN KEY (IdDistrito) REFERENCES Distritos (Id),
	CONSTRAINT fk_Clientes_Identidades FOREIGN KEY (IdTipoIdentificacion) REFERENCES TiposIdentificacion (Id),
	CONSTRAINT fk_Clientes_Sexo FOREIGN KEY (IdSexo) REFERENCES Sexo (Id)
);

GO
CREATE TABLE DatosFacturacion
(
	id int not null Primary Key identity(1,1),
	Nombre nvarchar(200) not null,
	Documento nvarchar(50) not null,
	Email nvarchar(200)not null,
	Telefono nvarchar(30) not null,
	IdCliente int not null,
	CONSTRAINT fk_Clientes_DatoFactura FOREIGN KEY (IdCliente) REFERENCES Clientes (Id)
);

GO
CREATE TABLE Especies
(
	id int not null Primary Key identity(1,1),
	Descripcion nvarchar(100) not null,
	Activo bit not null
);
GO
CREATE TABLE Razas
(
	id int not null Primary Key identity(1,1),
	Descripcion nvarchar(100) not null,
	Activo bit not null,
	IdEspecie int not null,
	CONSTRAINT fk_Razas_Especie FOREIGN KEY (IdEspecie) REFERENCES Especies (Id),
);
GO
CREATE TABLE CategoriasMascotas
(
	id int not null Primary Key identity(1,1),
	Descripcion nvarchar(100) not null,
	Activo bit not null,
	RangoInicialDias int not null,
	RangoFinalDias int not null
);
GO
CREATE TABLE Mascotas
(
 id int not null Primary Key identity(1,1),
 idCliente int not null,
 Nombre nvarchar(50) not null,
 FechaNac datetime not null,
 ImagenB varbinary(max) null,
 ImagenD nvarchar(max) null,
 FechaAlta datetime not null,
 FechaModificacion datetime null,
 IdSexo int not null,
 IdRaza int not null,
 IdCategoriaMascota int not null,
 CONSTRAINT fk_Mascotas_Clientes FOREIGN KEY (idCliente) REFERENCES Clientes (Id),
 CONSTRAINT fk_Mascota_Sexo FOREIGN KEY (IdSexo) REFERENCES Sexo (Id),
 CONSTRAINT fk_Razas_Mascota FOREIGN KEY (IdRaza) REFERENCES Razas (Id),
 CONSTRAINT fk_CategoriasM_Mascota FOREIGN KEY (IdCategoriaMascota) REFERENCES CategoriasMascotas (Id),
);
GO
CREATE TABLE CategoriaPesos
(
	id int not null Primary Key identity(1,1),
	Descripcion nvarchar(200) not null,
	IdEspecie int not null,
	PesoEspecieOrder smallint null,
	CONSTRAINT fk_Especie_Peso FOREIGN KEY (IdEspecie) REFERENCES Especies (Id)
);
GO
CREATE TABLE Pesos
(
	id int not null Primary Key identity(1,1),
	IdMascota int not null,
	Fecha datetime not null,
	IdCategoriaPeso int not null,
	CONSTRAINT fk_Mascota_Peso FOREIGN KEY (IdMascota) REFERENCES Mascotas (Id),
	CONSTRAINT fk_CategoriaPeso_Peso FOREIGN KEY (IdCategoriaPeso) REFERENCES CategoriaPesos (Id)
);
GO
CREATE TABLE Veterinarias
(
	id int not null Primary Key identity(1,1),
	Nombre nvarchar(200) not null,
	NombreFiscal nvarchar(200) not null,
	IdTipoIdentificacion int not null,
	Documento nvarchar(20) not null,
	NombreContacto nvarchar(200) not null,
	Puesto nvarchar(200) not null,
	Medico nvarchar(200) not null,
	NumColegiado nvarchar(200)  null,
	CorreoContacto nvarchar(200)  null,
	Maps nvarchar(MAX)  null,
	Estado bit null,
	Activo bit null,
	Eliminado bit null,
	Direccion nvarchar(max) not null,
	LogoB varbinary(max) null,
	LogoD nvarchar(max)  null,
	CONSTRAINT fk_TiposIdentificacion_Veterinaria FOREIGN KEY (IdTipoIdentificacion) REFERENCES TiposIdentificacion (Id)
);
