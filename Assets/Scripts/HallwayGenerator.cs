using UnityEngine;
using System.Collections.Generic;

public class HallwayGenerator : MonoBehaviour
{
    public GameObject easyPrefab;
    public GameObject mediumPrefab;
    public GameObject hardPrefab;
    public GameObject introPrefab;

    public GameObject player;
    public Transform startPoint;

    private string lastDifficulty = "";
    private Transform currentSpawnPoint;
    private int hallwayCount = 0;

    void Start()
    {
        if (player != null && startPoint != null)
        {
            player.transform.position = startPoint.position;
        }

        // Spawn intro hallway
        GameObject intro = Instantiate(introPrefab, startPoint.position, startPoint.rotation);
        intro.name = "Intro_Easy";
        currentSpawnPoint = GetSpawnPoint(intro);

        // Prepare for first divergence when player hits end
        lastDifficulty = "Easy";
    }

    public void SpawnNextHallways()
    {
        List<string> options = new List<string> { "Easy", "Medium", "Hard" };
        options.Remove(lastDifficulty);

        // Pick 2 random difficulties
        string first = options[Random.Range(0, options.Count)];
        options.Remove(first);
        string second = options[Random.Range(0, options.Count)];

        SpawnHallway(first);
        SpawnHallway(second);
    }

    void SpawnHallway(string difficulty)
    {
        GameObject prefab = GetPrefabByDifficulty(difficulty);
        if (prefab == null || currentSpawnPoint == null) return;

        GameObject newHall = Instantiate(prefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
        newHall.name = $"{difficulty}_Hall_{++hallwayCount}";

        // Update spawn point for next hallway(s)
        currentSpawnPoint = GetSpawnPoint(newHall);
        lastDifficulty = difficulty;
    }

    GameObject GetPrefabByDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy": return easyPrefab;
            case "Medium": return mediumPrefab;
            case "Hard": return hardPrefab;
            default: return null;
        }
    }

    Transform GetSpawnPoint(GameObject hall)
    {
        foreach (Transform child in hall.GetComponentsInChildren<Transform>())
        {
            if (child.name.ToLower().Contains("spawn"))
                return child;
        }
        return null;
    }
}
