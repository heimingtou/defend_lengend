using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    
    public GameObject bullet;
    public GameObject gun;
    private List<Transform> enemiesInRange = new List<Transform>();
    public float turnSpeed = 10f;
    Transform targetshoot;
    public float countdown = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
       //if (other.CompareTag("enemy"))
        {
            enemiesInRange.Add(other.transform);
            //Debug.Log("da vao");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.CompareTag("enemy"))
        {
            enemiesInRange.Remove(other.transform);
            //Debug.Log("da ra");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("sung hoat dong");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count > 0)
        {
            targetshoot = enemiesInRange[0].transform;
            LockOnTarget();
            shoot();
          
        }
        countdown += Time.deltaTime;
    }
    public void shoot()
    {
        if (countdown >= 1)
        {
            GameObject bulletVirtual = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            bullet targetBullet = bulletVirtual.GetComponent<bullet>();
            targetBullet.target = targetshoot;
            countdown = 0;
        }
        
    }
    void LockOnTarget()
    {
        Vector3 dir = targetshoot.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // --- QUAN TRỌNG: CHỈNH HƯỚNG ---
        // Nếu ảnh súng của bạn vẽ hướng lên trên (dọc), hãy trừ 90 độ
        // angle = angle - 90; 

        // 4. Tạo góc quay mục tiêu (Chỉ xoay trục Z)
       

        // 5. Xoay từ từ (Lerp)
        transform.rotation = Quaternion.Euler(0, 0,angle-90);
    }
    public void buildTower(Vector3 Position)
    {
        Instantiate(gameObject, Position, Quaternion.identity);
    }
}
