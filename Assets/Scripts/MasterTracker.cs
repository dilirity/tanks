using UnityEditor.PackageManager;
using UnityEngine;

public class MasterTracker : MonoBehaviour
{
    static MasterTracker instance = null;

    [SerializeField]
    int smallTankPoints = 100;
    int fastTankPoints = 200;
    int bigTankPoints = 300;
    int armoredTankPoints = 400;

    public int smallTankPointsWorth
    {
        get
        {
            return smallTankPoints;
        }
    }

    public int fastTankPointsWorth
    {
        get
        {
            return fastTankPoints;
        }
    }
    public int bigTankPointsWorth
    {
        get
        {
            return bigTankPoints;
        }
    }
    public int armoredTankPointsWorth
    {
        get
        {
            return armoredTankPoints;
        }
    }

    public static int smallTankDestroyed, fastTankDestroyed, bigTankDestroyed, armoredTankDestroyed;
    public static int stageNumber;
    public static int playerLives = 3;
    public static int playerScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
