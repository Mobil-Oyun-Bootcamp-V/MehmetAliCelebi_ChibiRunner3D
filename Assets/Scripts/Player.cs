using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    [SerializeField] float _hmoveSpeed;
    [SerializeField] Text _startText;
    [SerializeField] Text _diamondCountText;
    [SerializeField] Text _levelText;
    [SerializeField] GameObject _nextLevelPanel;
    [SerializeField] GameObject _failPanel;
    [SerializeField] Animator _playerAnimator;

    Vector2 direction;
    bool directionChosen;

    [SerializeField] int diamondCount;



    void Start()
    {
        _levelText.text = "Level " + GameManager.level.ToString();
    }
    void Update()
    {
        if (Input.touchCount <= 0 || _nextLevelPanel.active == true || _failPanel.active == true)
        {
            _playerAnimator.SetTrigger("Idle");
            return;
        }
        Move();

        print(Input.touchCount);
    }
    void Move()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            print(Input.touchCount);
            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                case TouchPhase.Stationary:
                    direction.x = 0f;
                    break;
                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = new Vector2(touch.deltaPosition.x, 0f).normalized / Time.deltaTime;
                    break;
            }

        }
        transform.position += new Vector3(-Time.deltaTime * _moveSpeed, 0, 0);
        transform.position += new Vector3(0, 0, direction.x * _hmoveSpeed * Time.deltaTime);


        _startText.enabled = false;
        _playerAnimator.SetTrigger("Move");
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            diamondCount++;
            Destroy(other.gameObject);
            _diamondCountText.text = diamondCount.ToString();
        }
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            _playerAnimator.SetTrigger("Death");
            _failPanel.active = true;
        }
         if (other.gameObject.tag == "Finish")
        {
            Invoke("NextLevel",.4f);
        }
    }

    void NextLevel(){
            _nextLevelPanel.active = true;
    }

}

