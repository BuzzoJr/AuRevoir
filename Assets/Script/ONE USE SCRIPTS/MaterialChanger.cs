using UnityEngine;
using System.Collections.Generic;

public class MaterialChanger : MonoBehaviour
{
    public List<Material> materials; // Lista de materiais a serem atribuídos
    private MeshRenderer meshRenderer;
    private int currentMaterialIndex = 0;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (materials.Count > 0)
        {
            meshRenderer.material = materials[currentMaterialIndex];
        }
    }

    public void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Count;
        meshRenderer.material = materials[currentMaterialIndex];
    }
}
