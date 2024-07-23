using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CameraPilot : MonoBehaviour
{
	[MenuItem("Tools/Camera Pilot")]
	public static void CreateCameraPilot()
	{
		GameObject oldObject = GameObject.Find(typeof(CameraPilot).ToString());
		if (oldObject != null && oldObject.GetComponent<CameraPilot>() != null) {
			EditorGUIUtility.PingObject(oldObject.GetInstanceID());
		}
		else {
			GameObject go = new GameObject(typeof(CameraPilot).ToString());
			go.AddComponent<CameraPilot>();
		}
	}

	private void OnEnable()
	{
		if (!Application.isPlaying) {
			SceneView.duringSceneGui += OnSceneGUI;
			Debug.Log($"{typeof(CameraPilot).ToString()} Enabled");
		}
	}

	private void OnDisable()
	{
		if (!Application.isPlaying) {
			Debug.Log($"{typeof(CameraPilot).ToString()} Disabled");
			SceneView.duringSceneGui -= OnSceneGUI;
		}
	}


	private static void OnSceneGUI(SceneView sceneView)
	{
		Vector3 cameraPosition = sceneView.camera.transform.position;
		Quaternion cameraRotation = sceneView.camera.transform.rotation;

		SetSceneViewCameraPosition(cameraPosition, cameraRotation);
	}

	private static void SetSceneViewCameraPosition(Vector3 position, Quaternion rotation)
	{
		Camera.main.transform.position = position;
		Camera.main.transform.rotation = rotation;
	}
}