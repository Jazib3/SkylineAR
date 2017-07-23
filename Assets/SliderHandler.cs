using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour {

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

	private void ValueChange() {
		int modelCount = dd.value;
		target.GetComponent<ModelModification>().changeCounterByInt(modelCount);
	}
}
