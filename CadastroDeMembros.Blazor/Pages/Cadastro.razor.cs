using CadastroDeMembros.MembrosFile;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CadastroDeMembros.Blazor.Pages
{
    public partial class Cadastro
    {
        [CascadingParameter]
        public IMudDialogInstance MudDialog { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public Membros membro { get; set; } = new Membros();

        [Parameter]
        public bool podeRemover { get; set; } = false;


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (membro == null)
            {
                membro = new Membros();
            }
        }
          public async Task Salvar()
          {
              MudDialog.Close(DialogResult.Ok(membro));
              await Task.CompletedTask;
          }

      /*  private void Salvar() => MudDialog.Close(DialogResult.Ok(membro));
      */

        public async Task Cancelar()
        {
            MudDialog.Close(DialogResult.Cancel());
            await Task.CompletedTask;
        }


    }
}
