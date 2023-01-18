using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Variables;

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

        foreach (var curve in root.Query<CurveField>().ToList())
        {
            curve.renderMode = CurveField.RenderMode.Mesh;
        }

        return root;
    }

    public void SetAsActiveManager()
    {
        GameManager.ActiveManager = _gameManager;
    }
}