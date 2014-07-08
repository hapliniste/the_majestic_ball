using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {

	public Transform jumpVector;
	public float jumpFactor = 1;
	[Range (0.0f, 3.0f)] public float timeToJump;

	public Transform ballTransform;
	private Rigidbody2D rigid;

	public Transform arrowTransform;

	public int smooth = 10;
	private Vector3 curAc;

	// Use this for initialization
	void Start ()
	{
		rigid = ballTransform.GetComponent<Rigidbody2D>();
		curAc = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "ball")
		{
			Lock ();
		}
	}

	void Lock()
	{
		//Invoke("Jump", timeToJump);
		ballTransform.position = this.transform.position;
		rigid.isKinematic = true;

		StartCoroutine(Orientation());
	}

	IEnumerator Orientation ()
	{
		float tmpTime = 0f;

		while(tmpTime < timeToJump)
		{
			//curAc = Vector3.Lerp(curAc, Input.acceleration * 5, Time.deltaTime/smooth);
			curAc = Input.acceleration;
			float tmpX = (Mathf.Abs(curAc.x) + Mathf.Sqrt(Mathf.Abs(curAc.x))) / 2 * (curAc.x / Mathf.Abs (curAc.x));
			float hori = Mathf.Clamp(tmpX, -1, 1);

			if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				hori = Input.GetAxis("Horizontal");
			}

			//BOUGER LA FLECHE ET LE VECTEUR
			float posX = Mathf.Sin(((hori-1)/4 * Mathf.PI));
			Debug.Log(posX.ToString());
			float posY = Mathf.Cos(((hori-1)/4 * Mathf.PI));
			Vector3 posVec = new Vector3(posX, posY, 0f);
			jumpVector.position = this.transform.position + posVec;

			arrowTransform.rotation = Quaternion.Euler(arrowTransform.rotation.x, arrowTransform.rotation.y, Mathf.Atan(posY/(posX-0.000001f))*45);

			Debug.Log ("posX: " + posX.ToString() + ", rotation: " + arrowTransform.rotation.z.ToString());


			tmpTime += Time.deltaTime;

			yield return null;
		}
		
		//print("Time's up!");
		
		//yield return new WaitForSeconds(3f);
		
		//print("MyCoroutine is now finished.");

		Jump ();
	}

	void Jump()
	{
		rigid.isKinematic = false;
		
		rigid.velocity = (jumpVector.position - transform.position)*jumpFactor;
	}
}
