using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MatchingType:MonoBehaviour
{
    [SerializeField]private int matchId;
 
    public int Get_ID()
    {
        return matchId;
    }
}
