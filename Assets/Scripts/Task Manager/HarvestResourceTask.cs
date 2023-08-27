using GPTSim.Resources;
using UnityEngine;

namespace GPTSim.Tasks
{
    public class HarvestResourceTask: ITask
    {
        public Vector2 Target { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        public Worker worker { get; set; }
        public ResourceType ResourceType { get; set; }

        public HarvestResourceTask(ResourceType type, Vector2 target)
        {
            Target = target;
            ResourceType = type;
        }
        public void AssignWorker(Worker worker)
        {
            this.worker = worker;
        }
        public void Update()
        {
            if(worker == null)
                TaskManager.Instance.AddTask(this); //Requeue task so it gets done
            
            if (Vector2.Distance(worker.transform.position, Target) < worker.reachTolerance)
            {
                worker.AddToInventory(this.ResourceType,1);
                var returnTask = new ReturnToStorageLocationTask(worker);
                worker.SetCurrentTask(returnTask);
                IsComplete = true;
            }
            else
            {
                // Move the worker towards the target
                worker.MoveTo(Target);
            }
        }
    }
}