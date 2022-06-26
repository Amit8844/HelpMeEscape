using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    

    public GameObject window;
   
    public GameObject indicator;
 
    public TMP_Text dialogueText;
   
    public List<string> dialogues;

    public float writingSpeed;
    private int index;
    private int charIndex;
    private bool Started;
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


   
    public void StartDialogue()
    {
        if (Started)
            return;

        //Boolean to indicate that we have started
        Started = true;
        //show the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //started index at zero
        index = i;
        //reset the character index
        charIndex = 0;
        //clear the dialogue component text;
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }

    //End Dialogue
    public void EndDialogue()
    {
        //started is disabled
        Started = false;
        //disable wait for next as well
        waitForNext = false;
        //stop all Ienumerators
        StopAllCoroutines();
        //hide the window
        ToggleWindow(false);
    }

    //Writing Logic

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //writing the character
        dialogueText.text += currentDialogue[charIndex];
        //Increase the character index
        charIndex++;
        //make sure you have reached the end of the sentance

        if(charIndex < currentDialogue.Length)
        {
            //wait X seconds
            yield return new WaitForSeconds(writingSpeed);
            //restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            //End this sentance and wait for the next one
            waitForNext = true;
        }
    }

    private void Update()
    {
        if (!Started)
            return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
         { 
            waitForNext = false;
            index++;
         }

        

        //check if we are in the scope for dialogue List
        if (index < dialogues.Count)
        {
            //If so fetch the next dialogue
            GetDialogue(index);
        }
        else
        {
            //if not the end of the dialogue process
            ToggleIndicator(true);
            EndDialogue();
        }
        
    }
}
