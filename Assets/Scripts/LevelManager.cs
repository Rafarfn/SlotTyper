using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public UISprite clock;
    

    public float speedFactor = 1;
    public float totalGameTime = 20;


    public float time;
    private float delayTime;

    private bool initialized = false;
    private TypeChecker typeChecker;
    public delegate void OnStartListener();


    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        listeners += StartGame;
        typeChecker = GetComponent<TypeChecker>();
        typeChecker.enabled = false;
	}


    private void UpdateClock()
    {
        clock.fillAmount = (time / totalGameTime);
    }
	// Update is called once per frame
	void Update () {
        time = Time.realtimeSinceStartup - delayTime;
        UpdateClock();
        Initialize();
	}

    void StartGame()
    {
        delayTime = Time.realtimeSinceStartup;
    }

    private void Initialize()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) && !initialized)
        {
            typeChecker.enabled = true;
            initialized = true;
            listeners();

        }
    }

    public OnStartListener listeners;

  
}
