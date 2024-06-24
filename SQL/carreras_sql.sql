DROP DATABASE IF EXISTS Carreras;
CREATE DATABASE Carreras;

USE Carreras;

CREATE TABLE dispositivo(
	disp_id INT UNSIGNED AUTO_INCREMENT,
	disp_descripcion TEXT NOT NULL,
	disp_latitud_actual FLOAT,
	disp_longitud_actual FLOAT,
	disp_fecha_ingreso TIMESTAMP DEFAULT (NOW()),
	disp_fecha_modificacion TIMESTAMP DEFAULT (NULL),
	disp_habilitado BOOLEAN NOT NULL DEFAULT(TRUE),
	PRIMARY KEY(disp_id)
);

CREATE TABLE info_dispositivo(
	info_id INT UNSIGNED AUTO_INCREMENT,
	info_disp_id INT UNSIGNED NOT NULL,
	info_latitud FLOAT,
	info_longitud FLOAT,
	info_fecha_ingreso TIMESTAMP DEFAULT (NOW()),
	PRIMARY KEY(info_id)
);

DELIMITER //

# DISPOSITIVOS

CREATE PROCEDURE sp_add_dispositivo(IN a_disp_descripcion TEXT, a_disp_latitud FLOAT, a_disp_longitud FLOAT, a_disp_habilitado BOOLEAN)
BEGIN
		INSERT INTO dispositivo(disp_descripcion, disp_latitud_actual, disp_longitud_actual, disp_habilitado) 
		VALUES(
			a_disp_descripcion,
			a_disp_latitud,
			a_disp_longitud,
			a_disp_habilitado
		);
END //

CREATE PROCEDURE sp_read_dispositivos()
BEGIN
	SELECT * FROM Dispositivo;
END //

CREATE PROCEDURE sp_update_dispositivo_position(IN a_disp_id INT UNSIGNED, a_disp_latitud FLOAT, a_disp_longitud FLOAT)
BEGIN
	UPDATE dispositivo 
	SET 
		disp_latitud_actual = a_disp_latitud, 
		disp_longitud_actual = a_disp_longitud 
	WHERE disp_id = a_disp_id;
END //

CREATE PROCEDURE sp_read_dispositivo_position(IN a_disp_id INT UNSIGNED)
BEGIN
	SELECT disp_latitud_actual, disp_longitud_actual FROM Dispositivo WHERE disp_id = a_disp_id;
END //

# INFORMACION DISPOSITIVOS

CREATE PROCEDURE sp_add_info_dispositivo(IN a_info_disp_id INT UNSIGNED, a_info_latitud FLOAT, a_info_longitud FLOAT)
BEGIN
	INSERT INTO info_dispositivo(info_disp_id, info_latitud, info_longitud) 
	VALUES(
		a_info_disp_id,
		a_info_latitud,
		a_info_longitud
	);
	CALL sp_remove_info_disp(a_info_disp_id);
	CALL sp_update_dispositivo_position(a_info_disp_id, a_info_latitud, a_info_longitud);
END //

CREATE PROCEDURE sp_read_info_dispositivos()
BEGIN
	SELECT * FROM info_dispositivo;
END //

CREATE PROCEDURE sp_read_info_dispositivo(IN a_info_disp_id INT UNSIGNED)
BEGIN
	SELECT * FROM info_dispositivo WHERE info_disp_id = a_info_disp_id;
END //

CREATE PROCEDURE sp_remove_info_disp(IN a_info_disp_id INT UNSIGNED)
BEGIN
	CREATE TEMPORARY TABLE ultima_informacion AS (
		SELECT info_id FROM info_dispositivo 
		WHERE info_disp_id = a_info_disp_id
		ORDER BY info_id DESC
		LIMIT 1000 # limite de informacion por dispositivo
	);
	DELETE FROM info_dispositivo
	WHERE info_id NOT IN (SELECT * FROM ultima_informacion) && info_disp_id = a_info_disp_id;
	DROP TABLE IF EXISTS ultima_informacion;
END //

DELIMITER ;

CALL sp_add_dispositivo("Gino", -30.768056, 60.676532, TRUE);
CALL sp_add_dispositivo("Stefano", 30.160236, -60.61532, TRUE);
CALL sp_add_dispositivo("Jeremias", 10.712316, 100.676532, TRUE);

CALL sp_add_info_dispositivo(1, 2, 2);
CALL sp_add_info_dispositivo(1, 500, 26.54);
CALL sp_add_info_dispositivo(2, 300, 700.53);
CALL sp_add_info_dispositivo(2, 700, 309.2);
CALL sp_add_info_dispositivo(2, 1000, 120.3);
CALL sp_add_info_dispositivo(1, 200, 3.102);
CALL sp_add_info_dispositivo(2, 1200, 120.3);
CALL sp_add_info_dispositivo(3, 800, 1230);
CALL sp_add_info_dispositivo(3, 1200, 1230);

CALL sp_read_info_dispositivos();