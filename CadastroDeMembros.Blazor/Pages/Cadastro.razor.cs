using CadastroDeMembros.MembrosFile;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CadastroDeMembros.Blazor.Pages
{
    public partial class Cadastro
    {
        [CascadingParameter] public IDialogReference MudDialog { get; set; }
        [Parameter] public Membros membro { get; set; } = new();

       public async Task Salvar()
        {
            Console.WriteLine("salvou");


        }

        public async Task Cancelar()
        {
            Console.WriteLine("cancelou");


        }






    }
}
