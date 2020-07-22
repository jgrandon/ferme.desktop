using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
//using ObservableCollection;
//using System.Windows.Forms.OpenFileDialog ofd;


namespace Ferme.CarpetaProducto
{
    /// <summary>
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : MetroWindow
    {

        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        Entities DB;
        int selectedUserId = 0;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private List<FileStream> imagenesPorCargar = new List<FileStream>();
        int filaSeleccionada;

        public Producto()
        {
            InitializeComponent();
            DB = new Entities();
            cargarComboFamilias();
            cargarProveedor();
            cargarTipoP();
            refrescarTabla();
            cargarComboProductos_Imagen();
            BtnOpenActualizarProducto.IsEnabled = false;
            BtnEliminarProducto.IsEnabled = false;
        }


        private void cargarComboProductos_Imagen()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();

            foreach (PRODUCTOS p in DB.PRODUCTOS)
            {
                list.Add(p.NOMBRE);
            }
            ComboBoxProducto_Imagen.ItemsSource = list;
        }

        public void BtnOpenActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            this.limpiarFormularioProducto();
            var datos = DataGridProducto.SelectedItem as DataRowView;
            if (datos != null)
            {
                txtStockProductos.Text = datos["Stock Producto"].ToString();
                txtActualizarNomProdu.Text = datos["Nombre"].ToString();
                txtActualizarDescripcion.Text = datos["Descripcion"].ToString();
                txtActualizarPrecio.Text = datos["Precio"].ToString();
                ComboBoxFamiliaPro.Text = datos["FAMILIA PRODUCTO"].ToString();
                ComboBoxTipoP.Text = datos["TIPO PRODUCTO"].ToString();
                ComboBoxProveedor.Text = datos["Provedoor"].ToString();
                DateActualizarFechaVen.Text = datos["Fecha vencimiento"].ToString();
            }
            DataGridProducto.Items.Refresh();
            FlyImagenes.IsOpen = false;
            FlyModificarProducto.IsOpen = true;
            BtnActualizarProducto.IsEnabled = true;
        }


        private void DataGridProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datos = DataGridProducto.SelectedItem as DataRowView;
            if (datos != null)
            {
                this.filaSeleccionada = Int32.Parse(datos.Row.ItemArray[1].ToString()); //almacena el id del producto al que se le hizo click en tabla
                BtnOpenActualizarProducto.IsEnabled = true;
                BtnEliminarProducto.IsEnabled = true;
            }
        }


        private void BtnMostrarListProducto_Click(object sender, RoutedEventArgs e)
        {
            FlyImagenes.IsOpen = false;
            FlyModificarProducto.IsOpen = true;
            this.limpiarFormularioProducto();
            BtnGuardarProducto.IsEnabled = true;
        }


        private async void BtnModificarProducto_Click(object sender, RoutedEventArgs e)

        {
            FAMILIAS_PRODUCTO FamiliaP = getFamiliaByName(ComboBoxFamiliaPro.Text);
            if (FamiliaP == null)
            {
                await this.ShowMessageAsync("Exito", "Error al Buscar Familia");
                return;
            }

            PROVEEDORES ProveedorP = getProveedorByName(ComboBoxProveedor.Text);
            if (ProveedorP == null)
            {
                await this.ShowMessageAsync("Exito", "Error al Buscar Proveedor");
                return;
            }

            TIPOS_PRODUCTO TipoP = getTipoByName(ComboBoxTipoP.Text);
            if (TipoP == null)
            {
                await this.ShowMessageAsync("Exito", "Error al Buscar Tipo Producto");
                return;
            }

            if (!this.isNumber(txtStockProductos.Text))
            {
                await this.ShowMessageAsync("Error", "El campo STOCK debe ser un numero");
                return;
            }

            if (!this.isNumber(txtActualizarPrecio.Text))
            {
                await this.ShowMessageAsync("Error", "El campo PRECIO debe ser un numero");
                return;
            }

            if (!this.isDate(DateActualizarFechaVen.Text))
            {
                await this.ShowMessageAsync("Error", "El campo FECHA VENCIMIENTO debe ser una fecha con formato dd/mm/yyyy");
                return;
            }
            if (txtActualizarNomProdu.Text.Trim().Equals(""))
            {
                await this.ShowMessageAsync("Error", "El campo NOMBRE no puede estar vacio");
                return;
            }



            DateTime dateObject = DateTime.Parse(DateActualizarFechaVen.Text);

            PRODUCTOS productoPorActualizar = DB.PRODUCTOS.Find(this.filaSeleccionada);

               

            var resultado = await this.ShowMessageAsync("Confirmacion Modificar", "Esta seguro que desea actualizar el producto: " + productoPorActualizar.NOMBRE,
                       MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);

            if (resultado == MessageDialogResult.Affirmative)
            {
                FR.Open();
                OracleCommand comando = new OracleCommand("UPDATE PRODUCTOS SET  ID_TIPOPRODUCTO ='" + TipoP.ID + "',ID_FAMILIAPRODUCTO = '"+FamiliaP.ID + "',ID_PROVEEDOR = '"+ProveedorP.ID + "',NOMBRE = '" + txtActualizarNomProdu.Text + "',DESCRIPCION ='" + txtActualizarDescripcion.Text + "',PRECIO = '"+ txtActualizarPrecio.Text +"',FECHA_VENCIMIENTO ='"+ DateActualizarFechaVen.Text  +"',STOCK ='"+txtStockProductos.Text  + "'WHERE ID ='"+this.filaSeleccionada + "'", FR);
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.UpdateCommand = comando;
                adaptador.UpdateCommand.ExecuteNonQuery();
                FR.Close();
               
                /*  UpdateUser.STOCK = Int32.Parse(txtStockProductos.Text);
               UpdateUser.NOMBRE = txtActualizarNomProdu.Text;
                //UpdateUser.DESCRIPCION = txtActualizarDescripcion.Text;
                ///UpdateUser.PRECIO = Int32.Parse(txtActualizarPrecio.Text);
                //UpdateUser.ID_FAMILIAPRODUCTO = Int32.Parse(ComboBoxFamiliaPro.Text);
                UpdateUser.ID_TIPOPRODUCTO = Int32.Parse(ComboBoxTipoP.Text);
                UpdateUser.ID_PROVEEDOR = Int32.Parse(ComboBoxProveedor.Text);
                */

                DB.SaveChanges();
                await this.ShowMessageAsync("Resultado", "Se Actualizo correctamente  ");
                System.Threading.Thread.Sleep(200);
                DataGridProducto.Items.Refresh();

                this.refrescarTabla();
                this.limpiarFormularioProducto();
                this.FlyModificarProducto.IsOpen = false;
            }
        }


        private async void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTOS productoPorActualizar = DB.PRODUCTOS.Find(this.filaSeleccionada);
            var resultado = await this.ShowMessageAsync("Confirmacion Eliminar", "Esta seguro que desea eliminar el producto: " + productoPorActualizar.NOMBRE,
                                                            MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);

            if (resultado == MessageDialogResult.Affirmative)
            {
                FR.Open();
                OracleCommand comando = new OracleCommand("ELIMINARPRO", FR);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_p", OracleDbType.Varchar2).Value = this.filaSeleccionada;
                comando.ExecuteNonQuery();
                FR.Close();
                await this.ShowMessageAsync("Resultado", "Se elimino el producto: " + productoPorActualizar.NOMBRE);
                this.refrescarTabla();
            }
        }

        private void refrescarTabla()
        {
            this.BtnMostrarListaPrtoduc_Click(null, null);
        }


        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }


        private void BtnMostrarListaPrtoduc_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand ComandoList = new OracleCommand("LISTPRODUCTOS", FR);
            ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoList.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoList;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            DataGridProducto.ItemsSource = tabla.DefaultView;
        }


        private void BtnAgregarNuevaImagen_Click(object sender, RoutedEventArgs e)
        {
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileDialog.DefaultExt = ".jpg"; // Required file extension 
            this.fileDialog.Filter = "JPG Images (.jpg)|*.jpg"; // Optional file extensions

            if (this.fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream imageStream = new FileStream(this.fileDialog.FileName, FileMode.Open, FileAccess.Read);
                this.LabelImagenesCargadas.Content = this.LabelImagenesCargadas.Content + "\n* " + this.fileDialog.FileName;
                this.imagenesPorCargar.Add(imageStream);
            }
        }


        private void BtnEliminarImagenesCargadas_Click(object sender, RoutedEventArgs e)
        {
            this.LabelImagenesCargadas.Content = "";
            this.imagenesPorCargar = new List<FileStream>();
        }


        private async void BtnGuardarImagenesProducto_Click(object sender, RoutedEventArgs e)
        {
            if (this.imagenesPorCargar.Count == 0)
            {
                await this.ShowMessageAsync("Error", "No hay imagenes agregadas");
                return;
            }

            if (this.ComboBoxProducto_Imagen.Text.Trim().Equals(""))
            {
                await this.ShowMessageAsync("Error", "Debe seleccionar un producto");
                return;
            }

            PRODUCTOS producto = this.getProductByName(this.ComboBoxProducto_Imagen.Text);
            foreach (FileStream imagen in this.imagenesPorCargar) 
            {
                /* Se convierte imagen a un array de byte */
                byte[] iBytes = new byte[imagen.Length + 1];
                imagen.Read(iBytes, 0, System.Convert.ToInt32(imagen.Length));

                /* Inserta imagenes en tabla */
                var ip = new PRODUCTO_IMAGENES()
                {
                    ID = this.getNextImageId(),
                    ID_PRODUCTO = producto.ID,
                    ORDER = this.getNextImageOrder(producto),
                    IMAGEN = iBytes
                };
                DB.PRODUCTO_IMAGENES.Add(ip);
                DB.SaveChanges();
            }

            /* Se limpia El Flyout*/
            this.LabelImagenesCargadas.Content = "";
            this.imagenesPorCargar = new List<FileStream>();
            this.ComboBoxProducto_Imagen.Text = "";

            await this.ShowMessageAsync("Exito", "Se guardaron sus imagenes en el producto " + producto.NOMBRE);

            FlyImagenes.IsOpen = false;
        }

        private PRODUCTOS getProductByName(string nombreBuscado)
        {
            PRODUCTOS productoEncontrado = null;
            foreach (PRODUCTOS p in this.DB.PRODUCTOS)
            {
                if (p.NOMBRE == nombreBuscado)   productoEncontrado = p;
            }
            return productoEncontrado;
        }

        private int getNextImageId()
        {
            int max = 0;
            foreach (PRODUCTO_IMAGENES pi in DB.PRODUCTO_IMAGENES)
            {
                if (pi.ID > max) max = Decimal.ToInt32(pi.ID);
            }
            return max+1;
        }

        private int getNextImageOrder(PRODUCTOS producto)
        {
            int order = 0;
            foreach (PRODUCTO_IMAGENES pi in DB.PRODUCTO_IMAGENES)
            {
                if (pi.ID_PRODUCTO == producto.ID && pi.ORDER > order) order = Decimal.ToInt32(pi.ID);
            }
            return order + 1;
        }


        private void BtnMostrarFlyImagenes_Click(object sender, RoutedEventArgs e)
        {
            FlyModificarProducto.IsOpen = false;
            FlyImagenes.IsOpen = true;
        }

        private async void BtnGuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            FAMILIAS_PRODUCTO FamiliaP = getFamiliaByName(ComboBoxFamiliaPro.Text);
            if (FamiliaP == null)
            {
                await this.ShowMessageAsync("Exito", "Error al Buscar Familia");
                return;
            }

            PROVEEDORES ProveedorP = getProveedorByName(ComboBoxProveedor.Text);
            if (ProveedorP == null)
            {
                await this.ShowMessageAsync("Exito", "Error al Buscar Proveedor");
                return;
            }

            TIPOS_PRODUCTO TipoP = getTipoByName(ComboBoxTipoP.Text);
            if (TipoP == null)
            {
                await this.ShowMessageAsync("Error", "Error al Buscar Tipo Producto");
                return;
            }

            if (!this.isNumber(txtStockProductos.Text)) {
                await this.ShowMessageAsync("Error", "El campo STOCK debe ser un numero");
                return;
            }

            if (!this.isNumber(txtActualizarPrecio.Text)) {
                await this.ShowMessageAsync("Error", "El campo PRECIO debe ser un numero");
                return;
            }

            if (!this.isDate(DateActualizarFechaVen.Text)) {
                await this.ShowMessageAsync("Error", "El campo FECHA VENCIMIENTO debe ser una fecha con formato dd/mm/yyyy");
                return;
            }
            if (txtActualizarNomProdu.Text.Trim().Equals("")) {
                await this.ShowMessageAsync("Error", "El campo NOMBRE no puede estar vacio");
                return;
            }

            DateTime dateObject = DateTime.Parse(DateActualizarFechaVen.Text);

            FR.Open();
            OracleCommand cmd = new OracleCommand("INSERTARPRO", FR);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("p_stock", OracleDbType.Varchar2).Value = txtStockProductos.Text;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = txtActualizarNomProdu.Text.Trim();
            cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = txtActualizarDescripcion.Text.Trim() + ".";
            cmd.Parameters.Add("p_precio", OracleDbType.Int32).Value = Int32.Parse(txtActualizarPrecio.Text);
            cmd.Parameters.Add("p_id_tipoproducto", OracleDbType.Int32).Value = TipoP.ID; 
            cmd.Parameters.Add("p_id_familiaproducto", OracleDbType.Int32).Value = FamiliaP.ID; 
            cmd.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = ProveedorP.ID;
            cmd.Parameters.Add("P_FECHAVENCIMIENTO", OracleDbType.Date).Value = dateObject;

            try {
                cmd.ExecuteNonQuery();

                await this.ShowMessageAsync("Exito", "Producto Registrado Correctamente");

                this.FlyModificarProducto.IsOpen = false;
                this.refrescarTabla();
                this.limpiarFormularioProducto();
            } catch (Exception)
            {
                await this.ShowMessageAsync("Error", "Ya existe un producto con esta misma definicion de FAMILIA, TIPO, PROVEEDOR y FECHA VENCIMIENTO. No se creó el producto");
            }
            FR.Close();
        }

        private void limpiarFormularioProducto()
        {
            txtStockProductos.Text = "";
            txtActualizarNomProdu.Text = "";
            txtActualizarDescripcion.Text = "";
            txtActualizarPrecio.Text = "";
            ComboBoxTipoP.Text = "";
            ComboBoxFamiliaPro.Text = "";
            ComboBoxProveedor.Text = "";
            DateActualizarFechaVen.Text = "";
            BtnActualizarProducto.IsEnabled = false;
            BtnGuardarProducto.IsEnabled = false;
        }

        private FAMILIAS_PRODUCTO getFamiliaByName(string nombre)
        {
            FAMILIAS_PRODUCTO FamiliaEncontrada = null;
            string nombreLimpio = nombre.Trim();
            foreach (FAMILIAS_PRODUCTO p in DB.FAMILIAS_PRODUCTO)
            {
                // await this.ShowMessageAsync("Exito", "-" + p.NOMBRE + "--" + nombreLimpio  + "-");
                if (String.Equals(p.NOMBRE, nombreLimpio))
                {
                    FamiliaEncontrada = p;
                }
            }
            return FamiliaEncontrada;
        }


        private PROVEEDORES getProveedorByName(string nombre)
        {
            PROVEEDORES ProveedorEncontrado = null;
            string nombreLimpio = nombre.Trim();
            foreach (PROVEEDORES p in DB.PROVEEDORES)
            {
                // await this.ShowMessageAsync("Exito", "-" + p.NOMBRE + "--" + nombreLimpio  + "-");
                if (String.Equals(p.NOMBRE, nombreLimpio))
                {
                    ProveedorEncontrado = p;
                }
            }
            return ProveedorEncontrado;
        }


        private TIPOS_PRODUCTO getTipoByName(string nombre)
        {
            TIPOS_PRODUCTO TipoPEncontrado = null;
            string nombreLimpio = nombre.Trim();
            foreach (TIPOS_PRODUCTO p in DB.TIPOS_PRODUCTO)
            {
                if (String.Equals(p.NOMBRE, nombreLimpio))
                {
                    TipoPEncontrado = p;
                }
            }
            return TipoPEncontrado;
        }


        private void cargarComboFamilias()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();

            foreach (FAMILIAS_PRODUCTO fp in DB.FAMILIAS_PRODUCTO)
            {
                list.Add(fp.NOMBRE);
            }
            ComboBoxFamiliaPro.ItemsSource = list;
        }


        private void cargarProveedor()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();

            foreach (PROVEEDORES fp in DB.PROVEEDORES)
            {
                list.Add(fp.NOMBRE);
            }
            ComboBoxProveedor.ItemsSource = list;
        }


        private void cargarTipoP()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();

            foreach (TIPOS_PRODUCTO fp in DB.TIPOS_PRODUCTO)
            {
                list.Add(fp.NOMBRE);
            }
            ComboBoxTipoP.ItemsSource = list;
        }


        private void DataGridProducto_AutoGeneratedColumns(object sender, EventArgs e)
        {

        }


        private Boolean isNumber(string text)
        {
            if (text.Trim().Equals("")) return false;
            return text.All(char.IsDigit);
        }

        private Boolean isDate(string text)
        {
            try
            {
                DateTime dateObject = DateTime.Parse(DateActualizarFechaVen.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}