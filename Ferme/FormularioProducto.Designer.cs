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
            this.cmbTiposP.Location = new System.Drawing.Point(866, 189);
            this.cmbTiposP.Name = "cmbTiposP";
            this.cmbTiposP.Size = new System.Drawing.Size(121, 21);
            this.cmbTiposP.TabIndex = 0;
            this.cmbTiposP.SelectedIndexChanged += new System.EventHandler(this.cmbTiposP_SelectedIndexChanged);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(866, 216);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(121, 21);
            this.cmbProveedor.TabIndex = 1;
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new System.Drawing.Point(866, 162);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoProducto.TabIndex = 2;
            // 
            // txtFamiliaP
            // 
            this.txtFamiliaP.AutoSize = true;
            this.txtFamiliaP.Location = new System.Drawing.Point(760, 165);
            this.txtFamiliaP.Name = "txtFamiliaP";
            this.txtFamiliaP.Size = new System.Drawing.Size(85, 13);
            this.txtFamiliaP.TabIndex = 3;
            this.txtFamiliaP.Text = "Familia Producto";
            this.txtFamiliaP.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo Producto";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedor";
            // 
            // txtDescripcionP
            // 
            this.txtDescripcionP.Location = new System.Drawing.Point(866, 136);
            this.txtDescripcionP.Name = "txtDescripcionP";
            this.txtDescripcionP.Size = new System.Drawing.Size(121, 20);
            this.txtDescripcionP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(771, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descripcion";
            // 
            // txtNombreP
            // 
            this.txtNombreP.Location = new System.Drawing.Point(866, 103);
            this.txtNombreP.Name = "txtNombreP";
            this.txtNombreP.Size = new System.Drawing.Size(121, 20);
            this.txtNombreP.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nombre";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(866, 243);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(121, 20);
            this.txtPrecio.TabIndex = 10;
            // 
            // Precio
            // 
            this.Precio.AutoSize = true;
            this.Precio.Location = new System.Drawing.Point(788, 250);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(37, 13);
            this.Precio.TabIndex = 11;
            this.Precio.Text = "Precio";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(733, 308);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bntAgregarP
            // 
            this.bntAgregarP.Location = new System.Drawing.Point(774, 292);
            this.bntAgregarP.Name = "bntAgregarP";
            this.bntAgregarP.Size = new System.Drawing.Size(87, 23);
            this.bntAgregarP.TabIndex = 13;
            this.bntAgregarP.Text = "Agregar";
            this.bntAgregarP.UseVisualStyleBackColor = true;
            this.bntAgregarP.Click += new System.EventHandler(this.bntAgregarP_Click);
            // 
            // btnActualizarP
            // 
            this.btnActualizarP.Location = new System.Drawing.Point(890, 292);
            this.btnActualizarP.Name = "btnActualizarP";
            this.btnActualizarP.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarP.TabIndex = 14;
            this.btnActualizarP.Text = "Actualizar";
            this.btnActualizarP.UseVisualStyleBackColor = true;
            this.btnActualizarP.Click += new System.EventHandler(this.btnActualizarP_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(865, 77);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(122, 20);
            this.txtID.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(781, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "ID";
            // 
            // txtEliminarP
            // 
            this.txtEliminarP.Location = new System.Drawing.Point(774, 346);
            this.txtEliminarP.Name = "txtEliminarP";
            this.txtEliminarP.Size = new System.Drawing.Size(87, 23);
            this.txtEliminarP.TabIndex = 17;
            this.txtEliminarP.Text = "Eliminar";
            this.txtEliminarP.UseVisualStyleBackColor = true;
            this.txtEliminarP.Click += new System.EventHandler(this.txtEliminarP_Click);
            // 
            // FormularioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 450);
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