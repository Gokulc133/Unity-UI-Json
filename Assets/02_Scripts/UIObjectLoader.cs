using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIObject
{
    public string name;
    public string type;
    public Vector2 position;
    public float rotation;
    public Vector2 scale;
    public Color color;
    public RectTransformProperties rectTransform;
    public ImageProperties image;
}

[System.Serializable]
public class RectTransformProperties
{
    public float width;
    public float height;
}

[System.Serializable]
public class ImageProperties
{
    public string source;
}

[System.Serializable]
public class UIObjectData
{
    public UIObject[] uiObjects;
}

public class UIObjectLoader : MonoBehaviour
{
    public TextAsset jsonFile;
    public Canvas canvas;

    void Start()
    {
        if (jsonFile != null)
        {
            LoadUIObjects();
        }
    }

    void LoadUIObjects()
    {
        string jsonContent = jsonFile.ToString();
        UIObjectData data = JsonUtility.FromJson<UIObjectData>(jsonContent);

        foreach (UIObject uiObject in data.uiObjects)
        {
            GameObject newUIElement = new GameObject(uiObject.name);
            newUIElement.transform.SetParent(canvas.transform);

            RectTransform rt = newUIElement.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(uiObject.rectTransform.width, uiObject.rectTransform.height);
            rt.anchoredPosition = uiObject.position;
            rt.eulerAngles = new Vector3(0, 0, uiObject.rotation);
            rt.localScale = uiObject.scale;

            Image img = newUIElement.AddComponent<Image>();
            img.color = uiObject.color;

            if (uiObject.type == "Panel")
            {
                ImageProperties imageProperties = uiObject.image;
                if (imageProperties != null)
                {
                    // Load image from source if available
                }
            }
            else if (uiObject.type == "Button")
            {
                // Handle button specific properties if needed
            }

            // Add other component handling as needed
        }
    }
}
