using System.Resources;
using GPTSim.Storage;
using UnityEngine;

namespace GPTSim.Tasks
{
    public class ReturnToStorageLocationTask:ITask
    {
        public Vector2 Target { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        public Worker worker { get; set; }
        
        private StorageLocation nearestStorageLocation;

        public ReturnToStorageLocationTask()
        { }

        public ReturnToStorageLocationTask(Worker worker)
        {
            this.worker = worker;
            FindNearestStorageLocation();
        }

        private void FindNearestStorageLocation()
        {
            nearestStorageLocation = StorageManager.Instance.FindNearestStorage(this.worker.transform.position);
            Target = nearestStorageLocation.transform.position;
        }
        
        public void Update()
        {
            //Requeue task if a worker isn't assigned
            if (worker == null)
            {
                TaskManager.Instance.AddTask(this);
            }
            
            //Find nearest storage location if one isn't already assigned
            if(nearestStorageLocation == null)
                FindNearestStorageLocation();
            
            if (Vector2.Distance(worker.transform.position, Target) < worker.reachTolerance)
            {
                IsComplete = true;
                nearestStorageLocation.AddResources(worker.RemoveInventory());
            }
            else
            {
                // Move the worker towards the target
                worker.MoveTo(Target);
            }
        }

        public void AssignWorker(Worker worker)
        {
            this.worker = worker;
            FindNearestStorageLocation();
        }
    }
}