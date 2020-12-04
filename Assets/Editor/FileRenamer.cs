using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class FileRenamer : EditorWindow
{
    private int _totalFilesFound;
    private int _filesSuccessfullyRenamedCount;
    private bool _hasStartedRenaming;

    private readonly string _scenesPath = "Assets/Scenes/";
    private readonly string _spritesPath = "Assets/Sprites/";
    private readonly string _imagesPath = "Assets/Images/";
    private readonly string _soundsPath = "Assets/Sounds/";
    private readonly string _animationsPath = "Assets/Animations/";
    private readonly string _presetsPath = "Assets/Presets/";
    private readonly string _palettesPath = "Assets/Tilemaps/Palettes";
    private readonly string _ruleTilesPath = "Assets/Tilemaps/RuleTiles";
    private readonly string _tilesetsPath = "Assets/Tilemaps/Tilesets";


    private readonly string _scenesAppendix = "_SCN";
    private readonly string _spritesAppendix = "_SPR";
    private readonly string _imagesAppendix = "_IMG";
    private readonly string _soundsAppendix = "_SND";
    private readonly string _animationsAppendix = "_ANM";
    private readonly string _presetsAppendix = "_PST";
    private readonly string _palettesAppendix = "_PLT";
    private readonly string _ruleTilesAppendix = "_RTL";
    private readonly string _tilesetsAppendix = "_TLS";

    private bool _shouldRenameScenes;
    private bool _shouldRenameSprites;
    private bool _shouldRenameImages;
    private bool _shouldRenameSounds;
    private bool _shouldRenameAnimations;
    private bool _shouldRenamePresets;
    private bool _shouldRenamePalettes;
    private bool _shouldRenameRuleTiles;
    private bool _shouldRenameTilesets;

    private readonly List<string> _consoleErrorsList = new List<string>();


    [MenuItem("Window/File Renamer")]
    public static void ShowWindow()
    {
        GetWindow(typeof(FileRenamer), false, "File Renamer");
    }

    void OnGUI()
    {
        DisplayModeToggleSection();
    }

    private void DisplayModeToggleSection()
    {
        EditorGUILayout.Space();
        if (GUILayout.Button("Rename Files", GUILayout.Height(60f)))
        {
            RenameAllFiles();
        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Check all", GUILayout.Height(30f)))
        {
            CheckAll();
        }
        if (GUILayout.Button("Reset all", GUILayout.Height(30f)))
        {
            ResetAll();
        }
        GUILayout.EndHorizontal();
        _shouldRenameScenes = GUILayout.Toggle(_shouldRenameScenes, "Rename Scenes", GUILayout.Height(40f));
        _shouldRenameSprites = GUILayout.Toggle(_shouldRenameSprites, "Rename Sprites", GUILayout.Height(40f));
        _shouldRenameImages = GUILayout.Toggle(_shouldRenameImages, "Rename Images", GUILayout.Height(40f));
        _shouldRenameSounds = GUILayout.Toggle(_shouldRenameSounds, "Rename Sounds", GUILayout.Height(40f));
        _shouldRenameAnimations = GUILayout.Toggle(_shouldRenameAnimations, "Rename Animations", GUILayout.Height(40f));
        _shouldRenamePresets = GUILayout.Toggle(_shouldRenamePresets, "Rename Presets", GUILayout.Height(40f));
        _shouldRenamePalettes = GUILayout.Toggle(_shouldRenamePalettes, "Rename Palettes", GUILayout.Height(40f));
        _shouldRenameRuleTiles = GUILayout.Toggle(_shouldRenameRuleTiles, "Rename Rule Tiles", GUILayout.Height(40f));
        _shouldRenameTilesets = GUILayout.Toggle(_shouldRenameTilesets, "Rename Tilesets", GUILayout.Height(40f));
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
        if (_hasStartedRenaming)
        {
            ShowRenameResults();
		}
        Console();
    }

    private void CheckAll()
    {
        _shouldRenameScenes = true;
        _shouldRenameSprites = true;
        _shouldRenameImages = true;
        _shouldRenameSounds = true;
        _shouldRenameAnimations = true;
        _shouldRenamePresets = true;
        _shouldRenamePalettes = true;
        _shouldRenameRuleTiles = true;
        _shouldRenameTilesets = true;
    }

    private void ResetAll()
    {
        _shouldRenameScenes = false;
        _shouldRenameSprites = false;
        _shouldRenameImages = false;
        _shouldRenameSounds = false;
        _shouldRenameAnimations = false;
        _shouldRenamePresets = false;
        _shouldRenamePalettes = false;
        _shouldRenameRuleTiles = false;
        _shouldRenameTilesets = false;
    }

    private void RenameAllFiles()
    {
        _consoleErrorsList.Clear();
        _totalFilesFound = 0;
        _filesSuccessfullyRenamedCount = 0;
        if (_shouldRenameScenes)
            RenameFolderFiles(_scenesPath, _scenesAppendix);
        if (_shouldRenameSprites)
            RenameFolderFiles(_spritesPath, _spritesAppendix);
        if (_shouldRenameImages)
            RenameFolderFiles(_imagesPath, _imagesAppendix);
        if (_shouldRenameSounds)
            RenameFolderFiles(_soundsPath, _soundsAppendix);
        if (_shouldRenameAnimations)
            RenameFolderFiles(_animationsPath, _animationsAppendix);
        if (_shouldRenamePresets)
            RenameFolderFiles(_presetsPath, _presetsAppendix);
        if (_shouldRenamePalettes)
            RenameFolderFiles(_palettesPath, _palettesAppendix);
        if (_shouldRenameRuleTiles)
            RenameFolderFiles(_ruleTilesPath, _ruleTilesAppendix);
        if (_shouldRenameTilesets)
            RenameFolderFiles(_tilesetsPath, _tilesetsAppendix);
        _hasStartedRenaming = true;
    }

    private void RenameFolderFiles(string path, string appendix)
    {
        if (Directory.Exists(path))
        {
            string[] filesFound = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string file in filesFound)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (!fileName.EndsWith(appendix))
                {
                    string error = AssetDatabase.RenameAsset(file, $"{fileName}{appendix}");
                    if (string.IsNullOrEmpty(error))
                    {
                        _filesSuccessfullyRenamedCount++;
                    }
                }
            }
            _totalFilesFound += filesFound.Length;
        }
        else
        {
            _consoleErrorsList.Add($"* File path `{path}` not found");
        }
	}

    private void ShowRenameResults()
    {
        GUIStyle centerLabelStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        GUIStyle successStyle = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        successStyle.normal.textColor = Color.green;
        EditorGUILayout.LabelField($"Total files found: {_totalFilesFound}", centerLabelStyle, GUILayout.ExpandWidth(true));
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Files succesfully renamed: {_filesSuccessfullyRenamedCount}", successStyle, GUILayout.ExpandWidth(true));
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
    }

    private void Console()
    {
        GUIStyle errorStyle = new GUIStyle(EditorStyles.label);
        errorStyle.normal.textColor = Color.red;
		foreach (string consoleError in _consoleErrorsList)
		{
            EditorGUILayout.LabelField(consoleError, errorStyle);
        }
    }
}
