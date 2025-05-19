using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindGrid();
            btnUpdate.Visible = false;
            dataGridView1.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Saqlash tugmasi bosilganda
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Iltimos, ismingizni kiriting!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLastName.Text == "" || txtLastName.Text == null)
            {
                MessageBox.Show("Iltimos, familiyangizni kiriting!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "" || txtAddress.Text == null)
            {
                MessageBox.Show("Iltimos, manzilingizni kiriting!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtContactNo.Text == "" || txtContactNo.Text == null)
            {
                MessageBox.Show("Iltimos, to'g'ri telefon raqamingizni kiriting!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (gender.SelectedItem == null)
            {
                MessageBox.Show("Iltimos, jinsingizni tanlang!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEmail.Text == "" || txtEmail.Text == null)
            {
                MessageBox.Show("Iltimos, to'g'ri elektron pochtangizni kiriting!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (enrolProgram.SelectedItem == null)
            {
                MessageBox.Show("Iltimos, ro'yxatdan o'tgan dasturingizni tanlang!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rBtnPending.Checked == false && rBtnPublished.Checked == false)
            {
                MessageBox.Show("Iltimos, holatni tanlang!", "Ogohlantirish xabari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Student obj = new Student();
                obj.firstName = txtFirstName.Text;
                obj.lastName = txtLastName.Text;
                obj.Address = txtAddress.Text;
                obj.Email = txtEmail.Text;
                obj.BirthDate = dob.Value;
                obj.ContactNo = txtContactNo.Text;
                obj.Gender = gender.SelectedItem.ToString();
                obj.RegisterDate = regDate.Value;
                obj.Courses = enrolProgram.SelectedItem.ToString();
                if (rBtnPending.Checked == true)
                {
                    obj.Status = rBtnPending.Text;
                }
                else if (rBtnPublished.Checked == true)
                {
                    obj.Status = rBtnPublished.Text;
                }

                obj.Add(obj);
                MessageBox.Show("Ma'lumotlar muvaffaqiyatli saqlandi", "Ma'lumot xabari", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid();
                Clear();
            }
        }

        private void BindGrid()
        {
            // Jadvalga ma'lumotlarni bog'lash
            Student obj = new Student();
            List<Student> listStudents = obj.List();
            DataTable dt = Utility.ConvertToDataTable(listStudents);
            dataGridStudent.DataSource = dt;
        }

        private void Clear()
        {
            // Barcha maydonlarni tozalash
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            dob.Value = DateTime.Today;
            txtContactNo.Text = "";
            gender.SelectedItem = null;
            regDate.Value = DateTime.Today;
            enrolProgram.SelectedItem = null;
            if (rBtnPending.Checked)
            {
                rBtnPending.Checked = false;
            }
            else
            {
                rBtnPublished.Checked = false;
            }
        }

        private void dataGridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Jadval katakchasini bosganda
            Student obj = new Student();
            if (e.ColumnIndex == 0)
            {
                // Bosilgan qatorning id ustuni qiymatini olish
                string value = dataGridStudent[2, e.RowIndex].Value.ToString();
                int id = 0;
                if (String.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Noto'g'ri ma'lumot");
                }
                else
                {
                    id = int.Parse(value);
                    Student s = obj.List().Where(X => X.Id == id).FirstOrDefault();
                    txtId.Text = s.Id.ToString();
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;
                    obj.firstName = txtFirstName.Text;
                    obj.lastName = txtLastName.Text;
                    obj.Address = txtAddress.Text;
                    obj.Email = txtEmail.Text;
                    obj.BirthDate = dob.Value;
                    obj.ContactNo = txtContactNo.Text;
                    obj.Gender = gender.SelectedItem.ToString();
                    obj.RegisterDate = regDate.Value;
                    obj.Courses = enrolProgram.SelectedItem.ToString();
                    if (rBtnPending.Checked == true)
                    {
                        obj.Status = rBtnPending.Text;
                    }
                    else if (rBtnPublished.Checked == true)
                    {
                        obj.Status = rBtnPublished.Text;
                    }
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
            else if (e.ColumnIndex == 1)
            {
                string value = dataGridStudent[2, e.RowIndex].Value.ToString();
                obj.Delete(int.Parse(value));
                BindGrid();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Yangilash tugmasi bosilganda
            Student obj = new Student();
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            obj.firstName = txtFirstName.Text;
            obj.lastName = txtLastName.Text;
            obj.Address = txtAddress.Text;
            obj.Email = txtEmail.Text;
            obj.BirthDate = dob.Value;
            obj.ContactNo = txtContactNo.Text;
            obj.Gender = gender.SelectedItem.ToString();
            obj.RegisterDate = regDate.Value;
            obj.Courses = enrolProgram.SelectedItem.ToString();
            if (rBtnPending.Checked == true)
            {
                obj.Status = rBtnPending.Text;
            }
            else if (rBtnPublished.Checked == true)
            {
                obj.Status = rBtnPublished.Text;
            }
            obj.Edit(obj);
            BindGrid();
            Clear();
            btnSave.Visible = true;
            MessageBox.Show("Ma'lumotlar muvaffaqiyatli yangilandi", "Ma'lumot xabari", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Bekor qilish tugmasi bosilganda
            MessageBox.Show("Haqiqatan ham bekor qilmoqchimisiz?", "Ogohlantirish xabari", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // O'chirish tugmasi bosilganda
            Student obj = new Student();
            int rowIndex = dataGridStudent.CurrentCell.RowIndex;
            string message = "Haqiqatan ham bu yozuvni o'chirmoqchimisiz?";
            string title = "O'chirish tasdiqlash";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.OK)
            {
                // Bosilgan qatorning id ustuni qiymatini olish
                string value = dataGridStudent[0, rowIndex].Value.ToString();
                obj.Delete(int.Parse(value));
                BindGrid();
                MessageBox.Show("Yozuv muvaffaqiyatli o'chirildi", "Ma'lumot xabari", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clear();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label11_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Tahrirlash tugmasi bosilganda
            int rowIndex = dataGridStudent.CurrentCell.RowIndex;
            if (dataGridStudent.SelectedRows.Count > 0) // foydalanuvchi kamida 1ta qator tanlaganligini tekshirish
            {
                string firstName = dataGridStudent.SelectedRows[0].Cells[1].Value + string.Empty;
                string lastName = dataGridStudent.SelectedRows[0].Cells[2].Value + string.Empty;
                string Address = dataGridStudent.SelectedRows[0].Cells[3].Value + string.Empty;
                string Email = dataGridStudent.SelectedRows[0].Cells[4].Value + string.Empty;
                string ContactNo = dataGridStudent.SelectedRows[0].Cells[6].Value + string.Empty;
                string Gender = dataGridStudent.SelectedRows[0].Cells[7].Value + string.Empty;
                string Courses = dataGridStudent.SelectedRows[0].Cells[9].Value + string.Empty;
                string Status = dataGridStudent.SelectedRows[0].Cells[10].Value + string.Empty;

                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtAddress.Text = Address;
                txtEmail.Text = Email;
                txtContactNo.Text = ContactNo;
                gender.Text = Gender;
                enrolProgram.Text = Courses;
                if (rBtnPending.Text == Status)
                {
                    rBtnPending.Checked = true;
                }
                else if (rBtnPublished.Text == Status)
                {
                    rBtnPublished.Checked = true;
                }
                else
                {
                    MessageBox.Show("Holat avval tanlanmagan edi");
                }
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tozalash
            Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Form2 ni ko'rsatish
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Form3 ni ko'rsatish
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void dataGridStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bo'sh metod
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Dasturdan chiqish
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Haftalik hisobot ko'rsatish
            // Student sinfining yangi obyekti
            Student obj = new Student();

            // Ro'yxatga olingan sananing kiritilgan qiymatini olish
            DateTime registeredDate = dateTimePicker1.Value;

            // Student sinfining List metodi, talabalar ro'yxatini qaytaradi
            List<Student> listStudents = obj.List();

            // Hafta boshlanishi va tugash kunlarini o'z ichiga olgan massivni qaytaruvchi FindWeek metodini chaqirish
            DateTime[] dateArray = obj.FindWeek(registeredDate);

            // Hafta talabalari ro'yxatini qaytaruvchi WeeklyStudent metodini chaqirish
            List<Student> weeklyStudents = obj.WeeklyStudent(dateArray, listStudents);

            // Ro'yxatni kurs bo'yicha guruhlash va ikkita ustun yaratish: kurs va soni
            var result = weeklyStudents
                    .GroupBy(l => l.Courses)
                    .Select(cl => new
                    {
                        Courses = cl.First().Courses,
                        Count = cl.Count().ToString()
                    }).ToList();

            dataGridView1.Show();
            dataGridStudent.Hide();

            // Natijani ma'lumotlar jadvaliga o'girish va uni data grid view-da ko'rsatish
            DataTable dt = Utility.ConvertToDataTable(result);
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void regDate_ValueChanged(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void enrolProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bo'sh metod
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Saralash tugmasi bosilganda
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Name")
                {
                    Student obj = new Student();

                    // Talabalarning asl ro'yxati
                    List<Student> listStudents = obj.List();

                    // Saralashdan keyin ro'yxat
                    List<Student> lst = obj.Sort(listStudents, "Name");

                    // Saralangan ro'yxatni ma'lumotlar jadvaliga qo'shish
                    DataTable dt = Utility.ConvertToDataTable(lst);
                    dataGridStudent.DataSource = dt;
                }
                else
                {
                    Student obj = new Student();
                    List<Student> listStudents = obj.List();
                    List<Student> lst = obj.Sort(listStudents, "Registration Date");
                    DataTable dt = Utility.ConvertToDataTable(lst);
                    dataGridStudent.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Noto'g'ri kiritish! Iltimos, biror qiymatni tanlang.", "Xato xabari", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}