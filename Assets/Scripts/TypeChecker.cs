using UnityEngine;
using System.Collections;

public class TypeChecker : MonoBehaviour
{


    public string stringToBeChecked = "¿De qué color es el caballo blanco de santiago?"; //what the user must type
    private string currentCheckedString = ""; //what the user is typing
    private string currentCheckedStringCopy = ""; //what the user type before the next char

    public int errorCounter = 0; //an error counter
    private int wordCounter = 0; //use to know wich letter must be compare

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
        stringToBeCheckedLabel.normal.textColor = Color.gray;

        currentCheckedStringLabel = new GUIStyle();
    }

    void Update()
    {
		Item item = Plate.currentPlate.GetNextItem();
		if (item != null || currentItem == null)
		{
			if (currentItem == null || currentItem != item)
			{
				currentCheckedString = "";
				stringToBeChecked = currentItem.itemString;
			}
		}
		else
		{
			stringToBeChecked = null;
		}

		GetInputFromKeyBoard();
    }


    /// <summary>
    /// Get the keyboard input and then it calls to the 
    /// WordChecker() method
    /// </summary>
    private void GetInputFromKeyBoard()
    {
		if (stringToBeChecked == null)
		{
			return;
		}

        currentCheckedStringCopy = currentCheckedString;
        foreach (char c in Input.inputString)
        {
            currentCheckedString += c;
            WordChecker();
        }
    }

    /// <summary>
    /// Check if the current input correspond with the 
    /// stringToBeChecked global variable
    /// </summary>
    private void WordChecker()
    {
        if (wordCounter >= stringToBeChecked.Length)
        {
			Plate.currentPlate.ItemTypedRight();
            errorCounter++;
        }
        else
        {
            if (!currentCheckedString[wordCounter].Equals(stringToBeChecked[wordCounter]))
            {
                errorCounter++;
                currentCheckedString = currentCheckedStringCopy;
                currentCheckedStringLabel.normal.textColor = Color.red;
             
            }
            else
            {
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
