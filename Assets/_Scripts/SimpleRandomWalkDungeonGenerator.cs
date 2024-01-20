using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    private SimpleRandomWalk randomWalkParameters;


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tileMapVisualizer.ClearTiles();
        tileMapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tileMapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
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
