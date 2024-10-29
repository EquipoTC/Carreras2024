DROP DATABASE IF EXISTS Carreras;
CREATE DATABASE Carreras;

USE Carreras;
SET SQL_SAFE_UPDATES = 0;

CREATE TABLE dispositivo(
	disp_id INT UNSIGNED AUTO_INCREMENT,
	disp_descripcion TEXT NOT NULL,
	disp_latitud_actual FLOAT,
	disp_longitud_actual FLOAT,
	disp_fecha_ingreso TIMESTAMP DEFAULT (NOW()),
	disp_fecha_modificacion TIMESTAMP DEFAULT (NOW()),
	disp_habilitado BOOLEAN NOT NULL DEFAULT(TRUE),
	PRIMARY KEY(disp_id)
);

CREATE TABLE info_dispositivo(
	info_id INT UNSIGNED AUTO_INCREMENT,
	info_disp_id INT UNSIGNED NOT NULL,
	info_latitud FLOAT,
	info_longitud FLOAT,
	info_corriente FLOAT,
	info_tension FLOAT,
	info_energia FLOAT,
	info_potencia FLOAT,
	info_velocidad FLOAT,
	info_fecha_ingreso TIMESTAMP DEFAULT (NOW()),
	PRIMARY KEY(info_id)
);

CREATE TABLE vuelta(
	vuelta_id INT UNSIGNED AUTO_INCREMENT,
	vuelta_numero INT UNSIGNED,
	vuelta_dispId INT UNSIGNED NOT NULL,
	vuelta_tiempo TIME(3) NOT NULL,
	vuelta_tiempoCronometro TIME(3) NOT NULL,
	PRIMARY KEY(vuelta_id)
);

DELIMITER //

# DISPOSITIVOS

CREATE PROCEDURE sp_get_dispositivo(
	IN 
		a_disp_descripcion TEXT, a_disp_latitud FLOAT, a_disp_longitud FLOAT,
		a_info_corriente FLOAT, a_info_tension FLOAT, a_info_energia FLOAT, 
		a_info_potencia FLOAT, a_info_velocidad FLOAT
	)
BEGIN
	SELECT @a_id := disp_id 
		FROM dispositivo 
		WHERE disp_descripcion = a_disp_descripcion;
	
	IF (@a_id IS NULL) THEN
		CALL sp_add_dispositivo(
			a_disp_descripcion, 
			a_disp_latitud, 
			a_disp_longitud, 
			TRUE,
			a_info_corriente,
			a_info_tension,
			a_info_energia,
			a_info_potencia,
			a_info_velocidad
		);
	ELSE
		CALL sp_add_info_dispositivo(
			@a_id, 
			a_disp_latitud, 
			a_disp_longitud,
			a_info_corriente,
			a_info_tension,
			a_info_energia,
			a_info_potencia,
			a_info_velocidad
		);
	END IF;
END //

CREATE PROCEDURE sp_add_dispositivo(
	IN 
		a_disp_descripcion TEXT, a_disp_latitud FLOAT, a_disp_longitud FLOAT, 
		a_disp_habilitado BOOLEAN, a_info_corriente FLOAT, a_info_tension FLOAT, 
		a_info_energia FLOAT, a_info_potencia FLOAT, a_info_velocidad FLOAT
)
BEGIN
		INSERT INTO dispositivo(
			disp_descripcion, disp_latitud_actual, disp_longitud_actual, disp_habilitado
		) 
		VALUES(
			a_disp_descripcion,
			a_disp_latitud,
			a_disp_longitud,
			a_disp_habilitado
		);
		CALL sp_add_info_dispositivo(
			LAST_INSERT_ID(), a_disp_latitud, a_disp_longitud, 
			a_info_corriente, a_info_tension, a_info_energia, 
			a_info_potencia, a_info_velocidad
		);
END //

CREATE PROCEDURE sp_read_dispositivos()
BEGIN
	SELECT * FROM dispositivo WHERE disp_habilitado = 1;
END //

CREATE PROCEDURE sp_update_dispositivo_position(
	IN 
	a_disp_id INT UNSIGNED, a_disp_latitud FLOAT, a_disp_longitud FLOAT
)
BEGIN
	UPDATE dispositivo 
	SET 
		disp_latitud_actual = a_disp_latitud, 
		disp_longitud_actual = a_disp_longitud 
	WHERE disp_id = a_disp_id;
END //

# INFORMACION DISPOSITIVOS

CREATE PROCEDURE sp_add_info_dispositivo(
	IN 
		a_info_disp_id INT UNSIGNED, a_info_latitud FLOAT, a_info_longitud FLOAT, 
		a_info_corriente FLOAT, a_info_tension FLOAT, a_info_energia FLOAT, 
		a_info_potencia FLOAT, a_info_velocidad FLOAT
	)
BEGIN
	INSERT INTO info_dispositivo(
		info_disp_id, info_latitud, info_longitud, info_corriente, info_tension, 
		info_energia, info_potencia, info_velocidad
	) 
	VALUES(
		a_info_disp_id,
		a_info_latitud,
		a_info_longitud,
		a_info_corriente,
		a_info_tension,
		a_info_energia,
		a_info_potencia,
		a_info_velocidad
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
	CREATE TABLE ultima_informacion(info_id INT PRIMARY KEY) AS(
		SELECT info_id FROM info_dispositivo 
		WHERE info_disp_id = a_info_disp_id
		ORDER BY info_id DESC
		LIMIT 1000 # limite de informacion por dispositivo
	);
	DELETE FROM info_dispositivo
	WHERE info_id NOT IN
		(SELECT * FROM ultima_informacion) && info_disp_id = a_info_disp_id;
	DROP TABLE IF EXISTS ultima_informacion;
END //

# VUELTAS

CREATE PROCEDURE sp_add_vuelta(
	IN 
		a_vuelta_numero INT UNSIGNED, a_vuelta_tiempo TIME(3), a_vuelta_tiempoCronometro TIME(3)
	)
BEGIN
	INSERT INTO vuelta(
		vuelta_numero, vuelta_tiempo, vuelta_tiempoCronometro
	) 
	VALUES(
		a_vuelta_numero,
		a_vuelta_tiempo,
		a_vuelta_tiempoCronometro
	);
END //

CREATE PROCEDURE sp_read_vueltas_dispositivo(IN disp_id INT UNSIGNED)
BEGIN
	SELECT * FROM vuelta WHERE disp_id = vuelta_dispId;
END //

DELIMITER ;

CALL sp_add_dispositivo('Auto 1', -34.697542172654494, -58.460152137859886, TRUE, 10, 20, 30, 50, 5);
CALL sp_add_dispositivo('Stefano', 30.160236, -60.61532, TRUE, 30, 20, 30, 10, 8);
CALL sp_add_dispositivo('Jeremias', 10.712316, 100.676532, TRUE, 0, 2, 10, 2, 20);

CALL sp_add_info_dispositivo(1, -34.697520342012, -58.459875233068644, 0, 1, 25, 30, 20);
CALL sp_add_info_dispositivo(1, -34.697461087381946, -58.45931763026985, 0, 1, 25, 30, 20);

DELETE FROM vuelta WHERE TRUE = TRUE;

