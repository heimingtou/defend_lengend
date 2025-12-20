using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero1 : tower
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Vector3 targetPosition;
    //private bool isMoving = false;
    private bool isSelected = false;
    public override void Start()
    {
        base.Start();
        targetPosition= transform.position;
        Debug.Log("bat dau ");
    }
    public override void Update()
    {
        
        base.Update();
        handle();
    }
    public void handle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("da nhan chuot");
            Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // Kiểm tra xem có bấm trúng Hero không (Yêu cầu Hero có Collider)
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit.collider==null)
            {
                Debug.Log("hit null");
                
            }
            if (isSelected)
            {
                targetPosition = mousePos;
                Move();
                isSelected = false;
            }
            else if (hit.collider!=null && hit.collider.CompareTag("hero")&&!isSelected)
            {
               isSelected = true;
                
                circleRange.SetActive(true);
            }
         
        }
    }
    public void Move()
    {
        transform.DOKill();
        Vector2 direction = (targetPosition - transform.position).normalized;
        Vector2 difference = (targetPosition - transform.position);
        float distanceQuick = difference.magnitude;
        float time = distanceQuick / speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 2. Dùng DORotate để xoay mượt mà đến góc đó
        // (Giả sử mũi máy bay mặc định hướng sang phải trục X)
        transform.DORotate(new Vector3(0, 0, angle), 0.3f);

        // Di chuyển đến targetPosition trong 0.5 giây
        // Ease.OutQuad giúp Hero bắt đầu nhanh và dừng lại mượt mà
       
        transform.DOMove(targetPosition, time).SetEase(Ease.OutQuad).OnComplete(() => {
            circleRange.SetActive(false);
        }); ;
        

    }
}
