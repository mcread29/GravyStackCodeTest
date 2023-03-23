using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public Sprite image;
    public string[] lines;
    public int zIndex;
    public Vector2 offset;
}

[System.Serializable]
public struct CharacterDialog
{
    public bool isTransition;
    public Character LeftCharacter;
    public Character CenterCharacter;
    public Character RightCharacter;
}

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