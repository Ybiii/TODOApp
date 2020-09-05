using System.Collections.Generic;
using TODO_lib.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TODO_lib.Controller
{
    public class TaskController
    {     
        public List<Task> Tasks { get; private set; }
        private Task task;

        public TaskController()
        {
            Tasks = TasksLoad();
            task = new Task();
        }

        public TaskController(string s) : this()
        {
            task.String = s;
            Tasks.Add(task);

            TasksSave(Tasks);
        }

        public void RemoveTask(int i)
        {
            Tasks.RemoveAt(i);

            TasksSave(Tasks);
        }

        public void ChangeStatus(int i)
        {
            if (Tasks[i].Status)
                Tasks[i].Status = false;
            else
                Tasks[i].Status = true;

            TasksSave(Tasks);
        }

        private void TasksSave(List<Task> t)
        {
            BinaryFormatter formater = new BinaryFormatter();
            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, Tasks);
            }
        }

        private List<Task> TasksLoad()
        {
            BinaryFormatter formater = new BinaryFormatter();
            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    return Tasks = (List<Task>)formater.Deserialize(fs);
                }
                else
                {
                    return new List<Task>();
                }
            }
        }
    }
}