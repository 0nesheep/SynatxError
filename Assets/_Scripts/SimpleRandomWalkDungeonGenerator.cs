using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    private SimpleRandomWalk randomWalkParameters;
    private Vector2Int startPosition = Vector2Int.zero;


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tileMapVisualizer.ClearTiles();
        tileMapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tileMapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        if (transform.position != null)
        {
            startPosition = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }
        else
        {
            Debug.LogError("PlayerScript is not assigned or does not have a valid reference to the player object.");
        }
        Debug.Log(startPosition);
        var currPosition = startPosition;
        HashSet<Vector2Int> floorPostions = new HashSet<Vector2Int>();  

        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currPosition, randomWalkParameters.walkLength);
            floorPostions.UnionWith(path);
            if(randomWalkParameters.startRandomlyEveryIteration)
            {
                currPosition = floorPostions.ElementAt(Random.Range(0, floorPostions.Count));
            }
        }
        return floorPostions;
    }
}
