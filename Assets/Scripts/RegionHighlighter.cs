using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RegionHighlighter : MonoBehaviour
{
    public static RegionHighlighter previous;
    
    [SerializeField] private Material materialHover; // Material que se aplicará cuando el mouse esté sobre el objeto
    [SerializeField] private Material materialOriginal; // Material original del objeto
    
    [SerializeField] private Renderer objectRenderer; // Renderer del objeto
    [SerializeField] private GameObject info;
    [SerializeField] private Button close;
    void Start()
    {
        materialOriginal = objectRenderer.material;
        GetComponent<Button>().onClick.AddListener(ShowInfo);
        close.onClick.AddListener(HideInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInfo()
    {
        info.SetActive(true);
        previous = this;
    }

    public void HideInfo()
    {
        if (previous != null)
        {
            previous.info.SetActive(false);
        }
       
    }
    
    public void HighlightRegion()
    {
        // Cuando el mouse entra en el objeto, aplicar el materialHover
        Debug.Log("Coma mierda Juanfer");
        objectRenderer.material = materialHover;
    }

    public void HideRegion()
    {
        // Cuando el mouse sale del objeto, volver a aplicar el material original
        Debug.Log("Pa que le dé más rabia, pirobo");
        objectRenderer.material = materialOriginal;
    }
}
