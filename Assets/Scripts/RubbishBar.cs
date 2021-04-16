using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubbishBar : MonoBehaviour
{
   public Slider slider;
   public bool rubbishFull = false;

   

   public void SetRubbish(int rubbish)
   {
      slider.value += rubbish;

      if (slider.value == 10)
      {
         rubbishFull = true;
      }
      else
      {
         rubbishFull = false;
      }
   }

   
   
   

}
