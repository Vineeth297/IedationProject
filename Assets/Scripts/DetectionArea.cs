using Unity.Mathematics;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
	[SerializeField] private Vector3 minAngle = new Vector3(0f,45f,0f);
	[SerializeField] private Vector3 maxAngle = new Vector3(0f,90f,0f);
	[SerializeField] private float rotationSpeed;
	[SerializeField] private bool reachedMaxLerp;

	private float _lerpTime = 0f;
	private Quaternion _startRotation;
	private Quaternion _endRotation;

	public bool foundTheCulprit;
	private void Start()
	{
		_startRotation = quaternion.Euler(minAngle);
		_endRotation = quaternion.Euler(maxAngle);
	}

	private void Update()
	{
		if(!foundTheCulprit)
			LookForTheCulprit();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			print("Found Player");
			foundTheCulprit = true;
		}
	}

	private void LookForTheCulprit()
	{
		if (_lerpTime < 1f && !reachedMaxLerp)
		{
			_lerpTime += Time.deltaTime * rotationSpeed;
			if (_lerpTime > 1f) reachedMaxLerp = true;
		}

		if (reachedMaxLerp)
		{
			_lerpTime -= Time.deltaTime * rotationSpeed;
			if (_lerpTime < 0f) reachedMaxLerp = false;
		}
		
		transform.rotation = Quaternion.Lerp(_startRotation,_endRotation,_lerpTime);
	}
	
}
