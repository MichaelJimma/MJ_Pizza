using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MJ_Pizza
{
    public partial class PizzaForm : Form
    {
        /*declarations*/
        private FoodItems foodList;
        private ContactForm contact;
        private IList<string> lstTopping = new List<string>();
        private IList<string> lstChickenWings = new List<string>();
        private IList<string> lstBeverages = new List<string>();
        public IList<string> lstContact = new List<string>();
        private double pizzaPrice = 0.00;
        private double toppingPrice = 0.00;
        private double wingsPrice = 0.00;
        private double bitesPrice = 0.00;
        private double stripsPrice = 0.00;
        private double SoftPrice = 0.00;
        private double smoothiesPrice = 0.00;
        public PizzaForm()
        {
            InitializeComponent();
        }
        
        private void PizzaForm_Load(object sender, EventArgs e)
        {
            InitializeClass();
        }

        #region Controls Event handlers

        /*fires when any of the check boxes checked or unchecked from this CheckedListBox control*/
        private void chkListToppings_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstTopping.Clear();//Clears all items from the lstTopping arraylist 
                toppingPrice = 0;
                foreach (var item in chkListToppings.CheckedItems)//Loops throgh all the items in the chkListToppings CheckedListBox and gets the value of the checked items only
                {
                    lstTopping.Add(string.Format("{0} - $1.50", item.ToString()));//Adds the checked items into lstTopping arraylist and formats the string
                    toppingPrice += 1.50;
                }
                foodList.ToppingList = lstTopping;//Copy the lstToppings arrayList into FoodItems object's ToppingList arraylist field
                DisplayOrder();//calls the display method to show the newly added or removed item in the display list from the lstTopping arraylist
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /*a method to handle the pizza size combo box selected index changed event*/
        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pizzaPrice = 0;
                switch (cmbSize.SelectedIndex)//gets the selected item's index number 
                {
                    case 0://first item in the combo box (Small)
                        this.imgFoodItem.Image = global::MJ_Pizza.Properties.Resources.smallPizza;//changes the image to smallPizza if the the selected index is 0 (Small)
                        foodList.PizzaSize = "Small Size - $8.95";//copy the text into the foodList object pizzaSize field
                        pizzaPrice = 8.95;
                        DisplayOrder();//calls the display method to show the newly added pizza size
                        break;
                    case 1:
                        this.imgFoodItem.Image = global::MJ_Pizza.Properties.Resources.mediumPizza;
                        foodList.PizzaSize = "Medium Size - $12.95";
                        pizzaPrice = 12.95;
                        DisplayOrder();
                        break;
                    case 2:
                        this.imgFoodItem.Image = global::MJ_Pizza.Properties.Resources.largePizza;
                        foodList.PizzaSize = "Large Size - $18.95";
                        pizzaPrice = 18.95;
                        DisplayOrder();
                        break;
                    default:
                        this.imgFoodItem.Image = global::MJ_Pizza.Properties.Resources.mediumPizza;
                        foodList.PizzaSize = "Medium Size - $12.95";
                        DisplayOrder();
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void chkOrderPizza_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this control type array holds all the controls tha i want to disable or enable accordingly
                Control[] controls = { cmbSize, chkListToppings, chkListSauce, chkListCheese, chkListCrust, chkListSpecial };
                pizzaPrice = 0;
                if (chkOrderPizza.Checked)
                {
                    EnableDisableControls(controls, true);
                    foodList.PizzaSize = string.Format("Medium Size - $12.95");
                    pizzaPrice = 12.95;
                    DisplayOrder();
                }
                else
                {
                    EnableDisableControls(controls, false);
                    chkListToppings.ClearSelected();
                    foodList.PizzaSize = "";
                    DisplayOrder();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /*this event handler handles all the suace radio buttons checked events*/
        private void SauceRadioButtons_CheckedChanged(Object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {
                RadioButton rdoSauce = (RadioButton)sender;
                foodList.Sauces = string.Format("{0} - $0.00", rdoSauce.Text);
                DisplayOrder();
            }
        }

        /*this event handler handles all the cheese radio buttons checked events*/
        private void CheeseRadioButtons_CheckedChanged(Object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {
                RadioButton rdoCheese = (RadioButton)sender;
                foodList.Cheese = string.Format("{0} - $0.00", rdoCheese.Text);
                DisplayOrder();
            }
        }

        /*this event handler handles all the crust radio buttons checked events*/
        private void CrustRadioButtons_CheckedChanged(Object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {
                RadioButton rdoCrust = (RadioButton)sender;
                foodList.Crust = string.Format("{0} - $0.00", rdoCrust.Text);
                DisplayOrder();
            }
        }

        /*this event handler handles all the special order radio buttons checked events*/
        private void SpecialOrderRadioButtons_CheckedChanged(Object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {
                RadioButton rdoSpecialOrder = (RadioButton)sender;
                foodList.SpecialOrder = string.Format("{0} - $0.00", rdoSpecialOrder.Text);
                DisplayOrder();
            }
        }

        /*this event handler handles all the chicken wings check boxes checked events*/
        private void ChickenWingsCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            try
            {
                //wingsPrice = 0;
                //bitesPrice = 0;
                //stripsPrice = 0;
                if (((CheckBox)sender).Checked)
                {
                    CheckBox chkChickenWings = (CheckBox)sender;
                    
                    foodList.ChickenWings.Add(chkChickenWings.Text.ToString());

                    switch (chkChickenWings.Name)
                    {
                        case "chkWing1":
                            foodList.ChickenPrice += 5.80;
                            wingsPrice += 5.80;
                            DisplayOrder();
                            break;
                        case "chkWing2":
                            foodList.ChickenPrice += 9.00;
                            wingsPrice += 9.00;
                            DisplayOrder();
                            break;
                        case "chkWing3":
                            DisplayOrder();
                            foodList.ChickenPrice += 17.00;
                            wingsPrice += 17.00;
                            DisplayOrder();
                            break;
                        case "chkBites1":
                            foodList.ChickenPrice += 9.00;
                            bitesPrice += 9.00;
                            DisplayOrder();
                            break;
                        case "chkBites2":
                            foodList.ChickenPrice += 17.00;
                            bitesPrice += 17.00;
                            DisplayOrder();
                            break;
                        case "chkStrip1":
                            foodList.ChickenPrice += 9.00;
                            stripsPrice += 9.00;
                            DisplayOrder();
                            break;
                        case "chkStrip2":
                            foodList.ChickenPrice += 17.00;
                            stripsPrice += 17.00;
                            DisplayOrder();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    CheckBox chkChickenWings = (CheckBox)sender;
                    if (foodList.ChickenWings.Contains(chkChickenWings.Text.ToString()))
                        foodList.ChickenWings.RemoveAt(foodList.ChickenWings.IndexOf(chkChickenWings.Text.ToString()));
                    switch (chkChickenWings.Name)
                    {
                        case "chkWing1":
                            foodList.ChickenPrice -= 5.80;
                            wingsPrice -= 5.80;
                            DisplayOrder();
                            break;
                        case "chkWing2":
                            foodList.ChickenPrice -= 9.00;
                            wingsPrice -= 9.00;
                            DisplayOrder();
                            break;
                        case "chkWing3":
                            DisplayOrder();
                            foodList.ChickenPrice -= 17.00;
                            wingsPrice -= 17.00;
                            DisplayOrder();
                            break;
                        case "chkBites1":
                            foodList.ChickenPrice -= 9.00;
                            bitesPrice -= 9.00;
                            DisplayOrder();
                            break;
                        case "chkBites2":
                            foodList.ChickenPrice -= 17.00;
                            bitesPrice -= 17.00;
                            DisplayOrder();
                            break;
                        case "chkStrip1":
                            foodList.ChickenPrice -= 9.00;
                            stripsPrice -= 9.00;
                            DisplayOrder();
                            break;
                        case "chkStrip2":
                            foodList.ChickenPrice -= 17.00;
                            stripsPrice -= 17.00;
                            DisplayOrder();
                            break;
                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /*this event handler handles all the beverages check boxes checked events*/
        private void BevragesCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            try
            {
                //SoftPrice = 0;
                //smoothiesPrice = 0;
                if (((CheckBox)sender).Checked)
                {
                    CheckBox chkBeverages = (CheckBox)sender;

                    if (chkBeverages.Name == "chkSoft")
                        numSoftDrinks.Enabled = true;
                    else
                        numSmoothie.Enabled = true;



                    switch (chkBeverages.Name.ToString())
                    {
                        case "chkSoft":
                            foodList.SoftDrinksPrice += 3.00;
                            SoftPrice += 3.00;
                            foodList.Softdrinks.Add(string.Format("{0} x {1}", chkBeverages.Text.ToString(), numSoftDrinks.Value));
                            DisplayOrder();
                            break;
                        case "chkSmoothie":
                            foodList.SmoothiesPrice += 4.00;
                            smoothiesPrice += 4.00;
                            foodList.Smoothies.Add(string.Format("{0} x {1}", chkBeverages.Text.ToString(), numSmoothie.Value));
                            DisplayOrder();
                            break;
                        default:
                            break;
                    }

                    DisplayOrder();
                }
                else
                {
                    CheckBox chkBeverages = (CheckBox)sender;
                    

                    if (chkBeverages.Name == "chkSoft")
                    {
                        numSoftDrinks.Enabled = false;
                        
                    }


                    else
                    {
                        numSmoothie.Enabled = false;
                        
                    }

                    switch (chkBeverages.Name.ToString())
                    {
                        case "chkSoft":
                            
                            foodList.Softdrinks.Clear();
                            foodList.SoftDrinksPrice = 0.00;
                            SoftPrice = 0.00;
                            DisplayOrder();
                            break;
                        case "chkSmoothie":
                            foodList.Smoothies.Clear();
                            foodList.SmoothiesPrice = 0.00;
                            smoothiesPrice = 0.00;
                            DisplayOrder();
                            break;
                        default:
                            break;
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "&Place Order")
            {
                contact.ShowDialog();
                DisplayOrder();
                InitializeClass();
                btnSubmit.Text = "&Clear List";
            }
            else
            {
                ResetControls();
                btnSubmit.Text = "&Place Order";
            }


        }

        private void numSoftDrinks_ValueChanged(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(numSoftDrinks.Value);
            try
            {
                foodList.SoftDrinksPrice = foodList.SoftDrinksPrice * val;
                SoftPrice = SoftPrice * val;
                foodList.Softdrinks.Clear();
                foodList.Softdrinks.Add(string.Format("{0} x {1}", this.chkSoft.Text.ToString(), numSoftDrinks.Value));
                DisplayOrder();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void numSmoothie_ValueChanged(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(numSmoothie.Value);
            try
            {
                foodList.Smoothies.Clear();
                foodList.SmoothiesPrice = foodList.SmoothiesPrice * val;
                smoothiesPrice = smoothiesPrice * val;
                foodList.Smoothies.Add(string.Format("{0} x {1}", this.chkSmoothie.Text.ToString(), numSmoothie.Value));
                DisplayOrder();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void imgFoodItem_Click(object sender, EventArgs e)
        {
            if (chkOrderPizza.Checked)
            {
                chkOrderPizza.Checked = false;
            }
            else
            {
                chkOrderPizza.Checked = true;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void softDrinksPictureBox_Click(object sender, EventArgs e)
        {
            if (chkSoft.Checked)
            {
                chkSoft.Checked = false;
            }
            else
            {
                chkSoft.Checked = true;
            }
        }

        private void smoothiesPictureBox_Click(object sender, EventArgs e)
        {
            if (chkSmoothie.Checked)
            {
                chkSmoothie.Checked = false;
            }
            else
            {
                chkSmoothie.Checked = true;
            }
        }

        private void sixWingsPictureBox_Click(object sender, EventArgs e)
        {
            if (chkWing1.Checked)
            {
                chkWing1.Checked = false;
            }
            else
            {
                chkWing1.Checked = true;
            }
        }

        private void stenWingsPictureBox_Click(object sender, EventArgs e)
        {
            if (chkWing2.Checked)
            {
                chkWing2.Checked = false;
            }
            else
            {
                chkWing2.Checked = true;
            }
        }

        private void twentyWingsPictureBox_Click(object sender, EventArgs e)
        {
            if (chkWing3.Checked)
            {
                chkWing3.Checked = false;
            }
            else
            {
                chkWing3.Checked = true;
            }
        }

        private void tenBitesPictureBox_Click(object sender, EventArgs e)
        {
            if (chkBites1.Checked)
            {
                chkBites1.Checked = false;
            }
            else
            {
                chkBites1.Checked = true;
            }
        }

        private void twentyBitesPictureBox_Click(object sender, EventArgs e)
        {
            if (chkBites2.Checked)
            {
                chkBites2.Checked = false;
            }
            else
            {
                chkBites2.Checked = true;
            }
        }

        private void tenStripsPictureBox_Click(object sender, EventArgs e)
        {
            if (chkStrip1.Checked)
            {
                chkStrip1.Checked = false;
            }
            else
            {
                chkStrip1.Checked = true;
            }
        }

        private void twentyStripsPictureBox_Click(object sender, EventArgs e)
        {
            if (chkStrip2.Checked)
            {
                chkStrip2.Checked = false;
            }
            else
            {
                chkStrip2.Checked = true;
            }
        }

        #endregion

        #region Methods

            /*
           Instantiates the objects of FoodItems and ContactForm classes. 
           This method is also used in the program to reset all fields in the classes to their default value.
           */
        private void InitializeClass()
        {
            foodList = new FoodItems();
            contact = new ContactForm(this);
        }


        /*return true if the value passed is empty*/
        public static bool IsEmpty(string value)
        {
            return String.IsNullOrEmpty(value) || value.Trim().Length == 0;
        }

        /*Enable or disable the contros passed with the array according to the bool value*/
        private void EnableDisableControls(Control[] ctn, bool enable)
        {
            try
            {
                if (enable)
                {
                    foreach (var item in ctn)
                    {
                        item.Enabled = enable;
                    }
                }

                else
                {
                    foreach (var item in ctn)
                    {
                        item.Enabled = enable;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /*Resets all the controls in the form*/
        public void ResetControls()
        {
            try
            {
                //it loops through all checked boxes and assigns the index in i, and pass the index to SetItemCheckState method and set the state unchaked
                foreach (int i in chkListToppings.CheckedIndices)
                {
                    chkListToppings.SetItemCheckState(i, CheckState.Unchecked);
                }

                chkOrderPizza.Checked = false;

                foreach (var item in chkListSauce.Controls)
                {
                    if (((RadioButton)item).Checked)
                    {
                        RadioButton rdoSauce = (RadioButton)item;
                        rdoSauce.Checked = false;
                    }
                }
                foreach (var item in chkListCheese.Controls)
                {
                    if (((RadioButton)item).Checked)
                    {
                        RadioButton rdoCheese = (RadioButton)item;
                        rdoCheese.Checked = false;
                    }
                }
                foreach (var item in chkListCrust.Controls)
                {
                    if (((RadioButton)item).Checked)
                    {
                        RadioButton rdoCrust = (RadioButton)item;
                        rdoCrust.Checked = false;
                    }
                }
                foreach (var item in chkListSpecial.Controls)
                {
                    if (((RadioButton)item).Checked)
                    {
                        RadioButton rdoSpecial = (RadioButton)item;
                        rdoSpecial.Checked = false;
                    }
                }
                foreach (var item in wingsGroupBox.Controls)
                {
                    if (item is CheckBox)
                    {
                        if (((CheckBox)item).Checked)
                        {
                            CheckBox chkWings = (CheckBox)item;
                            chkWings.Checked = false;
                        }
                    }

                }
                foreach (var item in bitesGroupBox.Controls)
                {
                    if (item is CheckBox)
                    {
                        if (((CheckBox)item).Checked)
                        {
                            CheckBox chkBits = (CheckBox)item;
                            chkBits.Checked = false;
                        }
                    }

                }
                foreach (var item in stripsGroupBox.Controls)
                {
                    if (item is CheckBox)
                    {
                        if (((CheckBox)item).Checked)
                        {
                            CheckBox chkStrips = (CheckBox)item;
                            chkStrips.Checked = false;
                        }
                    }

                }
                chkSoft.Checked = false;
                chkSmoothie.Checked = false;
                numSoftDrinks.Value = 1;
                numSmoothie.Value = 1;
                lstTopping.Clear();
                lstChickenWings.Clear();
                lstBeverages.Clear();
                lstContact.Clear();
                InitializeClass();
                lstOrderList.Items.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /*Displays all the selected value from the Main Window, the contact info from ContactForm and the calculated total amount from FoodItems class*/
        private void DisplayOrder()
        {
            try
            {


                lstOrderList.Items.Clear();
                if (!IsEmpty(foodList.PizzaSize))
                    lstOrderList.Items.Add(foodList.PizzaSize);

                foreach (var item in foodList.ToppingList)
                {
                    if (!IsEmpty(item))
                        lstOrderList.Items.Add(item);
                }

                if (!IsEmpty(foodList.Sauces))
                    lstOrderList.Items.Add(foodList.Sauces);

                if (!IsEmpty(foodList.Cheese))
                    lstOrderList.Items.Add(foodList.Cheese);

                if (!IsEmpty(foodList.Crust))
                    lstOrderList.Items.Add(foodList.Crust);

                if (!IsEmpty(foodList.SpecialOrder))
                    lstOrderList.Items.Add(foodList.SpecialOrder);

                foreach (var item in foodList.ChickenWings)
                {
                    if (!IsEmpty(item))
                        lstOrderList.Items.Add(item);
                }

                foreach (var item in foodList.Softdrinks)
                {
                    if (!IsEmpty(item))
                        lstOrderList.Items.Add(item);
                }
                foreach (var item in foodList.Smoothies)
                {
                    if (!IsEmpty(item))
                        lstOrderList.Items.Add(item);
                }

                lstOrderList.Items.Add("");
                lstOrderList.Items.Add(string.Format("Your total price is-------------------------{0:C}", CalculateTotal()));
                lstOrderList.Items.Add("");

                lstOrderList.Items.Add(string.Format("-------------------Contact Information--------------------------"));

                foreach (var item in lstContact)
                {
                    lstOrderList.Items.Add(item);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private double CalculateTotal()
        {
            return (pizzaPrice + toppingPrice + wingsPrice + bitesPrice + stripsPrice + SoftPrice + smoothiesPrice);
        }



        #endregion

    }
}
