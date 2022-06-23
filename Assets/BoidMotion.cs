using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMotion : MonoBehaviour
{
    // TODO: このボイドクラスが持つべきデータ・属性・バリエーション（フィールド）とは？
    // それぞれで異なる可能性がある数値
    private Vector3 position;  // 位置
    private Vector3 direction; // 移動方向
    private float speed;       // 移動速度
    // or
    // Vector3 velocity; // 速度ベクトル？

    public Vector3 Position
    {
        get { return position; }
    }

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
        // 自分自身も含む全てのボイドを探す = Boid というタグが付いている全てのゲームオブジェクトを取得する
        GameObject[] boids = GameObject.FindGameObjectsWithTag("Boid"); // 見つけたボイドを boids という配列に格納

        // boidsの中にいる自分自身を特定する　＝　各ボイドの名前をチェックし自分の名前と一致するか確認
        // 他のボイドの位置を知り、一定距離内にいるか、一定距離外にいるか、チェック
        for (int i = 0; i < boids.Length; ++i)
        {
            if (boids[i].name != this.gameObject.name)// 他のボイド？
            {
                BoidMotion boidMotion = boids[i].GetComponent<BoidMotion>(); //BoidMotionコンポーネント

                //  一定距離の内外をチェック
                //   距離の計算　＝　// TODO: this.position, boidMotion.Position の間の距離を計算
                float distance = Vector3.Distance(this.position, boidMotion.Position);
                //float distance = (this.position - boidMotion.Position).magnitude;

                //   求まった距離が、ある値未満か、ある値以上かをチェック
                if (distance < 2.0f)
                {
                    Debug.Log("NEAR!");
                }

                // boids[i].transform.position (あえて使わない)
                //Debug.Log(boids[i].name + ", " + this.gameObject.name);
            }
        }


        // 次の位置 = 現在位置と、速度 * 移動方向 * Time.deltaTimeの和
        position = position + (Time.deltaTime * direction * speed);
        transform.position = position; // ゲームオブジェクトに反映
    }
}
