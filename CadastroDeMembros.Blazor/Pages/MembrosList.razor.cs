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


        protected override async Task OnInitializedAsync()
        {
            membros = new List<Membros>
            {
                new Membros
                {
                    ID = 1,
                    Nome = "João da Silva",
                    Telefone = "(21) 999999999",
                    Email = "joaodasilva@gmail.com",
                    CPF = "000.000.000-00",
                    DataDeNascimento = DateTime.Parse("13/03/2001")
                }
            };
            await base.OnInitializedAsync();
        }




        /*    public async Task ToggleOpen()
            {
                membros.Add(new Membros
                {
                    ID = 1,
                    Nome = "João da Silva",
                    Telefone = "(21) 999999999",
                    Email = "joaodasilva@gmail.com",
                    CPF = "000.000.000-00",
                    DataDeNascimento = DateTime.Parse("13/03/2001")
                });

                await Task.CompletedTask;
            }*/


        public async Task OpenPoup(Membros membro = null, bool podeRemover = false)
        {
            var parameters = new DialogParameters
            {
                {"membro", membro ?? new Membros() },
                {"podeRemover", podeRemover }
            };
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, CloseButton = true, BackdropClick= true };
            var dialogReference = await DialogService.ShowAsync<Cadastro>("", parameters, options);
            var result = await dialogReference.Result;
            if (!result.Canceled)
            {
                var membroSalvo = result.Data as Membros;
                if (podeRemover)
                {
                    membros = membros.Where(n => n.ID != membro.ID).ToList();
                }
                else
                {
                    // Se é um membro existente, atualiza
                    if (membro != null && membros.Any(m => m.ID == membro.ID))
                    {
                        var index = membros.FindIndex(m => m.ID == membro.ID);
                        membros[index] = membroSalvo;
                    }
                    // Se é um membro novo, adiciona à lista
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