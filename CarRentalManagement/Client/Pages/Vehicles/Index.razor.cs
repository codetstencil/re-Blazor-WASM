using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Vehicles
{
  public partial class Index
  {
    [Inject] private IHttpRepository<Vehicle> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    private List<Vehicle> Vehicles;

    protected override async Task OnInitializedAsync()
    {
      Vehicles = await _client.GetAll($"{Endpoints.VehiclesEndpoint}");
    }

    private async Task Delete(int vehicleId)
    {
      var vehicle = Vehicles.First(q => q.Id == vehicleId);
      var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {vehicle.Vin}?");
      if (confirm)
      {
        await _client.Delete(Endpoints.VehiclesEndpoint, vehicleId);
        await OnInitializedAsync();
      }
    }
  }
}