using UnityEngine;
using System.Collections;

public class LowerBarrierOnTriggerEnter : MonoBehaviour
{

	public Plate plate;

	void OnTriggerEnter (Collider other)
	{
		if (plate != null)
		{
			plate.LowerBarrier();
		}
	}

}
