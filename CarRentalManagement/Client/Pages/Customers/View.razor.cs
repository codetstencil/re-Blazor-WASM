using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Customers
{
  public partial class View
  {
    [Inject] private IHttpRepository<Customer> Client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }

    [Parameter] public int Id { get; set; }
    private Customer _customer = new Customer();

    protected override async Task OnParametersSetAsync()
    {
      _customer = await Client.Get(Endpoints.CustomersEndpoint, Id);
    }
  }
}