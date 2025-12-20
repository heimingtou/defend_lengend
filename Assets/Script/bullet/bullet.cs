using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 5f;
    public float damage;
    public elementType element;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy= other.gameObject.GetComponent<Enemy>();
        if( enemy!=null)
        {
            float multiplier = elementManager.instance.calMultiplier(element,enemy.element);
            Destroy(gameObject);
            Debug.Log(multiplier);
            enemy.takeDamage(damage*multiplier);
            if(enemy.hp<=0)
            {
                enemy.die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
      {  Vector3 dir = target.transform.position - transform.position;

        // Tính khoảng cách đạn sẽ bay trong khung hình này
        float distanceThisFrame = speed * Time.deltaTime;

        // 3. Kiểm tra va chạm (Hit Detection)
        // Nếu khoảng cách đến địch nhỏ hơn khoảng cách sắp bay -> Coi như đã trún

        // 4. Di chuyển đạn
        // Normalize: Để giữ hướng nhưng độ dài vector = 1, giúp tốc độ ổn định
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        // 5. Xoay đạn hướng đầu về phía mục tiêu (Nhìn cho thật)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            // Áp dụng góc xoay vào trục Z (trục xoay của 2D)
            // Lưu ý: Nếu sprite đạn của bạn vẽ hướng lên trên thì có thể cần trừ đi 90 độ (angle - 90)
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
 

