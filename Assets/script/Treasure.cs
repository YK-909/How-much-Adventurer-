using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private Animator animtor;
    private int place;
    private int once;
    public int leftMin;
    public int leftMax;
    public int rightMin;
    public int rightMax;
    // Start is called before the first frame update
    void Start()
    {
        animtor = GetComponent<Animator>();
        place = Random.Range(0, 3);
        once = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (once == 0)
            {
                animtor.SetBool("open treasure ", true);
                once = 1;
            }
        }
    }
}
