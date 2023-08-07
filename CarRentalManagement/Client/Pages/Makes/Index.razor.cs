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
    [Inject] private IHttpRepository<Make> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    private List<Make> Makes;

    protected override async Task OnInitializedAsync()
    {
      Makes = await _client.GetAll(Endpoints.MakesEndpoint);
    }

    private async Task Delete(int makeId)
    {
      var make = Makes.First(q => q.Id == makeId);
      var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {make.Name}?");
      if (confirm)
      {
        await _client.Delete(Endpoints.MakesEndpoint, makeId);
        await OnInitializedAsync();
      }
    }
  }
}