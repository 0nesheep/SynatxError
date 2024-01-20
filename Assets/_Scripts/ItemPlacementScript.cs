using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementScript : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab;
        public String name;
    }

    public void spawnEnemies(HashSet<Vector2Int> floorPositions)
    {
        if (floorPositions != null)
        {
            Debug.Log(floorPositions.Count);
        }
    }
    
    
}
