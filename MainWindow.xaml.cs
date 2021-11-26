using MongoDB.Driver;
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
        #region
        private void tb_name_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_name.Text = "";
        }
        private void tb_surname_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_surname.Text = "";
        }
        private void tb_number_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_number.Text = "";
        }
        private void tb_team_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_team.Text = "";
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Player.ListBoxUpdate(listbox_players);
            //Team.TeamListBoxUpdate(listbox_teams);
        }
        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player(tb_name.Text, tb_surname.Text, Convert.ToInt32(tb_number.Text), tb_team.Text);
            Player.AddPlayer(player);
            Player.ListBoxUpdate(listbox_players);
        }
        private void lb_players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Players_Football_Teams");
            var collection = database.GetCollection<Player>("Players");

            Player player = (Player)listbox_players.SelectedItem;
            lbl.Content = $"{player.number}. {player.name} {player.surname}. \nCurrent team: {player.currentTeam}";
        }

        private void btn_newteam_Click(object sender, RoutedEventArgs e)
        {
            Player player1 = (Player)listbox_players.SelectedItem;
            Player player2 = (Player)listbox_players.SelectedItem;
            Player player3 = (Player)listbox_players.SelectedItem;
            List<Player> playersList = new List<Player>();
            playersList.Add(player1);
            playersList.Add(player2);
            playersList.Add(player3);
            Team team = new(tb_teamname.Text, playersList);
            Team.AddTeam(team);
            //Team.TeamListBoxUpdate(listbox_teams);
        }
    }
}
