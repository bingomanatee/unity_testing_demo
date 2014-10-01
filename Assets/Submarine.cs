using UnityEngine;
using System.Collections;

namespace SubHunt
{
		public class Submarine : MonoBehaviour
		{

				static Submarine instance;
				const float TORPEDO_SPEED = 2000.0f;
				static Vector3 START_POSITION = new Vector3 (0, 0, 10);
				float lastFireTime = 0f;
				const float FIRE_DELAY = 0.5f;
				const string SUB_SUBMERGED_STATE = "subSubmergedState";
				public State subState;
				const float SUBMERGE_HEIGHT = -10f;
				const float SURFACE_HEIGHT = 0f;

				// Use this for initialization
				void Start ()
				{
						if (!StateList.HasList (SUB_SUBMERGED_STATE)) {
								StateList list = new StateList (SUB_SUBMERGED_STATE, "unknown", "surfaced", "diving", "rising", "submerged");
								list.Constrain ("diving", "surfaced", "unknown");
								list.Constrain ("rising", "submerged", "unknown");
								list.Constrain ("surfaced", "rising", "unknown");
								list.Constrain ("submerged", "diving", "unknown");
						}
						subState = new State (SUB_SUBMERGED_STATE);

						subState.StateChangedEvent += OnSubmergedStateChange;
						subState.Change ("surfaced");
						instance = this;
				}

				public void OnSubmergedStateChange (StateChange change)
				{
						switch (change.toState.ToString ()) {

						case "surfaced": 
								transform.position = new Vector3 (transform.position.x, SURFACE_HEIGHT, transform.position.z);
								break;

						case "submerged": 
								transform.position = new Vector3 (transform.position.x, SUBMERGE_HEIGHT, transform.position.z);
								break;

						}
				}
	
				// Update is called once per frame
				void Update ()
				{
						if (Input.GetMouseButton (0) && lastFireTime + FIRE_DELAY < Time.time)
								Fire ();
				}

				public void Fire ()
				{
						Debug.Log ("FIRE TORPEDOS!");
						GameObject torpedo = (GameObject)Instantiate (Resources.Load ("Torpedo"));

						torpedo.transform.localPosition = transform.position;
						torpedo.transform.rotation = transform.rotation;
						torpedo.rigidbody.AddForce (transform.TransformDirection (new Vector3 (0, 0, TORPEDO_SPEED)));
						torpedo.rigidbody.AddForce (transform.rigidbody.velocity);
						lastFireTime = Time.time;
				}
		}
}