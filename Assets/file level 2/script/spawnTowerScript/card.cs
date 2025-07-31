using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Card/New card", fileName ="New card", order = 51)]
public class card : ScriptableObject
{
    public Sprite icon;
    public GameObject prefab;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
