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
using System.Windows.Shapes;

namespace GUIEksamen
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {

        public List<String> LearningList = new List<string>
        {
            "Redegøre for principperne i .Net frameworket og dets overordnede arkitektur samt beskrive og anvende programmeringssproget C#.",
            "Designe og implementere programmer med en grafisk brugergrænseflade til Microsoft Windows platformen med brug af .Net frameworket og programmeringssprogene C# og XAML.",
            "Anvende kontroller til opbygning af både modale og modeless dialoger, samt kunne anvende de forskellige layout panels.",
            "Anvende WPF's faciliteter til tegning af 2D grafik samt visning af billeder.",
            "Anvende styles og ressourcer.",
            "Anvende .Net frameworkets faciliteter til persistering af applikation- og brugerindstillinger samt til persistering af data i filer.",
            "Anvende data binding til at sammenknytte data i modellaget med deres præsentation i viewlaget.",
            "Redegøre for WPF's faciliteter til kommunikation mellem baggrundstråde og GUI-tråden i flertrådede programmer."
        };
        public AboutWindow()
        {
            InitializeComponent();
            Learning.ItemsSource = LearningList;
        }
    }
}
