using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Scanner : MonoBehaviour
{
    private void Start()
    {
        Invoke("DoSomeStuff", 0.3f);
    }

    void DoSomeStuff()
    {
        var data = AstarPath.active.data;
        GridGraph gridData = data.AddGraph(typeof(GridGraph)) as GridGraph;
        gridData.collision.use2D = true;
        gridData.center = transform.position;
        gridData.SetDimensions(10, 10, 1);
        gridData.rotation = true ? new Vector3(gridData.rotation.y - 90, 270, 90) : new Vector3(0, gridData.rotation.x + 90, 0);
        gridData.collision.mask = GameObject.FindObjectOfType<GameManager>().obstacleLayer;
        gridData.collision.diameter = 0.2f;
        gridData.Scan();
    }
}
