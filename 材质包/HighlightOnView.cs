using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnView : MonoBehaviour
{
    public Camera mainCamera;
    public Material outlineMaterial;
    private Material[] originalMaterials;
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        originalMaterials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalMaterials[i] = renderers[i].material;
        }
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        bool isVisible = false;

        foreach (Renderer renderer in renderers)
        {
            if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
            {
                isVisible = true;
                break;
            }
        }

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = isVisible ? outlineMaterial : originalMaterials[i];
        }
    }
}

