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


        public async Task OpenPoup(Membros membro= null)
        {
            var parameters = new DialogParameters
            {
                {"membro", membro ?? new Membros()  }
            };

            var options = new DialogOptions  {  CloseOnEscapeKey = true, FullWidth= true  };

            var dialog = DialogService.Show<Cadastro>("", parameters, options);

            var result = await dialog.Result;



            if (!result.Canceled && result.Data is Membros novoMembro)
            {
               
                novoMembro.ID = membros.Count > 0 ? membros.Max(m => m.ID) + 1 : 1;
                membros.Add(novoMembro);
                StateHasChanged();
            }
        }









    }












}