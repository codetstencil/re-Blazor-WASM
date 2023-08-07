using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Makes
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Make> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }

    private Make make = new Make();

    private async Task CreateMake()
    {
      await _client.Create(Endpoints.MakesEndpoint, make);
      _navManager.NavigateTo("/makes/");
    }
  }
}