using CreateClient.Views;

namespace CreateClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _CourseUserControl = new CourseUserControl();
            _CourseUserControl.DataContext = new CourseUserControlViewModel();
        }

        public CourseUserControl _CourseUserControl { get; set; }
    }
}