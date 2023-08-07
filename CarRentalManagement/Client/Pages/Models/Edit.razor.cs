using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Models
{
  public partial class Edit
  {
    [Inject] private IHttpRepository<Model> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    [Parameter] public int id { get; set; }
    private Model model = new Model();

    protected override async Task OnParametersSetAsync()
    {
      model = await _client.Get(Endpoints.ModelsEndpoint, id);
    }

    private async Task EditModel()
    {
      await _client.Update(Endpoints.ModelsEndpoint, model, id);
      _navManager.NavigateTo("/models/");
    }
  }
}