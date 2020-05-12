namespace Ferme
{
    partial class FormularioProducto
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
            this.cmbTiposP = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.txtFamiliaP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.Precio = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bntAgregarP = new System.Windows.Forms.Button();
            this.btnActualizarP = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEliminarP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTiposP
            // 
            this.cmbTiposP.FormattingEnabled = true;
            this.cmbTiposP.Location = new System.Drawing.Point(1010, 204);
            this.cmbTiposP.Name = "cmbTiposP";
            this.cmbTiposP.Size = new System.Drawing.Size(140, 22);
            this.cmbTiposP.TabIndex = 0;
            this.cmbTiposP.SelectedIndexChanged += new System.EventHandler(this.cmbTiposP_SelectedIndexChanged);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(1010, 233);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(140, 22);
            this.cmbProveedor.TabIndex = 1;
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new System.Drawing.Point(1010, 174);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new System.Drawing.Size(140, 22);
            this.cmbTipoProducto.TabIndex = 2;
            // 
            // txtFamiliaP
            // 
            this.txtFamiliaP.AutoSize = true;
            this.txtFamiliaP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFamiliaP.Location = new System.Drawing.Point(885, 177);
            this.txtFamiliaP.Name = "txtFamiliaP";
            this.txtFamiliaP.Size = new System.Drawing.Size(106, 14);
            this.txtFamiliaP.TabIndex = 3;
            this.txtFamiliaP.Text = "Familia Producto";
            this.txtFamiliaP.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(885, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo Producto";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(887, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedor";
            // 
            // txtDescripcionP
            // 
            this.txtDescripcionP.Location = new System.Drawing.Point(1010, 146);
            this.txtDescripcionP.Name = "txtDescripcionP";
            this.txtDescripcionP.Size = new System.Drawing.Size(140, 20);
            this.txtDescripcionP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(887, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descripcion";
            // 
            // txtNombreP
            // 
            this.txtNombreP.Location = new System.Drawing.Point(1010, 111);
            this.txtNombreP.Name = "txtNombreP";
            this.txtNombreP.Size = new System.Drawing.Size(140, 20);
            this.txtNombreP.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(887, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nombre";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(1010, 262);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(140, 20);
            this.txtPrecio.TabIndex = 10;
            // 
            // Precio
            // 
            this.Precio.AutoSize = true;
            this.Precio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Precio.Location = new System.Drawing.Point(887, 262);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(42, 14);
            this.Precio.TabIndex = 11;
            this.Precio.Text = "Precio";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 332);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bntAgregarP
            // 
            this.bntAgregarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bntAgregarP.Cursor = System.Windows.Forms.Cursors.Default;
            this.bntAgregarP.FlatAppearance.BorderSize = 0;
            this.bntAgregarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntAgregarP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bntAgregarP.Location = new System.Drawing.Point(988, 354);
            this.bntAgregarP.Name = "bntAgregarP";
            this.bntAgregarP.Size = new System.Drawing.Size(101, 25);
            this.bntAgregarP.TabIndex = 13;
            this.bntAgregarP.Text = "AGREGAR";
            this.bntAgregarP.UseVisualStyleBackColor = false;
            this.bntAgregarP.Click += new System.EventHandler(this.bntAgregarP_Click);
            // 
            // btnActualizarP
            // 
            this.btnActualizarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnActualizarP.FlatAppearance.BorderSize = 0;
            this.btnActualizarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizarP.Location = new System.Drawing.Point(1059, 409);
            this.btnActualizarP.Name = "btnActualizarP";
            this.btnActualizarP.Size = new System.Drawing.Size(94, 25);
            this.btnActualizarP.TabIndex = 14;
            this.btnActualizarP.Text = "ACTUALIZAR";
            this.btnActualizarP.UseVisualStyleBackColor = false;
            this.btnActualizarP.Click += new System.EventHandler(this.btnActualizarP_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1009, 83);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(142, 20);
            this.txtID.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(887, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "ID";
            // 
            // txtEliminarP
            // 
            this.txtEliminarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtEliminarP.FlatAppearance.BorderSize = 0;
            this.txtEliminarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtEliminarP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEliminarP.Location = new System.Drawing.Point(920, 409);
            this.txtEliminarP.Name = "txtEliminarP";
            this.txtEliminarP.Size = new System.Drawing.Size(101, 25);
            this.txtEliminarP.TabIndex = 17;
            this.txtEliminarP.Text = "ELIMINAR";
            this.txtEliminarP.UseVisualStyleBackColor = false;
            this.txtEliminarP.Click += new System.EventHandler(this.txtEliminarP_Click);
            // 
            // FormularioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1165, 485);
            this.Controls.Add(this.txtEliminarP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnActualizarP);
            this.Controls.Add(this.bntAgregarP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Precio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcionP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFamiliaP);
            this.Controls.Add(this.cmbTipoProducto);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.cmbTiposP);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormularioProducto";
            this.Text = "FormularioProducto";
            this.Load += new System.EventHandler(this.FormularioProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTiposP;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.ComboBox cmbTipoProducto;
        private System.Windows.Forms.Label txtFamiliaP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcionP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label Precio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bntAgregarP;
        private System.Windows.Forms.Button btnActualizarP;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button txtEliminarP;
    }
}