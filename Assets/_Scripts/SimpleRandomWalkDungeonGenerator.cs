using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ItemPlacementScript;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    private SimpleRandomWalk randomWalkParameters;
    private Vector2Int startPosition = Vector2Int.zero;

    [SerializeField]
    public Transform player;

    [Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab;
        public String name;
    }

    public List<EnemyType> enemyTypes = new List<EnemyType>();
    private List<GameObject> generatedEnemies = new List<GameObject>();

    [SerializeField]
    public GameObject decor;
    private List<GameObject> generatedDecor = new List<GameObject>();

    public HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

    protected override void RunProceduralGeneration()
    {
        //HashSet<Vector2Int> floorPositions = RunRandomWalk();
        floorPositions = RunRandomWalk();
        tileMapVisualizer.ClearTiles();
        Debug.Log("hi i reached after clear tiles");

        tileMapVisualizer.PaintFloorTiles(floorPositions);
        Debug.Log("hi i reached after paint floor tiles");
        spawnEnemies(10);
        Debug.Log("hi i reached after spwan enemies");
        WallGenerator.CreateWalls(floorPositions, tileMapVisualizer);
        Debug.Log("hi i reached after create walls");
        
    }
    private void spawnEnemies(int number)
    {
        ClearEnemies();
        for (int i = 0; i < number; i++)
        {
            EnemyType selectedEnemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            Debug.Log("reached select Enemy");
            Debug.Log(floorPositions.Count);
            // Instantiate the selected enemy type prefab at a random position
            Vector2Int randomPosition = floorPositions.ElementAt(UnityEngine.Random.Range(0, floorPositions.Count));
            Vector2Int decorPos = floorPositions.ElementAt(UnityEngine.Random.Range(0, floorPositions.Count));

            GameObject newDecor = Instantiate(decor, new Vector3(decorPos.x, decorPos.y, 0f), Quaternion.identity);
            generatedDecor.Add(newDecor);

            GameObject newEnemy = Instantiate(selectedEnemyType.enemyPrefab, new Vector3(randomPosition.x, randomPosition.y, 0f ), Quaternion.identity);
            generatedEnemies.Add(newEnemy);

            EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
            RunEnemy runEnemy = newEnemy.GetComponent<RunEnemy>();

            if (enemyScript != null)
            {
                // Set the player data in the EnemyScript component
                enemyScript.player = player; // Assuming 'player' is a public Transform field in EnemyScript
            }
            if (runEnemy != null)
            {
                runEnemy.player = player;
            }
        }
    }
    private void ClearEnemies()
    {
        foreach (GameObject enemy in generatedEnemies)
        {
            DestroyImmediate(enemy);
        }

        foreach(GameObject decor in generatedDecor)
        {
            DestroyImmediate(decor);
        }

        // Clear the list
        generatedEnemies.Clear();
    }
    protected HashSet<Vector2Int> RunRandomWalk()
    {
        /*if (transform.position != null)
        {
            startPosition = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }
        else
        {
            Debug.LogError("PlayerScript is not assigned or does not have a valid reference to the player object.");
        }
        Debug.Log(startPosition);*/
        var currPosition = startPosition;
        HashSet<Vector2Int> floorPositions3 = new HashSet<Vector2Int>();


        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currPosition, randomWalkParameters.walkLength);
            floorPositions3.UnionWith(path);
            if(randomWalkParameters.startRandomlyEveryIteration)
            {
                currPosition = floorPositions3.ElementAt(UnityEngine.Random.Range(0, floorPositions3.Count));
            }
        }
        return floorPositions3;
    }

    
}
