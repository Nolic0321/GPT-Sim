using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPTSim.Tasks
{
    public interface ITask
    {
        Vector2 Target { get; set; }
        int Priority { get; set; }
        bool IsComplete { get; set; }
        Worker worker { get; set; }
        
        
        void Update();
        void AssignWorker(Worker worker);
    }
}