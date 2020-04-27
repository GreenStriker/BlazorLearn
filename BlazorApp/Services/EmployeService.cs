using Blazor.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class EmployeService : IEmployeService
    {

        public EmployeService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<IEnumerable<Employe>> GetEmployes()
        {
            return await HttpClient.GetJsonAsync<Employe[]>("api/Employes");
        }
    }
}
