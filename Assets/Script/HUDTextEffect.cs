using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDTextEffect : MonoBehaviour {

	public float ScoreDelay = 0.5f;
	private Vector3 pos;
	private RectTransform rectTransform;
	private Rect rect;


	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform>();
		pos = rectTransform.localPosition;
		StartCoroutine("DisplayScore"); 
	}
	
	// Update is called once per frame
	void Update () {
		pos.y += 1f;
		rectTransform.localPosition = pos;
	}

	IEnumerator DisplayScore()
	{
		yield return new WaitForSeconds(ScoreDelay);
		
		for(float a = 1; a >= 0; a -= 0.05f)
		{
			GetComponent<Text>().color = new Vector4(0, 0, 0, a);

			yield return new WaitForFixedUpdate();
		}
		
		Destroy(gameObject);
	}
}
