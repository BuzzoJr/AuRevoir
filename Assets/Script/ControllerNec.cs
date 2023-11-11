using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerNec : MonoBehaviour {
    public GameObject cameraScene;
    public GameObject allBody;
    public GameObject target;
    public PanelNec panelScrpt;
    public float speed = 5f;
    private int pos = 0;
    private bool panelClick;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f)) {
                if (raycastHit.transform != null) {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

        Vector3 currentPosition = allBody.transform.position;
        Vector3 targetPosition = new Vector3(target.transform.position.x, currentPosition.y, currentPosition.z);
        allBody.transform.position = Vector3.Lerp(currentPosition, targetPosition, speed * Time.deltaTime);
    }

    public void CurrentClickedGameObject(GameObject gameObject) {
        if(gameObject.name == "Left") {
            if(pos > 0) {
                MoveBody(5f);
                pos--;
            }
        }
        else if(gameObject.name == "Right") {
            if(pos < 7) {
                MoveBody(-5f);
                pos++;
            }
        }
        else if(gameObject.name == "RedButton") {
        }
        else if(gameObject.name == "Panel") {
            if(!panelClick) {
                cameraScene.transform.rotation = Quaternion.Euler(24, 360, 0);
                cameraScene.GetComponent<Camera>().fieldOfView = 30;
            }
            else {
                cameraScene.transform.rotation = Quaternion.Euler(8, 360, 0);
                cameraScene.GetComponent<Camera>().fieldOfView = 75;
            }

            panelClick = !panelClick;
        }
        else if(gameObject.name == "Exit") {
            panelScrpt.exitPanel();
        }
    }

    public void MoveBody(float qtd) {
        Vector3 currentPosition = target.transform.position;
        currentPosition.x += qtd;
        target.transform.position = currentPosition;
    }
}
