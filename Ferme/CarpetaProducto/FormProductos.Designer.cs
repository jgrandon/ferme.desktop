namespace Ferme.CarpetaProducto
{
    partial class FormProductos
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
            this.txtEliminarP = new System.Windows.Forms.Button();
            this.btnActualizarP = new System.Windows.Forms.Button();
            this.bntAgregarP = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtNombreP = new System.Windows.Forms.TextBox();
            this.txtDescripcionP = new System.Windows.Forms.TextBox();
            this.cmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbTiposP = new System.Windows.Forms.ComboBox();
            this.txtStockPro = new System.Windows.Forms.TextBox();
            this.txtFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEliminarP
            // 
            this.txtEliminarP.BackColor = System.Drawing.Color.Blue;
            this.txtEliminarP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtEliminarP.ForeColor = System.Drawing.SystemColors.Window;
            this.txtEliminarP.Location = new System.Drawing.Point(1144, 392);
            this.txtEliminarP.Name = "txtEliminarP";
            this.txtEliminarP.Size = new System.Drawing.Size(142, 23);
            this.txtEliminarP.TabIndex = 71;
            this.txtEliminarP.Text = "Eliminar";
            this.txtEliminarP.UseVisualStyleBackColor = false;
            this.txtEliminarP.Click += new System.EventHandler(this.txtEliminarP_Click);
            // 
            // btnActualizarP
            // 
            this.btnActualizarP.BackColor = System.Drawing.Color.Blue;
            this.btnActualizarP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizarP.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizarP.Location = new System.Drawing.Point(1144, 336);
            this.btnActualizarP.Name = "btnActualizarP";
            this.btnActualizarP.Size = new System.Drawing.Size(142, 23);
            this.btnActualizarP.TabIndex = 68;
            this.btnActualizarP.Text = "Actualizar";
            this.btnActualizarP.UseVisualStyleBackColor = false;
            this.btnActualizarP.Click += new System.EventHandler(this.btnActualizarP_Click);
            // 
            // bntAgregarP
            // 
            this.bntAgregarP.BackColor = System.Drawing.Color.Blue;
            this.bntAgregarP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntAgregarP.ForeColor = System.Drawing.SystemColors.Window;
            this.bntAgregarP.Location = new System.Drawing.Point(1144, 285);
            this.bntAgregarP.Name = "bntAgregarP";
            this.bntAgregarP.Size = new System.Drawing.Size(142, 23);
            this.bntAgregarP.TabIndex = 67;
            this.bntAgregarP.Text = "Agregar";
            this.bntAgregarP.UseVisualStyleBackColor = false;
            this.bntAgregarP.Click += new System.EventHandler(this.bntAgregarP_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dataGridView1.Location = new System.Drawing.Point(-8, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1057, 406);
            this.dataGridView1.TabIndex = 66;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecio.BackColor = System.Drawing.Color.DimGray;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPrecio.Location = new System.Drawing.Point(1088, 158);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(123, 16);
            this.txtPrecio.TabIndex = 64;
            this.txtPrecio.Text = "Precio";
            // 
            // txtNombreP
            // 
            this.txtNombreP.BackColor = System.Drawing.Color.DimGray;
            this.txtNombreP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtNombreP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.txtNombreP.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNombreP.Location = new System.Drawing.Point(1088, 45);
            this.txtNombreP.Name = "txtNombreP";
            this.txtNombreP.Size = new System.Drawing.Size(121, 16);
            this.txtNombreP.TabIndex = 62;
            this.txtNombreP.Text = "Nombre";
            // 
            // txtDescripcionP
            // 
            this.txtDescripcionP.BackColor = System.Drawing.Color.DimGray;
            this.txtDescripcionP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDescripcionP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.txtDescripcionP.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDescripcionP.Location = new System.Drawing.Point(1088, 94);
            this.txtDescripcionP.Name = "txtDescripcionP";
            this.txtDescripcionP.Size = new System.Drawing.Size(121, 16);
            this.txtDescripcionP.TabIndex = 60;
            this.txtDescripcionP.Text = "Descripcion";
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.BackColor = System.Drawing.Color.DimGray;
            this.cmbTipoProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoProducto.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new System.Drawing.Point(1227, 40);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoProducto.TabIndex = 56;
            this.cmbTipoProducto.Text = "Familia Producto";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.BackColor = System.Drawing.Color.DimGray;
            this.cmbProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbProveedor.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(1227, 150);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(121, 24);
            this.cmbProveedor.TabIndex = 55;
            this.cmbProveedor.Text = "Proveedor";
            // 
            // cmbTiposP
            // 
            this.cmbTiposP.BackColor = System.Drawing.Color.DimGray;
            this.cmbTiposP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTiposP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTiposP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbTiposP.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbTiposP.FormattingEnabled = true;
            this.cmbTiposP.Location = new System.Drawing.Point(1227, 86);
            this.cmbTiposP.Name = "cmbTiposP";
            this.cmbTiposP.Size = new System.Drawing.Size(121, 24);
            this.cmbTiposP.TabIndex = 54;
            this.cmbTiposP.Text = "Tipo Producto";
            // 
            // txtStockPro
            // 
            this.txtStockPro.BackColor = System.Drawing.Color.DimGray;
            this.txtStockPro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStockPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.txtStockPro.ForeColor = System.Drawing.SystemColors.Window;
            this.txtStockPro.Location = new System.Drawing.Point(1088, 221);
            this.txtStockPro.Name = "txtStockPro";
            this.txtStockPro.Size = new System.Drawing.Size(121, 17);
            this.txtStockPro.TabIndex = 76;
            this.txtStockPro.Text = "Stock";
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.CalendarForeColor = System.Drawing.SystemColors.Window;
            this.txtFechaVencimiento.CalendarTitleForeColor = System.Drawing.SystemColors.MenuText;
            this.txtFechaVencimiento.CalendarTrailingForeColor = System.Drawing.Color.DimGray;
            this.txtFechaVencimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.txtFechaVencimiento.Location = new System.Drawing.Point(1227, 216);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.Size = new System.Drawing.Size(123, 22);
            this.txtFechaVencimiento.TabIndex = 78;
            // 
            // FormProductos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1360, 450);
            this.Controls.Add(this.txtFechaVencimiento);
            this.Controls.Add(this.txtStockPro);
            this.Controls.Add(this.txtEliminarP);
            this.Controls.Add(this.btnActualizarP);
            this.Controls.Add(this.bntAgregarP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtNombreP);
            this.Controls.Add(this.txtDescripcionP);
            this.Controls.Add(this.cmbTipoProducto);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.cmbTiposP);
            this.Name = "FormProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button txtEliminarP;
        private System.Windows.Forms.Button btnActualizarP;
        private System.Windows.Forms.Button bntAgregarP;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtNombreP;
        private System.Windows.Forms.TextBox txtDescripcionP;
        private System.Windows.Forms.ComboBox cmbTipoProducto;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.ComboBox cmbTiposP;
        private System.Windows.Forms.TextBox txtStockPro;
        private System.Windows.Forms.DateTimePicker txtFechaVencimiento;
    }
}