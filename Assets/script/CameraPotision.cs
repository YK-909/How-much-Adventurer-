using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPotision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Player = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(Player.x, Player.y + 7, Player.z - 4); ;
    }
}
