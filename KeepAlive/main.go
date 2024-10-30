package main

import (
	"fmt"
	"log"
	"net/http"
	"time"
)

func main() {
	url := "https://carreras2024.onrender.com/"
	ticker := time.NewTicker(5 * time.Minute)
	defer ticker.Stop()

	for {
		<-ticker.C

		req, err := http.NewRequest("GET", url, nil)
		if err != nil {
			log.Printf("Error creating request: %v", err)
			continue
		}

		client := &http.Client{}
		resp, err := client.Do(req)
		if err != nil {
			log.Printf("Error sending request: %v", err)
			continue
		}

		if resp.StatusCode == http.StatusOK {
			fmt.Println("Servicio activo, solicitud GET exitosa.")
		} else {
			log.Printf("Unexpected status code: %v", resp.StatusCode)
		}

		resp.Body.Close()
	}
}