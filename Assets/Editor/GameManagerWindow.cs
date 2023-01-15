using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerWindow : EditorWindow
{
    public GameManager m_GameManager;

    [MenuItem("Tools/Game Manager")]
    static void CreateMenu()
    {
        var window = GetWindow<GameManagerWindow>();
        window.minSize = new Vector2(250, 400);
        window.titleContent = new GUIContent("Game Manager");
    }

    private void OnEnable()
    {
        m_GameManager = GameManager.ActiveManager;
    }

    public void CreateGUI()
    {
        var scrollView = new VisualElement();

        scrollView.Add(new InspectorElement(m_GameManager));
        rootVisualElement.Add(scrollView);
    }
}
