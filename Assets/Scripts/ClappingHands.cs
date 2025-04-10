using UnityEngine;

public class ClappingHands : MonoBehaviour
{
    public AudioSource clapSound;   // مصدر الصوت للتصفيق
    public string otherHandTag = "OtherHand";  // التاج الخاص باليد الأخرى

    public bool hasClapped = false;  // لضمان أن التصفيق يحدث مرة واحدة فقط


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // التأكد من أن الجسم الذي يتصادم هو اليد الأخرى
        if (collision.gameObject.CompareTag(otherHandTag))
        {
            // إذا كانت اليد الأخرى تقترب وكانت التصفيق لم يتم بعد
            if (!hasClapped)
            {
                Debug.Log("Clapping!");
                if (clapSound != null)
                {
                    clapSound.Play();
                }
                hasClapped = true;  // تم التصفيق
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // إعادة تعيين حالة التصفيق عند خروج اليد من منطقة التصادم
        if (collision.gameObject.CompareTag(otherHandTag))
        {
            hasClapped = false;  // إعادة الحالة لتسمح بتكرار التصفيق
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        // التأكد من أن الجسم الذي يتصادم هو اليد الأخرى
        if (other.CompareTag(otherHandTag))
        {
            // إذا كانت اليد الأخرى تقترب وكانت التصفيق لم يتم بعد
            if (!hasClapped)
            {
                Debug.Log("👏 Clapping!");
                if (clapSound != null)
                {
                    clapSound.Play();
                }
                hasClapped = true;  // تم التصفيق
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // إعادة تعيين حالة التصفيق عند خروج اليد من منطقة التريغر
        if (other.CompareTag(otherHandTag))
        {
            hasClapped = false;  // إعادة الحالة لتسمح بتكرار التصفيق
        }
    }*/
}



