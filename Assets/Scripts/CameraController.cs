using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //场景中所有实体的基类，球体
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //transfrom 为当前实体camera的位置
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //LateUpdate（最后更新）效率会更高一点
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
