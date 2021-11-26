using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITParkApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Player.ListBoxUpdate(lb_players);
            Team.ListBoxTeamUpdate(lb_teams);
        }
        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player(tb_name.Text, tb_surname.Text, Convert.ToInt32(tb_number.Text));
            Player.AddPlayer(player);
            Player.ListBoxUpdate(lb_players);            
        }
        private void lb_players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl.Content = lb_players.SelectedItem;
        }
        private void btn_newteam_Click(object sender, RoutedEventArgs e)
        {
            List<Player> sqwad = new List<Player>();
            
            sqwad.Add(lb_players.SelectedItem);
        }

        private void lb_teams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team.ListBoxTeamUpdate(lb_teams);
        }
    }
}
