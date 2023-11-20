using Avalonia.Controls;
using OnlineSchool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateClient.ViewModels
{
    public class CourseUserControlViewModel : ViewModelBase
    {
        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set => this.RaiseAndSetIfChanged(ref _selectedCourse, value);
        }

        private HttpClient client = new HttpClient();
        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set => this.RaiseAndSetIfChanged(ref _courses, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public CourseUserControlViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:5141");
            Update();
        }

        public async Task Update()
        {
            var response = await client.GetAsync("/courses");
            if (!response.IsSuccessStatusCode)
            {
                Message = $"Ошибка сервера {response.StatusCode}";
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Message = "Пустой ответ от сервера";
            }
            Courses = JsonSerializer.Deserialize<ObservableCollection<Course>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedCourse == null) return;
            var response = await client.DeleteAsync($"/courses/{SelectedCourse.Id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            Courses.Remove(SelectedCourse);
            SelectedCourse = null;
            Message = "";

        }

        public async Task Add()
        {
            var course = new Course();
            var response = await client.PostAsJsonAsync($"/courses", course);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Course>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            course = content;
            Courses.Add(course);
            SelectedCourse = course;
        }


        public async Task Edit()
        {
            var response = await client.PutAsJsonAsync($"/course", SelectedCourse);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Course>();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedCourse = content;
        }
    }
}
    

