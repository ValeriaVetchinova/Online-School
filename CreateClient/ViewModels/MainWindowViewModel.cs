using CreateClient.Views;

namespace CreateClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() 
        { 
        _TeacherUserControl = new TeacherUserControl();
        _TeacherUserControl.DataContext = new TeacherUserControlViewModel();
        }
    public TeacherUserControl _TeacherUserControl { get; set; }
    }
}