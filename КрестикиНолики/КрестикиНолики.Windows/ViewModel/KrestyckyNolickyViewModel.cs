using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using КрестикиНолики.View;
using КрестикиНолики.Model;
using Windows.UI.Popups;
using Windows.UI;
using Windows.UI.Xaml.Media;
using System.ComponentModel;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace КрестикиНолики.ViewModel
{
    class KrestyckyNolickyViewModel
    {
        public INotifyCollectionChanged GameControls { get { return gameControls; } }
        private ObservableCollection<GameControl> gameControls = new ObservableCollection<GameControl>();
        private KrestykyNolikyModel model;
        private DispatcherTimer timer;
        public KrestyckyNolickyViewModel()
        {
            model = new KrestykyNolikyModel();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            model.ControlChanged += Model_ControlChanged;
            if (model.IndexOfComputer == 1)
                MakeOneMove(1, 1);
        }

        private void Model_ControlChanged(object sender, ControlChangedEventArgs e)
        {
            gameControls.Add(new GameControl(e.X, e.Y, e.Color));
        }

        private void Timer_Tick(object sender, object e)
        {
            int y;
            int x = model.ToThinkAboutMove(out y);
            MakeOneMove(x, y);
            timer.Stop();
        }
        public void MakeOneMove(int x, int y)
        {
            if(!model.MakeOneMove(x, y))
            {
                MessageDialog dialog = new MessageDialog("Победили" + model.GetColorOfWinner());
                dialog.ShowAsync();
            }
            else
            {
                if (model.FieldIsFull())
                {
                    MessageDialog dialog = new MessageDialog("Ничья!");
                    dialog.ShowAsync();
                    return;
                }
                if ((model.IndexOfComputer == 1 && model.IndexOfMover == 1) || (model.IndexOfComputer == 2 && model.IndexOfMover == 2))
                {
                    timer.Start();
                }
            }
        }
    }
}
