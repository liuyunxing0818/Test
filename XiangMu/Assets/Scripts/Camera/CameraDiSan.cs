using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDiSan : MonoBehaviour
{
    // 被跟随的角色
    public Transform target;
    // 相机与角色的距离
    public float distance = 5f;
    // 相机的高度
    public float height = 2f;
    // 相机旋转的平滑度
    public float smooth = 2f;

    // 当前相机的水平旋转角度
    private float currentRotationX = 0f;
    // 当前相机的垂直旋转角度
    private float currentRotationY = 0f;

    void LateUpdate()
    {
        // 获取鼠标输入以旋转相机
        float mouseX = Input.GetAxis("Mouse X"); // 获取鼠标水平移动
        float mouseY = Input.GetAxis("Mouse Y"); // 获取鼠标垂直移动

        // 更新相机的水平和垂直旋转角度
        currentRotationX += mouseX * smooth;
        currentRotationY -= mouseY * smooth;
        // 限制垂直旋转角度在 -80 到 80 度之间
        currentRotationY = Mathf.Clamp(currentRotationY, -80f, 80f);

        // 根据旋转角度计算相机的旋转四元数
        Quaternion rotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);

        // 计算相机的目标位置
        Vector3 position = target.position - (rotation * Vector3.forward * distance);
        position.y = target.position.y + height;

        // 平滑移动相机到目标位置
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, position, Time.deltaTime * smooth);
        // 平滑旋转相机到目标角度
        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, rotation, Time.deltaTime * smooth);
    }
}
