/* Scripted by Bamabu - omabuarts@gmail.com */
// Note: This script does not provide the functionality of controlling the animoji. 
// Rather, it is just for controlling the demo scene included with this asset package.
// To make and control the animoji, follow the tutorial by unity here:
// https://blogs.unity3d.com/en/2017/12/03/create-your-own-animated-emojis-with-unity/

using UnityEngine;
using UnityEngine.UI;

public class AnimojiDemo : MonoBehaviour {

	[Space (10)]
	public Animator [] anim;
	public Dropdown dropdown;

	void Start () {

		for (int i = 0; i < anim.Length; i++)
		{
			anim [i].transform.position = Vector3.zero;
			
			if (i != 0)
				anim [i].gameObject.SetActive (false);
		}
	}

	void Update () {

		if (Input.GetKeyDown ("right")) {
			Next ();
		}
		else if (Input.GetKeyDown ("left")) {
			Prev ();
		}
	}

	public void Next () {

		anim [dropdown.value].gameObject.SetActive (false);

		if (dropdown.value >= dropdown.options.Count - 1)
			dropdown.value = 0;
		else
			dropdown.value++;

		Play ();
	}

	public void Prev () {

		anim [dropdown.value].gameObject.SetActive (false);

		if (dropdown.value <= 0)
			dropdown.value = dropdown.options.Count - 1;
		else
			dropdown.value--;
		
		Play ();
	}

	public void Play () {

		int index = dropdown.value;

		anim [index].gameObject.SetActive (true);
		anim [index].SetTrigger ("Animoji");
	}

	public void GoToWebsite (string URL) {

		Application.OpenURL (URL);
	}
}
