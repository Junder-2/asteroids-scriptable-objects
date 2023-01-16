using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class GameManager : ScriptableObject
{
    private static GameManager _activeManager;

    public static GameManager ActiveManager
    {
        get
        {
            if (_activeManager == null)
            {
                GameManager manager = Resources.Load<GameManager>("GameManagerData");

                if (manager != null)
                {
                    _activeManager = manager;
                    return _activeManager;
                }
                
                manager = CreateInstance<GameManager>();
                AssetDatabase.CreateAsset(manager, "Assets/Resources/GameManagerData");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                _activeManager = manager;
                _activeManager.Reset();
            }
                

            return _activeManager;
        }
        set => _activeManager = value;
    }

    public void Reset()
    {
        PlayerThrottlePower = 7;
        PlayerRotationPower = 3;
        PlayerHealth = 10;
        PlayerLaserSpeed = .2f;
        PlayerFireRate = .25f;

        AsteroidSpawnTime = AnimationCurve.Linear(0, 1, 1, 4);
        AsteroidSpawnAmount = AnimationCurve.Linear(0, 1, 1, 2);
        AsteroidForce = AnimationCurve.Linear(0, 2, 1, 6);
        AsteroidSize = AnimationCurve.Linear(0, .2f, 1, 1);
        AsteroidTorque = AnimationCurve.Linear(0, .1f, 1, .5f);
    }

    public float PlayerThrottlePower;
    public float PlayerRotationPower;
    public int PlayerHealth;
    public float PlayerLaserSpeed;
    public float PlayerFireRate;
    
    public AnimationCurve AsteroidSpawnTime;
    public AnimationCurve AsteroidSpawnAmount;
    
    public AnimationCurve AsteroidForce;
    public AnimationCurve AsteroidSize;
    public AnimationCurve AsteroidTorque;
}