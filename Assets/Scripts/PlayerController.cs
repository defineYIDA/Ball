using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    public Text CountText;

    public Text WinText;

    public GameObject effect;

    public GameObject eatText; // 添加碰撞特效

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //绑定刚性对象
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();
        WinText.text = "";
    }

    //Update 和 FixedUpdate都是对象更新时被调用的函数，在每一帧都会调用的，
    //但是区别在于两者的帧长度是不一样的。
    //Update 与当前平台的帧数相关，根据渲染的帧数来调用的。
    //FixedUpdate采用的真实时间间隔作为帧长，处理物理逻辑一般在FixedUpdate中处理。
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//水平方向移动的数据
        float moveVertical = Input.GetAxis("Vertical");//垂直方向移动的数据

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //更改小球状态
        rb.AddForce(movement * speed);
    }

    //碰撞消失
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            GameObject newEffect = (GameObject)Instantiate(effect, transform.position, effect.transform.rotation);
            Destroy(newEffect, 1.0f);

            eatText.SetActive(true);
            print("on");
            
            count = count + 1;
            SetCountText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        eatText.SetActive(false);
        print("exit");
        // 不能提前false，不然不触发该函数
        other.gameObject.SetActive(false);
    }

    void SetCountText()
    {
        CountText.text = "Count:" + count.ToString();
        if (count >= 5)
        {
            //eatText.SetActive(false);
            WinText.text = "You Win!";
            int i = 5;
            while (i > 1) {
                GameObject newEffect = (GameObject)Instantiate(effect, transform.position, effect.transform.rotation);
                Destroy(newEffect, 1.0f);
                i--;
            }
        }
    }
}
