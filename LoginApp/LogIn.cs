using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both a username and password.", "Missing info");
                return;
            }

            if (UserStore.Users.ContainsKey(username))
            {
                MessageBox.Show("That username already exists. Please choose another.");
                return;
            }

            // Save the user
            UserStore.Users[username] = password;
            MessageBox.Show("Registration successful! You can now log in.");

            // Optionally clear fields
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            // Step 1: Validate empty fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information");
                return;
            }

            // Step 2: Check if user exists
            if (!UserStore.Users.ContainsKey(username))
            {
                MessageBox.Show("User not found. Please register first.", "Login Failed");
                return;
            }

            // Step 3: Validate password
            string storedPassword = UserStore.Users[username];
            if (storedPassword != password)
            {
                MessageBox.Show("Incorrect password. Please try again.", "Login Failed");
                return;
            }

            // Step 4: Login successful -> open BoardForm
            MessageBox.Show("Login successful. Redirecting to board...", "Success");

            this.Hide(); // hide login while board is open

            // Show the Kanban board; center on screen
            using (var board = new BoardForm())
            {
                board.StartPosition = FormStartPosition.CenterScreen;

                // Option A: Return to login after board closes (current behavior)
                board.ShowDialog(this);
                this.Show();

                // Option B: Exit the app after board closes (uncomment to use)
                // board.ShowDialog(this);
                // this.Close();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // Optional: set Accept/Cancel buttons so Enter/Esc work nicely
            // this.AcceptButton = signInButton;
            // this.CancelButton = closeButton; // if you have one
        }
    }
}
