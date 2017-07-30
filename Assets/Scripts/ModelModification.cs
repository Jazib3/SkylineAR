using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Vuforia;

public class ModelModification : MonoBehaviour {

	public GameObject dropdownGO;
	public GameObject sliderGO;
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;

		if (dropdownGO == null) {
			Debug.LogError("dropdown menu not set");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setCounter(int newCounter) {
		counter = sanitiseCounter(newCounter);
		updateDropdownMenu();
		updateDisplayedModel();
	}

	public int getCounter() {
		return counter;
	}

	public void updateDropdownMenu() {
		Dropdown dd = dropdownGO.GetComponent<Dropdown>();
		dd.value = counter;
	}

	public void updateSliderValue() {
		Slider s = sliderGO.GetComponent<Slider>();
		s.value = transform.localEulerAngles.y;
	}

	private void updateDisplayedModel() {
		// only show the model that is the current counter
		foreach(Transform child in transform) {
			bool active = false;
			if (transform.GetChild(counter) == child) {
				active = true;
			}

			child.gameObject.SetActive(active);
		}
	}

	private int sanitiseCounter(int count) {
		// sanitise for negative values
		int childrenCount = transform.childCount;
		Debug.Log("children count: " + childrenCount);
 		if (count < 0) {
			Debug.Log("counter value went too zero: " + count);
			count = 0;
		}
		// sanitise for positive values
		else if (count >= childrenCount) {
			Debug.Log("counter value went too beyond limit: " + count);
			count = childrenCount - 1;
		}

		return count;
	}
}
