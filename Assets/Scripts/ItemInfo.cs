using UnityEngine;
using System.Collections;

public class ItemInfo : MonoBehaviour
{

    public string nameInfo;

    public GameObject objectInfo;

    public GameObject objectPrefab;


    public void CreateItemInfo()
    {

        objectInfo = (GameObject)Instantiate(objectPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }
}
