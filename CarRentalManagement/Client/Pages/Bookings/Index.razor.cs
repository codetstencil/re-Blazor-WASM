using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Bookings
{
  public partial class Index : IDisposable
  {
    private List<Booking> _bookings;
    [Inject] private IHttpRepository<Booking> Client { get; set; }
    [Inject] private IJSRuntime js { get; set; }

    protected override async Task OnInitializedAsync()
    {
      _bookings = await Client.GetAll($"{Endpoints.BookingsEndpoint}");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      await js.InvokeVoidAsync("AddDataTable", "#bookingsTable");
    }

    public void Dispose()
    {
      js.InvokeVoidAsync("DataTablesDispose", "#bookingsTable");
    }

    private async Task Delete(int bookingsId)
    {
      var bookings = _bookings.First(q => q.Id == bookingsId);
      var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {bookings.Customer.TaxId}?");
      if (confirm)
      {
        await Client.Delete(Endpoints.BookingsEndpoint, bookingsId);
        await OnInitializedAsync();
      }
    }
  }
}