using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _direction;

    public Paddle paddle;

    public float minTime = 6f;
    public float maxTime = 16f;
    private bool isInverseMode = false;
    public GameObject switchText; 

    private void Start()
    {
        switchText.SetActive(false);
        StartCoroutine(SetInverseMode());
    }
    
    private void Update()
    {
        _direction = Vector2.zero;

        if (!isInverseMode) {
            if (Keyboard.current.wKey.isPressed)
                _direction = Vector2.up;
            else if (Keyboard.current.sKey.isPressed)
                _direction = Vector2.down;
        }
        else
        {
            InverseMode();
        }
    
        paddle.direction = _direction;
    }

    private void InverseMode()
    {
        if (Keyboard.current.sKey.isPressed)
            _direction = Vector2.up;
        else if (Keyboard.current.wKey.isPressed)
            _direction = Vector2.down;
    }
    
    private IEnumerator SetInverseMode()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime) - 2f);
            switchText.SetActive(true);
            yield return new WaitForSeconds(2f);

            isInverseMode = !isInverseMode;
            switchText.SetActive(false);
        }
    }
}