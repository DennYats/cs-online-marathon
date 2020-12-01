using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint10.Task9
{
    public interface ILead
    {
        void AssignTask();
        void CreateSubTask();
    }

    public interface IManager
    {
        void AssignTask();
    }

    public interface IProgrammer
    {
        void WorkOnTask();
    }

    public class TeamLead : ILead, IManager, IProgrammer
    {
        public void AssignTask() { }
        public void CreateSubTask() { }
        public void WorkOnTask() { }
    }

    public class Manager : IManager, ILead
    {
        public void AssignTask() { }
        public void CreateSubTask() { }
    }

    public class Programmer : IProgrammer
    {
        public void WorkOnTask() { }
    }
}
