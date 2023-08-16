class Program
{
    public enum MenuType
    {
        MainMenu, GeneratorMenu, LoadingMenu, FileMenu, BoxMenu, PalletMenu, SortingMenu
    }
    private static List<Pallet> pallets = new List<Pallet>();
    private static MenuType _currentMenuType;

    public static MenuType CurrentMenuType { get => _currentMenuType; set => _currentMenuType = value; }
    public static List<Pallet> Pallets { get => pallets; set => pallets = value; }

    static void Main(string[] args)
    {
        ShowCurrentMenu();
    }

    public static void ShowCurrentMenu()
    {
        Console.WriteLine("Добро пожаловать в StoreKeeper!");

        CurrentMenuType = MenuType.MainMenu;

        while (true)
        {
            switch (CurrentMenuType)
            {
                case MenuType.MainMenu:
                    MainMenu.ShowMainMenu();
                    break;
                case MenuType.GeneratorMenu:
                    GeneratorMenu.GenerateBoxes();
                    break;
                case MenuType.LoadingMenu:
                    LoadMenu.Show();
                    break;
                case MenuType.FileMenu:
                    DataStorage.CheckFolderPath();
                    break;
                case MenuType.BoxMenu:
                    BoxMenu.Show();
                    break;
                case MenuType.PalletMenu:
                    PalletMenu.ShowMenu();
                    break;
                case MenuType.SortingMenu:
                    SortingMenu.Show();
                    break;
                default:
                    break;
            }
        }
    }
}