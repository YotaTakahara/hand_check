using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateObject : MonoBehaviour
{
	RectTransform rectTransform = null;
//	[SerializeField]Vector3 target ;

	[SerializeField]Canvas canvas;
	public GameObject cube;

	public void InstanceObject(Vector3 place)
	{
		rectTransform = GetComponent<RectTransform> ();
		canvas = GetComponent<Graphic> ().canvas;


        var pos = Vector2.zero;
		var uiCamera = Camera.main;
		var worldCamera = Camera.main;
		var canvasRect = canvas.GetComponent<RectTransform> ();

		var screenPos = RectTransformUtility.WorldToScreenPoint (worldCamera, place);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out pos);
		Instantiate( cube,pos,Quaternion.identity);
	}

	// void IDragHandler.OnDrag(PointerEventData ev)
	// {
	// 	Vector3 worldPos;
	// 	var ray = RectTransformUtility.ScreenPointToRay (Camera.main, ev.position);
	// 	RaycastHit hit;
	// 	if (Physics.Raycast (ray, out hit)) {
	// 		target.position = hit.point + hit.normal * 0.5f;
	// 	}
	// }

	void Update ()
	{
		
	}
}
