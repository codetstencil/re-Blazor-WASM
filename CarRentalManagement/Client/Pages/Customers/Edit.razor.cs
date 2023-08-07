using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Customers
{
  public partial class Edit
  {
    [Inject] private IHttpRepository<Customer> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }

    [Parameter] public int id { get; set; }
    private Customer customer = new Customer();

    protected override async Task OnParametersSetAsync()
    {
      customer = await _client.Get(Endpoints.CustomersEndpoint, id);
    }

    private async Task EditCustomer()
    {
      await _client.Update(Endpoints.CustomersEndpoint, customer, id);
      _navManager.NavigateTo("/customers/");
    }
  }
}