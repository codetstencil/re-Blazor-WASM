using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Makes
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Make> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }

    private readonly Make _make = new Make();

    private async Task CreateMake()
    {
      await Client.Create(Endpoints.MakesEndpoint, _make);
      NavManager.NavigateTo("/makes/");
    }
  }
}