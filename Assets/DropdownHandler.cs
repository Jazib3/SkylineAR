using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DropdownHandler : MonoBehaviour {

	public GameObject target;
	private Dropdown dd;

	// Use this for initialization
	void Start () {
		// when the dropdown changes, change the model viewed
		dd = gameObject.GetComponent<Dropdown>();
		dd.onValueChanged.AddListener(delegate {
			ValueChange();
		});
	}

	// Update is called once per frame
	void Update () {
	}

	public void setValue(int counter) {
		dd.value = counter;
	}

	private void ValueChange() {
		int modelCount = dd.value;
		target.GetComponent<ButtonHandler>().setCounterByInt(modelCount);
	}
}
