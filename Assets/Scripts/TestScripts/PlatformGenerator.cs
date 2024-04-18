using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // Assign your platform prefab in the inspector
    public int width = 10; // The number of platforms in the X direction
    public int depth = 10; // The number of platforms in the Z direction
    public float spacing = 5.0f; // The space between platforms

    void Start()
    {
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        float currentY = 0.0f; // Starting Y position

        // Loop through each row (depth)
        for (int z = 0; z < depth; z++)
        {
            float currentX = z * 7.0f; // Offset each row on the X to stagger the platforms

            // Loop through each column (width)
            for (int x = 0; x < width; x++)
            {
                // Calculate the position for the new platform
                Vector3 position = new Vector3(currentX, currentY, z * spacing);
            
                // Instantiate the platform at the calculated position
                Instantiate(platformPrefab, position, Quaternion.identity);

                // Increment the X position for the next platform
                currentX += 7.0f; 
            }
            // Increment the Y position after each row
            currentY += 3.5f; 
        }
    }

}