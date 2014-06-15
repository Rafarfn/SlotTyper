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
    public delegate void OnStartListener();
	public delegate void OnEndListener();


	public GameObject startPanel;
	public GameObject winPanel;
	public GameObject lossPanel;


    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		initialized = false;
        listeners += StartGame;
	}


    private void UpdateClock()
    {
        clock.fillAmount = (time / totalGameTime);
    }

	// Update is called once per frame
	void Update ()
	{
		if (!initialized)	return;

        time = Time.realtimeSinceStartup - delayTime;
        UpdateClock();

		if (time >= totalGameTime)
		{
			Win();
		}
	}

    void StartGame()
    {
        delayTime = Time.realtimeSinceStartup;
		if (startPanel != null)
		{
			startPanel.SetActive(false);
		}
    }

    public void Initialize()
    {
        if (!initialized)
        {
            Debug.Log("starting");

            initialized = true;
            listeners();
			
			TypeChecker typeChecker = GetComponent<TypeChecker>();
			typeChecker.enabled = true;
			typeChecker.ForceUpdateItem();
        }
    }


	public void Win ()
	{
		initialized = false;
		if (winPanel != null)
		{
			winPanel.SetActive(true);
		}
		
		GetComponent<TypeChecker>().enabled = false;
		if (endListeners != null)
		{
			endListeners();
		}
	}

	public void Lose()
	{
		initialized = false;
		if (lossPanel != null)
		{
			lossPanel.SetActive(true);
		}
		
		GetComponent<TypeChecker>().enabled = false;
		if (endListeners != null)
		{
			endListeners();
		}
	}

    public OnStartListener listeners;
	
	public OnEndListener endListeners;
  
}
