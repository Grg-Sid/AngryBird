using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    int sceneIndex, currentIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentIndex = sceneIndex;
    }
    public void SceneLoaderNext()
    {
        SceneManager.LoadScene(sceneIndex + 1);
        currentIndex = sceneIndex + 1;
    }
    public void SceneLoaderPrevious()
    {
        SceneManager.LoadScene(sceneIndex - 1);
        currentIndex = sceneIndex - 1;
    }

    public void SceneReset()
    {
        SceneManager.LoadScene(sceneIndex);
        currentIndex = sceneIndex;
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("App has quit");
    }
}
