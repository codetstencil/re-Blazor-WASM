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
    [Parameter] public Booking Booking { get; set; }
    [Parameter] public string ButtonText { get; set; } = "Save";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
    [Inject] private IHttpRepository<Vehicle> ClientVehicle { get; set; }
    [Inject] private IHttpRepository<Customer> ClientCustomer { get; set; }

    private List<Vehicle> _vehicles;
    private List<Customer> _customers;

    protected override async Task OnInitializedAsync()
    {
      _customers = await ClientCustomer.GetAll(Endpoints.CustomersEndpoint);
      _vehicles = await ClientVehicle.GetAll(Endpoints.VehiclesEndpoint);
    }
  }
}