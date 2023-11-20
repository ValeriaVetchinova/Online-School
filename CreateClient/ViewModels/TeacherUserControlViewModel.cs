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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CreateClient.ViewModels
{
    public class TeacherUserControlViewModel : ViewModelBase
        {
        private Teacher _selectedTeacher;
		public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set => this.RaiseAndSetIfChanged(ref _selectedTeacher, value);
        }

        private HttpClient client = new HttpClient();
        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set => this.RaiseAndSetIfChanged(ref _teachers, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public TeacherUserControlViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:5141");
            Update();
        }


        public async Task Update()
            {
                var response = await client.GetAsync("");
                if (!response.IsSuccessStatusCode)
                {
                    Message = $"Ошибка сервера {response.StatusCode}";
                }
                var content = await response.Content.ReadAsStringAsync();
                if (content == null)
                {
                    Message = "Пустой ответ от сервера";
                }
                Teachers = JsonSerializer.Deserialize<ObservableCollection<Teacher>>(content);
                Message = "";
            }

            public async Task Delete()
            {
            if (SelectedTeacher == null) return;
            var response = await client.DeleteAsync($"/teachers/{SelectedTeacher.Id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            Teachers.Remove(SelectedTeacher);
            SelectedTeacher = null;
            Message = "";
        }

            public async Task Add()
            {
            var teacher = new Teacher();
            var response = await client.PostAsJsonAsync($"/teachers", teacher);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Teacher>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            teacher = content;
            Teachers.Add(teacher);
            SelectedTeacher = teacher;
        }

            public async Task Edit()
            {
            var response = await client.PutAsJsonAsync($"/teacher", SelectedTeacher);
			if (!response.IsSuccessStatusCode)
			{
				Message = "Ошибка изменения со стороны сервера";
				return;
			}
			var content = await response.Content.ReadFromJsonAsync<Teacher>();
			if (content == null)
			{
				Message = "При изменении сервер отправил пустой ответ";
				return;
			}
			SelectedTeacher = content;
            }
        }
    }
