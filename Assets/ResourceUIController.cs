using System.Collections;
using System.Collections.Generic;
using GPTSim.Resources;
using TMPro;
using UnityEngine;

public class ResourceUIController : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = ResourceManager.Instance;
        resourceManager.OnResourceChanged.AddListener(UpdateResourceText);
        resourceText = FindObjectOfType<TextMeshProUGUI>();
    }

    void UpdateResourceText()
    {
        Debug.Log("Updating Resource Text");
        resourceText.text = $"Resources\nWood: {resourceManager.GetResourceAmount(ResourceType.Wood)}\nStone: {resourceManager.GetResourceAmount(ResourceType.Stone)}";
    }
}