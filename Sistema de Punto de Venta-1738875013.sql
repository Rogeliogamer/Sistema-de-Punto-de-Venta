CREATE TABLE IF NOT EXISTS `Usuarios` (
	`id_usuario` int AUTO_INCREMENT NOT NULL UNIQUE,
	`nombre_usuario` varchar(255) NOT NULL UNIQUE,
	`contraseña` varchar(255) NOT NULL,
	`rol` int NOT NULL,
	PRIMARY KEY (`id_usuario`)
);

CREATE TABLE IF NOT EXISTS `Clientes` (
	`id_cliente` int AUTO_INCREMENT NOT NULL UNIQUE,
	`nombre` varchar(100) NOT NULL,
	`apellido_paterno` varchar(100) NOT NULL,
	`apellido_materno` varchar(100) NOT NULL,
	`estado` varchar(255) NOT NULL,
	`colonia` varchar(255) NOT NULL,
	`calle` int NOT NULL,
	`numero_exterior` int NOT NULL,
	`numero_interior` int NOT NULL,
	`codigo_postal` int NOT NULL,
	`telefono` varchar(15) NOT NULL,
	`fecha_registro` datetime NOT NULL,
	PRIMARY KEY (`id_cliente`)
);

CREATE TABLE IF NOT EXISTS `Productos` (
	`id_producto` int AUTO_INCREMENT NOT NULL UNIQUE,
	`nombre_producto` varchar(50) NOT NULL,
	`descripcion` varchar(255) NOT NULL,
	`cantidad` int NOT NULL DEFAULT '0',
	`precio_compra` decimal(10,2) NOT NULL,
	`precio_venta` decimal(10,2) NOT NULL,
	PRIMARY KEY (`id_producto`)
);

CREATE TABLE IF NOT EXISTS `Ventas` (
	`id_venta` int AUTO_INCREMENT NOT NULL UNIQUE,
	`id_cliente` int NOT NULL,
	`tipo_venta` binary(1) NOT NULL,
	`fecha_venta` datetime NOT NULL,
	`monto_total` decimal(10,2) NOT NULL,
	`abono_inicial` decimal(10,2),
	`monto_pendiente` decimal(10,2),
	PRIMARY KEY (`id_venta`)
);

CREATE TABLE IF NOT EXISTS `Detalle_Ventas` (
	`id_detalle` int AUTO_INCREMENT NOT NULL UNIQUE,
	`id_venta` int NOT NULL,
	`id_producto` int NOT NULL,
	`cantidad` int NOT NULL,
	`precio_unitario` decimal(10,2) NOT NULL,
	PRIMARY KEY (`id_detalle`)
);

CREATE TABLE IF NOT EXISTS `Pagos` (
	`id_pago` int NOT NULL,
	`id_venta` int NOT NULL,
	`monto` decimal(10,2) NOT NULL,
	`fecha_pago` datetime NOT NULL,
	PRIMARY KEY (`id_pago`)
);




ALTER TABLE `Ventas` ADD CONSTRAINT `Ventas_fk1` FOREIGN KEY (`id_cliente`) REFERENCES `Clientes`(`id_cliente`);
ALTER TABLE `Detalle_Ventas` ADD CONSTRAINT `Detalle_Ventas_fk1` FOREIGN KEY (`id_venta`) REFERENCES `Ventas`(`id_venta`);

ALTER TABLE `Detalle_Ventas` ADD CONSTRAINT `Detalle_Ventas_fk2` FOREIGN KEY (`id_producto`) REFERENCES `Productos`(`id_producto`);
ALTER TABLE `Pagos` ADD CONSTRAINT `Pagos_fk1` FOREIGN KEY (`id_venta`) REFERENCES `Ventas`(`id_venta`);