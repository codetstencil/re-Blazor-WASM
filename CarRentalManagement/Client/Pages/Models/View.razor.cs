using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Models
{
  public partial class View
  {
    [Inject] private IHttpRepository<Model> Client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }

    [Parameter] public int Id { get; set; }
    private Model _model = new Model();

    protected override async Task OnParametersSetAsync()
    {
      _model = await Client.Get(Endpoints.ModelsEndpoint, Id);
    }
  }
}