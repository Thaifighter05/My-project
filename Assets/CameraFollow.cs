using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new UnityEngine.Vector3 (followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
