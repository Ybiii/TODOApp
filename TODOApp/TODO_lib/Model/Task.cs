using System;

namespace TODO_lib.Model
{
    [Serializable]
    public class Task
    {
        public string String { get; internal set; }

        public bool Status { get; internal set; }

        internal Task()
        {
        }

        internal Task(string st)
        {
            String = st;
            Status = false;
        }
    }
}