using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stan : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GameObject.Find("Player").transform.position;
        float speed = 2.0f;

        //範囲を指定してあげると大きな円、小さな円を実装できます。
        pos.x += Mathf.Sin(Time.time * speed) * 0.4f;
        pos.z += Mathf.Cos(Time.time * speed) * 0.4f;
        pos.y = 0.3f;
        transform.position = pos;
    }
}
