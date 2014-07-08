using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	public float bumperForce = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		foreach (ContactPoint2D contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			if(collision.gameObject.tag == "Player")
			{
				Vector2 relPos = new Vector2(collision.gameObject.transform.position.x - this.transform.position.x, collision.gameObject.transform.position.y - this.transform.position.y);
				collision.gameObject.rigidbody2D.AddForce( -1  * contact.normal * bumperForce,  ForceMode2D.Impulse);
				Debug.Log(contact.normal);
			}
		}
	}
}
