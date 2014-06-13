using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
 
    public float speedFactor = 1;

    public float time;
    private float delayTime;

    private bool initialized = false;
    public delegate void OnStartListener();


    void Awake()
    {
        instance = new LevelManager();
    }

	// Use this for initialization
	void Start () {
        listeners += StartGame;
	}
	
	// Update is called once per frame
	void Update () {
        time = Time.realtimeSinceStartup - delayTime;
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
            Debug.Log("starting");
            Camera.main.GetComponent<TypeChecker>().enabled = true;
            initialized = true;
            listeners();

        }
    }

    public OnStartListener listeners;

  
}
