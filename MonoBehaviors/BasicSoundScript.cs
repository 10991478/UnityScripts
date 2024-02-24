using UnityEngine;

public class BasicSoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float[] volumes;

    private void Awake()
    {
        if (volumes.Length < audioClips.Length)
        {
            float[] temp = new float[audioClips.Length];
            for (int i = 0; i < volumes.Length; i++)
            {
                temp[i] = volumes[i];
            }
            for (int i = volumes.Length; i < temp.Length; i++)
            {
                temp[i] = 1f;
            }
            volumes = temp;
        }
    }

    public void PlayClipFromArray(int clip)
    {
        AudioSource.PlayClipAtPoint(audioClips[clip], new Vector3(0,0,0), volumes[clip]);
    }
}
