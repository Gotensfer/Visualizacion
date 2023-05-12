using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWaypoint : MonoBehaviour
{
    [Header("Episodio que contiene este punto de ruta\n¡Esto se asigna por codigo automaticamente al darle Play!")]
    public int episode;
    
    public void RenderPathToThisEpisode()
    {
        PathRenderer.instance.RenderPath(episode);
    }

    private void OnMouseDown()
    {
        InfoRenderer.instance.DisplayEpisodeInfo(episode);
    }
}
