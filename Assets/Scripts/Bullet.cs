using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float u = 0;
    float speed;
    float timeSinceSpawn = 0;
    Vector3[] controlesPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        u += speed * Time.deltaTime;
        if (u >= 1)
        {
            Destroy(this.gameObject);
        }
        if (controlesPoints != null)
        {
            Vector3 newPos = calcPointsCasteljaux(controlesPoints, controlesPoints.Length, u);
            transform.position = newPos;
        }
    }

    public void initialyseBullet(float vitesse,Vector3[] points)
    {
        speed = vitesse;
        controlesPoints = points;
        transform.position = points[0];

    }

    public Vector3 calcPointsCasteljaux(Vector3[] listPtsControles, int ptsControlesCount, float u)
    {
        Vector3[] tempList = new Vector3[ptsControlesCount - 1];

        for (int i = 0; i < ptsControlesCount - 1; i++)
        {
            Vector3 pt1 = listPtsControles[i];
            Vector3 pt2 = listPtsControles[i + 1];
            tempList[i] = Vector3.Lerp(pt1, pt2, u);
        }

        if (ptsControlesCount - 1 == 1)
        {
            return tempList[0];
        }

        return calcPointsCasteljaux(tempList, ptsControlesCount - 1, u);

    }
}
