using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{   
    //fields
    //window
    public GameObject window;
    //indicator
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogues list
    public List<string>dialogues;
    //Writing speed
    public float writingSpeed;
    //index on dialogue
    private int index;
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
    //Start Dialogue
    public void StartDialogue()
    {
        if(started)
        return;
        //Boolean to indicate that we have started
        started = true;
        //Show the window
        window.SetActive(true);
        //hide the indicator
        ToggleIndicator(false);
        //start index at zero
        index = 0;
        //Start with first dialogue
        GetDialogue(0);
    }
     private void GetDialogue(int i)
     {
        //start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Writing());
     }

    //End Dialogue
    public void EndDialogue()
    {
        //Started is disabled
        started = false;
        //Disable wat for next as well
        waitForNext =false;
        //Stop all IEnumerators
        StopAllCoroutines(); 
        //hide the window
        ToggleWindow(false);
    }

    //Writing logic

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);
        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //Increase the character index
        charIndex++;
        //Make sure you have reached the end of sentence
         if(charIndex < currentDialogue.Length)
         {
              //wait x seconds
        yield return new WaitForSeconds(writingSpeed);
        //restart the same process
        StartCoroutine(Writing());
            //Hello (5 chars)
            //H 0
            //E 1
            //L 2
            //L 3
            //O 4
            //? 5
         }

         else
         {
            //end this sentence and wat for the next one
            waitForNext = true;
         }
      
    }

    private void Update() 
    {
        if(!started)
            return;
        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;
            //Check if we are in the scope of dialogues list
            if(index< dialogues.Count )
            {
                //If so fetch the next dialogue
                GetDialogue(index);
            }
            else
            {
                //If not end the dialogues process
                ToggleIndicator(true);
                EndDialogue();
            }
            
        }
    }


 
}
