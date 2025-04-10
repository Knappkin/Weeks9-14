using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingtriangle : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 direction = mouse - transform.position;

        transform.up = direction;

        Vector2 pos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, mouse, 0.01f);
        
    }
}
