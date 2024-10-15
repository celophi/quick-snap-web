using Microsoft.AspNetCore.Components;
using QuickSnapWeb.Pictures;

namespace QuickSnapWeb.Pages;

public partial class Pictures : ComponentBase
{
    [Inject]
    private IPictureRepository _pictureRepository { get; init; } = default!;

    private List<Picture> _pictures = new();

    protected override async Task OnInitializedAsync()
    {
        _pictures = await _pictureRepository.GetAsync();
        StateHasChanged();
    }

    private string GetImageSource(byte[] imageData)
    {
        return $"data:image/jpeg;base64,{Convert.ToBase64String(imageData)}";
    }
}
