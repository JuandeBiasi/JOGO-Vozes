using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneInitiator : MonoBehaviour
{
    private CutSceneHandeler cutsceneHandler;

    public void Start()
    {
        cutsceneHandler = GetComponent<CutSceneHandeler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cutsceneHandler.PlayNextElement();
    }


}
