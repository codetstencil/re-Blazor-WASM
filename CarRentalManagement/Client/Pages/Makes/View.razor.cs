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
    [Inject] private IHttpRepository<Make> Client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }

    [Parameter] public int Id { get; set; }
    private Make _make = new Make();

    protected override async Task OnParametersSetAsync() => 
      _make = await Client.Get(Endpoints.MakesEndpoint, Id);
  }
}