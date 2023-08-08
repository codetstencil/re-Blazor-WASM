using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Customers
{
  public partial class Edit
  {
    [Inject] private IHttpRepository<Customer> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }

    [Parameter] public int Id { get; set; }
    private Customer _customer = new Customer();

    protected override async Task OnParametersSetAsync()
    {
      _customer = await Client.Get(Endpoints.CustomersEndpoint, Id);
    }

    private async Task EditCustomer()
    {
      await Client.Update(Endpoints.CustomersEndpoint, _customer, Id);
      NavManager.NavigateTo("/customers/");
    }
  }
}