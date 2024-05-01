using Application.BalanceManagmentAppFeatures.BalanceTransaction.Queries;
using Domain.Abstructions;
using Domain.ViewModel;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.Design;

namespace DataAcessPersistence.Service
{

    /// <summary>
    /// This Service Use to Deal with External Service
    /// </summary>
    public class BalanceManangementAppService: IBalanceManangementAppService
    {
        private readonly IHttpClientFactory httpClient;

        public IConfiguration configuration { get; }
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_httpClient"></param>
        /// <param name="_configuration"></param>
        public BalanceManangementAppService(IHttpClientFactory _httpClient, IConfiguration _configuration)
        {
            httpClient = _httpClient;
            configuration = _configuration;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        /// <summary>
        /// This Method Use to Get Current Balance of User
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<GetUserBalanceResponse> GetBalance(GetUserBalanceRequestViewModel getUserBalanceViewModel)
        {
            string baseUrl = configuration["AppSettings:BaseUrl"] ?? string.Empty;
            var url = $"{baseUrl}/api/v1/BalanceTransaction/GetUserBalance";

            var httpClient1 = httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            string jsonContent = System.Text.Json.JsonSerializer.Serialize(getUserBalanceViewModel);
            var content = new StringContent(jsonContent, null, "application/json");
            request.Content = content;

            using (var response = await httpClient1.SendAsync(request))
            {

                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                return await System.Text.Json.JsonSerializer.DeserializeAsync<GetUserBalanceResponse>(stream, _options) 
                                                                                        ?? new GetUserBalanceResponse();
            }
        }

        /// <summary>
        /// This Method to perform Debit and Credit transaction
        /// </summary>
        /// <param name="debitCreditRequestViewModel"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> DebitCreditExecution(DebitCreditRequestViewModel debitCreditRequestViewModel)
        {
            string baseUrl = configuration["AppSettings:BaseUrl"] ?? string.Empty;
            var url = $"{baseUrl}/api/v1/BalanceTransaction/DebitCreaditTransaction";

            var httpClient1 = httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            string jsonContent = System.Text.Json.JsonSerializer.Serialize(debitCreditRequestViewModel);
            var content = new StringContent(jsonContent, null, "application/json");
            request.Content = content;

            using (var response = await httpClient1.SendAsync(request))
            {

                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                return await System.Text.Json.JsonSerializer.DeserializeAsync<ResponseViewModel>(stream, _options)
                                                                                        ?? new ResponseViewModel();
            }
        }


    }
}
