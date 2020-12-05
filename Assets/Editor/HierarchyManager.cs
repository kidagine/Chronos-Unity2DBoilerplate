using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class HierarchyManager : EditorWindow
{
    private readonly List<GameObject> _defaultSceneObjects = new List<GameObject>();
    private readonly string _defaultSceneObjectsPath = "Assets/Editor Default Resources/DefaultSceneObjects/";
    private bool _hasPressedAddDefaultSceneObjectsButton;


    [MenuItem("Cronos/Hierarchy Manager")]
    public static void ShowWindow()
    {
        GetWindow(typeof(HierarchyManager), false, "Hierarchy Manager");
    }

    void OnGUI()
    {
        EditorGUILayout.Space();
        if (GUILayout.Button("Add default scene objects", GUILayout.Height(50f)))
        {
            _hasPressedAddDefaultSceneObjectsButton = true;
            _defaultSceneObjects.Clear();
            string[] root = Directory.GetFiles(_defaultSceneObjectsPath, "*.prefab");
            foreach (string prefabFile in root)
            {
                _defaultSceneObjects.Add(AssetDatabase.LoadAssetAtPath(prefabFile, typeof(GameObject)) as GameObject);
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
        if (_hasPressedAddDefaultSceneObjectsButton)
        {
            AddDefaultSceneObjects();
        }
    }

    private void AddDefaultSceneObjects()
    {
        if (_defaultSceneObjects.Count > 0)
        {
			foreach (GameObject defaultSceneObject in _defaultSceneObjects)
            {
                Debug.Log(defaultSceneObject.name);
                GameObject findDefaultSceneObject = GameObject.Find(defaultSceneObject.name);
                if (findDefaultSceneObject == null)
                {
                    EditorGUILayout.LabelField($"{defaultSceneObject.name}", GUILayout.ExpandWidth(true));
                    PrefabUtility.InstantiatePrefab(defaultSceneObject);
                }
                _hasPressedAddDefaultSceneObjectsButton = false;
            }
        }
    }
}
