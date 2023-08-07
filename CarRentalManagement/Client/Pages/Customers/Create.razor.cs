using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Customers
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Customer> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }
    private Customer customer = new Customer();

    private async Task CreateCustomer()
    {
      await _client.Create(Endpoints.CustomersEndpoint, customer);
      _navManager.NavigateTo("/customers/");
    }
  }
}