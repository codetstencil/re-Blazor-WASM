using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Makes
{
  public partial class View
  {
    [Inject] private IHttpRepository<Make> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    [Parameter] public int id { get; set; }
    private Make make = new Make();

    protected override async Task OnParametersSetAsync()
    {
      make = await _client.Get(Endpoints.MakesEndpoint, id);
    }
  }
}