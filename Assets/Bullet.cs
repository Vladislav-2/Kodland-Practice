using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    float timeToDestroy = 3;
    float _time = 0;
    Vector3 direction;

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        _time += Time.deltaTime;
        speed += 1f;

        Collider[] targets = Physics.OverlapSphere(transform.position, 1);
        foreach (var item in targets)
        {
            if (item.tag == "Enemy")
            {
                Destroy(item.gameObject);
                Destroy(this.gameObject);
            }
        }
        if (_time >= timeToDestroy)
            Destroy(this.gameObject);
    }
}
