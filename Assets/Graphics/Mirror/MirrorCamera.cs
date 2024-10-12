using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    public GameObject mirrorCam;
    public GameObject mirror;

    void Update()
    {
        // Camera atual
        Camera mainCam = Camera.main;

        // Arrumando a posição e angulo da camera do espelho

        // The formula to reflect a point P across a plane with a normal N and a point on the plane A is:
        //     Preflected = P - 2 * proj_N(P - A)
        //
        // Where:
        // - proj_N(V) is the projection of vector V onto the normal N.
        // - A is a point on the mirror plane.
        // - N is the normal vector of the plane.
        //
        // This formula computes the reflection of point P (camera position) across the plane defined by the point A and the normal N.

        // Posição
        mirrorCam.transform.position = mainCam.transform.position - 2 * Vector3.Dot(mainCam.transform.position - mirror.transform.position, mirror.transform.up) * mirror.transform.up;

        // Direção da frente
        Vector3 reflectedForward = mainCam.transform.forward - 2 * Vector3.Dot(mainCam.transform.forward, mirror.transform.up) * mirror.transform.up;

        // Direção de cima
        Vector3 reflectedUp = mainCam.transform.up - 2 * Vector3.Dot(mainCam.transform.up, mirror.transform.up) * mirror.transform.up;

        // Aplicando a rotação
        mirrorCam.transform.rotation = Quaternion.LookRotation(reflectedForward, reflectedUp);
    }
}
