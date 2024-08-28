using UnityEngine;

public class PlayerControllerTron : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject trailPrefab;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        HandleMovement();
        //CreateTrail();
    }

    void HandleMovement()
    {
        // Movimento contínuo para frente
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -90f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 90f);
        }
    }

    void CreateTrail()
    {
        if (Vector3.Distance(lastPosition, transform.position) >= 1f)
        {
            Instantiate(trailPrefab, lastPosition, Quaternion.identity);
            lastPosition = transform.position;
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log("Player morreu!");

    //    }
    //}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Player morreu!");
        }
    }
}
