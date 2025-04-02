using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
using RPG.UI;
public class AIConversant : MonoBehaviour
{
    
    PlayerConversant playerConversant;
    [SerializeField] Dialogue dialogue = null;
    

    private bool canActivate;//simple bool to determine if the dialogue box can be activated
    public bool isPerson = true;


    // Update is called once per frame
    void Update()
    {
        canActivate = false;
        //if the bool is true AND the button is pressed then call the dialogue box
        if (canActivate && Input.GetButtonDown("E"))
        {
            //Playercontroller.GetComponent<PlayerConversant>().StartDialogue(dialogue);
        }
    }
    //allows dialogue to be activated
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }
    //prevents dialogue from being activated
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }

   
}
