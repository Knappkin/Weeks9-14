using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class PointerEventsChallenge : MonoBehaviour
{
    public GameObject frog;
    public Sprite squintyFrog;
    public Sprite normalFrog;
    public GameObject parentCanvas;
    public GameObject heartReaction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Squint()
    {
        frog.GetComponent<Image>().sprite = squintyFrog;
    }

    public void unSquint()
    {
        frog.GetComponent<Image>().sprite = normalFrog;
    }

    public void makeHearth()
    {
        Vector3 spawnPos;
        spawnPos.x = Random.Range(0,Screen.width);
        spawnPos.y = Random.Range(0, Screen.height);
        spawnPos.z = 0;
        GameObject heartInstance = Instantiate(heartReaction, spawnPos, Quaternion.Euler(0,0,Random.Range(0,100)),parentCanvas.transform);
    }
}
