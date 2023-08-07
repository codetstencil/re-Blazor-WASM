using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Bookings
{
  public partial class FormComponent
  {
    [Parameter] public bool Disabled { get; set; } = false;
    [Parameter] public Booking booking { get; set; }
    [Parameter] public string ButtonText { get; set; } = "Save";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
    [Inject] private IHttpRepository<Vehicle> _clientVehicle { get; set; }
    [Inject] private IHttpRepository<Customer> _clientCustomer { get; set; }

    private List<Vehicle> Vehicles;
    private List<Customer> Customers;

    protected override async Task OnInitializedAsync()
    {
      Customers = await _clientCustomer.GetAll(Endpoints.CustomersEndpoint);
      Vehicles = await _clientVehicle.GetAll(Endpoints.VehiclesEndpoint);
    }
  }
}