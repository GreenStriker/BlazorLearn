using Blazor.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
namespace BlazorApp.Pages
{
    public partial class EmployeListBase :ComponentBase  
    {

        [Inject]
        public IEmployeService EmployeService { get; set; }
        public IEnumerable<Blazor.Models.Employe> employes { get; set; }

        protected override async Task OnInitializedAsync()
        {
             employes = (await EmployeService.GetEmployes()).ToList();

        }

       
    }
}
