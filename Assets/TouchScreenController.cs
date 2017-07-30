using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Vuforia;

public class TouchScreenController : MonoBehaviour {

	private float[] largeRange = {-50f, 50f};
	private float[] smallRange = {0.9f, 1.1f};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Following from: https://unity3d.com/learn/tutorials/topics/mobile-touch/pinch-zoom
		// If there are two touches on the device...
		if (Input.touchCount == 2) {
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			Debug.Log("pinch deltaMagnitudeDiff = " + deltaMagnitudeDiff);
			float newDelta = VuforiaCustom.map(-deltaMagnitudeDiff, largeRange[0], smallRange[0], 
				largeRange[1], smallRange[1]);
			Debug.Log("pinch delta = " + newDelta);

			// multiple the scale of the model by the magnitude of the pinch
			TrackableBehaviour tracker = VuforiaCustom.getActiveTracker();
			Transform trackerTransform = tracker.transform;
			Vector3 scale = trackerTransform.localScale;
			Vector3 newScale = scale * newDelta;
			trackerTransform.localScale = newScale;
		}
	}
}
