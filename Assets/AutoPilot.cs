using UnityEngine;
using System.Collections;

namespace SubHunt
{
		public class AutoPilot : MonoBehaviour
		{
				public Submarine sub;
				float DELAY = 0.5f;
				float DELAY2 = 0.6f;
				bool rotated45degreesPort = false;
				bool moved90degreesPort = false;
				bool firedForwardSecondTime = false;

				// Use this for initialization
				void Start ()
				{
						sub.Fire ();
				}
	
				// Update is called once per frame
				void Update ()
				{
						// fire second torpedo at 45 degrees port
						if (Time.time > DELAY && (!rotated45degreesPort)) {
								rotated45degreesPort = true;
								transform.Rotate (Vector3.up, -45);
								sub.Fire ();
						}

						// reset position to forward but moving at 90 degrees port
						if (Time.time > DELAY2 && (!moved90degreesPort)) {
								moved90degreesPort = true;
				sub.rigidbody.AddForce (new Vector3 (-5000, 0, 0));
				sub.transform.Rotate (Vector3.up, 45);
						}
			
						// fired while facing 90 degrees port
						if (sub.transform.position.x <= -2 && !firedForwardSecondTime) {
								firedForwardSecondTime = true;
								sub.Fire ();
						}
				}
		}
}