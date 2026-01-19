using CommunityToolkit.Mvvm.Input;
using MaciLaci_Avalonia.Models;
using MaciLaci_Avalonia.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MaciLaci_Avalonia.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private GameModel model;
        private int size;
        private bool paused;
        private int gameTime;
        private int kosarak;
        private bool pause_button_visibility;
        private double cellsize;
        private string gameovertext;
        public RelayCommand NewGameCommand { get; set; }
        public RelayCommand PauseGameCommand { get; set; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public string GameOverText
        {
            get { return gameovertext; }
            set { 
                if(gameovertext != value) { gameovertext = value; 
                    OnPropertyChanged(nameof(GameOverText));
                }
            }
        }
        public double CellSize { 
            get { return cellsize; } 
            set { 
                if(cellsize == value) return;
                cellsize = value;
                OnPropertyChanged(nameof(CellSize));
            }
        }

        public ObservableCollection<GameField> Fields { get; set; }

        //public ObservableCollection<string> MapSizes { get; }
        //public string? SelectedMapSize { get; set; }
        public int GameTime
        {
            get { return gameTime; }
            set
            {
                gameTime = value;
                OnPropertyChanged(nameof(GameTime));
            }
        }
        public Boolean SmallGame
        {
            get { return size==11; }
            set
            {
                if (size == 11)
                    return;

                Size = 11;
                //model.NewGame(11);
                OnPropertyChanged(nameof(SmallGame));
                OnPropertyChanged(nameof(MediumGame));
                OnPropertyChanged(nameof(BigGame));
            }
        }
        public bool MediumGame
        {
            get { return size == 15; }
            set {
                if (size == 15) return;
                Size = 15;
                //model.NewGame(15);
                OnPropertyChanged(nameof(SmallGame));
                OnPropertyChanged(nameof(MediumGame));
                OnPropertyChanged(nameof(BigGame));
            }
        }
        public bool BigGame {
            get { return size == 20; }
            set { 
                if(size == 20) return;
                Size = 20;
                //model.NewGame(20);
                OnPropertyChanged(nameof(SmallGame));
                OnPropertyChanged(nameof(MediumGame));
                OnPropertyChanged(nameof(BigGame));
            }
        }
        public int Kosarak
        {
            get { return kosarak; }
            set
            {
                kosarak = value;
                OnPropertyChanged(nameof(Kosarak));
            }
        }
        public bool Pause_Button_Visibility { get => pause_button_visibility; set { pause_button_visibility = value; OnPropertyChanged(nameof(Pause_Button_Visibility)); } }
        public bool Paused
        {
            get => paused;
            set
            {
                paused = value;
                if (value) model.Pause_Game();
                else model.Resume_Game();
                OnPropertyChanged(nameof(Paused));
            }
        }

        public int Size
        {
            get => size;
            set
            {
                if (size != value)
                {
                    size = value;
                    //OnPropertyChanged(nameof(Size));
                }
            }
        }

        public GameViewModel(GameModel model_)
        {
            gameovertext = "";
            this.model = model_;
            model.FieldChanged += new EventHandler<MaciLaciFieldEventArgs>(Model_FieldChanged);
            model.GameOver += new EventHandler<MaciLaciEventArgs>(Model_GameOver);
            GameTime = model.GameTime;
            Kosarak = model.Macilaci.Kosarak;
            NewGameCommand = new RelayCommand(OnNewGame);
            PauseGameCommand = new RelayCommand(OnGamePause);
            /*MapSizes = new ObservableCollection<string> {
                "11x11",
                "15x15",
                "20x20"
            };*/
            MoveLeftCommand = new RelayCommand(() => MoveMaci(Dir.LEFT));
            MoveRightCommand = new RelayCommand(() => MoveMaci(Dir.RIGHT));
            MoveUpCommand = new RelayCommand(() => MoveMaci(Dir.UP));
            MoveDownCommand = new RelayCommand(() => MoveMaci(Dir.DOWN));

            // játéktábla létrehozása
            Size = model.Size;
            CellSize = 900.0 / size;
            Fields = new ObservableCollection<GameField>();
            GenerateTable(model.Size);
            RefreshTable();
            pause_button_visibility = false;
            pause_button_text = "Pause";
            paused = true;
        }

        private void MoveMaci(Dir dir)
        {
            if(paused) return;
            model.MoveMaci(dir);
        }

        private void GenerateTable(int size)
        {
            Fields.Clear();

            for (int i = 0; i < size; i++) // inicializáljuk a mezőket
            {
                for (int j = 0; j < size; j++)
                {
                    Fields.Add(new GameField
                    {
                        Text = String.Empty,
                        X = i,
                        Y = j
                    });
                }
            }
        }
        private void RefreshTable()
        {
            foreach (GameField field in Fields)
            {
                switch (model.Forest.Table[field.X, field.Y])
                {
                    case ForestField.MaciLaci:
                        field.Text = "m";
                        break;
                    case ForestField.Tree:
                        field.Text = "t";
                        break;
                    case ForestField.Kosar:
                        field.Text = "k";
                        break;
                    case ForestField.Border:
                        field.Text = "b";
                        break;
                    case ForestField.Hunter:
                        field.Text = "h";
                        break;
                    case ForestField.Empty:
                        field.Text = " ";
                        break;
                    default:
                        break;
                }
            }
            GameTime = model.GameTime;
            Kosarak = model.Macilaci.Kosarak;
        }
        private string pause_button_text;
        public string Pause_Button_Text
        {
            get => pause_button_text; set
            {
                pause_button_text = value;
                OnPropertyChanged(nameof(Pause_Button_Text));
            }
        }


        private void OnGamePause()
        {
            if (Paused)
            {
                Paused = false;
                Pause_Button_Text = "Pause";
            }
            else
            {
                Paused = true;
                Pause_Button_Text = "Resume";
            }
        }

        private void OnNewGame()
        {
            GameOverText = "";
            OnPropertyChanged(nameof(Size));
            model.NewGame(size);
            CellSize=900.0/size;
            GenerateTable(size);
            RefreshTable();
            paused = false;
            Pause_Button_Visibility = true;
        }

        private void Model_GameOver(object? sender, MaciLaciEventArgs e)
        {
            Pause_Button_Visibility=false;
            if (e.IsWon)
            {
                GameOverText = "Gratulálok, győztél!" + Environment.NewLine +TimeSpan.FromSeconds(e.GameTime).ToString("g") + " ideig játszottál.";
            }
            else {
                GameOverText = "Sajnálom, vesztettél!" + Environment.NewLine +TimeSpan.FromSeconds(e.GameTime).ToString("g") + " ideig játszottál.";
            }
        }

        private void Model_FieldChanged(object? sender, MaciLaciFieldEventArgs e)
        {
            RefreshTable();
        }

    }
}
