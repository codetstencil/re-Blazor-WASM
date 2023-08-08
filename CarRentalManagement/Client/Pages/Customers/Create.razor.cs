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
    [Inject] private IHttpRepository<Customer> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }
    private readonly Customer _customer = new Customer();

    private async Task CreateCustomer()
    {
      await Client.Create(Endpoints.CustomersEndpoint, _customer);
      NavManager.NavigateTo("/customers/");
    }
  }
}