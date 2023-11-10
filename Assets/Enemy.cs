using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void Start()
    {
        float x = Random.Range(-5f, 5f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 1);

        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        float speed = 4;
        
        Vector2 movement = Vector2.left * speed * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.x < -Camera.main.orthographicSize - 1)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
