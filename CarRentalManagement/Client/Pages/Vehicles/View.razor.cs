using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Vehicles
{
  public partial class View
  {
    [Inject] private IHttpRepository<Vehicle> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    [Parameter] public int id { get; set; }
    private Vehicle vehicle = new Vehicle();

    protected override async Task OnParametersSetAsync()
    {
      vehicle = await _client.GetDetails(Endpoints.VehiclesEndpoint, id);
    }
  }
}