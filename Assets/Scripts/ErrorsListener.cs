using UnityEngine;
using System.Collections;

public class ErrorsListener : MonoBehaviour {

    public UILabel label;

    void Start()
    {
        label = GetComponent<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = "Errores: " + TypeChecker.errorCounter.ToString();
    }
}
