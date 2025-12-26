using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillsUI : MonoBehaviour
{
      private VisualElement root;

      private VisualElement rmb, lmb, e;
      private Label rmbCD, lmbCD, eCD;

      public void OnEnable()
      {
            root = GetComponent<UIDocument>().rootVisualElement;
            var skills = root.Q<VisualElement>("skills");

            rmb = skills.Q<VisualElement>("RMB");
            lmb = skills.Q<VisualElement>("LMB");
            e = skills.Q<VisualElement>("E");

            rmbCD = rmb.Q<Label>("cooldown");
            lmbCD = lmb.Q<Label>("cooldown");
            eCD = e.Q<Label>("cooldown"); 
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
      
      
}
