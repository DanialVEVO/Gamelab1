using UnityEngine;
using System.Collections;

public class FloatingObjectsScript : MonoBehaviour {

	public float floatHeight = 1;
	public float floatSpeed = 1;
	public float rotationSpeed = 25;

	private Vector3 floatStartPos;
	private bool floatUp;

	void Start () {
		floatStartPos = transform.localPosition;
	}

	void Update () {
		FloatingObject();
	}

	public void FloatingObject () {
		if (transform.localPosition.y >= floatStartPos.y + floatHeight) {
			floatUp = false;
		}
		if (transform.localPosition.y <= floatStartPos.y) {
			floatUp = true;
		}
		
		if (floatUp) {
			transform.localPosition += new Vector3 (0, 1 * floatSpeed * Time.deltaTime, 0);
		} else {
			transform.localPosition += new Vector3 (0, -1 * floatSpeed * Time.deltaTime, 0);
		}
		
		transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);	
	}

	public void DestroyThis () {
		Destroy(gameObject);
	}
}
