using UnityEngine;
using UnityEngine.SceneManagement;

public class BallLevels : MonoBehaviour
{
    private int level;
    public float speed;
    public bool touched = false;
    private SpawningLevels sl;
    private float multipliedSpeed;

    void Start()
    {
        sl = GameObject.FindObjectOfType<SpawningLevels>();
        level = sl.level;
        if (level % 4 == 0)
        {
            multipliedSpeed = 4;
        }
        else {
            multipliedSpeed = level%4;
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!PadBehaveLevels.isGameOver)
            transform.position = new Vector3(transform.position.x, transform.position.y - (0.001f * Time.deltaTime * speed*multipliedSpeed*SpawningLevels.levelMultiply), 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<CircleCollider2D>().enabled = false;
        touched = true;
        Invoke("InvokingDestroy", 1f);
    }

    /*public void Checkingpads(int chosen)
    {
        if (chosen == 2 && Spawning.yellowtogreen)
        {
            Debug.Log("green ball");
            GameObject ball = Instantiate(balls[3], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "greenball";
            touched = true;
        }
        if (chosen == 1 && Spawning.bluetopurple)
        {
            Debug.Log("purple ball");
            GameObject ball = Instantiate(balls[5], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "purpleball";
            touched = true;
        }
        if (chosen == 1 && Spawning.bluetogreen)
        {
            Debug.Log("green ball");
            GameObject ball = Instantiate(balls[3], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "greenball";
            touched = true;
        }
        if (chosen == 0 && Spawning.redtopurple)
        {
            Debug.Log("purple ball");
            GameObject ball = Instantiate(balls[5], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "purpleball";
            touched = true;
        }
        if (chosen == 0 && Spawning.redtoorange)
        {
            Debug.Log("orange ball");
            GameObject ball = Instantiate(balls[4], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "orangeball";
            touched = true;
        }
        if (chosen == 2 && Spawning.yellowtoorange)
        {
            Debug.Log("orange ball");
            GameObject ball = Instantiate(balls[4], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "orangeball";
            touched = true;
        }
        if (chosen == 2 && !Spawning.yellowtogreen && !Spawning.yellowtoorange)
        {
            Debug.Log("yellow ball");
            GameObject ball = Instantiate(balls[0], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "yellowball";
            touched = true;
        }
        if (chosen == 1 && !Spawning.bluetogreen && !Spawning.bluetopurple)
        {
            Debug.Log("blue ball");
            GameObject ball = Instantiate(balls[1], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "blueball";
            touched = true;
        }
        if (chosen == 0 && !Spawning.redtoorange && !Spawning.redtopurple)
        {
            GameObject ball = Instantiate(balls[2], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "redball";
            touched = true;
        }
    }*/

    private void InvokingDestroy()
    {
        Destroy(gameObject);
    }
}