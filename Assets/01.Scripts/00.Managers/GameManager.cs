using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager Start ! ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
