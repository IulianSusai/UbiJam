﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;
	private float currentShakeDuration;

	void Awake() {
		if (camTransform == null) {
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable() {
		originalPos = camTransform.localPosition;
	}

	public void Shake() {
		currentShakeDuration = shakeDuration;
	}

	void Update() {
		if (currentShakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			currentShakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
			currentShakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}