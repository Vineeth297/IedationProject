using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 5f;
	[SerializeField] private float xForce;
	public float xSpeed;
	private float _swipeSpeed = 3f;
	

	// Update is called once per frame
	private void Update()
	{

		if (Input.GetMouseButton(0))
		{
			transform.Translate(
				(Vector3.forward * movementSpeed + new Vector3(xForce * xSpeed, 0f, 0f)) * Time.deltaTime, Space.World);
		}

	#if UNITY_EDITOR
		xForce = Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") * xSpeed : 0;
	#elif UNITY_ANDROID
        if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		  {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			xForce = touchDeltaPosition.x*_swipeSpeed*Mathf.Deg2Rad;
          }
		if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		  {
			xForce = 0;
          }
	#endif
	}
}
