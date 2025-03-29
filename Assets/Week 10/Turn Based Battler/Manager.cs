using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public Canvas uiCanvas;
    public Button buttonA;
    public Button buttonB;

public void attackPressed(Button attackButton)
    {
        StartCoroutine(ControlButtons(attackButton));
    }
private IEnumerator ControlButtons(Button attackButton)
    {
        yield return null;
    }
}
