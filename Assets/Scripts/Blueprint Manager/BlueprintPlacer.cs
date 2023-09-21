using Assets.Scripts.Blueprint_Manager.Buildings;
using UnityEngine;

namespace Assets.Scripts.Blueprint_Manager
{
    public class BlueprintPlacer : MonoBehaviour
    {
        public GameObject blueprintPrefab; // Set this in the Unity Editor

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
                worldPosition.z = 0;
                PlaceBlueprint(worldPosition);
            }
        }

        void PlaceBlueprint(Vector3 position)
        {
            GameObject newBlueprint = Instantiate(blueprintPrefab, position, Quaternion.identity);

            // Initialize your BuildingBlueprint script here, if you have one
            Building building = newBlueprint.GetComponent<Building>();
            if (building != null)
            {
                Vector2 blueprintLocation = new Vector2(position.x, position.z);
                building.Initialize(building.Blueprint);
                // Additional initialization
            }
        }
    }
}