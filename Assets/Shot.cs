using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
     [SerializeField]
     float speed = 8;
      
    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(speed, 0) * Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.x > Camera.main.orthographicSize + 5)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
    


}
