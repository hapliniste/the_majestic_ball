using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public Transform target;    // The target we are following
	public float positionDamping;

	private Vector3 deltaPos;

	// Use this for initialization
	void Start () {
		deltaPos = new Vector3(-4f, 1f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPosition = target.position - (Vector3.forward * 10);
		
		//transform.position = Vector3.MoveTowards(transform.position, targetPosition + deltaPos, positionDamping * Time.deltaTime);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition + deltaPos, positionDamping * Time.deltaTime);	
	}

	void Update () {
		//Vector3 targetPosition = this.transform.position + (Vector3.right * Time.deltaTime * 50);
		
		//transform.position = Vector3.MoveTowards(transform.position, targetPosition + deltaPos, positionDamping * Time.deltaTime);
		//Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition- (Vector3.forward * 10), positionDamping * Time.deltaTime);	
	}
}