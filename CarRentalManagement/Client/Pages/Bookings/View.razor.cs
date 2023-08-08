using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Bookings
{
  public partial class View
  {
    [Parameter] public int Id { get; set; }
    [Inject] private IHttpRepository<Booking> Client { get; set; }

    private Booking _booking = new Booking();

    protected override async Task OnParametersSetAsync() => 
      _booking = await Client.Get(Endpoints.BookingsEndpoint, Id);
  }
}