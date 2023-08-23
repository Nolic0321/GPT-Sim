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
    private List<ResourceType> inventory = new List<ResourceType>();

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
            if(currentTask != null)
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


    public void AddToInventory(ResourceType resourceType)
    {
        Debug.Log($"Adding resource {resourceType} to inventory");
        inventory.Add(resourceType);
    }

    public void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }

    public ResourceType RemoveInventory()
    {
        var resourceType = inventory[0];
        inventory.RemoveAt(0);
        return resourceType;
    }

    public void SetCurrentTask(ITask task)
    {
        currentTask = task;
    }
}