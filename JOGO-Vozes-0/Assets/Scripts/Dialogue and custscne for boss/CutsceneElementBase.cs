using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneElementBase : MonoBehaviour
{
    public float duration;
    public CutSceneHandeler cutsceneHandler {  get; private set; }

    public void Start()
    {
        cutsceneHandler = GetComponent<CutSceneHandeler>();
    }

    public virtual void Execute()
    {

    }

    protected IEnumerator WaitAndAdvance()
    {
        yield return new WaitForSeconds(duration);
        cutsceneHandler.PlayNextElement();
    }


}
