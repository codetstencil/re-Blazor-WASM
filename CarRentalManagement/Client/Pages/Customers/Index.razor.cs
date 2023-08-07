using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Customers
{
  public partial class Index
  {
    [Inject] private IHttpRepository<Customer> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    private List<Customer> Customers;

    protected override async Task OnInitializedAsync()
    {
      Customers = await _client.GetAll(Endpoints.CustomersEndpoint);
    }

    private async Task Delete(int customerId)
    {
      var customer = Customers.First(q => q.Id == customerId);
      var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {customer.TaxId}?");
      if (confirm)
      {
        await _client.Delete(Endpoints.CustomersEndpoint, customerId);
        await OnInitializedAsync();
      }
    }
  }
}