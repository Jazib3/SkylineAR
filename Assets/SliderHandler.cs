using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour {

	public GameObject target;
	private Slider s;
	
	// Use this for initialization
	void Start () {
		// when the dropdown changes, change the model viewed
		s = gameObject.GetComponent<Slider>();
		s.onValueChanged.AddListener(delegate {
			ValueChange();
		});
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setValue(int rotation) {
		s.value = rotation;
	}

	private void ValueChange() {
		int rotate = (int) s.value;
		Debug.Log ("rotation set to: " + rotate + "; before was: " + s.value + "f");
		target.GetComponent<ButtonHandler>().setRotationByInt(rotate);
	}
}
