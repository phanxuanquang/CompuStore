using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
{
    using CompuStore.Database.Services;
    using Database.Models;
    public partial class StaffManagement_Tab : BaseTab
    {
        
        public StaffManagement_Tab()
        {
            this.DataTable.AutoGenerateColumns = false;
            InitializeComponent();
            this.DataTable.DataSource = sTAFFBindingSource;
            this.Load += StaffManagement_Tab_Load;
        }

        #region Binding
        private void LoadFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            // e.Result = (Database.ClassServices.Instance.GetClasss().Select(item => item.CLASSNAME).Distinct().ToArray(), Database.DataProvider.Instance.Database.CLASSes.Select(item => item.SCHOOLYEAR).Distinct().ToArray());
        }
        private void LoadFromDB_RunrWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*(string[], string[]) results = ((string[], string[]))(e.Result);
            Class_ComboBox.Items.AddRange(results.Item1);
            SchoolYear_ComboBox.Items.AddRange(results.Item2);*/

            /*Class_ComboBox.SelectedIndex = 0;
            SchoolYear_ComboBox.SelectedIndex = 0;*/
            
            //LoadToDataTable(GetListStudent(Class_ComboBox.SelectedItem.ToString(), SchoolYear_ComboBox.SelectedItem.ToString()));
            //loadingWindow.Close();
        }
        private void StaffManagement_Tab_Load(object sender, EventArgs e)
        {
            BindingStaff(GetListStaff());
        }
        public void BindingStaff(List<STAFF> sTAFFs)
        {
            sTAFFBindingSource.ResetBindings(true);
            sTAFFBindingSource.DataSource = sTAFFs;
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                STAFF selected = row.DataBoundItem as STAFF;
                if (selected != null)
                {
                    row.Cells["Id"].Value = selected.NAME_ID;
                    row.Cells["StaffName"].Value = selected.INFOR.NAME;
                    row.Cells["PhoneNum"].Value = selected.INFOR.PHONE_NUMBER;
                    row.Cells["Role"].Value = selected.STAFFROLE.ROLE;
                    row.Cells["Status"].Value = selected.WORKING_STATUS == 0 ? "Đã nghỉ việc" : "Đang làm việc";
                }
            }
        }
        private List<STAFF> GetListStaff()
        {
            List<STAFF> students = StaffServices.Instance.GetStaffs();
            /*if (className == "Mọi lớp")
            {
                if (schoolYear == "Mọi niên khóa")
                {
                    var allClass = Database.DataProvider.Instance.Database.CLASSes.ToList();
                    foreach (var aClass in allClass)
                    {
                        var listStudent = Database.ClassServices.Instance.GetListStudyingOfClass(aClass.CLASSNAME, aClass.SCHOOLYEAR);
                        foreach (var student in listStudent)
                        {
                            //DataTable.Rows.Add(student.CLASS.SCHOOLYEAR, student.ID.ToString().Substring(0, 7).ToUpper(), student.CLASS.CLASSNAME, student.INFOR.FIRSTNAME + " " + student.INFOR.LASTNAME, student.Status);
                            students.Add(student);
                        }
                    }
                }
                else
                {

                    var allClass = Database.DataProvider.Instance.Database.CLASSes.Where(item => item.SCHOOLYEAR == schoolYear).ToList();
                    foreach (var aClass in allClass)
                    {
                        var listStudent = Database.ClassServices.Instance.GetListStudyingOfClass(aClass.CLASSNAME, aClass.SCHOOLYEAR);
                        foreach (var student in listStudent)
                        {
                            //DataTable.Rows.Add(student.CLASS.SCHOOLYEAR, student.ID.ToString().Substring(0, 7).ToUpper(), student.CLASS.CLASSNAME, student.INFOR.FIRSTNAME + " " + student.INFOR.LASTNAME, student.Status);
                            students.Add(student);
                        }
                    }
                }
            }
            else
            {
                if (schoolYear == "Mọi niên khóa")
                {
                    var allClass = Database.DataProvider.Instance.Database.CLASSes.Where(item => item.CLASSNAME == Class_ComboBox.SelectedItem.ToString()).ToList();
                    foreach (var aClass in allClass)
                    {
                        var listStudent = Database.ClassServices.Instance.GetListStudyingOfClass(aClass.CLASSNAME, aClass.SCHOOLYEAR);
                        foreach (var student in listStudent)
                        {
                            //DataTable.Rows.Add(student.CLASS.SCHOOLYEAR, student.ID.ToString().Substring(0, 7).ToUpper(), student.CLASS.CLASSNAME, student.INFOR.FIRSTNAME + " " + student.INFOR.LASTNAME, student.Status);
                            students.Add(student);
                        }
                    }
                }
                else
                {

                    //var allClass = Database.ClassServices.Instance.GetClassByClassNameAndSchoolYear(className,schoolYear);

                    {
                        var listStudent = Database.ClassServices.Instance.GetListStudyingOfClass(className, schoolYear);
                        foreach (var student in listStudent)
                        {
                            //DataTable.Rows.Add(student.CLASS.SCHOOLYEAR, student.ID, student.CLASS.CLASSNAME, student.FIRSTNAME + " " + student.LASTNAME, student.Status);
                            students.Add(student);
                        }
                    }
                }
            }*/
            return students;
        }
        #endregion

        #region Buttons
        private void AddNew_Buttom_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(true, "THÊM NHÂN VIÊN", null);
            staffEdit_Form.ShowDialog();
            BindingStaff(GetListStaff());
        }
        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(false, "THÔNG TIN NHÂN VIÊN", sTAFFBindingSource.Current);
            staffEdit_Form.ShowDialog();
            BindingStaff(GetListStaff());
        }
        #endregion
    }
}
