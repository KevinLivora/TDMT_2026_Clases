using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Movement player1;
   
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private TMP_Text profileName;
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnCounter;
    [SerializeField] private TMP_Text textCounter;
    
    [SerializeField] private Slider sliderPlayer1Speed;
    [SerializeField] private TMP_Text textPlayer1Speed;
    private int counter = 0;
    private bool isPause = false;

    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnCounter.onClick.AddListener(OnCounterClicked);
        sliderPlayer1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged);
    }
    private void Start()
    {
        profileName.text = "Player Name";
        profileName.color = Color.red;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            mainMenuCanvas.SetActive (true);

            if (isPause ) 
            Time.timeScale = 0;
            else
            Time.timeScale = 1;
        }
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnCounter.onClick.RemoveAllListeners();
        sliderPlayer1Speed.onValueChanged.RemoveAllListeners();
    }
    private void OnPlayClicked ()
    {
        mainMenuCanvas.SetActive(false);
    }

    private void OnCounterClicked()
    {
        counter++;
        textCounter.text = counter.ToString();
    }

    private void OnPlayer1SpeedChanged(float value)
    {
        player1.moveSpeed = value;
        textPlayer1Speed.text = value.ToString("F2");
    }
    
}
