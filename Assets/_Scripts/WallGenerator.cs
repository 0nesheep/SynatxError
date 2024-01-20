using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tileMapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.CardinalDirectionList);
        foreach (var wallPosition in basicWallPositions)
        {
            tileMapVisualizer.PaintSingleBasicWall(wallPosition);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionsList)
            {
                var neighborPos = position + direction;
                if (floorPositions.Contains(neighborPos) == false)
                {
                    wallPositions.Add(neighborPos);
                }

            }
        }
        return wallPositions;
    }
}
