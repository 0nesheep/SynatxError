using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SimpleRandomParameters_", menuName = "PCG/SimpleRandomWalkData")]
public class SimpleRandomWalk : ScriptableObject
{
   public int iterations = 10, walkLength = 10;
   public bool startRandomlyEveryIteration = true;
}
