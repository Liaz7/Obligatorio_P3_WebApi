using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RestContextEcosistema : IRestContextEcosistema
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "";

        public RestContextEcosistema(string apiUrl)
        {
            this.apiUrl = apiUrl;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<EcosistemaDto> Add(EcosistemaDto entity)
        {
                // Método para agregar un nuevo elemento a la API.

                string entityJson = JsonSerializer.Serialize(entity);
                // Serializa el objeto entity a formato JSON.

                StringContent content = new StringContent(entityJson, System.Text.Encoding.UTF8, "application/json");
                // Crea un contenido de tipo StringContent con el JSON serializado.

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                // Realiza una solicitud POST a la URL de la API con el contenido JSON y espera la respuesta.

                string errorMessage = await response.Content.ReadAsStringAsync();
                // Lee el mensaje de error (si lo hay) de la respuesta HTTP.

                HttpErrorHandler.ThrowExceptionFromHttpStatusCodeAsync(response, errorMessage);
                // Llama a un manejador de errores personalizado para verificar el código de estado HTTP y lanzar excepciones si es necesario.

                string responseBody = await response.Content.ReadAsStringAsync();
                // Lee el cuerpo de la respuesta HTTP.

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                // Configura opciones para la deserialización JSON.

                var createdEntity = JsonSerializer.Deserialize<EcosistemaDto>(responseBody, options);
                // Realiza la deserialización del cuerpo de la respuesta en un objeto del tipo T.

                return createdEntity;
                // Devuelve el objeto creado y deserializado.
        }
    }
}
