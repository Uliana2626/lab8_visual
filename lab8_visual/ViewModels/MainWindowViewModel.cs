using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using lab8_visual.Models;

namespace lab8_visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<Zadanie> todoTasks;
        ObservableCollection<Zadanie> doingTasks;
        ObservableCollection<Zadanie> doneTasks;

        public MainWindowViewModel()
        {
            todoTasks = new ObservableCollection<Zadanie>();
            doingTasks = new ObservableCollection<Zadanie>();
            doneTasks = new ObservableCollection<Zadanie>();
        }

        public ObservableCollection<Zadanie> TodoTasks
        {
            get => todoTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref todoTasks, value);
            }
        }

        public ObservableCollection<Zadanie> DoingTasks
        {
            get => doingTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref doingTasks, value);
            }
        }

        public ObservableCollection<Zadanie> DoneTasks
        {
            get => doneTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref doneTasks, value);
            }
        }

        public void AddTask(string taskType)
        {
            switch (taskType)
            {
                case "ToDo":
                    TodoTasks.Add(new Zadanie("ToDo"));
                    break;
                case "Doing":
                    DoingTasks.Add(new Zadanie("Doing"));
                    break;
                case "Done":
                    DoneTasks.Add(new Zadanie("Done"));
                    break;
            }
        }

        public void SaveFile(string path)
        {
            List<ObservableCollection<Zadanie>> tasks = new List<ObservableCollection<Zadanie>> { TodoTasks, DoingTasks, DoneTasks };
            File_read_write.SaveFile(path, tasks);
        }

        public void LoadFile(string path)
        {
            List<ObservableCollection<Zadanie>> tasks = File_read_write.LoadFile(path);
            TodoTasks = tasks[0];
            DoingTasks = tasks[1];
            DoneTasks = tasks[2];
        }
    }
}
