using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }
    }
}
