using System;
using System.Collections.Generic;
using GPTSim.Storage;
using UnityEngine;
using UnityEngine.Events;

namespace GPTSim.Resources
{
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance { get; private set; }
        public UnityEvent OnResourceChanged = new();

        private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void RegisterStorage(StorageLocation storage)
        {
            storage.OnResourceAdded += AddResource;
            storage.OnResourceRemoved += RemoveResource;
        }

        private void AddResource(ResourceType type, int amount)
        {
            Debug.Log($"Resource added {type} {amount}");
            if (resources.ContainsKey(type))
                resources[type] += amount;
            else
                resources[type] = amount;
            
            Instance.OnResourceChanged.Invoke();
        }

        private void RemoveResource(ResourceType type, int amount)
        {
            if (resources.ContainsKey(type))
            {
                if( resources[type] <= amount)
                    resources[type] -= resources[type];
                else
                    resources[type] -= amount;

                Instance.OnResourceChanged.Invoke();

            }

        }

        public int GetResourceAmount(ResourceType type)
        {
            return resources.ContainsKey(type) ? resources[type] : 0;
        }

        // Other resource management methods...
    }
}
