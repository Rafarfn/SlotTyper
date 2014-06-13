using UnityEngine;
using System.Collections;

/// <summary>
/// Every of the items on the screen that is dropped towards the user.
/// Contains a string that is the sequence of characters needed to
/// "destroy" the item
/// </summary>
public class Item : MonoBehaviour
{
	/// <summary>
	/// String that represents the item, 
	/// </summary>
	public string itemString;

	/// <summary>
	/// The current movement direction.
	/// </summary>
	protected Vector3 mMovementDirection = Vector3.zero;
	public Vector3 movementDirection
	{
		get { return mMovementDirection; }
		set
		{
			mMovementDirection = value;
			mMovementDirection.y = 0;
			mMovementDirection.Normalize();
		}
	}


	/// <summary>
	/// Movement speed.
	/// </summary>
	public float speed = 1.0f;

	protected bool mIsStopped = false;
	public bool isStopped
	{
		get { return mIsStopped; }
		set
		{
			mIsStopped = value;
		}
	}


	public delegate void OnItemFell (Item item);
	/// <summary>
	/// Delegate that notifies about the item ended falling to a plate (or the queue over it).
	/// </summary>
	public OnItemFell fallListeners;


	void Update ()
	{
		if (mIsStopped)	return;

		transform.root.Translate(movementDirection * speed * Time.deltaTime);
	}

	/// <summary>
	/// Destroy the item, as it may have been typed correctly .
	/// </summary>
	public void Destroy ()
	{
		speed *= 4;
		isStopped = false;
	}


	void OnCollisionEnter (Collision other)
	{
		if (fallListeners != null)
		{
			fallListeners(this);
		}
	}

}
