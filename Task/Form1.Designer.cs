
namespace tASK
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridForPairedEmployees = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridForPairedEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridForPairedEmployees
            // 
            this.dataGridForPairedEmployees.AllowUserToAddRows = false;
            this.dataGridForPairedEmployees.AllowUserToDeleteRows = false;
            this.dataGridForPairedEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridForPairedEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridForPairedEmployees.Location = new System.Drawing.Point(46, 132);
            this.dataGridForPairedEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridForPairedEmployees.Name = "dataGridForPairedEmployees";
            this.dataGridForPairedEmployees.ReadOnly = true;
            this.dataGridForPairedEmployees.RowHeadersWidth = 51;
            this.dataGridForPairedEmployees.RowTemplate.Height = 24;
            this.dataGridForPairedEmployees.Size = new System.Drawing.Size(790, 394);
            this.dataGridForPairedEmployees.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(276, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(332, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Paired Employees";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridForPairedEmployees);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridForPairedEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridForPairedEmployees;
        private System.Windows.Forms.Button button1;
    }
}

