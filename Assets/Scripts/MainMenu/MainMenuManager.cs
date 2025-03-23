using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void LoadGameScene(){
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void Quit(){
        Application.Quit();
    }
}
