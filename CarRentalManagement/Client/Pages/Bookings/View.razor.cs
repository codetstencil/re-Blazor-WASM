using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Bookings
{
  public partial class View
  {
    [Parameter] public int id { get; set; }
    [Inject] private IHttpRepository<Booking> _client { get; set; }

    private Booking booking = new Booking();

    protected override async Task OnParametersSetAsync()
    {
      booking = await _client.Get(Endpoints.BookingsEndpoint, id);
    }
  }
}