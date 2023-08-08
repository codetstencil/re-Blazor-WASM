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
    [Inject] private IHttpRepository<Model> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }

    [Parameter] public int Id { get; set; }
    private Model _model = new Model();

    protected override async Task OnParametersSetAsync()
    {
      _model = await Client.Get(Endpoints.ModelsEndpoint, Id);
    }

    private async Task EditModel()
    {
      await Client.Update(Endpoints.ModelsEndpoint, _model, Id);
      NavManager.NavigateTo("/models/");
    }
  }
}