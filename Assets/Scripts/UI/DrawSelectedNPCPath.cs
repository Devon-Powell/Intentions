using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawSelectedNPCPath : MonoBehaviour
{
    public static DrawSelectedNPCPath Instance;
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        line = this.gameObject.GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
        line.SetWidth(0.5f, 0.5f);
        line.SetColors(Color.yellow, Color.yellow);
    }

    public void DrawPath(NavMeshAgent agent)
    {
        //NavMeshPath path;
        //NavMesh.CalculatePath(agent, agent., path);
        //line.SetPositions(path.corners);
    }
}
