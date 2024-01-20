using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField]
    protected TileMapVisualizer tileMapVisualizer = null;

    public void GenerateDungeon()
    {
        tileMapVisualizer.ClearTiles();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
