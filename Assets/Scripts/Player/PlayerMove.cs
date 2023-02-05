/* =======================================================
 *  Unity版本：2021.3.16f1c1

 *  作 者：朗朗
 *  主要功能：人物走格子式移动

 *  创建时间：2023-02-05 17:12:51
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;     //玩家速度
    public Transform movePoint; //玩家下一步的移动点
    private float movex, movey; //获取x,y轴的输入
    private Vector2 moveDirection; //玩家的前进方向
    public LayerMask whatStopsMovement;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position,movePoint.position) <= 0.4f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f),.1f,whatStopsMovement));
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f),.1f,whatStopsMovement));
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
        
        //InputSection();
    }
    void FixedUpdate() 
    {
        //Playermove();
    }
    private void Playermove()
    {
        //rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void InputSection()
    {
        //movex = Input.GetAxisRaw("Horizontal");
        //movey = Input.GetAxisRaw("Vertical");
        //moveDirection = new Vector2(movex, movey).normalized;
    }
}
