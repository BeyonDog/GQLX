using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*先写个移动用于测试，后面你们再改--by红豆*/
public class PlayerMove : MonoBehaviour
{

    private float inputX, inputY;//移动的横纵偏移量
    private Vector2 movementInput;//移动向量
    private Rigidbody2D playerRigid;//人物的刚体

    public float speed = 5;//移速调整

    private bool canControl = true;//能否操控

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        EventHandler.GameEventUI += OnGameEventUI;
        EventHandler.GameEventAgain += OnGameEventAgain;
        EventHandler.GameEventEnd += OnGameEventEnd;
    }

    private void OnDisable()
    {
        EventHandler.GameEventUI -= OnGameEventUI;
        EventHandler.GameEventAgain -= OnGameEventAgain;
        EventHandler.GameEventEnd -= OnGameEventEnd;
    }

    private void OnGameEventAgain(string arg1, Sprite arg2)
    {
        canControl = false;
    }

    /// <summary>
    /// 触发事件时不可控制
    /// </summary>
    /// <param name="gameEventDetails"></param>
    private void OnGameEventUI(string gameEventID)
    {
        canControl = false;
    }

    private void OnGameEventEnd(string endText, Sprite endSprite)
    {
        canControl = true;
    }

    private void Update()
    {
        if (canControl)
            PlayerInput();
    }
    private void FixedUpdate()
    {
        if (canControl)
            Movement();
    }
    /// <summary>
    /// 根据键盘输入计算移动向量
    /// </summary>
    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 && inputY != 0)
        {
            inputX = inputX * 0.7f;
            inputY = inputY * 0.7f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            inputX *= 0.5f;
            inputY *= 0.5f;
        }
        movementInput = new Vector2(inputX, inputY);
    }
    /// <summary>
    /// 移动方法
    /// </summary>
    void Movement()
    {
        playerRigid.MovePosition(playerRigid.position + movementInput * speed * Time.deltaTime);
    }
}
