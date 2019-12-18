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

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();
        Task task = new Task();
        List<Categorie> categories = new List<Categorie>();
        public MainWindow()
        {
            InitializeComponent();
            Initialised();
        }

        //void InitialisedListBoxOfString()
        //{
        //   items.Add("HELLO");
        //    ListBoxTasks.ItemsSource = items;
        //    using(var db = new TasksDBEntities())
        //    {
        //        tasks = db.Tasks.ToList();
        //    }
        //    //get the description and add it to list
        //    foreach(var item in tasks)
        //    {
        //        items.Add($"{item.TasskID,-10}{item.Description, -40}{item.Done,-10}{item.DataDone}");
        //    }
        //}

        void Initialised()
        {

            using (var db = new TasksDBEntities())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = tasks;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategortyID.ItemsSource = categories;
            ComboBoxCategortyID.DisplayMemberPath = "CategoryName";
        }
        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                //ask = (Task)ListBoxTasks.SelectedItem;
                TextBoxID.Text = task.TasskID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryID.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;

                if(task.CategoryID != null)
                {
                    ComboBoxCategortyID.SelectedIndex = (int)task.CategoryID-1;
                }
                else
                {
                    ComboBoxCategortyID.SelectedItem = null;
                }

            }
            //print out details of selected item
            //instance == convert to task the item selected in listbox by user

        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryID.IsReadOnly = false;
                ButtonEdit.Content = "Save";


            }
            else
            {
                using (var db = new TasksDBEntities())
                {
                    var tasktoEdit = db.Tasks.Find(task.TasskID);
                    //update description & categorieID
                    tasktoEdit.Description = TextBoxDescription.Text;

                    //converting category id to interher from text box (string)
                    //tryparse is a safe way to do conversion : null i fails
                    int.TryParse(TextBoxCategoryID.Text, out int categoryID);
                    tasktoEdit.CategoryID = categoryID;

                    //update recode in database
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null;//rest list box
                    tasks = db.Tasks.ToList();//get fresh list
                    ListBoxTasks.ItemsSource = tasks;

                }

                ButtonEdit.Content = "Edit";
                ButtonEdit.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryID.IsReadOnly = true;

                var brush = new BrushConverter();



                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxCategoryID.Background = (Brush)brush.ConvertFrom("#EEFAFF"); ;
                TextBoxID.Background = (Brush)brush.ConvertFrom("#EEFAFF");

            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm";
                //set booxes to editable
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryID.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryID.IsReadOnly = false;
                //clear out boxes
                TextBoxID.Text = "";
                TextBoxCategoryID.Text = "";
                TextBoxDescription.Text = "";


            }
            else
            {
                ButtonAdd.Content = "Add";
                //set booxes to editable
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryID.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryID.IsReadOnly = true;

                int.TryParse(TextBoxCategoryID.Text, out int categoryID);

                var taskToAdd = new Task()
                {

                    Description = TextBoxDescription.Text,
                    CategoryID = categoryID
                    
                };
                //clear out boxes
                using (var db = new TasksDBEntities())
                {
                    db.Tasks.Add(taskToAdd);
                    


                    //update recode in database
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null;//rest list box
                    tasks = db.Tasks.ToList();//get fresh list
                    ListBoxTasks.ItemsSource = tasks;
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Delected";
                //set booxes to editable
                //TextBoxDescription.Background = Brushes.White;
                //TextBoxCategoryID.Background = Brushes.White;
                //TextBoxDescription.IsReadOnly = false;
                //TextBoxCategoryID.IsReadOnly = false;
                //clear out boxes
                //TextBoxID.Text = "";
                //TextBoxCategoryID.Text = "";
                //TextBoxDescription.Text = "";


            }
            else
            {
                using (var db = new TasksDBEntities())
                {
                    var delete = db.Tasks.Find(task.TasskID);
                    db.Tasks.Remove(delete);



                    //update recode in database
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null;//rest list box
                    tasks = db.Tasks.ToList();//get fresh list
                    ListBoxTasks.ItemsSource = tasks;
                }
            }
        }
    }
}
