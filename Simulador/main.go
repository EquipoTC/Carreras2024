package main

import (
	"bytes"
	"encoding/json"
	"fmt"
	"log"
	"math/rand"
	"net/http"
	"strconv"
	"time"
)

// Data es la estructura del JSON que se enviará
type Data struct {
	Descripcion string `json:"descripcion"`
	Latitud     string `json:"latitud"`
	Longitud    string `json:"longitud"`
	Corriente   string `json:"corriente"`
	Tension     string `json:"tension"`
	Energia     string `json:"energia"`
	Potencia    string `json:"potencia"`
	Velocidad   string `json:"velocidad"`
}

var coordenadas = []struct {
	lat float64
	lon float64
}{
	{-34.697524531093144, -58.45979805139124},
	{-34.697401038228264, -58.45865006604178},
	{-34.697356933589, -58.45823164147515},
	{-34.69724226141692, -58.457620097877786},
	{-34.696801213057036, -58.45689053701353},
	{-34.696280773043725, -58.45656867196227},
	{-34.695381021571684, -58.45643992594177},
	{-34.695319273562944, -58.45642919710673},
	{-34.694701790941686, -58.45632190875631},
	{-34.69419898026126, -58.45627899341615},
	{-34.6942078015276, -58.45624680691102},
	{-34.69305220763215, -58.45612878972557},
	{-34.691834846993686, -58.45612878972557},
	{-34.69110265769698, -58.45701928303402},
	{-34.69097033363907, -58.45765228430148},
	{-34.691005620075195, -58.45815653954844},
	{-34.691481985490555, -58.45911140586715},
	{-34.69225827881178, -58.45978732247477},
	{-34.692919886690945, -58.46031303539182},
	{-34.69364323858683, -58.46089239248407},
	{-34.69432247790437, -58.46146102074128},
	{-34.69529908483, -58.46224370294673},
	{-34.69574491601585, -58.46258819073484},
	{-34.69684112602944, -58.46353872193863},
	{-34.69718204962329, -58.46384493330584},
	{-34.697701299782985, -58.46402355660339},
	{-34.69794781134449, -58.46384493330584},
	{-34.69792683166572, -58.46336009864109},
	{-34.69785864767297, -58.46244146453945},
	{-34.697736174541404, -58.461353784028695},
}

func main() {
	url := "https://carreras2024.onrender.com/disp/ingresar"
	ticker := time.NewTicker(1 * time.Second)
	defer ticker.Stop()

	for {
		for i := 0; i < len(coordenadas); i++ {
			<-ticker.C

			data := Data{
				Descripcion: "simulador",
				Latitud:     strconv.FormatFloat(coordenadas[i].lat, 'f', 6, 64),
				Longitud:    strconv.FormatFloat(coordenadas[i].lon, 'f', 6, 64),
				Corriente:   strconv.Itoa(getRandomNumber()),
				Tension:     strconv.Itoa(getRandomNumber()),
				Energia:     strconv.Itoa(getRandomNumber()),
				Potencia:    strconv.Itoa(getRandomNumber()),
				Velocidad:   strconv.Itoa(getRandomNumber()),
			}

			jsonData, err := json.Marshal(data)
			if err != nil {
				log.Printf("Error marshaling data: %v", err)
				continue
			}

			// Imprime el JSON en la consola antes de enviarlo
			fmt.Printf("Enviando JSON: %s\n", jsonData)

			req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonData))
			if err != nil {
				log.Printf("Error creating request: %v", err)
				continue
			}

			req.Header.Set("Content-Type", "application/json")

			client := &http.Client{}
			resp, err := client.Do(req)
			if err != nil {
				log.Printf("Error sending request: %v", err)
				continue
			}

			if resp.StatusCode != http.StatusOK {
				log.Printf("Unexpected status code: %v", resp.StatusCode)
			} else {
				log.Printf("Sent data: %v", data)
			}

			resp.Body.Close()
		}
	}
}

func getRandomNumber() int {
	// rand.Seed(time.Now().UnixNano())
	randomNumber := rand.Intn(100) + 1
	return randomNumber
}
