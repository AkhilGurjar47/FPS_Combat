using UnityEngine;
using UnityEngine.UI;
public class WeaponController : MonoBehaviour
{
    public enum FireType
    {
        semiAuto,
        auto
    }
    public FireType fireType = FireType.semiAuto;

    public Camera playerCamera;

    public Text bulletText;
    public int maxBullets = 10;
    private int currentBullets;

    public float fireRate = 0.2f;
    public ParticleSystem muzzleFlash;
    public GameObject bulletHole;
    public AudioClip fireSound;
    private AudioSource source;
    private float nextTimeFire = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBullets = maxBullets;
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (fireType == FireType.semiAuto)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeFire)
            {
                Fire();
                nextTimeFire = Time.time + fireRate;
            }
        }
        else if (fireType == FireType.auto)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeFire)
            {
                Fire();
                nextTimeFire += Time.time + fireRate;
            }
        }
        bulletText.text = currentBullets.ToString();
    }
    void Fire()
    {
        if(currentBullets <= 0)
        {
            Debug.Log("Out Of Bullets");
            return;
        }
        muzzleFlash.Play(true);
        //source.PlayOneShot(fireSound);
        currentBullets--;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.transform.name);
            GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.identity);
            Destroy(hole, 10);
        }
    }
}
