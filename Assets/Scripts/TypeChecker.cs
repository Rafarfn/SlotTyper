using UnityEngine;
using System.Collections;

public class TypeChecker : MonoBehaviour
{


    public string stringToBeChecked ="pera";
    private string currenteCheckedString="asd";
    public bool isCorrect = true;
    private int wordCounter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // GetKeys();
        if (Input.anyKeyDown)
        {
            Debug.Log(Input.inputString);
        }
    }

    private void GetKeys()
    {
        if (Input.anyKeyDown )
        {
            currenteCheckedString += Input.inputString;
            Debug.Log(Input.inputString);
           /* if (currenteCheckedString[wordCounter].Equals(stringToBeChecked[wordCounter]))
            {
                isCorrect = true;
            }
            else
            {
                
                isCorrect = false;
            }*/
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(50,50,100,20), currenteCheckedString);
    }
}
