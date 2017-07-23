using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelModification : MonoBehaviour {

	private GameObject dummyModels;
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
		dummyModels = GameObject.Find("Dummy Models");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeCounter(int direction) {
		// identify direction (left or right)
		if (direction > 0) {
			counter++;
		}
		else if (direction < 0) {
			counter--;
		}

		counter = sanitiseCounter(counter);
		updateDisplayedModel();
	}

	public void changeCounterByInt(int newCount) {
		counter = sanitiseCounter(newCount);
		updateDisplayedModel();
	}

	private void updateDisplayedModel() {
		// remove all current models as a child of this gameobject
		foreach(Transform child in transform) {
			Destroy(child.gameObject);
		}

		// assign the correct model onto this gameobject
		Transform model = dummyModels.transform.GetChild(counter);
		Vector3 defaultPos = new Vector3(0, 0, 0);
		Quaternion defaultRot = new Quaternion(0, 0, 0, 0);
		Transform clone = Instantiate(model, transform, false);
		clone.gameObject.SetActive(true);
	}

	private int sanitiseCounter(int count) {
		// sanitise for negative values
		int childrenCount = dummyModels.transform.childCount;
		if (count < 0) {
			count = 0;
		}
		// sanitise for positive values
		else if (count >= childrenCount) {
			count = childrenCount - 1;
		}

		return count;
	}
}
