CREATE DATABASE parcial2;
GO;
USE parcial2;
GO;

CREATE TABLE categoria(
	id_categoria INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE modo_pago(
	num_pago INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	otros_detalles VARCHAR(255) NOT NULL
);

CREATE TABLE cliente(
	id_cliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	apellido VARCHAR(100) NOT NULL,
	direccion VARCHAR(200) NOT NULL,
	fecha_nacimiento DATE NOT NULL,
	telefono VARCHAR(8) NOT NULL,
	email VARCHAR(50) NOT NULL
);

CREATE TABLE producto(
	id_producto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	precio DECIMAL(9,4) NOt NULL,
	stock INT NOT NULL,
	id_categoria INT NOT NULL,
	FOREIGN KEY(id_categoria) REFERENCES categoria(id_categoria)
);

CREATE TABLE factura(
	num_factura INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	id_cliente INT NOT NULL,
	fecha DATE NOT NULL,
	num_pago INT NOT NULL,
	FOREIGN KEY(id_cliente) REFERENCES cliente(id_cliente),
	FOREIGN KEY(num_pago) REFERENCES modo_pago(num_pago)
);

CREATE TABLE detalle(
	num_detalle INT NOT NULL,
	id_factura INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad DECIMAL(9,4) NOT NULL,
	precio DECIMAL(9,4) NOT NULL,
	PRIMARY KEY(num_detalle, id_factura),
	FOREIGN KEY(id_factura) REFERENCES factura(num_factura),
	FOREIGN KEY(id_producto) REFERENCES producto(id_producto)
);

