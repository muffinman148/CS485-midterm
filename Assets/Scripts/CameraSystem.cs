using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

//	public GameObject player;
//	public float xMin;
//	public float xMax;
//	public float yMin;
//	public float yMax;
//
//	// Use this for initialization
//	void Start () {
//		player = GameObject.FindGameObjectWithTag ("Player");
//	}
//	
//	// Update is called once per frame
//	void LateUpdate () {
//		float x = Mathf.Clamp (player.transform.position.x, xMin, xMax);
//		float y = Mathf.Clamp (player.transform.position.y, yMin, yMax);
//		gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
//	}

	public Transform target;

	Vector3 velocity = Vector3.zero;

	// Time to follow target
	public float smoothTime = .15f;

	// Toggle Y Max
	public bool YMaxEnabled = false;
	public float YMaxValue = 0;

	// Toggle Y Min
	public bool YMinEnabled = false;
	public float YMinValue = 0;

	// Toggle X Max
	public bool XMaxEnabled = false;
	public float XMaxValue = 0;

	// Toggle X Min
	public bool XMinEnabled = false;
	public float XMinValue = 0;

	void FixedUpdate() {
		// Target Position
		Vector3 targetPos = target.position;

		// Vertical
		if (YMinEnabled && YMaxEnabled) {
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, YMaxValue);
		} else if (YMinEnabled) {
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, target.position.y);
		} else if (YMaxEnabled) {
			targetPos.y = Mathf.Clamp (target.position.y, target.position.y, YMaxValue);
		}

		// Horizontal
		if (XMinEnabled && XMaxEnabled) {
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, XMaxValue);
		} else if (XMinEnabled) {
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, target.position.x);
		} else if (XMaxEnabled) {
			targetPos.x = Mathf.Clamp (target.position.x, target.position.x, XMaxValue);
		}

		// Align to target
		targetPos.z = transform.position.z;
		// Smooth Camera Movement
		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);
	}
}
