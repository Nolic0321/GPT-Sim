using System;
using System.Collections.Generic;
using GPTSim.Resources;
using GPTSim.Tasks;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float reachTolerance = 0.1f;

    private ITask currentTask;
    private TaskManager taskManager;
    private Vector2 moveToTarget;
    private bool isTaskPerformed = true;
    private Dictionary<ResourceType, int> inventory = new Dictionary<ResourceType, int>();


    private void Start()
    {
        taskManager = TaskManager.Instance;
    }

    private void Update()
    {
        if (currentTask == null)
        {
            Debug.Log($"{name} is getting a new task");
            currentTask = taskManager.GetNextTask();
            if (currentTask != null)
            {
                Debug.Log($"New task assigned to {name}");
                currentTask.AssignWorker(this);
            }
        }
        else
        {
            Debug.Log($"{name} doing task {currentTask}");
            currentTask.Update();
            if (currentTask.IsComplete)
            {
                currentTask = null;
            }
        }
    }


    public void AddToInventory(ResourceType resourceType, int amount)
    {
        if (inventory.ContainsKey(resourceType))
        {
            inventory[resourceType] += amount;
        }
        else
        {
            inventory[resourceType] = amount;
        }

        Debug.Log($"Added {amount} of {resourceType} to inventory.");
    }

    public int GetResourceAmount(ResourceType resourceType)
    {
        if (inventory.ContainsKey(resourceType))
        {
            return inventory[resourceType];
        }

        return 0;
    }

    public bool HasResource(ResourceType resourceType, int amount)
    {
        return GetResourceAmount(resourceType) >= amount;
    }

    public void RemoveFromInventory(ResourceType resourceType, int amount)
    {
        if (HasResource(resourceType, amount))
        {
            inventory[resourceType] -= amount;
        }
        // Optionally, handle case where you try to remove more than exists
    }

    public void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }

    public void SetCurrentTask(ITask task)
    {
        currentTask = task;
    }

    public Dictionary<ResourceType,int> RemoveInventory()
    {
        var temp = new Dictionary<ResourceType, int>(inventory);
        inventory.Clear();
        return temp;
    }
}