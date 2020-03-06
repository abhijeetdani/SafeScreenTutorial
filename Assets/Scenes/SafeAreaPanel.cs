using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaPanel : MonoBehaviour {

	private RectTransform _rectTransform;

	private void Awake() {
		_rectTransform = GetComponent<RectTransform>();
		RefreshPanel(Screen.safeArea);
	}

	private void OnEnable() {
		SafeAreaDetection.OnSafeAreaChanged += RefreshPanel;
	}

	private void OnDisable() {
		SafeAreaDetection.OnSafeAreaChanged -= RefreshPanel;
	}

	private void RefreshPanel(Rect safeArea) {

		Vector2 anchorMin = safeArea.position;
		Vector2 anchorMax = safeArea.position + safeArea.size;

		anchorMin.x /= Screen.width;
		anchorMin.y /= Screen.height;
		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;

		_rectTransform.anchorMin = anchorMin;
		_rectTransform.anchorMax = anchorMax;
	}
}
