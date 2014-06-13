using UnityEngine;
using System.Collections;

public class ItemInfo : MonoBehaviour
{

    public string nameInfo;

    public GameObject objectInfo;

    public static ItemInfo instance;

    void Awake()
    {
        instance = new ItemInfo();
    }

    public void CreateItemInfo()
    {

        Instantiate(objectInfo, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }
}
