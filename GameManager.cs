using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Member Variables & Objects
    public static GameManager instance;
    public static GameState state = GameState.Menu;
    public GameObject Menu, Game, GameOver, Cube, fire, Player, platform, toplevel, castle,Insect,Queen, watermelon, tree;
    public TMP_Text Health, Lives, Score, Highscore;
    public static int score, hi_score = 0, health, lives;
    public AudioSource start, finale;
    public static List<GameObject> all = new List<GameObject>();

    // Enumerator for changing states
    public enum GameState
    {
        Menu,Game,GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        //Method calls for GameManager Script
        Camera.main.transform.position = new Vector3(0f, 60f, 0f);
        Camera.main.transform.LookAt(Vector3.zero, new Vector3(0f, 0f, 1f));
        finale = GetComponent<AudioSource>();
        start = GetComponent<AudioSource>();
        finale.Stop();
        start.Stop();
        instance = this;
        setState(GameState.Menu);
        MoveBlocks();
        MoveFire();
        MovePlatforms();
        UpperLevel();
        CreateCastle();
        CreateWatermelon();
        CreateTree();
    }

    // Switch statement for moving between states Menu,Game and GameOver
    public static void setState(GameState current)
    {
        state = current;

        switch (current)
        {
            case GameState.Menu:
                instance.Game.SetActive(false);
                instance.GameOver.SetActive(false);
                instance.Menu.SetActive(true);
                GameManager.instance.PlayIntro();
                break;
            case GameState.Game:
                instance.GameOver.SetActive(false);
                instance.Menu.SetActive(false);
                instance.Game.SetActive(true);
                break;
            case GameState.GameOver:
                instance.Menu.SetActive(false);
                instance.Game.SetActive(false);
                instance.GameOver.SetActive(true);
                GameManager.instance.PlayGameOver();
                break;
        }
    }

    // StartGame() Method primarily used to set scores,lives,health and spawn player and enemies
    // Skybox created using Unity Assets Store
    // DinvStudio(2020)
    public void StartGame()
    {
        setState(GameState.Game);
        setScore(0);
        setLives(3);
        setHealth(100);
        CreatePlayer();
        CreateEnemy();
        CreateSpiderQueen();
    }

    // method for changing state from Game Over Screen to Menu using back button
    // Objects created using Unity Assets Store
    // (BayatGames/Support, 2020)
    public void GameOverScreen()
    {
        setState(GameState.Menu);
    }

    // Method for changing state to menu screen
    // Objects created using Unity Assets Store
    // (BayatGames/Support, 2020)
    public static void MenuScreen()
    {
        setState(GameState.Menu);
    }

    // Creates Player Game Object
    // Objects created using Unity Assets Store
    // ANON(2020)
    public static void CreatePlayer()
    {
        GameObject player = Instantiate(instance.Player) as GameObject;
    }

    // Creates Insect Enemy Game Object
    // Objects created using Unity Assets Store
    // (Leo Blanchette 3d: Interactive Media, Illustration, and Design | LB3D, 2020)
    public static void CreateEnemy()
    {
        GameObject Go = Instantiate(instance.Insect) as GameObject;
        all.Add(Go);
    }

    // Creates Spider Queen Game Object
    // Objects created using Unity Assets Store
    // (Tilen Jordan, 2020)
    public static void CreateSpiderQueen()
    {
        GameObject Boss = Instantiate(instance.Queen) as GameObject;
    }

    // Creates Castle Game Object
    // Objects created using Unity Assets Store
    // (Forest - Low Poly Toon Battle Arena / Tower Defense Pack, 2020)
    void CreateCastle()
    {
        Instantiate(castle, transform.position = new Vector3(-8, -20, 12), Quaternion.identity);
    }

    // Creates Watermelon Game Object
    // Objects created using Unity Assets Store
    //(Rem - Unity Connect, 2020)
    void CreateWatermelon()
    {
        Instantiate(watermelon, transform.position = new Vector3(-13f, -20f, -30f), Quaternion.identity);
    }

    // Creates Tree Game Object
    // Objects created using Unity Assets Store
    // (Forest - Low Poly Toon Battle Arena / Tower Defense Pack, 2020)
    void CreateTree()
    {
        Instantiate(tree, transform.position = new Vector3(-13f, -20f, -30f), Quaternion.identity);
    }

    // Method that moves botom level cubes to designated positions (Hard - Coded)
    // Objects created using Unity Assets Store
    // (Forest - Low Poly Toon Battle Arena / Tower Defense Pack, 2020)
    void MoveBlocks()
    {
        Vector3 initial = new Vector3(-85f, -20f, -36f);
        Vector3 current = initial;

        for (int i = 0; i < 6; i++)
        {
            current.x += 24f;
            GameObject block = Instantiate(instance.Cube) as GameObject;
            block.transform.position = current;
        }
    }

    // Method that moves mid level cubes to designated positions (Hard - Coded)
    // Objects created using Unity Assets Store
    // (Forest - Low Poly Toon Battle Arena / Tower Defense Pack, 2020)
    void MovePlatforms()
    {
        Vector3 initial = new Vector3(-65, -20f, -10f);
        Vector3 current = initial;

        for (int i = 0; i < 5; i++)
        {
            current.x += 21.5f;
            GameObject block = Instantiate(instance.platform) as GameObject;
            block.transform.position = current;
        }
    }


    // Method that moves Upper level cubes to designated positions (Hard - Coded)
    // Objects created using Unity Assets Store
    // (Forest - Low Poly Toon Battle Arena / Tower Defense Pack, 2020)
    void UpperLevel()
    {
        Vector3 initial = new Vector3(-55, -20f, 12f);
        Vector3 current = initial;

        for (int i = 0; i < 3; i++)
        {
            current.x += 23.5f;
            GameObject block = Instantiate(instance.toplevel) as GameObject;
            block.transform.position = current;
        }

    }

    // Method that moves Particle System "Fire" to designated positions (Hard - Coded)
    // Objects created using Unity Assets Store
    // (Forest - Low Poly Toon Battle Arena / Tower Defense Pack, 2020)
    void MoveFire()
    {
        Vector3 initial = new Vector3(-65, -10f, -36f);
        Vector3 current = initial;

        for (int i = 0; i < 5; i++)
        {
            current.x += 21.5f;
            GameObject block = Instantiate(instance.fire) as GameObject;
            block.transform.position = current;
        }
    }

    // Method used to set Score and update Hi-Score 
    // and use Text Mesh Pro Text Objects to display on Game Screen
    public static void setScore(int new_score)
    {
        score = new_score;
        instance.Score.text = "Score: " + score;
        if (score > hi_score)
        {
            hi_score = score;
            instance.Highscore.text = "HI-Score: " + hi_score;
        }

        if (score > 4500)
        {
            setState(GameState.GameOver);
            Debug.Log("Congratulations you won");
        }
    }

    // Method used to set number of lives Player will receive
    // and use Text Mesh Pro Text Objects to display on Game Screen
    public static void setLives(int new_lives)
    {
        lives = new_lives;
        instance.Lives.text = "Lives: " + lives;
    }

    // Method used to set Health the Player will receive
    // and use Text Mesh Pro Text Objects to display on Game Screen
    public static void setHealth(int new_health)
    {
        health = new_health;
        instance.Health.text = "Health: " + health;
    }

    // method for Start Game button attached  to on click in Inspector
    public void onclickStartGameButton()
    {
        StartGame();
    }

    // method for Quit Game button attached  to on click in Inspector
    public void onclickQuitGameButton()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    // method to play Quit game music
    // Sounds taken from Unity Assets Store (Zero Rare Home, 2020)
    public void PlayGameOver()
    {
        finale.Play();
    }

    // method to play Start game music
    // Sounds taken from Unity Assets Store (Zero Rare Home, 2020)
    public void PlayIntro()
    {
        start.Play();
    }
}
