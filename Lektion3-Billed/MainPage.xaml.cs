using System;
namespace Lektion3_Billed
{
    public partial class MainPage : ContentPage
    {
        private string _imagePath;
        Image selectedImage;

        public MainPage()
        {
            InitializeComponent();
            selectedImage = new Image();
        }

        private async void OnSelectedImageClicked(object sender, EventArgs e)
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
}
