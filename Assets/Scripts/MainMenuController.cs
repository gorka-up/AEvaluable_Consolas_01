using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        playButton.Select();
    }

    private void Update()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log("Device conected in Main menu");
                    playButton.Select();
                    break;

                case InputDeviceChange.Removed:
                    Debug.Log("Device disconected in Main menu");
                    EventSystem.current.SetSelectedGameObject(null);
                    break;
            }
        };
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            playButton.Select();
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
