namespace Coursework
{
    partial class Form4
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
            this.dataGridStudentStat = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentStat)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridStudentStat
            // 
            this.dataGridStudentStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStudentStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.TotalStudents});
            this.dataGridStudentStat.Location = new System.Drawing.Point(16, 15);
            this.dataGridStudentStat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridStudentStat.Name = "dataGridStudentStat";
            this.dataGridStudentStat.RowHeadersWidth = 51;
            this.dataGridStudentStat.Size = new System.Drawing.Size(555, 289);
            this.dataGridStudentStat.TabIndex = 0;
            // 
            // Course
            // 
            this.Course.HeaderText = "Kurslar";
            this.Course.MinimumWidth = 6;
            this.Course.Name = "Course";
            this.Course.Width = 125;
            // 
            // TotalStudents
            // 
            this.TotalStudents.HeaderText = "Jami Talabalar";
            this.TotalStudents.MinimumWidth = 6;
            this.TotalStudents.Name = "TotalStudents";
            this.TotalStudents.Width = 125;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 327);
            this.Controls.Add(this.dataGridStudentStat);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentStat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridStudentStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStudents;
    }
}