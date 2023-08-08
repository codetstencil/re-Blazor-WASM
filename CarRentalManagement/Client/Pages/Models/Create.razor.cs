using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Models
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Model> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }

    private readonly Model _model = new Model();

    private async Task CreateModel()
    {
      await Client.Create(Endpoints.ModelsEndpoint, _model);
      NavManager.NavigateTo("/models/");
    }
  }
}