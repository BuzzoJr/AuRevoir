using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffset : MonoBehaviour
{
    public Material myMaterial;
    public float ofsetX = 0;
    public float ofsetY = 0;

    void Update()
    {
        float newOffsetX = myMaterial.mainTextureOffset.x + Time.deltaTime * ofsetX;
        float newOffsetY = myMaterial.mainTextureOffset.y + Time.deltaTime * ofsetY;

        if (newOffsetX > 1)
        {
            newOffsetX -= 1f;
        }

        if (newOffsetY > 1)
        {
            newOffsetY -= 1f;
        }

        myMaterial.mainTextureOffset = new Vector2(newOffsetX, newOffsetY);
    }
}
