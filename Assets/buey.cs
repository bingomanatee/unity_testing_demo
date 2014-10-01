using UnityEngine;
using System.Collections;

public class buey : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
		void OnCollisionEnter (Collision collision)
		{
				{
						if (collision.gameObject.tag == "Bullet") {
								gameObject.SetActive (false);
								collision.gameObject.SetActive (false);
								Debug.Log (name + " is Destroyed!");
						} else {
								Debug.Log ("Non bullet collission: " + collision.gameObject.tag);
						}
				}
		}
}