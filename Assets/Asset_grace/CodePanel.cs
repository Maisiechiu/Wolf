using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
	public Text codeText;
	string codeTextValue = "";

	//bool isSafeOpened;

	void Start()
	{
		//isSafeOpened = lockerController.isSafeOpened;
	}

	// Update is called once per frame
	void Update () {
		codeText.text = codeTextValue;
		if (codeTextValue == "1215") {
			Debug.Log("passward true");
			//isSafeOpened = true;
			lockerController.isSafeOpened = true;
		}

		if (codeTextValue.Length >= 4)
			codeTextValue = "";
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}
