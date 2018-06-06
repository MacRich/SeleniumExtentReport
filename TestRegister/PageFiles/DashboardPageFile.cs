using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRegister.Framework;

namespace TestRegister.PageFiles
{
    public class DashboardPageFile :CommonMethod
    {
        public By dashboardmenu = By.Id("menu_dashboard_index");
        public By dashboardpanel = By.Id("CPVW_IMES_000001_B2");
        public By displaygraph = By.Id("div_graph_display_emp_distribution");
        public By panel2 = By.Id("panel_draggable_1_1");
    }
}