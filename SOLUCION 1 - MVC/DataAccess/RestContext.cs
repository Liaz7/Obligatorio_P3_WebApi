﻿using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RestContext<T> : IRestContext<T>
    {
        // Clase genérica RestContext que implementa la interfaz IRestContext<T>.

        private readonly HttpClient httpClient;
        private readonly string apiUrl = "";

        // Campo privado para almacenar una instancia de HttpClient y la URL base de la API.

        public RestContext(string apiUrl)
        {
            // Constructor de la clase que acepta la URL base de la API como argumento.

            this.apiUrl = apiUrl;
            // Inicializa la URL base de la API con el valor proporcionado.

            httpClient = new HttpClient();
            // Inicializa una instancia de HttpClient, que se utilizará para realizar solicitudes HTTP a la API.

           

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Configura los encabezados HTTP para indicar que se espera una respuesta en formato JSON.
        }

        public async Task<IEnumerable<T>> GetAll(string filters)
        {
            // Método para obtener todos los elementos de la API con opciones de filtros.

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl + filters);
            // Realiza una solicitud GET a la URL de la API con filtros opcionales y espera la respuesta.

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
            // Configura opciones para la deserialización JSON, como el formato de nombres en camelCase y la escritura en formato JSON con sangría para una mejor legibilidad.

            var entities = JsonSerializer.Deserialize<List<T>>(responseBody, options);
            // Realiza la deserialización del cuerpo de la respuesta en una lista de objetos del tipo T.

            return entities;
            // Devuelve la lista de entidades deserializadas.
        }

        public async Task<IEnumerable<T>> GetAllWoFilters()
        {
            // Método para obtener todos los elementos de la API con opciones de filtros.

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            // Realiza una solicitud GET a la URL de la API con filtros opcionales y espera la respuesta.

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
            // Configura opciones para la deserialización JSON, como el formato de nombres en camelCase y la escritura en formato JSON con sangría para una mejor legibilidad.

            var entities = JsonSerializer.Deserialize<List<T>>(responseBody, options);
            // Realiza la deserialización del cuerpo de la respuesta en una lista de objetos del tipo T.

            return entities;
            // Devuelve la lista de entidades deserializadas.
        }

        public async Task<T> GetById(int id)
        {
            // Método para obtener un elemento de la API por su ID.

            HttpResponseMessage response = await httpClient.GetAsync($"{apiUrl}/{id}");
            // Realiza una solicitud GET a la URL de la API con el ID especificado y espera la respuesta.

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

            var entity = JsonSerializer.Deserialize<T>(responseBody, options);
            // Realiza la deserialización del cuerpo de la respuesta en un objeto del tipo T.

            return entity;
            // Devuelve el objeto deserializado.
        }

        public async Task<T> GetByName(string name)
        {
            // Método para obtener un elemento de la API por su ID.

            HttpResponseMessage response = await httpClient.GetAsync($"{apiUrl}/{name}");
            // Realiza una solicitud GET a la URL de la API con el ID especificado y espera la respuesta.

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

            var entity = JsonSerializer.Deserialize<T>(responseBody, options);
            // Realiza la deserialización del cuerpo de la respuesta en un objeto del tipo T.

            return entity;
            // Devuelve el objeto deserializado.
        }

        public async Task<T> Add(T entity)
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

            var createdEntity = JsonSerializer.Deserialize<T>(responseBody, options);
            // Realiza la deserialización del cuerpo de la respuesta en un objeto del tipo T.

            return createdEntity;
            // Devuelve el objeto creado y deserializado.
        }

        public async Task<bool> Update(int id, T entity)
        {
            // Método para actualizar un elemento de la API por su ID.

            string entityJson = JsonSerializer.Serialize(entity);
            // Serializa el objeto entity a formato JSON.

            StringContent content = new StringContent(entityJson, System.Text.Encoding.UTF8, "application/json");
            // Crea un contenido de tipo StringContent con el JSON serializado.

            HttpResponseMessage response = await httpClient.PutAsync($"{apiUrl}/{id}", content);
            // Realiza una solicitud PUT a la URL de la API con el ID y el contenido JSON y espera la respuesta.

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


            return response.IsSuccessStatusCode;
            // Devuelve el objeto actualizado y deserializado.
        }

        public async Task<bool> Remove(int id)
        {
            // Método para eliminar un elemento de la API por su ID.

            HttpResponseMessage response = await httpClient.DeleteAsync($"{apiUrl}/{id}");
            // Realiza una solicitud DELETE a la URL de la API con el ID especificado y espera la respuesta.

            string errorMessage = await response.Content.ReadAsStringAsync();
            // Lee el mensaje de error (si lo hay) de la respuesta HTTP.

            HttpErrorHandler.ThrowExceptionFromHttpStatusCodeAsync(response, errorMessage);
            // Llama a un manejador de errores personalizado para verificar el código de estado HTTP y lanzar excepciones si es necesario.

            return response.IsSuccessStatusCode;
            // Devuelve true si la solicitud fue exitosa (código de estado HTTP 2xx) y false en caso contrario.
        }



        public async Task<UsuarioDto> Login(UsuarioDto entity)

        {
          

            string entityJson = JsonSerializer.Serialize(entity);
            StringContent content = new StringContent(entityJson, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            string errorMessage = await response.Content.ReadAsStringAsync();
            HttpErrorHandler.ThrowExceptionFromHttpStatusCodeAsync(response, errorMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // set camelCase       
                WriteIndented = true                                // write pretty json
            };
            // pass options to deserializer
            var createdEntity = JsonSerializer.Deserialize<UsuarioDto>(responseBody, options);
            return createdEntity;
        }

    }
}
