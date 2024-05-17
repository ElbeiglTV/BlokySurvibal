using UnityEngine;

public class YunqueUpgradeTriguer : MonoBehaviour
{
    public GameObject UpgradeCamvas;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            if (other.GetComponent<UserModel>().inputCheck == 0)
                UpgradeCamvas.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            UpgradeCamvas.SetActive(false);
    }
}
