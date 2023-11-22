using CreateClient.Views;

namespace CreateClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _TeacherUserControl = new TeacherUserControl();
            _TeacherUserControl.DataContext = new TeacherUserControlViewModel();
            _CourseUserControl = new CourseUserControl();
            _CourseUserControl.DataContext = new CourseUserControlViewModel();
        }
        public TeacherUserControl _TeacherUserControl { get; set; }
        public CourseUserControl _CourseUserControl { get; set; }
    }
}