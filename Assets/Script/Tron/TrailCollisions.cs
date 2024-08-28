using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailCollisions : MonoBehaviour
{
    TrailRenderer myTrail;
    List<GameObject> trailColliders = new List<GameObject>();

    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();
    }

    void Update()
    {
        SetColliderPointsFromTrail(myTrail);
    }

    void SetColliderPointsFromTrail(TrailRenderer trail)
    {
        // Clear previous colliders
        foreach (var collider in trailColliders)
        {
            Destroy(collider);
        }
        trailColliders.Clear();

        // Create colliders along the trail
        for (int position = 0; position < trail.positionCount - 1; position++)
        {
            Vector3 start = trail.GetPosition(position);
            Vector3 end = trail.GetPosition(position + 1);

            // Create a new collider between these two points
            GameObject colliderObject = new GameObject("TrailColliderSegment");
            BoxCollider boxCollider = colliderObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;

            // Position the collider at the midpoint between the two trail positions
            colliderObject.transform.position = (start + end) / 2;

            // Set the collider's size and orientation
            boxCollider.size = new Vector3(0.1f, 0.1f, Vector3.Distance(start, end));
            colliderObject.transform.rotation = Quaternion.LookRotation(end - start);

            // Add the collider to the list
            trailColliders.Add(colliderObject);
        }
    }

    void OnDestroy()
    {
        foreach (var collider in trailColliders)
        {
            Destroy(collider);
        }
    }
}
