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
    public class RestContextLogin : IRestContextLogin
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "";

        public RestContextLogin(string apiUrl)
        {
            this.apiUrl = apiUrl;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
