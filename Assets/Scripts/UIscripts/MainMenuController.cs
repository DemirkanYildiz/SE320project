using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private VisualElement root;
    private VisualElement mainMenuPanel;
    private VisualElement optionsPanel;
    private VisualElement dungeonSelectPanel;
    private Button playButton;
    private Button optionsButton;
    private Button exitButton;
    private Button dungeon1Button;
    private Button dungeon2Button;
    private Button dungeonBackButton;
    private Button dungeonEnterButton;
    private Label statsHp;
    private Label statsArmor;
    private Label statsDamage;
    private Label statsCooldown;
    private Button optionsBackButton;

    [SerializeField] private Stats playerStats;
    private int sceneId;

    void OnEnable()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        Time.timeScale = 1f;

        root = GetComponent<UIDocument>().rootVisualElement;

        mainMenuPanel = root.Q<VisualElement>("main-menu-panel");
        optionsPanel = root.Q<VisualElement>("options-panel");
        dungeonSelectPanel = root.Q<VisualElement>("dungeon-select-panel");

        playButton = root.Q<Button>("play-button");
        optionsButton = root.Q<Button>("options-button");
        exitButton = root.Q<Button>("exit-button");

        playButton.clicked += () => SwitchPanel(mainMenuPanel, dungeonSelectPanel);
        optionsButton.clicked += () => SwitchPanel(mainMenuPanel, optionsPanel);
        exitButton.clicked += () => { Application.Quit(); };
        
        dungeon1Button = root.Q<Button>("dungeon-1-button");
        dungeon2Button = root.Q<Button>("dungeon-2-button");
        dungeonBackButton = root.Q<Button>("dungeon-back-button");
        dungeonEnterButton = root.Q<Button>("dungeon-enter-button");
        statsHp = root.Q<Label>("stats-hp");
        statsArmor = root.Q<Label>("stats-armor");
        statsDamage = root.Q<Label>("stats-damage");
        statsCooldown = root.Q<Label>("stats-cooldown");

        dungeonBackButton.clicked += () => SwitchPanel(dungeonSelectPanel, mainMenuPanel);
        dungeonEnterButton.clicked += OnEnterDungeon;
        dungeon1Button.clicked += () => SelectScene(1);

        optionsBackButton = root.Q<Button>("options-back-button");
        optionsBackButton.clicked += () => SwitchPanel(optionsPanel, mainMenuPanel);

        if (playerStats != null)
        {
            ShowPlayerStats();
        }
    }

    void SwitchPanel(VisualElement panelToHide, VisualElement panelToShow)
    {
        panelToHide.style.display = DisplayStyle.None;
        panelToShow.style.display = DisplayStyle.Flex;
    }

    void SelectScene(int id)
    {
        this.sceneId = id;
    }

    void ShowPlayerStats()
    {
        statsHp.text = "Max Hp: " + playerStats.getMaxHp();
        statsArmor.text = "Armor: " + playerStats.getArmor();
        statsDamage.text = "Attack damage: " + playerStats.getAttackDamage();
        statsCooldown.text = "Cooldown reduction: " + playerStats.getCooldownReduction();
    }

    public void OnEnterDungeon()
    {
        SceneManager.LoadScene(sceneId);
    }
}