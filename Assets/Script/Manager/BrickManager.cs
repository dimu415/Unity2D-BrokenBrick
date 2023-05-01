using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [System.Serializable]
   public class Pos
    {
        public List<Vector3> po;
        public Transform Parent;
    }
    public Pos[] os;
    public GameObject[] Brick;
    public float time = 5;
    public void StartCreateBrick()
    {
        time = 4;
        StartCoroutine(CreateBrick());
    }
    IEnumerator CreateBrick()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, time));
            int rand = Random.Range(0, 4);

            GameObject inst = Instantiate(Brick[rand]);

            int a = Random.Range(0, os[rand].po.Count);
            inst.transform.position = os[rand].po[a];
            inst.transform.SetParent(os[rand].Parent);
            inst.GetComponent<brick>().id = rand;
            if (time > 2) time -= 0.01f;
        }
    }
    public void move(int id)
    {
        switch (id)
        {
            case 0:
                for (int i = 0; i < os[id].Parent.childCount-1; i++)
                {
                    os[id].Parent.GetChild(i).transform.Translate(new Vector2(0,-0.1f));
                }
                break;
            case 1:
                for (int i = 0; i < os[id].Parent.childCount-1; i++)
                {
                    os[id].Parent.GetChild(i).transform.Translate(new Vector2(0.1f , 0));
                }
                break;
            case 2:
                for (int i = 0; i < os[id].Parent.childCount-1; i++)
                {
                    os[id].Parent.GetChild(i).transform.Translate(new Vector2( -0.1f , 0));
                }
                break;
            case 3:
                for (int i = 0; i < os[id].Parent.childCount-1; i++)
                {
                    os[id].Parent.GetChild(i).transform.Translate(new Vector2(0, 0.1f));
                }
                break;

        }
    }

    public void ResetBreick()
    {
        for(int i = 0; i < os.Length; i++)
        {
            for(int j = 0; j < os[i].Parent.childCount; j++)
            {
                Destroy(os[i].Parent.GetChild(j).gameObject);
            }
        }
        for (int i = 0; i < os.Length; i++)
        {
            for (int j = 0; j < os[i].po.Count; j++)
            {
                GameObject inst = Instantiate(Brick[i]);

                inst.transform.position = os[i].po[j];
                inst.transform.SetParent(os[i].Parent);
                inst.GetComponent<brick>().id = i;
            }
        }
    }
}
