using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPTSim.Storage
{
    public class StorageManager : MonoBehaviour
    {
        public static StorageManager Instance;

        private List<StorageLocation> storageLocations;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            storageLocations = new List<StorageLocation>(FindObjectsOfType<StorageLocation>());
        }

        public StorageLocation FindNearestStorage(Vector2 position)
        {
            Debug.Log("Finding nearest storage");
            StorageLocation nearestStorage = null;
            float closestDistance = float.MaxValue;

            foreach (StorageLocation storage in storageLocations)
            {
                Debug.Log($"Checking storage {storage}");
                float distance = Vector2.Distance(position, storage.transform.position);
                if (distance < closestDistance)
                {
                    Debug.Log($"Closer storage found {storage}");
                    closestDistance = distance;
                    nearestStorage = storage;
                }
            }

            return nearestStorage;
        }

        public void AddStorage(StorageLocation storage)
        {
            if(storageLocations.Contains(storage)) return;
            storageLocations.Add(storage);
        }

        public void RemoveStorage(StorageLocation storage)
        {
            storageLocations.Remove(storage);
        }
    }
}