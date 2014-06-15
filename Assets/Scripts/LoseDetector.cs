using UnityEngine;
using System.Collections;

/// <summary>
/// When a collider with a Plate attached to it collides with this gameObject,
/// it calls LevelManager's Lose method.
/// </summary>
public class LoseDetector : MonoBehaviour {


	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<Plate>() != null)
		{
			LevelManager.instance.Lose();
		}
	}

}
