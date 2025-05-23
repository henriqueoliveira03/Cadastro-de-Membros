using CadastroDeMembros.MembrosFile;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CadastroDeMembros.Blazor.Pages
{
    public partial class Cadastro
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter] 
        public Membros membro { get; set; }

        [Parameter]
        public bool PodeRemover { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        public async Task Salvar()
        {
            await Task.CompletedTask;
        }

        public async Task Cancelar()
        {
            await Task.CompletedTask;
        }






    }
}
