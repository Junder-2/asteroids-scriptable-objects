using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public VisualTreeAsset m_UXML;

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        m_UXML.CloneTree(root);

        return root;
    }
}