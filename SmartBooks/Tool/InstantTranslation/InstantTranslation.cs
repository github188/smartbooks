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
        private TranslateBing bing;
        private string clipboardText = "";

        public InstantTranslation()
        {
            InitializeComponent();
        }
        private void InstantTranslation_Load(object sender, EventArgs e)
        {
            bing = new TranslateBing();
            bing.On_Sucess += new Sucess(bing_On_Sucess);
            bing.On_Error += new Error(bing_On_Error);
            Clipboard.Clear();
            timer1.Start();
        }
        private void bing_On_Sucess(LanguageStructure language)
        {
            this.rtxText.Text = language.Translation;
        }
        private void bing_On_Error(string error)
        {
            this.rtxText.Text = error;
        }

        //Show
        private void tolMenuShow_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }
        //Exit
        private void tolMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Listen Blord
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string originalText = Clipboard.GetText(TextDataFormat.Text);
            if (!string.IsNullOrEmpty(originalText) && originalText!= clipboardText)
            {
                clipboardText = originalText;
                bing.Translate(new LanguageStructure { OriginalText = originalText, Translation = "" });
            }
            timer1.Start();
        }
    }
}