using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Tank Settings")]
    [SerializeField] private List<GameObject> tankPrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Transform waypointContainer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SpawnTanks();
    }

    private void SpawnTanks()
    {
        if (tankPrefabs.Count == 0 || spawnPoints.Count == 0)
        {
            Debug.LogError("Missing tank prefabs or spawn points in GameManager!");
            return;
        }

        if (waypointContainer == null || waypointContainer.childCount == 0)
        {
            Debug.LogError("Waypoint container not set or empty!");
            return;
        }

        // Get all waypoints from the container
        Transform[] waypoints = new Transform[waypointContainer.childCount];
        for (int i = 0; i < waypointContainer.childCount; i++)
        {
            waypoints[i] = waypointContainer.GetChild(i);
        }

        // Keep track of used spawn points to avoid duplicates
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        // Spawn tanks at random points
        for (int i = 0; i < Mathf.Min(tankPrefabs.Count, spawnPoints.Count); i++)
        {
            if (availableSpawnPoints.Count == 0)
            {
                Debug.LogWarning("Not enough spawn points for all tanks!");
                break;
            }

            // Pick a random spawn point
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform chosenSpawnPoint = availableSpawnPoints[randomIndex];
            availableSpawnPoints.RemoveAt(randomIndex); // Remove the chosen point to avoid reusing it

            // Instantiate the tank at the random spawn point
            GameObject tank = Instantiate(
                tankPrefabs[i],
                chosenSpawnPoint.position,
                chosenSpawnPoint.rotation
            );

            // Configure StateController
            StateController stateController = tank.GetComponent<StateController>();
            if (stateController != null)
            {
                stateController.SetupAI(true, waypoints);
            }
            else
            {
                Debug.LogWarning($"Tank prefab {tankPrefabs[i].name} is missing StateController!");
            }
        }
    }


    // Add optional helper method for easy access in editor
    public void SetWaypointContainer(Transform container)
    {
        waypointContainer = container;
    }
}
