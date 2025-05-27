using UnityEngine;

public class NoteHitDetector : MonoBehaviour
{
    public string lane; 
    public KeyCode hitKey; 

    public float perfectWindow = 0.1f;
    public float goodWindow = 0.25f;

    void Update()
    {
        if (Input.GetKeyDown(hitKey))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);

            NoteDataHolder bestNote = null;
            float smallestTimeDiff = float.MaxValue;

            foreach (var hit in hits)
            {
                NoteDataHolder note = hit.GetComponent<NoteDataHolder>();
                if (note != null && note.lane == lane)
                {
                    float timeDiff = Mathf.Abs(GameManager.Instance.SongTime - note.noteTime);
                    if (timeDiff < smallestTimeDiff)
                    {
                        smallestTimeDiff = timeDiff;
                        bestNote = note;
                    }
                }
            }

            if (bestNote != null)
            {
                if (smallestTimeDiff <= perfectWindow)
                {
                    Debug.Log("Perfect!");
                }
                else if (smallestTimeDiff <= goodWindow)
                {
                    Debug.Log("Good!");
                }
                else
                {
                    Debug.Log("Miss!");
                }

                Destroy(bestNote.gameObject);
            }
            else
            {
                Debug.Log("No note to hit!");
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
