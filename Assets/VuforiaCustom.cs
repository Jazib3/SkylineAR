using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaCustom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

	// from: https://forum.unity3d.com/threads/re-map-a-number-from-one-range-to-another.119437/
	public static float map(float value, float from1, float to1, float from2, float to2) {
		if (value <= from1) {
			return to1;
		}
		if (value >= from2) {
			return to2;
		}

		return (value - from1) * (to2 - to1) / (from2 - from1) + to1;
	}

	public static TrackableBehaviour getActiveTracker() {
		StateManager sm = TrackerManager.Instance.GetStateManager();

		// Query the StateManager to retrieve the list of active trackers
		IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

		// only one tracker is allowed in a scene so take the first 
		// active tracker found
		foreach (TrackableBehaviour tb in activeTrackables) {
			return tb;
		}

		return null;
	}
}
