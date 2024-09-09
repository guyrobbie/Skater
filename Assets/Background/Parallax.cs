using UnityEngine;

public class Parallex : MonoBehaviour {

	private float length, startPos;
	// private float lengthY, startPosY;

	public GameObject cam;
	public float parallexEffect;

	void Start () {
		startPos = transform.position.x;
		// startPosY = transform.position.y;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void FixedUpdate () {

		float temp = (cam.transform.position.x * (1-parallexEffect));
		float dist = (cam.transform.position.x*parallexEffect);

		// float tempY = (cam.transform.position.y * (1-parallexEffect));
		// float distY = (cam.transform.position.y*parallexEffect);

		transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

		if      (temp > startPos + length) startPos += length;
		else if (temp < startPos - length) startPos -= length;

		// if      (tempY > startPosY + lengthY) startPosY += lengthY;
		// else if (tempY < startPosY - lengthY) startPosY -= lengthY;


	}

}
