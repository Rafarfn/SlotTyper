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


	void Start ()
	{
		timeSinceLastItem = timeBetweenItems;
	}

	public void CreateItem ()
	{
		if (plate != null)
		{
			GameObject itemObject = GameObject.Instantiate(itemPrefab, generationPlaceholder.transform.position, Quaternion.identity) as GameObject;
			
			Item item = itemObject.GetComponentInChildren<Item>();

			plate.OnItemStartToFall(item);

			// Set a movement direction for the item
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
