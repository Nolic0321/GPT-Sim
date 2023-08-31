using System.Collections.Generic;
using GPTSim.Resources;
using UnityEngine;

namespace Assets.Scripts.Blueprint_Manager
{
    [System.Serializable]
    public class ResourceEntry
    {
        public ResourceType resourceType;
        public int amount;
    }
    
    [CreateAssetMenu(fileName = "NewBuildingBlueprint", menuName = "Building/Blueprint")]
    public class BuildingBlueprint: ScriptableObject
    {
        public enum State { NotStarted, ResourcesGathered, Constructing, Completed }

        public State CurrentState { get; set; }
        public Vector2 Location { get; set; }
        
        [SerializeField] private List<ResourceEntry> serializedRequiredResources = new List<ResourceEntry>();

        // Exposed method to convert the serialized list into a dictionary
        public Dictionary<ResourceType, int> RequiredResources
        {
            get
            {
                Dictionary<ResourceType, int> dict = new Dictionary<ResourceType, int>();
                foreach (var entry in serializedRequiredResources)
                {
                    dict[entry.resourceType] = entry.amount;
                }
                return dict;
            }
        }
        public Dictionary<ResourceType, int> GatheredResources { get; set; }

        public BuildingBlueprint(Vector2 location)
        {
            this.Location = location;
            this.CurrentState = State.NotStarted;
            this.GatheredResources = new Dictionary<ResourceType, int>();
        }

        public virtual void InitializeRequiredResources()
        {
            // Override this method in child classes to set RequiredResources
        }

        // Method to check if all required resources have been gathered
        public bool AreResourcesGathered()
        {
            foreach (var entry in RequiredResources)
            {
                if (!GatheredResources.ContainsKey(entry.Key) ||
                    GatheredResources[entry.Key] < entry.Value)
                {
                    return false;
                }
            }
            return true;
        }

        // Method to add a gathered resource to the blueprint
        public void AddResource(ResourceType type, int amount)
        {
            if (GatheredResources.ContainsKey(type))
            {
                GatheredResources[type] += amount;
            }
            else
            {
                GatheredResources[type] = amount;
            }
        }
        public void StartBuilding()
        {
            if (AreResourcesGathered() && CurrentState != State.Completed)
            {
                CurrentState = State.Constructing;
            }
        }

        public void CompleteBuilding()
        {
            if (CurrentState == State.Constructing)
            {
                CurrentState = State.Completed;
            }
        }

        // Additional methods for building logic, like starting building, completing building etc.
    }

}