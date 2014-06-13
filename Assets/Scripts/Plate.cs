using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Script for the plates in the middle of the screen, which get lowered when the Items
/// get dropped on it
/// </summary>
public class Plate : MonoBehaviour
{

	/// <summary>
	/// The currently selected plate
	/// </summary>
	public static Plate currentPlate;

	/// <summary>
	/// Current list of items in the 
	/// </summary>
	protected List<Item> items = new List<Item>();

	/// <summary>
	/// Items that are falling in the same lane, but have not reached
	/// the plate (yet).
	/// </summary>
	protected Queue<Item> itemsFalling = new Queue<Item>();


	/// <summary>
	/// The plate accessed when the wants to go to another plate from this one.
	/// </summary>
	public Plate nextPlate;

	/// <summary>
	/// The initial position, where the plate is when it has no items over it
	/// </summary>
	public Vector3 standByPosition;

	/// <summary>
	/// The size of every step.
	/// </summary>
	public Vector3 stepSize;



	void Start ()
	{
		standByPosition = transform.position;
	}


	void Update ()
	{
		// TODO: Move to the position depending on the current number of items queued
		int itemsOnPlate = items.Count;

		if (itemsOnPlate > 0)
		{
			// Move the plate to a position according to the number of elements queued
			//transform.Translate(Vector3.Lerp(transform.position, standByPosition - stepSize * itemsOnPlate, Time.deltaTime));

		}

	}


	void OnDestroy ()
	{
		if (currentPlate == this)	currentPlate = null;
	}


	/// <summary>
	/// Returns the next item in the queue, or the one that is falling to this
	/// plate. Returns null if there is no Item
	/// </summary>
	/// <returns>The next item.</returns>
	public Item GetNextItem ()
	{
		if (items.Count == 0)
		{
			if (itemsFalling.Count == 0)	return null;

			return itemsFalling.Peek();
		}

		return items[0];
	}

	/// <summary>
	/// Called when the last item in the queue was typed properly.
	/// Also, if the item was in the queue of items already in the plate,
	/// it gets raised
	/// </summary>
	public void ItemTypedRight ()
	{
		Item itemDestroyed = null;
		if (items.Count == 0)
		{
			if (itemsFalling.Count == 0)	return;

			itemDestroyed = itemsFalling.Dequeue();
		}
		else
		{
			itemDestroyed = items[0];
			items.RemoveAt(0);

			// Unsubscribe from its listener, and subscribe to the first falling (if any)
			itemDestroyed.fallListeners -= OnItemFell;
			if (itemsFalling.Count > 0)
			{
				itemsFalling.Peek().fallListeners += OnItemFell;
			}
		}

		if (itemDestroyed != null)
		{
			itemDestroyed.Destroy();
		}
	}

	/// <summary>
	/// Called when the last item in the queue was typed wrong.
	/// </summary>
	public void ItemTypedWrong ()
	{
		// TODO
		Debug.Log("Item typed wrongly");
	}

	/// <summary>
	/// When an item fell to the plate or an item queued over it, this method
	/// gets called. It moves the first item that is falling to the queue of items
	/// </summary>
	protected void OnItemFell (Item itemThatFell)
	{
		if (itemsFalling.Count == 0)	return;
		
		// Unsubscribe form the last item queued
		if (items.Count > 0)
		{
			items[items.Count - 1].fallListeners -= OnItemFell;
		}

		// Grab the first item falling and pass it to the items queued
		Item lastItemQueued = itemsFalling.Dequeue();
		lastItemQueued.isStopped = true;
		
		// Subscribe to its fallListeners, and queue it
		lastItemQueued.fallListeners += OnItemFell;
		items.Add(lastItemQueued);
	}

	/// <summary>
	/// Called when an item starts to fall to this plate
	/// </summary>
	/// <param name="item">Item.</param>
	public void OnItemStartToFall (Item item)
	{
		if (item == null)	return;

		itemsFalling.Enqueue(item);

		// Subscribe to its listeners, if there are no items currently queued
		if (items.Count == 0)
		{
			item.fallListeners += OnItemFell;
		}
	}

}
