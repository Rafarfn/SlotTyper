using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour {

	public static ItemManager instance;

	public List<GameObject> lista = new List<GameObject>();


	void Awake ()
	{
		instance = this;
	}

    public static GameObject CreateRandomObject()
    {
		int index = Random.Range(0, instance.lista.Count);
        GameObject newObject = GameObject.Instantiate(instance.lista[index]) as GameObject;
		return newObject;
    }
}
