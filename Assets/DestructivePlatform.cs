using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructivePlatform : MonoBehaviour
{ 
    [SerializeField]
     float time;
    
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject,time);
        }
    }
}
