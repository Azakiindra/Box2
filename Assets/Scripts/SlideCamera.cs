using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class SlideCamera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    protected int PointerId;
    public CinemachineFreeLook Ojek;
    public float Speed = 80;
    [HideInInspector]
    public bool Pressed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }

        SwipeCam();

    }

    private void SwipeCam(){

        if (TouchDist.x < -5)
        {
            
            Ojek.m_XAxis.Value -= Speed * Time.deltaTime;

        }
        
        else if (TouchDist.x > 5)
        {

            Ojek.m_XAxis.Value += Speed * Time.deltaTime;
            
        }

             if (TouchDist.y > 10 && Ojek.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY < 1f)
            {
                
                Ojek.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY += 0.01f;

            }
            
            else if (TouchDist.y < -10 && Ojek.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY > 0.5f)
            {

                Ojek.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY -= 0.01f;
                
            }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
    
}