Unity UI Object Template Generator with JSON

Introduction
The Unity UI Object Template Generator with JSON is a custom tool designed to streamline the creation and management of UI object templates within the Unity Editor. This tool allows users to define predefined configurations for object hierarchies using JSON data. These templates can be easily instantiated and customized in Unity scenes.

Features
1. JSON Data Format
Description: The tool utilizes a specific JSON file format to store data representing UI object hierarchies.

Properties: Each template includes properties such as object name, position, rotation, scale, color, and additional UI attributes or components.

Example JSON Data:

json
{
  "uiObjects": [
    {
      "name": "Panel1",
            "type": "Panel",
            "position": {
                "x": 100,
                "y": 200
            },
            "rotation": 0,
            "scale": {
                "x": 1,
                "y": 1
            },
            "color": {
                "r": 255,
                "g": 255,
                "b": 255,
                "a": 255
            },
            "rectTransform": {
                "width": 200,
                "height": 150
            }
    },
    // More objects...
  ]
}

2. Unity Custom Editor
Description: The tool provides a custom Unity editor window or inspector for managing UI object templates.
Features:
Load, view, and edit JSON data for object templates within the Unity Editor.
Display JSON data in a user-friendly way for easy editing.

3. Template Creation
Description: Users can create new UI object templates directly within the custom editor.
Features:
UI for specifying template properties (name, position, rotation, scale, color, etc.).
Ability to save these properties to the JSON file.

4. Template Instantiation
Description: Functionality to instantiate UI hierarchies in Unity scenes based on selected templates.
Process:
When users select a template from the custom editor, a Canvas Hierarchy is created in the current scene with the specified properties.

5. Customization
Description: Users can customize instantiated objects' properties within the Unity Editor.
Features:
UI controls for adjusting position, rotation, scale, color, etc.
Ability to save these customizations back to the JSON data.
