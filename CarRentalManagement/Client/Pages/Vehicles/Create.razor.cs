using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Vehicles
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Vehicle> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    private readonly Vehicle _vehicle = new Vehicle();

    private async Task CreateVehicle()
    {
      await _client.Create(Endpoints.VehiclesEndpoint, _vehicle);
      _navManager.NavigateTo("/vehicles/");
    }
  }
}