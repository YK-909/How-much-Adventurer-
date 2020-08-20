using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public PlayerMove PlayerMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int bCount;
        bCount = PlayerMove.count;
        Debug.Log(bCount); //5
    }
}
