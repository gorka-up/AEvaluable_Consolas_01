using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("StarPosition")]
    [SerializeField] private Transform start;


    [Header("Menus")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;

    void Start()
    {
        this.transform.position = start.position;

        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
    }


    void Update()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if(change == InputDeviceChange.Removed)
            {
                Debug.Log("Device disconected in Main menu");
                //pause
            }
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.tag == "Spike") Die();
        else if (collision.gameObject.tag == "End") Win();
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        //move character
    }
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        //move character
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //jump
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        //Pause
    }

    private void Die()
    {
        //call loseMenu
    }

    private void Win()
    {
        //call winMenu
    }
}
