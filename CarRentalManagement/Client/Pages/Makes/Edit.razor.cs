using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Makes
{
  public partial class Edit
  {
    [Inject] private IHttpRepository<Make> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }

    [Parameter] public int Id { get; set; }
    private Make _make = new Make();

    protected override async Task OnParametersSetAsync()
    {
      _make = await Client.Get(Endpoints.MakesEndpoint, Id);
    }

    private async Task EditMake()
    {
      await Client.Update(Endpoints.MakesEndpoint, _make, Id);
      NavManager.NavigateTo("/makes/");
    }
  }
}