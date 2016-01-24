using UnityEngine;
using System.Collections;

namespace Thingiebox
{
	public class Animate 
	{
		void Tween(MonoBehaviour behaviour, System.Action<float> action, float duration, System.Action callBack)
		{
			behaviour.StopAllCoroutines ();
			behaviour.StartCoroutine (AnimationInternal (behaviour, action, duration, callBack));
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
			callBack();
		}
	}
	
}
