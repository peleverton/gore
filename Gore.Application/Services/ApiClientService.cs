using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gore.Application.Services
{
    public class ApiClientService : IApiClientService
    {
        HttpClient _httpClient;
        AddressViewModel address;

        public ApiClientService()
        {
            //_httpClient = httpClient;
        }


        public async Task<AddressViewModel> GetCepAsync(string cep)
        {
            using (_httpClient = new HttpClient())
            {
                var uri = "https://viacep.com.br/ws/";
                var format = "/json/";

                var response = await _httpClient.GetAsync($"{uri}{cep}{format}");

                if (response.IsSuccessStatusCode)
                {
                    ResultadoCep result = JsonConvert.DeserializeObject<ResultadoCep>(response.Content.ReadAsStringAsync().Result);
                    address = new AddressViewModel
                    {
                        Bairro = result.Bairro,
                        Cep = result.Cep.Replace("-", ""),
                        City = result.Localidade,
                        Street = result.Logradouro,
                        State = result.Uf
                    };
                }
                else
                    address = null;
            }

            return address;

        }
    }
}
