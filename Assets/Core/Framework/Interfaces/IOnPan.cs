using UnityEngine;
using System.Collections;

public interface IOnPan 
{
	void OnTransformStart ();

	void OnTransform();

	void OnTransformComplete();
}
