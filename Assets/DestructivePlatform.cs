using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructivePlatform : MonoBehaviour
{
     float time;
     [SerializeField]
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject,time);
        }
    }
}
