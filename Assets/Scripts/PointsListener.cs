using UnityEngine;
using System.Collections;

public class PointsListener : MonoBehaviour {

    public UILabel label;

    void Start()
    {
        label = GetComponent<UILabel>();
    }

	// Update is called once per frame
	void Update ()
    {
        label.text = "Puntos: " + Plate.points.ToString();
	}
}
