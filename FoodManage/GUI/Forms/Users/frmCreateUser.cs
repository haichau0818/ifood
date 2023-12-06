using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FoodManage.ULTI;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using FoodManage.Models;
using FoodManage.BUS;

namespace FoodManage.GUI.Forms.Users
{
    public partial class frmCreateUser : Form
    {

        //private readonly UserBUS _userBUS = new UserBUS();

        #region Rounded Corners Form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

            );

        #endregion

        #region Move form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

      
        public frmCreateUser()
        {
            InitializeComponent();
          
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        #region handle form
        private void frmCreateUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void picCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region feature form


        private void btnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.FullName = txtFullname.Text.Trim();
            if (!handle.IsValidEmail(txtEmail.Text.Trim()))
                return;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.PhoneNumber = txtPhoneNumber.Text;
            user.Address = txtAddress.Text;
            user.GenderId = 1;
            user.Avatar = handle.ConvertImageFromPictureBox(picAvatar);
            user.DateOfBird = dtpDateOfBird.Value;
            user.RoleId = 1;
            try
            {
                   // _userBUS.Insert(user);
                
                    MessageBox.Show("Create successfully!");
                    this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                picAvatar.Image = new Bitmap(open.FileName);
                // image file path
                lblFolderName.Visible = true;
                lblFolderName.Text = open.FileName;

            }
        }


        private void loadGender()
        {
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");

        }

        private void loadRole()
        {

        }
        #endregion

        #region Properties

        User user = new User();
        private User _userProperties
        {
            get
            {
                user.FullName = txtFullname.Text.Trim();
                user.Password = txtConfirmPassword.Text.Trim();
                user.Address = txtAddress.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.PhoneNumber = txtPhoneNumber.Text.Trim();

                //user.Role = Convert.ToInt32(cboRole.ValueMember);
                //user.Dateofbird = dtpDateOfBird.Value;
                return user;
            }
            set
            {
                user = value;
                txtFullname.Text = value.FullName;
                txtPassword.Text = value.Password;
                txtAddress.Text = value.Address;
                txtEmail.Text = value.Email;
                //txtPhoneNumber.Text = value.Phonenumber;
                // picAvatar.Image = handle.ConverByteArrayToImage(value.Avatar);

            }
        }

        #endregion


        private void frmCreateUser_Load(object sender, EventArgs e)
        {
            //load gender text and auto select first item
            loadGender();
            cboGender.SelectedIndex = 0;
            loadRole();
        }
    }
}
