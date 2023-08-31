using UnityEngine;

namespace Assets.Scripts.Blueprint_Manager
{
    public class BlueprintManager : MonoBehaviour
    {
        public static BlueprintManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void CreateBuilding(Vector2 location, BuildingBlueprint blueprint)
        {
            // TODO: Instantiate a GameObject and attach the blueprint to it
        }

        // More blueprint-related methods here...
    }
}