using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Bookings
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Booking> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }

    private Booking booking = new Booking
    {
      DateOut = DateTime.Now.Date
    };

    private async Task CreateBooking()
    {
      await _client.Create(Endpoints.BookingsEndpoint, booking);
      _navManager.NavigateTo("/bookings/");
    }
  }
}