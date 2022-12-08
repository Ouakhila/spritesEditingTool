using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

//sing System.Reflection.Emit;
//using static System.Net.Mime.MediaTypeNames;

public class EditorGUILayoutTextField : EditorWindow
{

    [SerializeField]
    int x;
    [SerializeField]
    int y;

    bool buttonpressed = false;

    private Button addButton;
    private Label statusLabel;

    [MenuItem("Tools/Scene Selector %#o")]
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(EditorGUILayoutTextField));
        window.Show();
    }

    private void CreateGUI()

    {

        // Each editor window contains a root VisualElement object.

        VisualElement root = rootVisualElement;

        // Create elements and add them to the visual tree.
        root.Add(new PropertyField() { bindingPath = nameof(x) });
        root.Add(new PropertyField() { bindingPath = nameof(y) });

        addButton = new Button(ToAddObjOnAxis)
        {
            text = "Add"
        };

        root.Add(addButton);


        // Bind the created fields to this window's serializable data
        root.Bind(new SerializedObject(this));
    }

    private void ToAddObjOnAxis()
    {


        for (int a = 0; a < x; a++)

        {
            if (Selection.activeGameObject)
            {
                Instantiate(Selection.activeGameObject, new Vector3(a * 1, 0, 0), Quaternion.identity);
            }


        }


        for (int i = 0; i < y; i++)
        {
            if (Selection.activeGameObject)
            {
                Instantiate(Selection.activeGameObject, new Vector3(0, i * 1, 0), Quaternion.identity);
            }

        }
    }
}

