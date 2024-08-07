using UnityEngine;

public class CircleLayout : MonoBehaviour
{
    public GameObject prefab; // Your prefab to spawn
    public int numberOfItems; // Number of prefabs to spawn
    public float radius = 5f; // Radius of the circle

    private void Start()
    {
        PopulateCircle();
    }

    private void PopulateCircle()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            // Calculate the angle at which to place the prefab
            float angle = i * 360f / numberOfItems;
            Vector3 position = CalculatePosition(angle);
            Instantiate(prefab, position, Quaternion.identity, this.transform);
        }
    }

    private Vector3 CalculatePosition(float angle)
    {
        // Convert angle from degrees to radians
        float radian = angle * Mathf.Deg2Rad;

        // Calculate x and y position
        float x = radius * Mathf.Cos(radian);
        float y = radius * Mathf.Sin(radian);

        // Adjust position based on the transform's position
        return new Vector3(x + transform.position.x, y + transform.position.y, 0);
    }
}
