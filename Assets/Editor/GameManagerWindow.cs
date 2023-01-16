using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerWindow : EditorWindow, IHasCustomMenu
{
    public GameManager m_GameManager;

    [MenuItem("Tools/Game Manager")]
    static void CreateMenu()
    {
        var window = GetWindow<GameManagerWindow>();
        window.position = new Rect(50f, 50f, 250, 400);
        window.titleContent = new GUIContent("Game Manager");
    }

    private void OnEnable()
    {
        m_GameManager = GameManager.ActiveManager;
    }

    public void CreateGUI()
    {
        var view = new VisualElement();

        view.Add(new InspectorElement(m_GameManager));
        rootVisualElement.Add(view);
    }

    private void ResetAsset()
    {
        Undo.RecordObject(m_GameManager, "Reset Values");
        m_GameManager.Reset();
    }

    public void AddItemsToMenu(GenericMenu menu)
    {
        GUIContent content = new GUIContent("Reset Values");
        menu.AddItem(content, false, ResetAsset);
    }
}
