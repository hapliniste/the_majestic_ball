using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	[Range (0.0f, 20.0f)] public float gravity;
	[Range (0.0f, 5.0f)] public float force;

	private Vector3 curAc;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		curAc = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//curAc = Vector3.Lerp(curAc, Input.acceleration * 5, Time.deltaTime/smooth);
		curAc = Input.acceleration;
		float tmpX = Mathf.Sqrt(Mathf.Abs(curAc.x)) * (curAc.x / Mathf.Abs (curAc.x));
		float hori = Mathf.Clamp(tmpX, -1, 1);

		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			hori = Input.GetAxis("Horizontal");
		}

		Vector2 grav = new Vector2(hori*force, -1f);
		grav.Normalize();
		grav *= gravity;
		Physics2D.gravity = (grav);
	
		if(Input.GetButton("Jump"))
		{
			Rigidbody2D rigid = this.GetComponent<Rigidbody2D>();

			rigid.velocity = new Vector2(rigid.velocity.x, 6f);
		}
	}
}
