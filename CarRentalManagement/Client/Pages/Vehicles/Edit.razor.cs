using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Vehicles
{
  public partial class Edit
  {
    [Inject] private IHttpRepository<Vehicle> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    [Parameter] public int id { get; set; }
    private Vehicle _vehicle = new Vehicle();

    protected override async Task OnParametersSetAsync() => 
      _vehicle = await _client.Get(Endpoints.VehiclesEndpoint, id);

    private async Task EditVehicle()
    {
      await _client.Update(Endpoints.VehiclesEndpoint, _vehicle, id);
      _navManager.NavigateTo("/vehicles/");
    }
  }
}