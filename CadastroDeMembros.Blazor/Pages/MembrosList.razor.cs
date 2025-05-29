using Microsoft.AspNetCore.Components;
using CadastroDeMembros.MembrosFile;
using MudBlazor;

namespace CadastroDeMembros.Blazor.Pages
{
    public partial class MembrosList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        [Parameter]
        public string ID { get; set; }

        public List<Membros> membros { get; set; } = new List<Membros>();

        public async Task OpenPoup(Membros membro = null, bool podeRemover = false)
        {
            var parameters = new DialogParameters
            {
                {"membro", membro != null ? new Membros
                    {
                        ID = membro.ID,
                        Nome = membro.Nome,
                        Telefone = membro.Telefone,
                        Email = membro.Email,
                        CPF = membro.CPF,
                        DataDeNascimento = membro.DataDeNascimento
                    } : new Membros() },
                {"podeRemover", podeRemover }
            };
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, CloseButton = true, BackdropClick = true };
            var dialogReference = await DialogService.ShowAsync<Cadastro>("", parameters, options);
            var result = await dialogReference.Result;

            if (!result.Canceled)
            {
                var membroSalvo = result.Data as Membros;
                if (podeRemover && membro != null)
                {
                    membros.RemoveAll(m => m.ID == membro.ID);
                }
                else
                {
                    if (membro != null)
                    {
                        var index = membros.FindIndex(m => m.ID == membro.ID);
                        if (index >= 0)
                        {
                            membros[index] = membroSalvo;
                        }
                    }
                    else
                    {
                        membros.Add(membroSalvo);
                    }
                }
                StateHasChanged();
            }
        }
    }
}