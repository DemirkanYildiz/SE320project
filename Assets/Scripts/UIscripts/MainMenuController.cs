using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // K�k eleman
    private VisualElement root;

    // Panellerimiz
    private VisualElement mainMenuPanel;
    private VisualElement optionsPanel;
    private VisualElement dungeonSelectPanel;

    // Ana Men� Butonlar�
    private Button playButton;
    private Button optionsButton;
    private Button exitButton;

    // Zindan Se�im Paneli Elemanlar�
    private Button dungeon1Button;
    private Button dungeon2Button;
    private Button dungeonBackButton;
    private Button dungeonEnterButton;
    private Label statsHp;
    private Label statsArmor;
    private Label statsDamage;
    private Label statsCooldown;

    // --- G�NCELLEME 1: De�i�keni buraya ta��d�k ---
    private Button optionsBackButton; // YEN� EKLEND� (tan�mlama)
    
    // player stats
    [SerializeField] private Stats playerStats;

    //0->testScene 1-> dungeon1
    private int sceneId;


    void OnEnable()
    {
        // 1. K�k eleman� �ek
        root = GetComponent<UIDocument>().rootVisualElement;

        // 2. Panelleri bul
        mainMenuPanel = root.Q<VisualElement>("main-menu-panel");
        optionsPanel = root.Q<VisualElement>("options-panel");
        dungeonSelectPanel = root.Q<VisualElement>("dungeon-select-panel");

        // 3. Ana Men� Butonlar�n� bul ve ba�la
        playButton = root.Q<Button>("play-button");
        optionsButton = root.Q<Button>("options-button");
        exitButton = root.Q<Button>("exit-button");

        playButton.clicked += () => SwitchPanel(mainMenuPanel, dungeonSelectPanel);
        optionsButton.clicked += () => SwitchPanel(mainMenuPanel, optionsPanel);
        exitButton.clicked += () => {
            Debug.Log("Exiting game...");
            Application.Quit();
        };

        // 4. Zindan Paneli Elemanlar�n� bul ve ba�la
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
        //when dungeon 2 finished open this.
        //dungeon2Button.clicked += () => SelectScene(2);

        // --- G�NCELLEME 2: Options 'Back' Butonunu burada bulup ba�l�yoruz ---

        // Options 'Back' butonunu bul
        optionsBackButton = root.Q<Button>("options-back-button");

        // 'Back' butonu: Options panelini gizle, Ana men�y� g�ster
        optionsBackButton.clicked += () => SwitchPanel(optionsPanel, mainMenuPanel);

        // --- Bitti ---

        // Ba�lang��ta varsay�lan istatistikleri g�ster
        ShowPlayerStats();
    }

    // �ki panel aras�nda ge�i� yapmak i�in yard�mc� bir fonksiyon
    void SwitchPanel(VisualElement panelToHide, VisualElement panelToShow)
    {
        panelToHide.style.display = DisplayStyle.None;
        panelToShow.style.display = DisplayStyle.Flex;
    }

    void SelectScene(int id)
    {
        this.sceneId = id;
    }
    
    
    // Se�ilen zindana g�re istatistikleri g�ncelleyen fonksiyon
    void ShowPlayerStats()
    {
        //show player stats here.
        /*if (dungeonID == 1)
        {
            statsHp.text = "Max Hp: 100";
            statsArmor.text = "Armor: 5";
            statsDamage.text = "Attack damage: 10";
            statsCooldown.text = "Cooldown reduction: 0%";
            dungeon1Button.AddToClassList("button-selected");
            dungeon2Button.RemoveFromClassList("button-selected");
        }
        else if (dungeonID == 2)
        {
            statsHp.text = "Max Hp: 150";
            statsArmor.text = "Armor: 10";
            statsDamage.text = "Attack damage: 15";
            statsCooldown.text = "Cooldown reduction: 10%";
            dungeon1Button.RemoveFromClassList("button-selected");
            dungeon2Button.AddToClassList("button-selected");
        }*/
        statsHp.text = "Max Hp: "+playerStats.getMaxHp();
        statsArmor.text = "Armor: "+playerStats.getArmor();
        statsDamage.text = "Attack damage: "+playerStats.getAttackDamage();
        statsCooldown.text = "Cooldown reduction: "+playerStats.getCooldownReduction();
    }

    public void OnEnterDungeon()
    {
        SceneManager.LoadScene(sceneId);
    }
    
}