package app

import (
	"fmt"
	"html/template"
	"net/http"

	"github.com/gorilla/mux"
)

var Plantillas *template.Template

// METODOS / Handlers
func Inicio(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Generic API")
}

func Index(w http.ResponseWriter, r *http.Request) {
	Plantillas.ExecuteTemplate(w, "index", nil)
}

func ObtenerSucesos(w http.ResponseWriter, r *http.Request) {
	// Ejecutar la consulta SQL
	query := "SELECT * FROM suceso"
	ObtenerConsultaJSON(w, r, query)
}

func ObtenerLocalidades(w http.ResponseWriter, r *http.Request) {
	// Ejecutar la consulta SQL
	query := "SELECT * FROM localidad"
	ObtenerConsultaJSON(w, r, query)
}

func ObtenerSuceso(w http.ResponseWriter, r *http.Request) {
	//obtener parametros
	vars := mux.Vars(r)
	suceID := vars["suceID"]

	// Ejecutar la consulta SQL
	if suceID != "" {
		query := "SELECT * FROM suceso where suce_id = " + suceID
		ObtenerConsultaJSON(w, r, query)
	}
}

func InsertarSala(w http.ResponseWriter, r *http.Request) {
	// Lee el cuerpo de la solicitud HTTP en un []byte.
	body := GetBody(r)

	if body != nil {
		descripcion := ObtenerParametroPOST(body, "descripcion")
		areaID := ObtenerParametroPOST(body, "areaID")

		if descripcion != "" && areaID != "" {
			query := "exec sp_insertarSala " + Comillas(descripcion) + " , " + areaID
			ObtenerConsultaJSON(w, r, query)
		} else {
			http.Error(w, "Usuario o Password invalidos!", http.StatusBadRequest)
		}

	} else {
		http.Error(w, "No se puede leer el body", http.StatusBadRequest)
	}
}

func ObtenerDispositivos(w http.ResponseWriter, r *http.Request) {
	query := "CALL sp_read_dispositivos()"
	ObtenerConsultaJSON(w, r, query)
}

func ObtenerInfoDispositivos(w http.ResponseWriter, r *http.Request) {
	query := "CALL sp_read_info_dispositivos()"
	ObtenerConsultaJSON(w, r, query)
}

func ObtenerInfoDispositivo(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	dispID := vars["dispID"]
	query := "CALL sp_read_info_dispositivo(" + dispID + ")"
	ObtenerConsultaJSON(w, r, query)
}

func InsertarDispositivo(w http.ResponseWriter, r *http.Request) {

	if body := GetBody(r); body != nil {
		descripcion := ObtenerParametroPOST(body, "descripcion")
		latitud := ObtenerParametroPOST(body, "latitud")
		longitud := ObtenerParametroPOST(body, "longitud")
		corriete := ObtenerParametroPOST(body, "corriente")
		tension := ObtenerParametroPOST(body, "tension")
		energia := ObtenerParametroPOST(body, "energia")
		potencia := ObtenerParametroPOST(body, "potencia")
		velocidad := ObtenerParametroPOST(body, "velocidad")

		query := "CALL sp_get_dispositivo(" + Comillas(descripcion) + ", " + latitud + ", " + longitud + ", " + corriete + ", " + tension + ", " + energia + ", " + potencia + ", " + velocidad + ")"
		ObtenerConsultaJSON(w, r, query)
	} else {
		http.Error(w, "No se puede leer el body", http.StatusBadRequest)
	}
}

func InsertarVuelta(w http.ResponseWriter, r *http.Request) {

	if body := GetBody(r); body != nil {
		numero := ObtenerParametroPOST(body, "numero")
		tiempo := ObtenerParametroPOST(body, "tiempo")
		tiempoCronometro := ObtenerParametroPOST(body, "tiempoCronometro")

		query := "CALL sp_add_vuelta(" + numero + ", " + Comillas(tiempo) + ", " + Comillas(tiempoCronometro) + ")"
		ObtenerConsultaJSON(w, r, query)
	} else {
		http.Error(w, "No se puede leer el body", http.StatusBadRequest)
	}
}

func ObtenerVueltaDispositivo(w http.ResponseWriter, r *http.Request){
	vars := mux.Vars(r)
	dispID := vars["dispID"]
	query := "CALL sp_read_vueltas_dispositivo(" + dispID + ")"
	ObtenerConsultaJSON(w, r, query)
}

