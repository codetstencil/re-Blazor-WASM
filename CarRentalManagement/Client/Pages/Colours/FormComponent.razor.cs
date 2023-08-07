using Microsoft.AspNetCore.Components;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Client.Pages.Colours
{
  public partial class FormComponent
  {
    [Parameter] public bool Disabled { get; set; } = false;
    [Parameter] public Colour colour { get; set; }
    [Parameter] public string ButtonText { get; set; } = "Save";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
  }
}