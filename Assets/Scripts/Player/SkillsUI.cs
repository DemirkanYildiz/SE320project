using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillsUI : MonoBehaviour
{
      private VisualElement root;

      private VisualElement rmb, lmb, e, r;
      private Label rmbCD, lmbCD, eCD, rCD, rDuration, eUsage;

      public void OnEnable()
      {
            root = GetComponent<UIDocument>().rootVisualElement;
            var skills = root.Q<VisualElement>("skills");

            rmb = skills.Q<VisualElement>("RMB");
            lmb = skills.Q<VisualElement>("LMB");
            e = skills.Q<VisualElement>("E");
            r = skills.Q<VisualElement>("R");

            rmbCD = rmb.Q<Label>("cooldown");
            lmbCD = lmb.Q<Label>("cooldown");
            eCD = e.Q<Label>("cooldown"); 
            rCD = r.Q<Label>("cooldown");
            rDuration = r.Q<Label>("duration");
            eUsage = e.Q<Label>("usage");
      }

      public void updateCooldownRMB(string rmbCooldown)
      {
            rmbCD.text = rmbCooldown;
      }

      public void updateCooldownLMB(string lmbCooldown)
      {
            lmbCD.text = lmbCooldown;
      }

      public void updateCooldownE(string eCooldown)
      {
            eCD.text = eCooldown;
      }

      public void updateCooldownR(string rCooldown)
      {
            rCD.text = rCooldown;
      }
      public void updateDurationR(string rDuration)
      {
            this.rDuration.text = "duration: "+rDuration;
      }

      public void updateUsageE(string eUsage)
      {
            this.eUsage.text = "usages: "+eUsage;
      }
      
      
}
