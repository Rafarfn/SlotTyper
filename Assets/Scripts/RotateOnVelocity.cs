using UnityEngine;
using System.Collections;

/// <summary>
/// Makes an object spin taken the magnitude of a velocity of a rigidbody
/// </summary>
public class RotateOnVelocity : MonoBehaviour
{
	public Rigidbody rigidbodyToObserve;

	/// <summary>
	/// Multiplier applied to the rotation speed
	/// </summary>
	public float spinFactor = 1.0f;


	public Transform transformToObserve;
	protected Vector3 previousPosition;


	void OnEnable ()
	{
		transformToObserve = transform;
		previousPosition = transform.position;
		if (rigidbodyToObserve == null)
		{
			//rigidbodyToObserve = rigidbody;
		}
	}

	void Update ()
	{
		transform.RotateAround(transform.position, transform.right, (transform.position - previousPosition).magnitude * spinFactor);
		previousPosition = transform.position;
	}

}
