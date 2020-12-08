using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float bulletSpeed = 15f;

    [SerializeField]
    private GameObject bullet;
    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(BulletCoroutine());
        }
    }

    private void Move()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += Movement * speed * Time.deltaTime;
    }

    private IEnumerator BulletCoroutine()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        GameObject instantiatedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        instantiatedBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        yield return new WaitForSeconds(1.5f);
        Destroy(instantiatedBullet);
        yield return new WaitForEndOfFrame();
    }
}
