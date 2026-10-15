using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMenuController : MonoBehaviour
{
    [Header("PauseMenu")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuPauseButton;

    private bool isPause = false;

    [Header("WinMenu")]
    [SerializeField] private GameObject winMenu;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button mainMenuWinButton;

    [Header("loseMenu")]
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuLoseButton;

    private bool winOrLose = false;

    void Start()
    {
        pauseMenu.SetActive(false);

        InputSystem.onDeviceChange += (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log("Device conected in Main menu");
                    if(isPause) resumeButton.Select();
                    break;

                case InputDeviceChange.Removed:
                    Debug.Log("Device disconected in Main menu");
                    if (!isPause) Pause();
                    break;
            }
        };
    }

    public void Pause()
    {
        if (isPause)
        {
            EventSystem.current.SetSelectedGameObject(null);
            pauseMenu.SetActive(false);
            isPause = false;

        }
        else
        {
            pauseMenu.SetActive(true);
            resumeButton.Select();
            isPause = true;
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        //Reestart position player
    }
}
