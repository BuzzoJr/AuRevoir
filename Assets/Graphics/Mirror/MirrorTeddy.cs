using UnityEngine;

public class MirrorTeddy : MonoBehaviour
{
    public GameObject mirror;
    public GameObject teddy;

    void Update()
    {
        // Mesma lógica que está em MirrorCamera
        transform.position = teddy.transform.position - 2 * Vector3.Dot(teddy.transform.position - mirror.transform.position, mirror.transform.up) * mirror.transform.up;

        Vector3 reflectedForward = teddy.transform.forward - 2 * Vector3.Dot(teddy.transform.forward, mirror.transform.up) * mirror.transform.up;
        Vector3 reflectedUp = teddy.transform.up - 2 * Vector3.Dot(teddy.transform.up, mirror.transform.up) * mirror.transform.up;
        transform.rotation = Quaternion.LookRotation(reflectedForward, reflectedUp);

        var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);
        Ray ray = Camera.main.ScreenPointToRay(viewportPos);
        RaycastHit hitPoint;
        if (!Physics.Raycast(ray, out hitPoint, Mathf.Infinity, layerMask: 1 << 10))
            return;

        if (hitPoint.transform == transform)
            Trigger();
    }

    public void Trigger()
    {
        var trigger = teddy.GetComponent<TeddybearGlitch>();
        if (trigger == null)
            return;

        trigger.Trigger();
    }
}
