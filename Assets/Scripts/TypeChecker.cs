﻿using UnityEngine;
using System.Collections;

public class TypeChecker : MonoBehaviour
{


    public string stringToBeChecked = ""; //what the user must type
    private string currentCheckedString = ""; //what the user is typing


    public int errorCounter = 0; //an error counter
    private int wordCounter = 0; //use to know wich letter must be compare

    /// <summary>
    /// Label to put the text on
    /// </summary>
    public UILabel label;
    public UILabel correctLabel;

    private bool isEnded = false;


    /// <summary>
    /// The item we are currently typing.
    /// </summary>
    protected Item currentItem;



    private GUIStyle stringToBeCheckedLabel;
    private GUIStyle currentCheckedStringLabel;


    void Start()
    {
        stringToBeCheckedLabel = new GUIStyle();
        stringToBeCheckedLabel.normal.textColor = Color.white;
        currentCheckedStringLabel = new GUIStyle();
    }

    void Update()
    {

        Item item = Plate.currentPlate.GetNextItem();
        if (item != null)
        {

            if (currentItem == null || currentItem != item)
            {
                isEnded = false;
                currentItem = item;
                currentCheckedString = "";
                wordCounter = 0;
                stringToBeChecked = currentItem.itemString;
            }
        }
        else
        {
            isEnded = true;            
            // stringToBeChecked = null;
        }
        if (!isEnded)
        {

            GetInputFromKeyBoard();
        }
        

    }


    /// <summary>
    /// Get the keyboard input and then it calls to the 
    /// WordChecker() method
    /// </summary>
    private void GetInputFromKeyBoard()
    {

        string currentCheckedStringCopy = currentCheckedString;
        foreach (char c in Input.inputString)
        {
            currentCheckedString += c;
            WordChecker(currentCheckedStringCopy);
        }
    }



    void LateUpdate()
    {
        label.text = stringToBeChecked;
        correctLabel.text = currentCheckedString;
    }

    /// <summary>
    /// Check if the current input correspond with the 
    /// stringToBeChecked global variable
    /// </summary>
    private void WordChecker(string currentCheckedStringCopy)
    {

        if (wordCounter >= stringToBeChecked.Length)
        {
            isEnded = true;
            Plate.currentPlate.ItemTypedRight();
        }
        else
        {
            if (!currentCheckedString[wordCounter].Equals(stringToBeChecked[wordCounter]))
            {
                correctLabel.color = Color.red;
                currentCheckedString = currentCheckedStringCopy;
                errorCounter++;
                currentCheckedStringLabel.normal.textColor = Color.red;
            }
            else
            {
                correctLabel.color = Color.green;
                currentCheckedStringLabel.normal.textColor = Color.green;
                wordCounter++;
            }
        }


    }


    
    void OnGUI()
    {
        GUI.Label(new Rect(0, 50, 100, 100), stringToBeChecked, stringToBeCheckedLabel);
        GUI.Label(new Rect(0, 50, 100, 100), currentCheckedString, currentCheckedStringLabel);
        GUI.Label(new Rect(50, 100, 100, 100), "Errores: " + errorCounter);
    }
}
