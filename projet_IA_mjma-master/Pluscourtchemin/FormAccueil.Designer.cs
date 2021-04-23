namespace Pluscourtchemin
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.btn_33 = new System.Windows.Forms.Button();
            this.btn_55 = new System.Windows.Forms.Button();
            this.Label_accueil = new System.Windows.Forms.Label();
            this.label_dimension = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_33
            // 
            this.btn_33.Location = new System.Drawing.Point(258, 234);
            this.btn_33.Name = "btn_33";
            this.btn_33.Size = new System.Drawing.Size(231, 130);
            this.btn_33.TabIndex = 0;
            this.btn_33.Text = "3 x 3";
            this.btn_33.UseVisualStyleBackColor = true;
            this.btn_33.Click += new System.EventHandler(this.btn_33_Click);
            // 
            // btn_55
            // 
            this.btn_55.Location = new System.Drawing.Point(643, 234);
            this.btn_55.Name = "btn_55";
            this.btn_55.Size = new System.Drawing.Size(215, 130);
            this.btn_55.TabIndex = 1;
            this.btn_55.Text = "5 x 5";
            this.btn_55.UseVisualStyleBackColor = true;
            this.btn_55.Click += new System.EventHandler(this.btn_55_Click);
            // 
            // Label_accueil
            // 
            this.Label_accueil.AutoSize = true;
            this.Label_accueil.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_accueil.Location = new System.Drawing.Point(253, 62);
            this.Label_accueil.Name = "Label_accueil";
            this.Label_accueil.Size = new System.Drawing.Size(605, 30);
            this.Label_accueil.TabIndex = 2;
            this.Label_accueil.Text = "Bienvenue, prêt à résoudre du Taquin?";
            // 
            // label_dimension
            // 
            this.label_dimension.AutoSize = true;
            this.label_dimension.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dimension.Location = new System.Drawing.Point(307, 163);
            this.label_dimension.Name = "label_dimension";
            this.label_dimension.Size = new System.Drawing.Size(449, 19);
            this.label_dimension.TabIndex = 3;
            this.label_dimension.Text = "Choisissez la dimension du Taquin à résoudre";
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 591);
            this.Controls.Add(this.label_dimension);
            this.Controls.Add(this.Label_accueil);
            this.Controls.Add(this.btn_55);
            this.Controls.Add(this.btn_33);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccueil";
            this.Text = "FormAccueil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_33;
        private System.Windows.Forms.Button btn_55;
        private System.Windows.Forms.Label Label_accueil;
        private System.Windows.Forms.Label label_dimension;
    }
}