using System;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    private GameManager _gameManager;

    private void OnEnable()
    {
        _gameManager = (GameManager)target;
        SetAsActiveManager();
    }

    public VisualTreeAsset m_UXML;

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        m_UXML.CloneTree(root);

        return root;
    }
    
    public void SetAsActiveManager()
    {
        GameManager.ActiveManager = _gameManager;
    }
}