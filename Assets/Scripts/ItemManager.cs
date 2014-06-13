using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour {

    public static List<ItemInfo> lista = new List<ItemInfo>();

    public static ItemInfo CreateRandomObject()
    {
        int index = Random.Range(0, lista.Count);
        lista[index].CreateItemInfo();
        return lista[index];
    }
}
