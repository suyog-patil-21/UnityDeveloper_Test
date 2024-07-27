using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverUIObject;
    
    public void gameOver(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverUIObject.SetActive(true);
    } 

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
