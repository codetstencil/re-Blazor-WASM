using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Models
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Model> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }

    private Model model = new Model();

    private async Task CreateModel()
    {
      await _client.Create(Endpoints.ModelsEndpoint, model);
      _navManager.NavigateTo("/models/");
    }
  }
}