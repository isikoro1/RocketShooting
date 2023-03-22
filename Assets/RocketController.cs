using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
    //移動速度
    private float moveSpeed = 6f;

    public GameObject bulletPrefab;

    //移動制限処理用変数
    private Vector2 playerPos;
    private readonly float playerPosXClamp = 2.3f;
    private readonly float playerPosYClamp = 7.0f;

    void Update()
    {

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1 * this.moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(this.moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        // 移動制限処理
        this.MovingRestrictions();
    }

    /// <summary>
    /// 移動制限
    /// </summary>
    private void MovingRestrictions()
    {
        //変数に自分の今の位置を入れる
        this.playerPos = transform.position;

        //playerPos変数のxとyに制限した値を入れる
        //playerPos.xという値を-playerPosXClamp～playerPosXClampの間に収める
        this.playerPos.x = Mathf.Clamp(this.playerPos.x, -this.playerPosXClamp, this.playerPosXClamp);
        this.playerPos.y = Mathf.Clamp(this.playerPos.y, -this.playerPosYClamp, this.playerPosYClamp);

        transform.position = new Vector2(this.playerPos.x, this.playerPos.y);
    }

}