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

    public void ChangeMusic(){
        AudioSource audioSource = AlwaysMusic.instance.GetComponent<AudioSource>();
        if(audioSource.isPlaying){
            audioSource.Pause();
        }
        else{
            audioSource.Play();
        }
    }
}
