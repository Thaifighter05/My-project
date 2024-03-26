using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
    
public class Blades : MonoBehaviour
{

    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    float speed;
    [SerializeField]
    Transform pos1;

    [SerializeField]
    Transform pos2;
    bool turnback;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
        if (transform.position.y >= pos1.position.y) 
        {
            turnback = true;
        }

        if (transform.position.y <= pos2.position.y)
        {
            turnback = false;
        }
        if (turnback)
        {
            transform.position = Vector2.MoveTowards(transform.position,pos2.position,speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,pos1.position,speed * Time.deltaTime);
        }
    }
}
