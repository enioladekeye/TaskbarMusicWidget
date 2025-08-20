using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskbarMusicWidget
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => BlurHelper.EnableBlur(this); 

            Loaded += (s, e) =>
            {
                WindowRounder.EnableRoundedCorners(this);
                PositionOnTaskbar();
            };
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void PositionOnTaskbar()
        {
            // Get screen dimensions
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double taskbarHeight = screenHeight - SystemParameters.WorkArea.Height;

            // Stick to bottom-left corner
            this.Left = 0;
            this.Top = screenHeight - taskbarHeight - this.Height;
        }
    }
}