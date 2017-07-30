using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void setCounterByIncrement(int direction) {
		// update the active tracker that is dynamically defined
		TrackableBehaviour activeTracker = VuforiaCustom.getActiveTracker();
		if (activeTracker == null) {
			Debug.LogError("no active trackers found in the scene");
			return;
		}

		// get the current counter value
		//Debug.Log(activeTracker);
		//Debug.Log(activeTracker.gameObject);
		ModelModification mm = activeTracker.gameObject.GetComponent<ModelModification>();
		int counter = mm.getCounter();

		// identify direction (left or right)
		if (direction > 0) {
			counter++;
		}
		else if (direction < 0) {
			counter--;
		}

		mm.setCounter(counter);
	}

	public void setCounterByInt(int newCount) {
		// update the active tracker that is dynamically defined
		TrackableBehaviour activeTracker = VuforiaCustom.getActiveTracker();
		if (activeTracker == null) {
			Debug.LogError("no active trackers found in the scene");
			return;
		}

		// set the new counter value to the currently tracked target
		ModelModification mm = activeTracker.gameObject.GetComponent<ModelModification>();
		mm.setCounter(newCount);
	}

	public void setRotationByInt(int angle) {
		if (angle < 0 || angle >= 360) {
			angle = 0;
		}

		// set the rotation angle to the currently tracked target
		TrackableBehaviour activeTracker = VuforiaCustom.getActiveTracker();
		foreach (Transform child in activeTracker.transform) {
			// rotate the models currently selected by the user
			if (child.gameObject.activeSelf) {
				// get the current angle and update the y-axis
				Vector3 currAngle = child.localEulerAngles;
				currAngle.y = angle;
				child.localEulerAngles = currAngle;
			}
		}
	}
}
