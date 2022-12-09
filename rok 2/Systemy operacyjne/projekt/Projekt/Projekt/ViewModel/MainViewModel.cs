namespace Projekt.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _BGImage = @"C:\Users\petit\Desktop\repos\UO\rok 2\Systemy operacyjne\projekt\Projekt\Projekt\Assets\Image\mapa_v3.png";


        public MainViewModel()
        {

        }

        public string BGImage
        {
            get => this._BGImage;
            set
            {
                _BGImage = value;
                OnPropertyChanged();
            }
        }
    }
}
