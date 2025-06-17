using UnityEngine;

public class TechHallwayGenerator : MonoBehaviour
{
    public Material wallMaterial;
    public Material floorMaterial;
    public Material ceilingMaterial;
    public GameObject playerPrefab;          // Reference to player prefab
    public int length = 10;
    public float width = 4f;
    public float height = 3f;

    private GameObject playerInstance;

    void Start()
    {
        GenerateHallway();
        PlacePlayerAtStart();
    }

    void GenerateHallway()
    {
        for (int i = 0; i < length; i++)
        {
            Vector3 offset = new Vector3(0, 0, i * 4f);

            // Floor
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(width, 0.2f, 4f);
            floor.transform.position = new Vector3(0, -0.1f, 0) + offset;
            floor.GetComponent<Renderer>().material = floorMaterial;

            // Ceiling
            GameObject ceiling = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ceiling.transform.localScale = new Vector3(width, 0.2f, 4f);
            ceiling.transform.position = new Vector3(0, height + 0.1f, 0) + offset;
            ceiling.GetComponent<Renderer>().material = ceilingMaterial;

            // Left wall
            GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leftWall.transform.localScale = new Vector3(0.2f, height, 4f);
            leftWall.transform.position = new Vector3(-width / 2f, height / 2f, 0) + offset;
            leftWall.GetComponent<Renderer>().material = wallMaterial;

            // Right wall
            GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rightWall.transform.localScale = new Vector3(0.2f, height, 4f);
            rightWall.transform.position = new Vector3(width / 2f, height / 2f, 0) + offset;
            rightWall.GetComponent<Renderer>().material = wallMaterial;

            // Neon Strip
            GameObject neonStrip = GameObject.CreatePrimitive(PrimitiveType.Cube);
            neonStrip.transform.localScale = new Vector3(0.1f, 0.1f, 3.5f);
            neonStrip.transform.position = new Vector3(0, 0.1f, 0) + offset;
            Renderer r = neonStrip.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Standard"));
            r.material.color = Color.cyan;
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", Color.cyan * 1.5f);
        }
    }

    void PlacePlayerAtStart()
    {
        if (playerPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(0, 1f, -2f); // Slightly behind the hallway
            playerInstance = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No player prefab assigned in TechHallwayGenerator.");
        }
    }
}
