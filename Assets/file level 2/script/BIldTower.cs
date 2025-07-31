using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BIldTower : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < Size.y; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color =  new Color(0f,1f,0f,0.1f);
                Gizmos.DrawCube(transform.position + new Vector3(x,y), new  Vector3 (1,1f,1));
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
