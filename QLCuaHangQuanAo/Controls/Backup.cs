using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangQuanAo.Controls
{
    public partial class Backup : UserControl
    {
        private DataGridView dgvBackupHistory;
        private Button btnBackup;
        private Button btnRestore;
        private Button btnBrowse;
        private TextBox txtBackupLocation;
        private ProgressBar progressBar;
        private RadioButton rbFullBackup;
        private RadioButton rbDifferentialBackup;
        private RadioButton rbTransactionLogBackup;

        DatabaseHelper db;
        public Backup()
        {
            InitializeComponent();

            MyInitializeComponent();

            db = new DatabaseHelper();
        }
        private void MyInitializeComponent()
        {
            // Initialize Controls
            dgvBackupHistory = new DataGridView();
            btnBackup = new Button();
            btnRestore = new Button();
            btnBrowse = new Button();
            txtBackupLocation = new TextBox();
            progressBar = new ProgressBar();
            rbFullBackup = new RadioButton();
            rbDifferentialBackup = new RadioButton();
            rbTransactionLogBackup = new RadioButton();

            // DataGridView - For displaying backup history
            dgvBackupHistory.Location = new Point(20, 20);
            dgvBackupHistory.Size = new Size(500, 150);
            dgvBackupHistory.AutoGenerateColumns = true; // Will display columns from the query
            this.Controls.Add(dgvBackupHistory);

            // Browse Button - To select backup location
            btnBrowse.Text = "Browse";
            btnBrowse.Location = new Point(20, 200);
            btnBrowse.Click += BtnBrowse_Click;
            this.Controls.Add(btnBrowse);

            // Backup Button - To perform backup
            btnBackup.Text = "Backup";
            btnBackup.Location = new Point(120, 200);
            btnBackup.Click += BtnBackup_Click;
            this.Controls.Add(btnBackup);

            // Restore Button - For restoring from a backup (Optional)
            btnRestore.Text = "Restore";
            btnRestore.Location = new Point(220, 200);
            this.Controls.Add(btnRestore);

            // Backup Location TextBox
            txtBackupLocation.Location = new Point(20, 170);
            txtBackupLocation.Width = 300;
            this.Controls.Add(txtBackupLocation);

            // Progress Bar for backup progress
            progressBar.Location = new Point(20, 240);
            progressBar.Width = 500;
            this.Controls.Add(progressBar);

            // Full Backup RadioButton
            rbFullBackup.Text = "Full Backup";
            rbFullBackup.Location = new Point(20, 270);
            rbFullBackup.Checked = true; // Default to full backup
            this.Controls.Add(rbFullBackup);

            // Differential Backup RadioButton
            rbDifferentialBackup.Text = "Differential Backup";
            rbDifferentialBackup.Location = new Point(120, 270);
            this.Controls.Add(rbDifferentialBackup);

            // Transaction Log Backup RadioButton
            rbTransactionLogBackup.Text = "Transaction Log Backup";
            rbTransactionLogBackup.Location = new Point(250, 270);
            this.Controls.Add(rbTransactionLogBackup);

            // Load Backup History when the form is loaded
            this.Load += BackupForm_Load;
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            // Load backup history from SQL Server
            LoadBackupHistory();
        }

        private void LoadBackupHistory()
        {
            DataTable dataTable = db.ExecuteQuery("layDanhSachBackup");
            dgvBackupHistory.DataSource = dataTable;
            dgvBackupHistory.Columns[0].Width = 150;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Show FolderDialog to choose backup location
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupLocation.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            // Perform the backup
            string backupLocation = txtBackupLocation.Text;
            if (string.IsNullOrEmpty(backupLocation))
            {
                MessageBox.Show("Please choose a backup location.");
                return;
            }

            string backupType = "FULL";
            if (rbDifferentialBackup.Checked)
            {
                backupType = "DIFFERENTIAL";
            }
            else if (rbTransactionLogBackup.Checked)
            {
                backupType = "LOG";
            }

            string backupQuery = $"BACKUP DATABASE QuanLyCuaHangQuanAo2 TO DISK = '{backupLocation}\\QuanLyCuaHangQuanAo2.bak' WITH {backupType}";

            db.ExecuteNonQuery(backupQuery);
            MessageBox.Show("Backup completed successfully!");
            LoadBackupHistory(); // Refresh backup history
        }
    }
}
