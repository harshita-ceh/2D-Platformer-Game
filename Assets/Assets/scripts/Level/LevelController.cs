using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Playercontroller>() != null)
        {
            Debug.Log("LEVEL COMPLETE");
            LevelManager.Instance.MarkCurrentLevelCompleted();
        }
    }
}
