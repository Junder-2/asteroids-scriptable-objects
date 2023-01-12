using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Manager Data", menuName = "Tools/GameManagerData")]
public class GameManager : ScriptableObject
{
    private static GameManager _activeManager;

    public static GameManager ActiveManager
    {
        get
        {
            if (_activeManager == null)
                _activeManager = CreateInstance<GameManager>();

            return _activeManager;
        }
        set => _activeManager = value;
    }
    
    public float PlayerThrottlePower = 7;
    public float PlayerRotationPower = 3;
    public int PlayerHealth = 10;
    public float PlayerLaserSpeed = .2f;
    
    public AnimationCurve AsteroidSpawnTime = AnimationCurve.Linear(0, 1, 1, 4);
    public AnimationCurve AsteroidSpawnAmount = AnimationCurve.Linear(0, 1, 1, 2);
    
    public AnimationCurve AsteroidForce = AnimationCurve.Linear(0, 2, 1, 6);
    public AnimationCurve AsteroidSize = AnimationCurve.Linear(0, .2f, 1, 1);
    public AnimationCurve AsteroidTorque = AnimationCurve.Linear(0, .1f, 1, .5f);
}