using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Highlight : MonoBehaviour {

	public Color normalColor;
	public Color highlightColor;
	public SpriteRenderer image;
	public float highlightTime;
	public GameObject target;
	private float time;

	void Start()
	{
		time = 0;
	}

	// Update is called once per frame
	void Update () {
		Vector2 touchPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit2D = Physics2D.Raycast(touchPostion, Vector2.zero);
		if (hit2D.collider != null && hit2D.collider.gameObject == target && time < highlightTime)
			time += Time.deltaTime;
		else if (time > 0)
			time -= Time.deltaTime;
		if (time < 0)
			time = 0;
		else if (time > highlightTime)
			time = highlightTime;
		image.material.color = Color.Lerp (normalColor,highlightColor,time/highlightTime);
	}
}
