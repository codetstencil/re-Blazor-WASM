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
    [Inject] private IHttpRepository<Booking> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }

    private readonly Booking _booking = new Booking
    {
      DateOut = DateTime.Now.Date
    };

    private async Task CreateBooking()
    {
      await Client.Create(Endpoints.BookingsEndpoint, _booking);
      NavManager.NavigateTo("/bookings/");
    }
  }
}