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
        window.titleContent = new GUIContent("Game Manager");
    }

    public void CreateGUI()
    {
        if(m_GameManager == null) return;

        var scrollView = new ScrollView { viewDataKey = "WindowScrollView" };
        scrollView.Add(new InspectorElement(m_GameManager));
        rootVisualElement.Add(scrollView);
    }
}
