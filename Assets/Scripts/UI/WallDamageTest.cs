using UnityEngine;


public class WallDamageTest : MonoBehaviour
{
    public WallDamage wall;   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            wall.TakeDamage(10f);
            Debug.Log("Pressed E: Wall took 10 damage");
        }
    }
}