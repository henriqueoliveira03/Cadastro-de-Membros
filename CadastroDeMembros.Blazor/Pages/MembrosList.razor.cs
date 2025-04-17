using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using CadastroDeMembros.MembrosFile;


namespace CadastroDeMembros.Blazor.Pages 
{

    public partial class MembrosList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        private MembrosList[] membros;

        protected override async Task OnInitializedAsync()
        {
            // membros = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("");

        }





    }









}