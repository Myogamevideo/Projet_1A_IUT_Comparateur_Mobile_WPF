using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

/// <summary>
/// La classe CustomControl de type TextBox sert à representer une TextBox particuliére avec 2 bouton pour augmenter ou reduire la valeur à intérieur de cette TextBox.
/// </summary>
/// 
namespace EasyPhone.customcontrol
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EasyPhone.customcontrol"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EasyPhone.customcontrol;assembly=EasyPhone.customcontrol"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace1:CustomControl1/>
    ///
    /// </summary>
    public class CustomControl1 : TextBox
    {
        public static readonly DependencyProperty CustomProperty;

        private TextBox text;
        private Button button1;
        private Button button2;

        static CustomControl1()
        {
            CustomProperty = DependencyProperty.Register("custom", typeof(int), typeof(CustomControl1));

        }

        override
        public void OnApplyTemplate()
        {
            button1 = GetTemplateChild("b1") as Button;
            button2 = GetTemplateChild("b2") as Button;
            text = GetTemplateChild("t") as TextBox;

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            text.KeyDown += text_KeyDown;
        }

        private void text_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F1)
                button1.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            if (e.Key == System.Windows.Input.Key.F2)
                button2.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int valeur;
            if (int.TryParse(text.Text, out valeur))
            {
                int nombre = int.Parse(text.Text);
                nombre--;
                text.Text = nombre.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un chiffre/nombre");
                text.Text = "";
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int valeur;
            if (int.TryParse(text.Text, out valeur))
            {
                int nombre = int.Parse(text.Text);
                nombre++;
                text.Text = nombre.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un chiffre/nombre");
                text.Text = "";
            }
        }
    }
}
