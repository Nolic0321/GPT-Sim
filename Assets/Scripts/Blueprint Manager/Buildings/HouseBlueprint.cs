using GPTSim.Resources;
using UnityEngine;

namespace Assets.Scripts.Blueprint_Manager.Buildings
{
    public class HouseBlueprint : BuildingBlueprint
    {
        public HouseBlueprint(Vector2 location) : base(location)
        {
            InitializeRequiredResources();
        }

        public override void InitializeRequiredResources()
        {
            RequiredResources[ResourceType.Wood] = 50;
            RequiredResources[ResourceType.Stone] = 20;
        }
    }

}