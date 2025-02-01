namespace Lektion3_BilledLagre;

public partial class MainPage : ContentPage
{
    int count = 0;
    string _imagePath;
    Image selectedImage;

    public MainPage()
    {
        InitializeComponent();
        selectedImage = new Image();
    }

    private async void PickImage()
    {
        var image = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image",
            FileTypes = FilePickerFileType.Images
        });

        if (image != null)
        {
            _imagePath = image.FullPath.ToString();
            selectedImage.Source = _imagePath;
        }
    }
}
