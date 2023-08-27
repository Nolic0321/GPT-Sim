using System;
using System.Collections.Generic;
using GPTSim.Resources;
using UnityEngine;

namespace GPTSim.Storage
{
    public class StorageLocation : MonoBehaviour
    {
        public event Action<ResourceType, int> OnResourceAdded;
        public event Action<ResourceType, int> OnResourceRemoved;

        private Dictionary<ResourceType, int> localResources = new Dictionary<ResourceType, int>();

        private void Start()
        {
            // Register this storage location with the ResourceManager
            ResourceManager.Instance.RegisterStorage(this);
            StorageManager.Instance.AddStorage(this);
        }

        public void AddResource(ResourceType type, int amount)
        {
            if (localResources.ContainsKey(type))
                localResources[type] += amount;
            else
                localResources[type] = amount;

            // Notify the ResourceManager of the resource addition
            OnResourceAdded?.Invoke(type, amount);
        }

        public void AddResources(Dictionary<ResourceType, int> resources)
        {
            foreach (var resource in resources)
            {
                AddResource(resource.Key,resource.Value);
            }
        }

        public void RemoveResource(ResourceType type, int amount)
        {
            if (localResources.ContainsKey(type))
            {
                localResources[type] -= amount;

                // You may want to prevent negative amounts
                if (localResources[type] < 0) localResources[type] = 0;

                // Notify the ResourceManager of the resource removal
                OnResourceRemoved?.Invoke(type, amount);
            }
        }

        public int GetLocalResourceAmount(ResourceType type)
        {
            return localResources.ContainsKey(type) ? localResources[type] : 0;
        }

        // Other methods to handle specific storage functionalities...
    }
}