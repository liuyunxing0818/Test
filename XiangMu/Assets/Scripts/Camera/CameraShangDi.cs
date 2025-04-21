using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShangDi : MonoBehaviour
{
    // 移动速度
    public float moveSpeed = 5f;
    // 旋转速度
    public float rotateSpeed = 2f;
    // 缩放速度
    public float zoomSpeed = 5f;
    // 最小缩放距离
    public float minZoom = 2f;
    // 最大缩放距离
    public float maxZoom = 10f;

    void Update()
    {
        // 前后左右移动
        float verticalInput = Input.GetAxis("Vertical"); // 获取垂直方向输入
        float horizontalInput = Input.GetAxis("Horizontal"); // 获取水平方向输入
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime); // 根据输入前后移动
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime); // 根据输入左右移动

        // 旋转视角
        float rotateHorizontal = Input.GetAxis("Mouse X"); // 获取鼠标水平方向移动
        float rotateVertical = Input.GetAxis("Mouse Y"); // 获取鼠标垂直方向移动
        transform.Rotate(Vector3.up, rotateHorizontal * rotateSpeed); // 绕Y轴旋转
        transform.Rotate(Vector3.left, rotateVertical * rotateSpeed); // 绕X轴旋转

        // 缩放视角
        float scrollInput = Input.GetAxis("Mouse ScrollWheel"); // 获取鼠标滚轮输入
        float newDistance = Camera.main.transform.localPosition.z - scrollInput * zoomSpeed; // 计算新的缩放距离
        newDistance = Mathf.Clamp(newDistance, -maxZoom, -minZoom); // 限制缩放距离在最小和最大范围内
        Camera.main.transform.localPosition = new Vector3(0, 0, newDistance); // 更新相机位置
    }
}
