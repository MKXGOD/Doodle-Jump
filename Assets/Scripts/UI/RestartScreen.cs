using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _goScreen;
    [SerializeField] private PigControl _pigControl;

    private void Update()
    {
        GameOverScreen();
    }
    public void GameOverScreen()
    {
        if (_pigControl.IsAlive == false)
        {
            Time.timeScale = 0;
            _goScreen.SetActive(true);
        }
        else Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
