using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class HierarchyManager : EditorWindow
{
    private readonly List<GameObject> _defaultSceneObjects = new List<GameObject>();
    private readonly string _defaultSceneObjectsPath = "Assets/Editor Default Resources/DefaultSceneObjects/";
    private readonly string _defaultGameSceneObjectsPath = "Assets/Editor Default Resources/DefaultSceneObjects/DefaultGameSceneObjects";
    private bool _hasPressedAddDefaultSceneObjectsButton;
    private bool _includeDefaultGameSceneObjects;


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
            if (_includeDefaultGameSceneObjects)
            {
                string[] rootGame = Directory.GetFiles(_defaultGameSceneObjectsPath, "*.prefab");
                foreach (string prefabFile in rootGame)
                {
                    _defaultSceneObjects.Add(AssetDatabase.LoadAssetAtPath(prefabFile, typeof(GameObject)) as GameObject);
                }
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
        _includeDefaultGameSceneObjects = GUILayout.Toggle(_includeDefaultGameSceneObjects, "Include default game scene objects", GUILayout.Height(40f));
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
