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
	CONSTRAINT fk_Clientes_Cuidades FOREIGN KEY (IdDistrito) REFERENCES Distritos (Id),
	CONSTRAINT fk_Clientes_Identidades FOREIGN KEY (IdTipoIdentificacion) REFERENCES TiposIdentificacion (Id),
	CONSTRAINT fk_Clientes_Sexo FOREIGN KEY (IdSexo) REFERENCES Sexo (Id)
);
