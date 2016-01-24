using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour 
{
	public Transform startPos;
	public Transform endPos;


	public void Start()
	{
		Animate(this, l => transform.position = Vector3.Lerp(startPos.position, endPos.position, l), 2, Finish);
	}

	void Finish()
	{
		Debug.Log("finished");
	}

	void Animate(MonoBehaviour behaviour, System.Action<float> action, float duration, System.Action callBack)
	{
		behaviour.StopAllCoroutines ();
		behaviour.StartCoroutine (AnimationInternal (behaviour, action, duration, Finish));
	}

	IEnumerator AnimationInternal(MonoBehaviour behaviour, System.Action<float> action, float duration, System.Action callBack)
	{
		float t = 0; 
		while( t < duration)
		{
			t += Time.deltaTime;
			action (t);
			yield return new WaitForEndOfFrame ();
		}
		Finish ();
	}

}
