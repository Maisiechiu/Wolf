using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Demo : MonoBehaviour
{

    //     // 我的背景图片为关于 y 轴对称的
    //     // 摄像机的延迟时间
    //     public GameObject Player;
    //     private Transform _playertrans;
    //     private Transform _cameratrans;

    //     // 背景图片
    //     public float _rightboundary;
    //     public float _leftboundary;
    //     public float _upboundary;
    //     public float _downboundary;
    //     // 背景图片的宽度



    //     void Start()
    //     {
    //         _playertrans = Player.GetComponent<Transform>();

    //         mainCamera = gameObject.GetComponent<Camera>();

    //         bgWidth = bgBounds.sprite.bounds.size.x * bgBounds.transform.localScale.x;

    //         bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
    //     }

    //     void Update()
    //     {

    //         float hight = mainCamera.orthographicSize;

    //         float width = hight * Screen.width / Screen.height;
    //         // 要移动到的位置
    //         Vector3 temp;
    //         // 当角色的横坐标 + 摄像机的一半宽度大于背景图片的一半宽度，则为到了边界，把摄像机的宽度设为临界点
    //         if (width + Mathf.Abs(target.position.x) > bgWidth / 2)
    //         {
    //             temp = new Vector3(Mathf.Sign(target.position.x) * (bgWidth / 2 - width), target.position.y, transform.position.z);
    //         }
    //         else
    //         {
    //             // 否则则为正常移动
    //             temp = new Vector3(target.position.x, target.position.y, transform.position.z);
    //         }
    //         // 摄像机高度的临界点同理...

    //         // 实现摄像机的延迟移动
    //         transform.position = Vector3.SmoothDamp(transform.position, temp, ref velocity, smoothTime);
    //     }
}

