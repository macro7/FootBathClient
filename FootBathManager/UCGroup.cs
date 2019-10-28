using M.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FootBathManager
{
    public partial class UCGroup : UserControl
    {
        public UCGroup(EmployeeInfos employeeInfo)
        {
            InitializeComponent();
            lblGroupName.Text = string.Join(Environment.NewLine, employeeInfo.GroupName.ToArray());
        }

        public void AddItems(List<Emplyoyee> employeeMapVO)
        {
            int x = 2;
            int y = 2;
            int spacing = 2;
            foreach (var emplyoyee in employeeMapVO)
            {
                UCButton ucButton1 = new UCButton();
                ucButton1.BackColor = System.Drawing.Color.Transparent;
                ucButton1.BtnBackColor = System.Drawing.Color.White;
                ucButton1.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
                ucButton1.BtnForeColor = System.Drawing.Color.White;
                ucButton1.BtnText = emplyoyee.EmployeeNO;
                ucButton1.ConerRadius = 15;
                ucButton1.Cursor = Cursors.Hand;
                ucButton1.FillColor = System.Drawing.Color.FromArgb(255, 77, 59);
                ucButton1.IsRadius = true;
                ucButton1.IsShowRect = true;
                ucButton1.IsShowTips = false;
                ucButton1.Location = new System.Drawing.Point(177, 191);
                ucButton1.Margin = new System.Windows.Forms.Padding(0);
                ucButton1.Name = "ucButton1" + emplyoyee.EmployeeNO;
                ucButton1.RectColor = System.Drawing.Color.FromArgb(255, 77, 58);
                ucButton1.RectWidth = 1;
                ucButton1.Size = new System.Drawing.Size(184, 60);
                ucButton1.TipsColor = System.Drawing.Color.FromArgb(232, 30, 99);
                ucButton1.Location = new System.Drawing.Point(x, y);
                x += 100 + spacing;
                if (x + 102 > pnlItems.Width)
                {
                    y += 100 + spacing;
                    x = 2;
                }
                pnlItems.Controls.Add(ucButton1);
            }
        }
    }
}
