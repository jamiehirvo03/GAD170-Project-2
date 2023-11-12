using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextDisplay : MonoBehaviour
{
    public Text myText;

    public Button approveButton;
    public Button declineButton;
    public Button nextTurnButton;

    public TextMeshProUGUI nextTurnText;

    private bool isProblem = false;

    // Start is called before the first frame update
    void Start()
    {
        nextTurnButton.interactable = false;
    }

    //This function will add text to the field
    public void AddText(string textToAdd)
    {
        if (!isProblem)
        {
            myText.text += textToAdd;
        }
        else
        {
            myText.text = textToAdd;
        }
    }

    //This function clears the text field
    public void ClearText()
    {
        myText.text = " ";
    }

    //This function clears the text field, prints an error message and prevents any further text being added
    public void Problems()
    {
        isProblem = true;
        ClearText();
        AddText("There has been an error!");

    }

    public void NextTurnEnable()
    {
        //Disables the 'Approve' and 'Decline' buttons to signal when their choice has been made and no longer need to press the buttons on this turn
        approveButton.interactable = false;
        declineButton.interactable = false;

        //Enables the 'Next Turn' button, indicating to the player how they continue to the next turn
        nextTurnButton.interactable = true;
    }
    public void NextTurnDisable()
    {
        //Enables the 'Approve' and 'Decline' buttons to signal when they can make their choice
        approveButton.interactable = true;
        declineButton.interactable = true;

        //Disables the 'Next Turn' button, indicating when they are not able to continue to the next turn as their input is being waited on
        nextTurnButton.interactable = false;
    }

    //Changes the 'Next Turn' button into a 'New Game Button'
    public void NewGameButton()
    {
        nextTurnText.text = "New Game";
    }

    //Changes the 'New Game' button back to the 'Next Turn button' when new game is started
    public void NextTurnButton()
    {
        nextTurnText.text = "Next Turn";
    }
}
