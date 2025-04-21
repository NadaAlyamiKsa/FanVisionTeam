using UnityEngine;

public class ChangeHandMaterial : MonoBehaviour
{
    public SkinnedMeshRenderer leftHandRenderer;
    public SkinnedMeshRenderer rightHandRenderer;
    public Material newMaterial;

    public void ChangeMaterial()
    {
        leftHandRenderer.material = newMaterial;
        rightHandRenderer.material = newMaterial;
    }
}
