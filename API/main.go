package main

import (
	"carrerasAPI/app"
	"fmt"
	"html/template"
	"net/http"
	"strconv"

	Config "carrerasAPI/app/config"

	"github.com/gorilla/mux"
	"github.com/sirupsen/logrus"
)

func main() {
	logrus.Info("Starting application...")

	app.Plantillas = template.Must(template.ParseGlob("templates/*"))
	// Cargar configuracion
	err := Config.LoadConfig()
	if err != nil {
		logrus.Error("main.LoadConfig.error: " + err.Error())
		return
	}
	router := mux.NewRouter()

	fmt.Println("Servidor corriendo...")

	// Definicion de rutas
	router.HandleFunc("/info", app.ObtenerInfoDispositivo)
	router.HandleFunc("/disp", app.ObtenerDispositivos)
	router.HandleFunc("/disp/position/{dispID}", app.ObterDispositivoPosicion)
	/*
		router.HandleFunc("/", app.Inicio)                                    // Muestra un mensaje en pantalla
		router.HandleFunc("/index", app.Index)                                // Muestra una pagina web utilizando templates
		router.HandleFunc("/sucesos", app.ObtenerSucesos)                     // Obtiene el listado de sucesos en JSON
		router.HandleFunc("/suceso/{suceID}", app.ObtenerSuceso)              // Obtiene los datos de un suceso en JSON recibiendo por parametro GET el Id de suceso
		router.HandleFunc("/insertar_sala", app.InsertarSala).Methods("POST") // Inserta una sala, enviandole los datos a insertar atravez de un metodo POST

		router.HandleFunc("/localidades", app.ObtenerLocalidades)
	*/
	// Inicio del servicio en el puerto configurado
	fmt.Printf("http://localhost:" + strconv.Itoa(Config.AppConfig.Port))
	http.ListenAndServe(":"+strconv.Itoa(Config.AppConfig.Port), router)
}
