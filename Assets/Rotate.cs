using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
       float rotateSpeed1;

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(0,0,rotateSpeed1);
    }
}
