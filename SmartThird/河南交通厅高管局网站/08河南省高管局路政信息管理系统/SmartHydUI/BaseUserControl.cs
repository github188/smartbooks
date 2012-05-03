using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SmartHyd.UI {
    public class BaseUserControl : System.Web.UI.UserControl {
        public Panel AddPanel = new Panel();
        public Panel DeletePanel = new Panel();
        public Panel ListPanel = new Panel();
        public Button button = new Button();
        public string Roles = "roles all";

        public BaseUserControl()
        {
            this.Controls.Add(AddPanel);
            this.Controls.Add(DeletePanel);
            this.Controls.Add(ListPanel);
            this.Controls.Add(button);

            AddPanel.GroupingText = "add";
            DeletePanel.GroupingText = "del";
            ListPanel.GroupingText = "list";

            AddPanel.Controls.Add(button);
            button.Text = "button";
        }
    }
}
