using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Colours
{
  public partial class Create
  {
    [Inject] private IHttpRepository<Colour> Client { get; set; }
    [Inject] private NavigationManager NavManager { get; set; }

    private Colour colour = new Colour();

    private async Task CreateColour()
    {
      await Client.Create(Endpoints.ColoursEndpoint, colour);
      NavManager.NavigateTo("/colours/");
    }
  }
}