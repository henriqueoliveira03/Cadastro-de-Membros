using Microsoft.AspNetCore.Components;
using CadastroDeMembros.MembrosFile;
//using MudBlazor;



namespace CadastroDeMembros.Blazor.Pages 
{

    public partial class MembrosList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public List<Membros> membros { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // membros = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("");


            membros = new List<Membros>
            {
                new (){ID= 1, Nome= "João da Silva", Telefone= "(21) 999999999", Email= "joaodasilva@gmail.com", CPF="000.000.000-00", DataDeNascimento= DateTime.Parse("13/03/2001")  }
            };


            
        }





    }









}