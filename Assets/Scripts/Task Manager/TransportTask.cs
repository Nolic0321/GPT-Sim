using Assets.Scripts.Blueprint_Manager;
using GPTSim.Resources;
using UnityEngine;

namespace GPTSim.Tasks
{
    public class TransportTask:ITask
    {
        public Vector2 Target { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        public Worker worker { get; set; }
        public BuildingBlueprint TargetBlueprint { get; private set; }
        public ResourceType ResourceType { get; private set; }
        
        public TransportTask(BuildingBlueprint targetBlueprint, ResourceType resourceType)
        {
            TargetBlueprint = targetBlueprint;
            ResourceType = resourceType;
            Target = TargetBlueprint.Location;  // May not need this?
            IsComplete = false;
        }
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void AssignWorker(Worker worker)
        {
            throw new System.NotImplementedException();
        }
    }
}