using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmartBooks.Translate;

namespace InstantTranslation
{
    public partial class InstantTranslation : Form
    {
        public InstantTranslation()
        {
            InitializeComponent();
        }

        private void InstantTranslation_Load(object sender, EventArgs e)
        {
            TranslateBing bing = new TranslateBing();            
            bing.On_Sucess += new Sucess(bing_On_Sucess);
            bing.On_Error += new Error(bing_On_Error);
            bing.Translate(new LanguageStructure { OriginalText = "English", Translation = "" });
        }

        private void bing_On_Sucess(LanguageStructure language)
        {
            this.Text = language.Translation;
        }
        private void bing_On_Error(string error)
        {
            this.Text = error;
        }
    }
}