using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected;
    //Dete trigger with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if we trigger the player enable playerdetected and show indicator
        if(other.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

     private void OnTriggerExit2D(Collider2D other)
     {
        //If we lost Triger with the player, disable playerdetected and hide indicator
            if(other.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
        
     }
    //Detected trigger with player X
    //If detected show indicator X
    //If not detected hide indicator X
    //While detected if we interact start the dialogue
    private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}
