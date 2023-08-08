using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Makes
{
  public partial class Index
  {
    [Inject] private IHttpRepository<Make> Client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService Interceptor { get; set; }

    private List<Make> _makes;

    protected override async Task OnInitializedAsync()
    {
      _makes = await Client.GetAll(Endpoints.MakesEndpoint);
    }

    private async Task Delete(int makeId)
    {
      var make = _makes.First(q => q.Id == makeId);
      var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {make.Name}?");
      if (confirm)
      {
        await Client.Delete(Endpoints.MakesEndpoint, makeId);
        await OnInitializedAsync();
      }
    }
  }
}