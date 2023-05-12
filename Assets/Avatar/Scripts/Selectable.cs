using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Selectable : MonoBehaviour
{
    [SerializeField] private Material materialHover; // Material que se aplicará cuando el mouse esté sobre el objeto
    private Material materialOriginal; // Material original del objeto
    
    private Renderer objectRenderer; // Renderer del objeto

    private void Start()
    {
        // Obtener el renderer y el material original del objeto
        objectRenderer = GetComponent<Renderer>();
        materialOriginal = objectRenderer.material;
    }

    private void OnMouseEnter()
    {
        // Cuando el mouse entra en el objeto, aplicar el materialHover
        objectRenderer.material = materialHover;
    }

    private void OnMouseExit()
    {
        // Cuando el mouse sale del objeto, volver a aplicar el material original
        objectRenderer.material = materialOriginal;
    }
}