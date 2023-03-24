using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// Data for the individual characters
[System.Serializable]
public class Character
{
    // image to use for a specific dialog
    public Sprite image;
    // the lines the character should say
    public string[] lines;
    // the sort order for the character
    public int zIndex;
    // the x/y offset for a specific dialog
    public Vector2 offset;
}

// One dialog for 3 characters
[System.Serializable]
public struct CharacterDialog
{
    public bool isTransition;
    public Character LeftCharacter;
    public Character CenterCharacter;
    public Character RightCharacter;
}

// Scriptable object to define a specific sequence of dialogs
public class DialogSequence : ScriptableObject
{
    public CharacterDialog[] dialogs;

#if UNITY_EDITOR
    [MenuItem("Assets/Create/DialogSequence")]
    public static void CreateMyAsset()
    {
        DialogSequence asset = ScriptableObject.CreateInstance<DialogSequence>();

        AssetDatabase.CreateAsset(asset, "Assets/NewDialogSequence.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
#endif
}