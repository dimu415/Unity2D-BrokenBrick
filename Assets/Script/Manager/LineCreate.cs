
using UnityEngine;
public class LineCreate : MonoBehaviour
{
    public GameObject Line;
    new Camera camera;
    public float MaxLineLength=1;
    
    Vector2[] coliderPoint;
   public GameObject inst;
    public int Count = 1;
    private void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
    private void OnMouseDown()
    {
        if (inst != null) Destroy(inst);
             inst = Instantiate(Line);
           
            Vector2 MousePostion = Input.mousePosition;

            coliderPoint = inst.GetComponent<EdgeCollider2D>().points;
            inst.GetComponent<LineRenderer>().SetPosition(0, new Vector3(camera.ScreenToWorldPoint(MousePostion).x, camera.ScreenToWorldPoint(MousePostion).y, 0));
            
        
    }
    private void OnMouseDrag()
    {
            Vector2 MousePostion = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 instPo = inst.GetComponent<LineRenderer>().GetPosition(0);
            Vector2 v=MousePostion -instPo ;
            float v2 = Mathf.Atan2(v.y, v.x) ;
             float x =instPo.x + Mathf.Abs(MaxLineLength * Mathf.Cos(v2));
            float y = instPo.y + Mathf.Abs(MaxLineLength * Mathf.Sin(v2));

            MousePostion.x = Mathf.Clamp(MousePostion.x, instPo.x - Mathf.Abs(MaxLineLength * Mathf.Cos(v2)), instPo.x + Mathf.Abs(MaxLineLength * Mathf.Cos(v2)));
            MousePostion.y = Mathf.Clamp(MousePostion.y, instPo.y - Mathf.Abs(MaxLineLength * Mathf.Sin(v2)), instPo.y + Mathf.Abs(MaxLineLength * Mathf.Sin(v2)));
            inst.GetComponent<LineRenderer>().SetPosition(1, MousePostion);
        


            coliderPoint[0] = new Vector3(inst.GetComponent<LineRenderer>().GetPosition(0).x, inst.GetComponent<LineRenderer>().GetPosition(0).y);
            coliderPoint[1] = new Vector3(inst.GetComponent<LineRenderer>().GetPosition(1).x, inst.GetComponent<LineRenderer>().GetPosition(1).y);

            inst.GetComponent<EdgeCollider2D>().points = coliderPoint;

        
        
    }
    private void OnMouseUp()
    {
            inst.GetComponent<EdgeCollider2D>().enabled = true;
          
    }
}
