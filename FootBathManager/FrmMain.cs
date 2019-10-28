using M.Core.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootBathManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            List<EmployeeInfos> employeeInfos = new List<EmployeeInfos>();
            for (var i = 0; i < 3; i++)
            {
                var emplyoyees = new List<Emplyoyee>();
                for (var j = 0; j < 20; j++)
                {
                    emplyoyees.Add(
                        new Emplyoyee()
                        {
                            EmployeeId = i.ToString(),
                            EmployeeNO = i.ToString(),
                            RoomNO = "Toom" + i.ToString()
                        }
                    );
                }
                employeeInfos.Add(new EmployeeInfos()
                {
                    EmployeeMapVO = emplyoyees,
                    GroupId = i.ToString(),
                    GroupName = i.ToString()
                });
            }
            var height = 300;
            if (employeeInfos.Count < 4)
            {
                height = pnlMain.Height / employeeInfos.Count;
            }
            int n = 0;
            foreach (var employeeInfo in employeeInfos)
            {
                int y = height * (n) + (n > 0 ? 1 : 0);
                var uCGroup = new UCGroup(employeeInfo)
                {
                    Height = height,
                    Location = new System.Drawing.Point(0, y),
                    Dock = DockStyle.Top
                };
                uCGroup.Show();
                uCGroup.AddItems(employeeInfo.EmployeeMapVO);
                n++;
                pnlMain.Controls.Add(uCGroup);
                pnlMain.Controls.Add(new UCSplitLine_H()
                {
                    Height = 1,
                    BackColor = System.Drawing.Color.White,
                    Location = new System.Drawing.Point(0, y + 1),
                    Dock = DockStyle.Top
                });
            }
        }
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                if (WindowState == FormWindowState.Maximized) //窗体最大化
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.Sizable;
                }
                else
                {
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = FormBorderStyle.None;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
    public class EmployeeInfos
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public List<Emplyoyee> EmployeeMapVO { get; set; }
    }
    public class Emplyoyee
    {
        public string QueueNum { get; set; }
        public string EmployeeId { get; set; }
        public string linxi { get; set; }
        public string RoomNO { get; set; }
        public string EmployeeNO { get; set; }
        public string Gender { get; set; }
        public string GenderName { get; set; }
        public string EmployeeStatusId { get; set; }
        public string EmployeeStatusName { get; set; }
    }
}
