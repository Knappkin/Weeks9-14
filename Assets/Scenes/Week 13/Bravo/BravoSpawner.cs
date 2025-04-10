using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BravoSpawner : MonoBehaviour
{
    public GameObject prefab;

    public Slider scaleSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void spawnPrefab()
    {
        GameObject prefabInstance = Instantiate(prefab);
        Vector2 randomSpawn = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        prefabInstance.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(randomSpawn);
        prefabInstance.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        //scaleSlider.onValueChanged.AddListener(prefabInstance.start);
    }
}
