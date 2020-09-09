namespace Entrepot
{
    partial class accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.liberer = new System.Windows.Forms.Button();
            this.obtenir_libre = new System.Windows.Forms.Button();
            this.stock = new System.Windows.Forms.Button();
            this.impress = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // liberer
            // 
            this.liberer.Location = new System.Drawing.Point(13, 13);
            this.liberer.Name = "liberer";
            this.liberer.Size = new System.Drawing.Size(202, 41);
            this.liberer.TabIndex = 0;
            this.liberer.TabStop = false;
            this.liberer.Text = "Libérer un emplacement";
            this.liberer.UseVisualStyleBackColor = true;
            this.liberer.Click += new System.EventHandler(this.liberer_Click);
            // 
            // obtenir_libre
            // 
            this.obtenir_libre.Location = new System.Drawing.Point(13, 60);
            this.obtenir_libre.Name = "obtenir_libre";
            this.obtenir_libre.Size = new System.Drawing.Size(202, 42);
            this.obtenir_libre.TabIndex = 1;
            this.obtenir_libre.TabStop = false;
            this.obtenir_libre.Text = "Obtenir un emplacement libre";
            this.obtenir_libre.UseVisualStyleBackColor = true;
            this.obtenir_libre.Click += new System.EventHandler(this.obtenir_libre_Click);
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(13, 108);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(202, 44);
            this.stock.TabIndex = 2;
            this.stock.TabStop = false;
            this.stock.Text = "Liste des produits en stock";
            this.stock.UseVisualStyleBackColor = true;
            this.stock.Click += new System.EventHandler(this.stock_Click);
            // 
            // impress
            // 
            this.impress.Location = new System.Drawing.Point(13, 158);
            this.impress.Name = "impress";
            this.impress.Size = new System.Drawing.Size(202, 84);
            this.impress.TabIndex = 3;
            this.impress.TabStop = false;
            this.impress.Text = "Rechercher un produit dans le stock";
            this.impress.UseVisualStyleBackColor = true;
            this.impress.Click += new System.EventHandler(this.impress_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(338, 201);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(75, 41);
            this.quit.TabIndex = 4;
            this.quit.TabStop = false;
            this.quit.Text = "Quitter";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quitter_Click);
            // 
            // accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 259);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.impress);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.obtenir_libre);
            this.Controls.Add(this.liberer);
            this.Name = "accueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.accueil_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button liberer;
        private System.Windows.Forms.Button obtenir_libre;
        private System.Windows.Forms.Button stock;
        private System.Windows.Forms.Button impress;
        private System.Windows.Forms.Button quit;
    }
}

