using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class UIObject
{
    public string Name;
    public Vector2 Position;
    public float Rotation;
    public Vector2 Scale;
    public Color Color;
}

[System.Serializable]
public class CustomUIObjectData
{
    public List<UIObject> uiObjects = new List<UIObject>();
}

public class UITemplateEditor : EditorWindow
{
    private TextAsset jsonFile;
    private string loadedJSONData = "";
    private string newTemplateName = "New Template";
    private Vector2 newPosition;
    private float newRotation;
    private Vector2 newScale = Vector2.one;
    private Color newColor = Color.white;

    [MenuItem("Window/UITemplate Editor")]
    public static void ShowWindow()
    {
        GetWindow<UITemplateEditor>("UITemplate Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("UI Template Editor", EditorStyles.boldLabel);

        jsonFile = EditorGUILayout.ObjectField("JSON File", jsonFile, typeof(TextAsset), false) as TextAsset;

        if (jsonFile != null)
        {
            string path = AssetDatabase.GetAssetPath(jsonFile);
            loadedJSONData = File.ReadAllText(path);
        }
        else
        {
            loadedJSONData = "";
        }

        EditorGUILayout.LabelField("Loaded JSON Data:");
        loadedJSONData = EditorGUILayout.TextArea(loadedJSONData, GUILayout.Height(200));

        // UI for creating a new template
        newTemplateName = EditorGUILayout.TextField("Template Name", newTemplateName);
        newPosition = EditorGUILayout.Vector2Field("Position", newPosition);
        newRotation = EditorGUILayout.FloatField("Rotation", newRotation);
        newScale = EditorGUILayout.Vector2Field("Scale", newScale);
        newColor = EditorGUILayout.ColorField("Color", newColor);

        if (GUILayout.Button("Create Template"))
        {
            CreateTemplate();
        }

        if (GUILayout.Button("Save Changes"))
        {
            SaveChanges();
        }
    }

    private void CreateTemplate()
    {
        UIObject newObject = new UIObject
        {
            Name = newTemplateName,
            Position = newPosition,
            Rotation = newRotation,
            Scale = newScale,
            Color = newColor
        };

        // Add the new object to your list of UIObjects (uiObjects)
        // Assuming you have a list of UIObjects somewhere in your script
        // uiObjects.Add(newObject);
    }

    private void SaveChanges()
    {
        if (jsonFile != null)
        {
            string path = AssetDatabase.GetAssetPath(jsonFile);

            try
            {
                File.WriteAllText(path, loadedJSONData);
                AssetDatabase.Refresh();
                Debug.Log("Changes saved successfully!");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error saving changes: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("No valid JSON file selected.");
        }
    }
}
