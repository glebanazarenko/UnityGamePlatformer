using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour
{
    public void RestartGame(){
        MoneyText.Coin = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMenu(){
        SceneManager.LoadScene("SelectLevel");
    }

    public void StartLevel1(){
        SceneManager.LoadScene("1.01");
    }

    public void StartLevel2(){
        SceneManager.LoadScene("First");
    }

    public void StartLevel3(){
        SceneManager.LoadScene("Second");
    }
}
