using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMotion : MonoBehaviour
{
    // TODO: このボイドクラスが持つべきデータ・属性・バリエーション（フィールド）とは？
    // それぞれで異なる可能性がある数値
    Vector3 position;  // 位置
    Vector3 direction; // 移動方向
    float speed;       // 移動速度
    // or
    // Vector3 velocity; // 速度ベクトル？

    // - 色、大きさ
    // - 対人距離、近寄りがたさ etc...

    // TODO: このボイドクラスが持つべき機能（メソッド）は？
    //
    // クラスインスタンスに共通する機能・手続き・処理

    void Awake() //コンストラクタ代わり　＝　全ボイドが出現するときに行われる
    {
        Vector3 p = Vector3.zero;
        p.x = Random.Range(-5.0f, 5.0f);
        p.y = Random.Range(-5.0f, 5.0f);
        p.z = Random.Range(-5.0f, 5.0f);
        position = p;
        //direction = Vector3.forward;
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);
        direction.z = Random.Range(-1.0f, 1.0f);     
        speed = Random.Range(0.0f, 5.0f); // 5.0は適当な数値
    }

    void Start()
    {
    }
    void Update()
    {
        // 次の位置 = 現在位置と、速度 * 移動方向 * Time.deltaTimeの和
        position = position + (Time.deltaTime * direction * speed);
        transform.position = position; // ゲームオブジェクトに反映
    }
}
