using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("Jammo is Dead! Game Over!");
        GameObject.Find("Canvas").GetComponent<GameOver>().ShowRestartButton();
        gameObject.SetActive(false); // Hide Jammo
    }
}
