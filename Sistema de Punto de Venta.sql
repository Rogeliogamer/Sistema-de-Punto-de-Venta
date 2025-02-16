CREATE TABLE IF NOT EXISTS `Usuarios` (
	`id_usuario` int AUTO_INCREMENT NOT NULL UNIQUE,
	`nombre_usuario` varchar(255) NOT NULL UNIQUE,
	`contrasena` varchar(255) NOT NULL,
	`id_rol` int NOT NULL,
	PRIMARY KEY (`id_usuario`)
);

CREATE TABLE IF NOT EXISTS `Clientes` (
	`id_cliente` int AUTO_INCREMENT NOT NULL UNIQUE,
	`nombre` varchar(100) NOT NULL,
	`apellido_paterno` varchar(100) NOT NULL,
	`apellido_materno` varchar(100) NOT NULL,
	`estado` varchar(255) NOT NULL,
	`colonia` varchar(255) NOT NULL,
	`calle` varchar(255) NOT NULL,
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
	`id_tipo_venta` int NOT NULL,
	`fecha_venta` datetime NOT NULL,
	`monto_total` decimal(10,2) NOT NULL,
	PRIMARY KEY (`id_venta`)
);

CREATE TABLE IF NOT EXISTS `ticket` (
	`id_ticket` int AUTO_INCREMENT NOT NULL UNIQUE,
	`id_venta` int NOT NULL,
	`fecha_emision` datetime NOT NULL,
	`monto_total` decimal(10,2) NOT NULL,
	`estado_ticket` varchar(50) NOT NULL DEFAULT 'Activo',
	PRIMARY KEY (`id_ticket`)
);

CREATE TABLE IF NOT EXISTS `Pagos` (
	`id_pago` int AUTO_INCREMENT NOT NULL UNIQUE,
	`id_cliente` int NOT NULL,
	`id_estado_pago` int NOT NULL,
	`fecha_pago` datetime NOT NULL,
	`monto_total` decimal(10,2) NOT NULL,
	`abono_inicial` decimal(10,2) NOT NULL,
	`monto_pendiente` decimal(10,2) NOT NULL,
	PRIMARY KEY (`id_pago`)
);

CREATE TABLE IF NOT EXISTS `roles` (
	`id_rol` int AUTO_INCREMENT NOT NULL UNIQUE,
	`nombre_rol` varchar(50) NOT NULL,
	PRIMARY KEY (`id_rol`)
);

CREATE TABLE IF NOT EXISTS `detalle_tickets` (
	`id_detalle_ticket` int AUTO_INCREMENT NOT NULL UNIQUE,
	`id_ticket` int NOT NULL,
	`id_producto` int NOT NULL,
	`cantidad` int NOT NULL,
	`precio_unitario` decimal(10,2) NOT NULL,
	`sub_total` decimal(10,2) NOT NULL,
	PRIMARY KEY (`id_detalle_ticket`)
);

ALTER TABLE `Usuarios` ADD CONSTRAINT `Usuarios_fk3` FOREIGN KEY (`id_rol`) REFERENCES `roles`(`id_rol`);


ALTER TABLE `Ventas` ADD CONSTRAINT `Ventas_fk1` FOREIGN KEY (`id_cliente`) REFERENCES `Clientes`(`id_cliente`);

ALTER TABLE `Ventas` ADD CONSTRAINT `Ventas_fk2` FOREIGN KEY (`id_tipo_venta`) REFERENCES `Tipos_Venta`(`id_tipo_venta`);
ALTER TABLE `ticket` ADD CONSTRAINT `ticket_fk1` FOREIGN KEY (`id_venta`) REFERENCES `Ventas`(`id_venta`);
ALTER TABLE `Pagos` ADD CONSTRAINT `Pagos_fk1` FOREIGN KEY (`id_cliente`) REFERENCES `Clientes`(`id_cliente`);

ALTER TABLE `Pagos` ADD CONSTRAINT `Pagos_fk2` FOREIGN KEY (`id_estado_pago`) REFERENCES `estados_pago`(`id_estado_pago`);

ALTER TABLE `Pagos` ADD CONSTRAINT `Pagos_fk4` FOREIGN KEY (`monto_total`) REFERENCES `Ventas`(`monto_total`);

ALTER TABLE `detalle_tickets` ADD CONSTRAINT `detalle_tickets_fk1` FOREIGN KEY (`id_ticket`) REFERENCES `ticket`(`id_ticket`);

ALTER TABLE `detalle_tickets` ADD CONSTRAINT `detalle_tickets_fk2` FOREIGN KEY (`id_producto`) REFERENCES `Productos`(`id_producto`);