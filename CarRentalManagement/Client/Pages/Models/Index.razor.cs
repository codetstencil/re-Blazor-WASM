using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Services;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Models
{
  public partial class Index
  {
    [Inject] private IHttpRepository<Model> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Inject] private HttpInterceptorService _interceptor { get; set; }

    private List<Model> Models;

    protected override async Task OnInitializedAsync()
    {
      Models = await _client.GetAll(Endpoints.ModelsEndpoint);
    }

    private async Task Delete(int modelId)
    {
      var model = Models.First(q => q.Id == modelId);
      var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {model.Name}?");
      if (confirm)
      {
        await _client.Delete(Endpoints.ModelsEndpoint, modelId);
        await OnInitializedAsync();
      }
    }
  }
}