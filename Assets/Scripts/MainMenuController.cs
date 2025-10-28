using UnityEngine;
using UnityEngine.UIElements;
// using UnityEngine.SceneManagement; // Zindana girmek için bu satýr ileride gerekecek

public class MainMenuController : MonoBehaviour
{
    // Kök eleman
    private VisualElement root;

    // Panellerimiz
    private VisualElement mainMenuPanel;
    private VisualElement optionsPanel;
    private VisualElement dungeonSelectPanel;

    // Ana Menü Butonlarý
    private Button playButton;
    private Button optionsButton;
    private Button exitButton;

    // Zindan Seçim Paneli Elemanlarý
    private Button dungeon1Button;
    private Button dungeon2Button;
    private Button dungeonBackButton;
    private Button dungeonEnterButton;
    private Label statsHp;
    private Label statsArmor;
    private Label statsDamage;
    private Label statsCooldown;

    // --- GÜNCELLEME 1: Deðiþkeni buraya taþýdýk ---
    private Button optionsBackButton; // YENÝ EKLENDÝ (tanýmlama)


    void OnEnable()
    {
        // 1. Kök elemaný çek
        root = GetComponent<UIDocument>().rootVisualElement;

        // 2. Panelleri bul
        mainMenuPanel = root.Q<VisualElement>("main-menu-panel");
        optionsPanel = root.Q<VisualElement>("options-panel");
        dungeonSelectPanel = root.Q<VisualElement>("dungeon-select-panel");

        // 3. Ana Menü Butonlarýný bul ve baðla
        playButton = root.Q<Button>("play-button");
        optionsButton = root.Q<Button>("options-button");
        exitButton = root.Q<Button>("exit-button");

        playButton.clicked += () => SwitchPanel(mainMenuPanel, dungeonSelectPanel);
        optionsButton.clicked += () => SwitchPanel(mainMenuPanel, optionsPanel);
        exitButton.clicked += () => {
            Debug.Log("Exiting game...");
            Application.Quit();
        };

        // 4. Zindan Paneli Elemanlarýný bul ve baðla
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
        dungeon1Button.clicked += () => ShowDungeonStats(1);
        dungeon2Button.clicked += () => ShowDungeonStats(2);

        // --- GÜNCELLEME 2: Options 'Back' Butonunu burada bulup baðlýyoruz ---

        // Options 'Back' butonunu bul
        optionsBackButton = root.Q<Button>("options-back-button");

        // 'Back' butonu: Options panelini gizle, Ana menüyü göster
        optionsBackButton.clicked += () => SwitchPanel(optionsPanel, mainMenuPanel);

        // --- Bitti ---

        // Baþlangýçta varsayýlan istatistikleri göster
        ShowDungeonStats(1);
    }

    // Ýki panel arasýnda geçiþ yapmak için yardýmcý bir fonksiyon
    void SwitchPanel(VisualElement panelToHide, VisualElement panelToShow)
    {
        panelToHide.style.display = DisplayStyle.None;
        panelToShow.style.display = DisplayStyle.Flex;
    }

    // Seçilen zindana göre istatistikleri güncelleyen fonksiyon
    void ShowDungeonStats(int dungeonID)
    {
        if (dungeonID == 1)
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
        }
    }

    void OnEnterDungeon()
    {
        Debug.Log("Entering dungeon... (Scene loading logic goes here)");
    }
}