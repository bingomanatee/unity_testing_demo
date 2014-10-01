using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour
{
		const float TIME_TO_ARM = 0.1f;
		bool armed = false;
		float startTime = 0;
		// Use this for initialization
		void Start ()
		{
				startTime = Time.time;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if ((!armed) && ((startTime + TIME_TO_ARM) < Time.time))
						Arm ();
		}

		void Arm ()
		{
				armed = true;
				GetComponent<BoxCollider> ().enabled = true;
				Debug.Log ("TORPEDO ARMED");
		}
}
