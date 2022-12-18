using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private List<Transform> PlayerPositions;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    #region UIPart

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(index);
    }

    #endregion
}
