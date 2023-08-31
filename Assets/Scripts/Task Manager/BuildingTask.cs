using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Blueprint_Manager;
using GPTSim.Resources;
using UnityEngine;

namespace GPTSim.Tasks
{
    public enum BuildingTaskState
    {
        CollectingResources,
        TransportingResources,
        Building,
        Completed
    }
    
    public class BuildingTask : ITask
    {
        public BuildingTaskState TaskState { get; private set; }
        public BuildingBlueprint Blueprint { get; private set; }
        public Worker AssignedWorker { get; private set; }
        public Vector2 Target { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        public Worker worker { get; set; }
        public Dictionary<ResourceType, int> ResourcesOnSite { get; set; } = new Dictionary<ResourceType, int>();


        public BuildingTask(BuildingBlueprint blueprint)
        {
            Blueprint = blueprint;
            TaskState = BuildingTaskState.TransportingResources;
            IsComplete = false;
            CreateTransportTasks();
        }

        public void AssignWorker(Worker worker)
        {
            this.AssignedWorker = worker;
        }

        public void Update()
        {
            if (IsComplete) return;

            switch (TaskState)
            {
                case BuildingTaskState.CollectingResources:
                    // TODO: Implement this in future for automatic harvesting tasks based on resource requirements
                    break;

                case BuildingTaskState.TransportingResources:
                    // Check if all resources are on site
                    if (Blueprint.AreResourcesGathered())
                    {
                        TaskState = BuildingTaskState.Building;
                    }
                    break;

                case BuildingTaskState.Building:
                    // Build the building
                    // Once building is complete, change state
                    if (Blueprint.CurrentState == BuildingBlueprint.State.Completed)
                    {
                        TaskState = BuildingTaskState.Completed;
                    }
                    break;
                
                case BuildingTaskState.Completed:
                    IsComplete = true;
                    break;
            }
        }

        public void CreateTransportTasks()
        {
            // Generate tasks for workers to transport resources to the building site.
            foreach (var entry in Blueprint.RequiredResources)
            {
                for(int i = 0; i < entry.Value; i++)
                {
                    var transportTask = new TransportTask(Blueprint, entry.Key);
                    TaskManager.Instance.AddTask(transportTask);
                }
            }
            Blueprint.CurrentState = BuildingBlueprint.State.ResourcesGathered;  // For now, directly transition
        }
    }
}