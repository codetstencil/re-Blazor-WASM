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
    [Inject] private IHttpRepository<Colour> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Parameter] public int id { get; set; }
    private Colour colour = new Colour();

    protected override async Task OnParametersSetAsync()
    {
      colour = await _client.Get(Endpoints.ColoursEndpoint, id);
    }
  }
}