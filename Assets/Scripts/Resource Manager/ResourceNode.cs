using GPTSim.Tasks;
using UnityEngine;

namespace GPTSim.Resources
{
    public class ResourceNode : MonoBehaviour
    {
        public ResourceType resourceType;
        private void OnMouseDown()
        {
            CreateHarvestTask();
        }

        private void CreateHarvestTask()
        {
            HarvestResourceTask harvestTask = new HarvestResourceTask(resourceType, transform.position);
            TaskManager.Instance.AddTask(harvestTask);
        }
    }

    public enum ResourceType
    {
        Stone,
        Wood
    }
}