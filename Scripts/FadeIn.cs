using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	/// <summary>
	/// The text to fade.
	/// </summary>
	public Text[] textToFade;

	/// <summary>
	/// The images to fade.
	/// </summary>
	public Image[] imagesToFade;

	/// <summary>
	/// How long the animation lasts, .
	/// </summary>
	public float endTime;

	/// <summary>
	/// How much time has passed since the start of the animation.
	/// </summary>
	private float time;

	void Start()
	{
		time = 0;
	}

	void Update () {
		if (time < endTime) 
		{
			foreach (Text text in textToFade)
				text.color = Color.Lerp (new Color (text.color.r, text.color.g, text.color.b, 0),
					new Color (text.color.r, text.color.g, text.color.b, 255),
					time / endTime);
			foreach (Image img in imagesToFade)
				img.color = Color.Lerp (new Color (img.color.r, img.color.g, img.color.b, 0),
					new Color (img.color.r, img.color.g, img.color.b, 255),
					time / endTime);
		}
		time += Time.deltaTime;
	}
}
