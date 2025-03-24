using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private CinemachineCamera mainCamera;

    public static float globalGameSpeed = 1f;
    [SerializeField] private float gameSpeedAddition = 0.2f;


    [SerializeField] private Game[] gameList;
    private List<Game> activeGameList;
    private Game activeGame;

    private int gameChangeCounter;

    private float timer = 3f;
    private float defaultTimer = 3f;
    private bool pauseTimer = true;

    //Stats
    private bool gameEnded = false;
    private float gameTime = 0;
    private float score = 0;
    private float scoreMultiplier = 10;

    //game speed panel
    [SerializeField] private RectTransform gameSpeedPanel;
    [SerializeField] private Animator gameSpeedAnimatior;
    [SerializeField] private TMP_Text gameSpeedText;

    //End Panel
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TMP_Text gameTimeText;
    [SerializeField] private TMP_Text scoreText;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }

        globalGameSpeed = 1f;

        activeGameList = gameList.ToList();
    }

    IEnumerator Start()
    { 
        StartCoroutine(CalculateTimeAndScore());
        //Select random game at start
        activeGame = gameList[Random.Range(0, gameList.Length)];

        activeGameList.ForEach(game => game.StopGame());

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PlayGame(activeGame));
    }

    void Update()
    {
        //Game Change Cycle
        if(timer <= 0f){
            timer = defaultTimer;

            //if only 1 game left - do not change until game lost
            if(activeGameList.Count > 1){
                StartCoroutine(ChangeGame());
            }
        }
        else{
            if(!pauseTimer){
                timer -= Time.deltaTime;
            }
        }
    }

    public IEnumerator ChangeGame(){
        StopGame(activeGame);
        gameChangeCounter++;

        //Boost game speed every 3 game cycle
        if(gameChangeCounter % 2 == 0 && gameChangeCounter != 0){
            globalGameSpeed += gameSpeedAddition;
            gameChangeCounter = 0;

            gameSpeedPanel.gameObject.SetActive(true);
            gameSpeedText.text = "X" + globalGameSpeed;
            gameSpeedAnimatior.SetTrigger("ShowGameSpeed");
            yield return new WaitForSeconds(1.8f);
            gameSpeedPanel.gameObject.SetActive(false);
        }
        else{
            yield return new WaitForSeconds(0.5f); //Wait for camera change
        }

        List<Game> selectableGames = new List<Game>(activeGameList);
        selectableGames.Remove(activeGame);

        Game selectedGame = selectableGames[Random.Range(0, selectableGames.Count)];
       
        StartCoroutine(PlayGame(selectedGame));

        scoreMultiplier += 10; //Score increases more when game changed
    }

    public IEnumerator PlayGame(Game game){
        game.GetGameCamera().Priority = 10;
        mainCamera.Priority = 0;
        activeGame = game;

        yield return new WaitForSeconds(0.5f);

        timer = defaultTimer;
        game.ContinueGame();
        pauseTimer = false;
    }

    public void StopGame(Game game){
        game.StopGame();
        pauseTimer = true;
        mainCamera.Priority = 10;
        game.GetGameCamera().Priority = 0;
    }

    public void LoseSingleGame(Game game){
        game.Lose();
        activeGameList.Remove(game);
        game.StopGame();

        if(activeGameList.Count == 0){
            StartCoroutine(EndGame());
        }
        else{
            StartCoroutine(ChangeGame());
        }
    }

    private IEnumerator EndGame(){
        mainCamera.Priority = 50;
        pauseTimer = true;

        yield return new WaitForSeconds(0.5f);

        endPanel.GetComponent<Animator>().SetTrigger("Activate");
        gameTimeText.text = Mathf.Floor(gameTime / 60) + ":" + gameTime % 60;
        scoreText.text = "Score: " + score.ToString();
    }

    private IEnumerator CalculateTimeAndScore(){
        while(!gameEnded){
            yield return new WaitForSeconds(1);
            gameTime += 1;
            score += scoreMultiplier * globalGameSpeed;
        }
    }

    public void Replay(){
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu(){
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit(){
        Application.Quit();
    }
}
