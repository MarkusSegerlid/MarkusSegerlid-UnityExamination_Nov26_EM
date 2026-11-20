using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{
    public void LoadScene(string destination) => SceneManager.LoadSceneAsync(destination, LoadSceneMode.Single);
    
    public void QuitGame() => Application.Quit();
}
