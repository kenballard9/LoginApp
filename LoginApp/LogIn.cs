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

            // Step 4: Login successful -> open BoardForm (keep login hidden)
            MessageBox.Show("Login successful. Redirecting to board...", "Success");

            // Hide the login form and show the board modelessly
            this.Hide();

            var board = new BoardForm
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            // When the board closes, close the (hidden) login form to end the app cleanly
            board.FormClosed += (s, args) => this.Close();

            board.Show();
            // DO NOT call this.Show() again — we want the login to remain hidden.
            // DO NOT use ShowDialog() here — it would block and complicate lifetime.
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // Optional: set Accept/Cancel buttons so Enter/Esc work nicely
            // this.AcceptButton = signInButton;
            // this.CancelButton = closeButton; // if you have one
        }
    }
}
