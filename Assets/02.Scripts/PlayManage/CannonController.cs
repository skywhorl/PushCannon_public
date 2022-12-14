using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObject MoveCannon = null;
    [SerializeField] private GameObject SpinSideCannon = null;
    [SerializeField] private GameObject SpinUpDownCannon = null;

    [SerializeField] private Transform Arrow = null; // 발사방향
    [SerializeField] private float rotateSpeed = 0;
    [SerializeField] private float moveSpeed = 0;

    public AudioClip shoot;

    // 대포 발사 후 대기 시간
    float timers = 1.5f;

    // 포신 회전용
    private Vector3 rotate;
    // 대포알
    private GameObject Bullet;


    void Start()
    {
        // 설정 값 초기화
        rotate = this.transform.eulerAngles;
        timers = 1.5f;

    }


    void Update()
    {
        if (GamePlayManager.instance.status == GamePlayManager.GameStatus.GameStart)
        {
            // 조이스틱이 눌렸을 때
            if (JoyStickControll.isTouched)
            {
                // 조이스틱이 움직인 값 만큼 포신 회전하기 
                rotate += new Vector3(JoyStickControll.value.y * Time.deltaTime * JoyStickControll.distance * rotateSpeed, -JoyStickControll.value.x * JoyStickControll.distance * Time.deltaTime * rotateSpeed, 0f);
                if (rotate.x >= 20)
                {
                    rotate.x = 20;
                }
                else if (rotate.x <= -20)
                {
                    rotate.x = -20;
                }
                else if (rotate.y >= 20)
                {
                    rotate.y = 20;

                }
                else if (rotate.y <= -20)
                {
                    rotate.y = -20;
                }
                SpinSideCannon.transform.rotation = Quaternion.Euler(0, rotate.y, rotate.z);
                SpinUpDownCannon.transform.rotation = Quaternion.Euler(rotate);
            }


            // 좌우 버튼이 눌렸을 때 각각의 행동에 맞게 이동
            if (JoyStickControll.turnRight)
            {
                if (this.gameObject.transform.GetChild(0).transform.position.x < 9)
                {
                    MoveCannon.transform.Translate(moveSpeed, 0, 0);
                }

            }
            else if (JoyStickControll.turnLeft)
            {
                if (this.gameObject.transform.GetChild(0).transform.position.x > -9)
                {
                    MoveCannon.transform.Translate(-moveSpeed, 0, 0);
                }

            }
        }
        // 발사 후 대기시간은 계속해서 설정
        timers -= Time.deltaTime;

    }


    // 발사 버튼을 눌렀을 때
    public void Shooting()
    {

        if (this.gameObject.activeSelf == true)
        {
            if (GamePlayManager.instance.status == GamePlayManager.GameStatus.GameStart)
            {
                if (timers <= 0)
                {
                    SoundCtrl.instance.SoundEffectPlay(shoot);
                    Bullet = ObjPooling.instance.GetPooledObj();
                    // 오브젝트 풀링이 안 되어 있을 때
                    if (Bullet == null)
                    {
                        // 다시 초기화
                        ObjPooling.instance.ResetObj();
                        Bullet = ObjPooling.instance.GetPooledObj();
                    }
                    //DataManager.instance.CannonScale(Bullet);
                    Bullet.transform.localScale = DataManager.instance.LocalScales();
                    Bullet.GetComponent<Rigidbody>().mass = DataManager.instance.MassCtrl();
                    Bullet.SetActive(true);
                    Bullet.transform.position = Arrow.position;
                    Bullet.transform.rotation = Arrow.rotation;
                    Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * DataManager.instance.CannonVelocity();



                    // 발사 후 대기 시간 추가
                    timers = DataManager.instance.CannonShotDelay();
                }
            }
        }
    }
}