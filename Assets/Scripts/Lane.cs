using UnityEngine;
using System.Collections;

/// <summary>
/// Represents "paths" where one plate is placed, and items fall towards it.
/// </summary>
public class Lane : MonoBehaviour
{
	/// <summary>
	/// The plate on this lane
	/// </summary>
	public Plate plate;

	/// <summary>
	/// Time between two consecutive items.
	/// </summary>
	public float timeBetweenItems = 15.0f;
	protected float timeSinceLastItem = 0;

	/// <summary>
	/// Prefab of item to clone.
	/// TODO: An ItemManager will deal with tihs
	/// </summary>
	public GameObject itemPrefab;

	/// <summary>
	/// Used to mark the position where the items got created
	/// </summary>
	public GameObject generationPlaceholder;


	public void CreateItem ()
	{
		if (plate != null)
		{
			GameObject itemObject = GameObject.Instantiate(itemPrefab, generationPlaceholder.transform.position, Quaternion.identity) as GameObject;
			plate.OnItemStartToFall(itemObject.GetComponent<Item>());

			// Set a movement direction for the item
			Item item = itemObject.GetComponent<Item>();
			if (item != null)
			{
				// Move towards the plate form the starting position
				item.movementDirection = plate.transform.position - generationPlaceholder.transform.position;
			}
		}
	}


	void Update ()
	{
		timeSinceLastItem += Time.deltaTime;
		if (timeSinceLastItem >= timeBetweenItems)
		{
			timeSinceLastItem = 0;
			CreateItem();
		}
	}

}
