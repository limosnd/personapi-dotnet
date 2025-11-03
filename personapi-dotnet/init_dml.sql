-- =========================================
-- DML: Inserción de datos iniciales
-- =========================================

-- Personas
INSERT INTO persona (cc, nombre, apellido, genero, edad)
VALUES 
(1001, 'Carlos', 'Pérez', 'M', 30),
(1002, 'Ana', 'Gómez', 'F', 25),
(1003, 'Luis', 'Martínez', 'M', 40);

-- Profesiones
INSERT INTO profesion (id, nom, des)
VALUES
(1, 'Ingeniero de Sistemas', 'Diseño y desarrollo de sistemas informáticos'),
(2, 'Médico', 'Profesional de la salud'),
(3, 'Arquitecto', 'Diseña y supervisa proyectos de construcción');

-- Estudios
INSERT INTO estudios (id_prof, cc_per, fecha, univer)
VALUES
(1, 1001, '2018-06-15', 'Universidad Javeriana'),
(2, 1002, '2019-11-22', 'Universidad Nacional'),
(3, 1003, '2015-05-10', 'Universidad de los Andes');

-- Teléfonos
INSERT INTO telefono (num, oper, duenio)
VALUES
('3001112233', 'Claro', 1001),
('3102223344', 'Tigo', 1002),
('3203334455', 'Movistar', 1003);