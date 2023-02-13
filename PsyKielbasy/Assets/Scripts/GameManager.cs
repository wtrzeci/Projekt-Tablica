using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject Player;
    [SerializeField] private List<Transform> PlayerPositions;
    public static event Action switchDirection;
    public static event Action Restart;
    [SerializeField]private GameObject GameEndedMenu;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Dog");
        Time.timeScale = 0f;//stop the time at the beginning of the game
        Objective.GameWon += GameEnded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Objective.GameWon -= GameEnded;
    }
    private void GameEnded()
    {
        Debug.Log("Game ended");
        Time.timeScale = 0f;
        GameEndedMenu.SetActive(true);
    }
    #region UIPart

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        DontDestroyOnLoad(Player);
        SceneManager.LoadScene(index);
        RestartGame();
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
    }
    public void SwitchDirection()
    {
        switchDirection?.Invoke();
        Debug.Log("Direction change");
    }
    public void RestartGame()
    {   
        if (StartButton != null)
        StartButton.SetActive(true);
        Restart?.Invoke();
        Time.timeScale = 0f;
        Debug.Log("Level restarted");
    }

    #endregion
}
