using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Colours
{
  public partial class View
  {
    [Inject] private IHttpRepository<Colour> Client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Parameter] public int Id { get; set; }
    private Colour colour = new Colour();

    protected override async Task OnParametersSetAsync()
    {
      colour = await Client.Get(Endpoints.ColoursEndpoint, Id);
    }
  }
}