using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public static PathRenderer instance;

    [Header("Puntos de ruta de los caminos\nLos puntos de ruta son respectivos a los episodios")]
    public Transform[] pathWaypoints;

    [Header("Indicadores de episodios")]
    [SerializeField] int bookOfEarthStartEpisode;
    [SerializeField] int bookOfFireStartEpisode;
    [SerializeField] int finalEpisode;

    [Header("Renderers de los caminos")]
    [SerializeField] LineRenderer waterPathRenderer;
    [SerializeField] LineRenderer earthPathRenderer;
    [SerializeField] LineRenderer firePathRenderer;

    [Header("Debug mode\n\n'Espacio' -> Activar\n'Q' -> Desactivar\nep -> Episodio a mostrar")]
    [Tooltip("El episodio que se mostrara al usar 'Espacio' del modo Debug")]
    public int ep;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < pathWaypoints.Length; i++)
        {
            if (pathWaypoints[i].TryGetComponent<PathWaypoint>(out PathWaypoint path))
            {
                path.episode = i;
            }
            else
            {
                pathWaypoints[i].AddComponent<PathWaypoint>().episode = i;
                pathWaypoints[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RenderPath(ep);
            
            for (int i = ep - 1; i < finalEpisode; i++)
            {
                pathWaypoints[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < ep; i++)
            {
                pathWaypoints[i].gameObject.SetActive(true);
            }

            ep = Mathf.Clamp(ep + 1, 0, finalEpisode);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            HidePaths();
        }
    }

    public void RenderPath(int selectedEpisode)
    {
        HidePaths();

        RenderWaterPath(selectedEpisode);
        RenderEarthPath(selectedEpisode);
        RenderFirePath(selectedEpisode);
    }

    public void HidePaths()
    {
        waterPathRenderer.positionCount = 0;
        earthPathRenderer.positionCount = 0;
        firePathRenderer.positionCount = 0;
    }

    private void RenderWaterPath(int episode)
    {
        int maxEpisodePathToRender = Mathf.Clamp(episode - 1, 0, bookOfEarthStartEpisode - 1);
        

        if (maxEpisodePathToRender >= 1) // Si no es el episodio 1
        {
            waterPathRenderer.positionCount = maxEpisodePathToRender + 1; 

            for (int i = 0; i <= maxEpisodePathToRender; i++)
            {
                
                waterPathRenderer.SetPosition(i, pathWaypoints[i].position);
            }
        }    
    }

    private void RenderEarthPath(int episode)
    {
        int maxEpisodePathToRender = Mathf.Clamp(episode - 1, bookOfEarthStartEpisode - 1, bookOfFireStartEpisode - 1);
        print(maxEpisodePathToRender);
        if (maxEpisodePathToRender >= bookOfEarthStartEpisode) // Si no es el episodio inicial del libro de tierra
        {
            earthPathRenderer.positionCount = maxEpisodePathToRender - bookOfEarthStartEpisode + 2;

            for (int i = 0; i < earthPathRenderer.positionCount; i++)
            {
                print(i);
                earthPathRenderer.SetPosition(i, pathWaypoints[i + bookOfEarthStartEpisode - 1].position);
            }
        }
    }

    private void RenderFirePath(int episode)
    {
        int maxEpisodePathToRender = Mathf.Clamp(episode - 1, bookOfFireStartEpisode - 1, finalEpisode - 1);

        if (maxEpisodePathToRender >= bookOfFireStartEpisode) // Si no es el episodio inicial del libro de tierra
        {
            firePathRenderer.positionCount = maxEpisodePathToRender - bookOfFireStartEpisode + 2;

            for (int i = 0; i < firePathRenderer.positionCount; i++)
            {
                firePathRenderer.SetPosition(i, pathWaypoints[i + bookOfFireStartEpisode - 1].position);
            }
        }
    }
}
