using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace lab8_visual.Models
{
    public class File_read_write
    {
        public static void SaveFile(string path, List<ObservableCollection<Zadanie>> tasks)
        {
            File.WriteAllText(path, "");
            List<string> data = new List<string>();
            foreach (ObservableCollection<Zadanie> taskList in tasks)
            {
                foreach (Zadanie task in taskList)
                {
                    data.Add(task.Status);
                    data.Add(task.Name);
                    data.Add(task.Description);
                    data.Add(task.ImagePath);
                }
                data.Add("");
            }
            File.WriteAllLines(path, data);
        }

        public static List<ObservableCollection<Zadanie>> LoadFile(string path)
        {
            List<ObservableCollection<Zadanie>> tasks = new List<ObservableCollection<Zadanie>>
            {
                new ObservableCollection<Zadanie>(),
                new ObservableCollection<Zadanie>(),
                new ObservableCollection<Zadanie>()
            };

            StreamReader file = new StreamReader(path);

            try
            {
                for (int i = 0; i < tasks.Count(); i++)
                {
                    ObservableCollection<Zadanie> tmp = new ObservableCollection<Zadanie>();
                    while (true)
                    {
                        string status = file.ReadLine();
                        if (status == "")
                            break;
                        string name = file.ReadLine();
                        string description = file.ReadLine();
                        string imagePath = file.ReadLine();

                        tmp.Add(new Zadanie(status, name, description, imagePath));
                    }
                    tasks[i] = tmp;
                }
                file.Close();
                return tasks;
            }
            catch
            {
                file.Close();
                return new List<ObservableCollection<Zadanie>>
                {
                    new ObservableCollection<Zadanie>(),
                    new ObservableCollection<Zadanie>(),
                    new ObservableCollection<Zadanie>()
                };
            }
        }
    }
}
