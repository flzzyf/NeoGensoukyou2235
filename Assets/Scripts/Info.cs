using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
	[TextArea(3, 10)]
	public string infoText;

	[TextArea(3, 10)]
	public string defaultText;

	public Text text;
	public GameObject textBox;

	private void Update()
	{
		if (!textBox.activeSelf)
			return;

		if(Input.GetKeyDown("e"))
		{
			text.text = infoText;

			Canvas.ForceUpdateCanvases();
			textBox.GetComponent<ContentSizeFitter>().enabled = false;
			textBox.GetComponent<ContentSizeFitter>().enabled = true;

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		textBox.SetActive(true);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		text.text = defaultText;

		Canvas.ForceUpdateCanvases();
		textBox.GetComponent<ContentSizeFitter>().enabled = false;
		textBox.GetComponent<ContentSizeFitter>().enabled = true;

		textBox.SetActive(false);
	}
}
