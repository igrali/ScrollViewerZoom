using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScrollViewerZoom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HomePageViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.ViewModel = new HomePageViewModel();
            this.DataContext = ViewModel;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.ViewModel.PageWidth = e.NewSize.Width;
            this.ViewModel.PageHeight = e.NewSize.Height;
        }
    }

    public class WindowsWallpaper
    {
        public string ImageUri { get; set; }
    }

    public class HomePageViewModel : INotifyPropertyChanged
    {
        private double pageWidth;
        private double pageHeight;

        public HomePageViewModel()
        {
            this.Wallpapers = new List<WindowsWallpaper>
        {
            new WindowsWallpaper
            {
                ImageUri = "img13.jpg"
            }
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double PageWidth
        {
            get
            {
                return this.pageWidth;
            }
            set
            {
                if (this.pageWidth != value)
                {
                    this.pageWidth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double PageHeight
        {
            get
            {
                return this.pageHeight;
            }
            set
            {
                if (this.pageHeight != value)
                {
                    this.pageHeight = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<WindowsWallpaper> Wallpapers { get; private set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
