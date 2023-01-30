using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*先写个移动用于测试，后面你们再改--by红豆*/
public class PlayerMoveController : MonoBehaviour
{

    private float inputX, inputY;//移动的横纵偏移量
    private Vector2 movementInput;//移动向量
    private Rigidbody2D playerRigid;//人物的刚体

    public float speed = 5;//移速调整

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
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
