using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using CarRentalManagement.Client.Contracts;
using CarRentalManagement.Client.Static;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Vehicles
{
  public partial class FormComponent
  {
    private IList<Make> _makes;
    private IList<Model> _models;
    private IList<Colour> _colours;
    private string _uploadFileWarning;

    protected override async Task OnInitializedAsync()
    {
      _models = await _clientModels.GetAll(Endpoints.ModelsEndpoint);
      _colours = await _clientColors.GetAll(Endpoints.ColoursEndpoint);
      _makes = await _clientMakes.GetAll(Endpoints.MakesEndpoint);
    }

    private async void HandleFileSelection(InputFileChangeEventArgs e)
    {
      var file = e.File;
      if (file != null)
      {
        var ext = System.IO.Path.GetExtension(file.Name);
        if (ext.ToLower().Contains("jpg")
            || ext.ToLower().Contains("png")
            || ext.ToLower().Contains("jpeg"))
        {
          var picId = Guid.NewGuid().ToString().Replace("-", "");
          Vehicle.ImageName = $"{picId}{ext}";
          Vehicle.Image = new byte[file.Size];
          await file.OpenReadStream().ReadAsync(Vehicle.Image);
          _uploadFileWarning = string.Empty;
        }
        else
        {
          _uploadFileWarning = "Please select a valid image file (*.jpg | *.png)";
        }
      }
    }

    [Parameter] public bool Disabled { get; set; } = false;
    [Parameter] public Vehicle Vehicle { get; set; }
    [Parameter] public string ButtonText { get; set; } = "Save";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
    [Inject] private IHttpRepository<Make> _clientMakes { get; set; }
    [Inject] private IHttpRepository<Colour> _clientColors { get; set; }
    [Inject] private IHttpRepository<Model> _clientModels { get; set; }
  }
}