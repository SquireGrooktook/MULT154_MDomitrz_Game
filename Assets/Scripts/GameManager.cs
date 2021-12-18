using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

    public GameManager Game_Manager;

    private int score = 0;

    bool initializeScene = false;
    string sceneName;
    public GameObject player_Prefab;
    GameObject player;
    //GameObject VolumeSliderGet;
    //float VolumeSliderGetFloat;
    public Slider mSlider;

    //Audio

    public AudioSource audioSource;
    public const string VOLUME_LEVEL_KEY = "VolumeLevel";
    public const float DEFAULT_VOLUME = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;

        DontDestroyOnLoad(this.gameObject);

        //Audio stuff
        audioSource = GetComponent<AudioSource>();

        float volume = PlayerPrefs.GetFloat(VOLUME_LEVEL_KEY, DEFAULT_VOLUME);
        audioSource.volume = volume;

        mSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        mSlider.value = volume;
        //VolumeSliderGet = GameObject.Find("Volume Slider");
        //VolumeSliderGetFloat = VolumeSliderGet.GetComponent<Slider>().value;

        //VolumeSliderGet = volume;

        //GameObject.Find("Volume Slider").GetComponent<Slider>().value = volume;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Scene State Machine
        switch (sceneName)
        {
            case "MainGameScene":
            {
                if (initializeScene == false)
                {
                    //Create player
                    player = Instantiate(player_Prefab, new Vector3(-0.16f, 1f, -0.028f), Quaternion.identity);
                    //Get script from player so we can set its game controller variable to this object
                    Player player_script = player.GetComponent<Player>();
                    player_script.Game_Manager = this;

                    //_scoreText.text = "BOOPPIT " + score;
                    //Create Score HUD
                    //scoreHUD = Instantiate(score_Prefab, new Vector3(-0.16f, 1f, -0.028f), Quaternion.identity);
                    audioSource.Play();

                     _scoreText.text = "Score " + score;

                    //Initialization complete
                    initializeScene = true;
                }
                break;
            }
            case "EndScene":
                {
                    if (initializeScene == false)
                    {
                        _scoreText.text = "";

                        //Initialization complete
                        initializeScene = true;
                    }
                    break;
                }
        }

    }

    // scene transition functions
    public void SceneTransition(string sceneChoice)
    {
        sceneName = sceneChoice;
        initializeScene = false;
        SceneManager.LoadScene(sceneChoice, LoadSceneMode.Single);
    }

    // score functions
    public void addScore(int points)
    {
        //Debug.Log(score);
        score += points;
        _scoreText.text = "Score " + score;
    }

    public void clearScore()
    {
        score = 0;
        _scoreText.text = "Score " + score;
    }

    // audio functions

    public void AdjustVolume(float level)
    {
        audioSource.volume = level;
        PlayerPrefs.SetFloat("VolumeLevel", level);
    }


}
