using GPTSim.Tasks;
using UnityEngine;

namespace Assets.Scripts.Blueprint_Manager.Buildings
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        private BuildingBlueprint _blueprint;

        public BuildingBlueprint Blueprint 
        { 
            get { return _blueprint; } 
            private set { _blueprint = value; }
        }
        public bool IsCompleted { get; private set; } = false;

        public void Initialize(BuildingBlueprint blueprint)
        {
            this.Blueprint = blueprint;
            // Set this game object's position based on the Blueprint's Location
            // This is necessary if the user doesn't place the building via a mouse click
            // Commenting out for now
            // transform.position = new Vector3(Blueprint.Location.x, 0, Blueprint.Location.y);
            Debug.Log($"{name}: building started");
            TaskManager.Instance.AddTask(new BuildingTask(Blueprint));
        }

        public void UpdateBuilding()
        {
            if (Blueprint.CurrentState == BuildingBlueprint.State.ResourcesGathered)
            {
                // Logic to build the structure here
                Blueprint.StartBuilding();
                Debug.Log($"{name}: resources gathered, ready to construct");
            }
            
            if (Blueprint.CurrentState == BuildingBlueprint.State.Constructing)
            {
                // Logic to build the structure here
                IsCompleted = true;
                Blueprint.CompleteBuilding();
                Debug.Log($"{name}: building finished");
            }
        }
    }
}