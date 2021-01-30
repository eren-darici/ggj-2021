using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Scanner : MonoBehaviour
{
    AstarPath astar;

    private void Start()
    {
        astar = GetComponentInChildren<AstarPath>();
        astar.astarData.gridGraph.center = transform.position;
    }

}
