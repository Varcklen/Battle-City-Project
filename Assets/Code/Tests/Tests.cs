using UnityEditor;

public static class Tests 
{
    [MenuItem("Test/Deal Damage To Player")]
    public static void TakeDamagePlayer()
    {
        GameManager.Instance.Player.GetComponent<Unit>().TakeDamage();
    }
}
