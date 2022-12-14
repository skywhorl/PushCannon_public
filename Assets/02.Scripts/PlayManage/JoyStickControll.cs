using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform Joypad = null;
    [SerializeField] private RectTransform Joystick = null;

    // 회전용
    public static Vector2 value;

    // 대포 이동용
    public static bool turnLeft;
    public static bool turnRight;

    private float radius;
    public static float distance;
    public static bool isTouched;

    float timers;
    GameObject Bullet;

    void Start()
    {
        // 설정 값 초기화
        radius = Joypad.rect.width * 0.5f;
        isTouched = false;
        turnLeft = false;
        turnRight = false;
    }

    // 조이스틱을 끌었을 때(드레그 형식으로 이동)
    public void OnDrag(PointerEventData eventData)
    {
        // 조이스틱이 조이패드 밖으로 나가지 않도록 설정 + 드레그 했을 때 움직인 값을 value와 distance에 저장
        value = eventData.position - (Vector2)Joypad.position;

        value = Vector2.ClampMagnitude(value, radius);
        Joystick.localPosition = value;

        distance = Vector2.Distance(Joypad.position, Joystick.position) / radius;
        value = value.normalized;
    }


    // 조이스틱을 눌렸을 때
    public void OnPointerDown(PointerEventData eventData)
    {
        isTouched = true;
    }


    // 조이스틱을 뗐을 때
    public void OnPointerUp(PointerEventData eventData)
    {
        isTouched = false;
        Joystick.localPosition = Vector3.zero;
    }


    // 좌우 버튼을 눌렸을 때
    public void PointerDown(string types)
    {
        switch (types)
        {
            case "R":
                turnRight = true;
                break;
            case "L":
                turnLeft = true;
                break;
        }
    }


    // 좌우 버튼을 뗐을 때
    public void PointerUP(string types)
    {
        switch (types)
        {
            case "R":
                turnRight = false;
                break;
            case "L":
                turnLeft = false;
                break;
        }
    }

    
}
