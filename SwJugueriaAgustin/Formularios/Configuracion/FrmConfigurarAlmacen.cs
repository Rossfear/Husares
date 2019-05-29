using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Configuracion
{
    public partial class FrmConfigurarAlmacen : Form
    {
        Funciones fn = new Funciones();
        public FrmConfigurarAlmacen()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            txtFecha.Text = dtpFecha.Value.ToShortDateString();

            txtSucursal.Text = cboSucursal.Text;
            txtSucursal.Tag = cboSucursal.SelectedValue;

            txtAlmacen.Text = fn.selectValue("select Almacen from Almacen where IDSucursal = '"+txtSucursal.Tag+"'");
            txtAlmacen.Tag = fn.selectValue("select IDAlmacen from Almacen where IDSucursal = '" + txtSucursal.Tag + "'");

            saldosInicialFinal();

            AperturarAlmacen();


            CerrarAlmacen();
        }

    

        private void CerrarAlmacen()
        {
            string IDApertura = fn.selectValue("select idApertura from AperturaAlmacen where FechaApertura = '"+txtFecha.Text+"' and IDSucursal = '"+txtSucursal.Tag+"'");

            bool cerrado = false;

            if (fn.selectValue("select Estado from AperturaAlmacen where IDApertura = '" + IDApertura + "'") == "C")
            {
                cerrado = true;
                dgvCerrarAlmacen.Columns["cnEspecificar"].Visible = false;
            }
            else
            {
                cerrado = false;
            }

            if (dgvCerrarAlmacen.Rows.Count == 0)
            {
                //OBTENEMOS INSUMOS PARA EL CONTROL
                SqlDataReader lectorInsumos = fn.selectMultiValues("SELECT sa.IDStockAlmacen,i.Insumo FROM StockAlmacen sa  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo WHERE a.PermiteVender = 'True' and sa.PermitirControl = '1' and a.IDSucursal = '" + txtSucursal.Tag + "'");
                while (lectorInsumos.Read())
                {
                    string idStockAlmacen = lectorInsumos["IDStockAlmacen"].ToString();
                    string insumo = lectorInsumos["Insumo"].ToString();

                    string fecha = Convert.ToDateTime(txtFecha.Text).ToShortDateString();
                    float cantidadApertura = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select aad.CantidadInicial  from AperturaAlmacen aa  inner join [AperturaAlmacen.Detalle] aad on aa.IDApertura = aad.IDApertura  inner join StockAlmacen sa on aad.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where sa.IDStockAlmacen = '" + idStockAlmacen + "' and AA.FechaApertura = '" + fecha + "' and  aa.IDApertura = '" + IDApertura + "'")));
                    float cantidadEntrada = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleEntradaInsumo de inner join EntradaInsumo ei on de.IDEntradaInsumo = ei.IDEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join EntradaTienda et on ei.IDEntrada = et.IDEntrada inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura inner join Insumo i on de.IDInsumo = i.IDInsumo where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + insumo + "' and aa.FechaApertura = '" + fecha + "' and aa.IDApertura = '" + IDApertura + "' AND de.Anulado = 0")));
                    float cantidadSalida = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura  inner join Insumo i on de.IDInsumo = i.IDInsumo  where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + insumo + "' and aa.FechaApertura = '" + fecha + "'  and aa.IDApertura = '" + IDApertura + "' and de.Anulado = 0")));
                    float cantidadVenta = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(r.Cantidad * dv.Cantidad) as CantidadVenta from venta v inner join CAJA c on v.IDCaja = c.id inner join VentaDetalle dv on v.IDVenta = dv.IDVenta inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion inner join Receta r on p.IDPresentacion = r.IDPresentacion inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where sa.IDStockAlmacen = '" + idStockAlmacen + "' and v.Anulada = 'False' and cast(c.fecha_hora as date) = '" + fecha + "' and c.IDSucursal = '" + txtSucursal.Tag + "' group by i.Insumo")));
                    float saldoSistema = (cantidadApertura + cantidadEntrada) - (cantidadSalida + cantidadVenta);

                    if (cerrado == true)
                    {
                        float saldoFinal = Convert.ToSingle(fn.remplazarNulo((fn.selectValue("select CantidadFinal from [AperturaAlmacen.Detalle] where IDApertura = '" + IDApertura + "' and IDStockAlmacen = '" + idStockAlmacen + "'"))));
                        double faltante = saldoSistema - saldoFinal;

                        dgvCerrarAlmacen.Rows.Add(idStockAlmacen, insumo, cantidadApertura, cantidadEntrada, cantidadSalida, cantidadVenta, saldoSistema, saldoFinal, faltante);
                    }
                    else
                    {
                        dgvCerrarAlmacen.Rows.Add(idStockAlmacen, insumo, cantidadApertura, cantidadEntrada, cantidadSalida, cantidadVenta, saldoSistema, "", "");
                    }

                }

                lectorInsumos.Close();
            }
            else
            {
                foreach (DataGridViewRow row in dgvCerrarAlmacen.Rows)
                {
                    string idStockAlmacen = row.Cells["cnCodigoCerrar"].Value.ToString();
                    string insumo = row.Cells["cnInsumoCerrar"].Value.ToString();
                    string fecha = Convert.ToDateTime(txtFecha.Text).ToShortDateString();
                    float cantidadApertura = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select aad.CantidadInicial  from AperturaAlmacen aa  inner join [AperturaAlmacen.Detalle] aad on aa.IDApertura = aad.IDApertura  inner join StockAlmacen sa on aad.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where sa.IDStockAlmacen = '" + idStockAlmacen + "' and AA.FechaApertura = '" + fecha + "' and  aa.IDApertura = '" + IDApertura + "'")));
                    float cantidadEntrada = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleEntradaInsumo de inner join EntradaInsumo ei on de.IDEntradaInsumo = ei.IDEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join EntradaTienda et on ei.IDEntrada = et.IDEntrada inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura inner join Insumo i on de.IDInsumo = i.IDInsumo where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + insumo + "' and aa.FechaApertura = '" + fecha + "' and aa.IDApertura = '" + IDApertura + "' and de.Anulado = '0'")));
                    float cantidadSalida = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura  inner join Insumo i on de.IDInsumo = i.IDInsumo  where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + insumo + "' and aa.FechaApertura = '" + fecha + "' and aa.IDApertura = '" + IDApertura + "' and de.Anulado = '0'")));
                    float cantidadVenta = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(r.Cantidad * dv.Cantidad) as CantidadVenta from venta v inner join CAJA c on v.IDCaja = c.id inner join VentaDetalle dv on v.IDVenta = dv.IDVenta inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion inner join Receta r on p.IDPresentacion = r.IDPresentacion inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where sa.IDStockAlmacen = '" + idStockAlmacen + "' and v.Anulada = 'False' and cast(c.fecha_hora as date) = '" + fecha + "' and c.IDSucursal = '" + txtSucursal.Tag + "' group by i.Insumo")));
                    float saldoSistema = (cantidadApertura + cantidadEntrada) - (cantidadSalida + cantidadVenta);

                    row.Cells["cnSaldoInicial"].Value = cantidadApertura;
                    row.Cells["cnEntrada"].Value = cantidadEntrada;
                    row.Cells["cnDescarte"].Value = cantidadSalida;
                    row.Cells["cnSalidaVenta"].Value = cantidadVenta;
                    row.Cells["cnSaldo"].Value = saldoSistema;


                    calcularTotal();
                }
            }
        }

        private void calcularTotal()
        {
            try
            {
                foreach (DataGridViewRow row in dgvCerrarAlmacen.Rows)
                {

                    double saldoSistema = Convert.ToDouble(row.Cells["cnSaldo"].Value);
                    double saldoReal = Convert.ToDouble(fn.remplazarNulo(row.Cells["cnCantidadCerrada"].Value.ToString()));


                    double faltante = saldoSistema - saldoReal;

                    row.Cells["cnSobrante"].Value = faltante;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void saldosInicialFinal()
        {
            //GRID
            fn.ActualizarGrid(dgvSaldosIniciales, "select aad.IDApertura,aad.IDStockAlmacen,i.Insumo,aad.CantidadInicial,aad.CantidadFinal from AperturaAlmacen aa inner join [AperturaAlmacen.Detalle] aad on aa.IDApertura = aad.IDApertura inner join StockAlmacen sa on aad.IDStockAlmacen = sa.IDStockAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo where aa.FechaApertura = '" + dtpFecha.Value.ToShortDateString() + "' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "'");
            dgvSaldosIniciales.Columns["IDApertura"].Visible = false;
            dgvSaldosIniciales.Columns["IDStockAlmacen"].Visible = false;
            dgvSaldosIniciales.Columns["Insumo"].ReadOnly = true;
        }

        private void AperturarAlmacen()
        {
            try
            {
                dgvAperturaAlmacen.Rows.Clear();
                string idApertura = fn.selectValue("SELECT top(1) IDApertura FROM AperturaAlmacen where IDSucursal = '" + txtSucursal.Tag + "' and FechaApertura < '" + txtFecha.Text + "' order by FechaApertura desc");

                SqlDataReader reader = fn.selectMultiValues("select sa.IDStockAlmacen,i.Insumo from Almacen a inner join StockAlmacen sa on a.IDAlmacen = sa.IDAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo where a.IDAlmacen = '" + txtAlmacen.Tag + "' and sa.PermitirControl = 'True'");
                while (reader.Read())
                {
                    string idStockAlmacen = reader["IDStockAlmacen"].ToString();
                    string insumo = reader["Insumo"].ToString();

                    float cantidadApertura = 0;

                    if (fn.Existencia("*", "[AperturaAlmacen.Detalle]", "IDApertura = '" + idApertura + "' and IDStockAlmacen = '" + idStockAlmacen + "'") == true)
                    {
                        cantidadApertura = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select CantidadFinal from [AperturaAlmacen.Detalle] where IDApertura = '" + idApertura + "' and IDStockAlmacen = '" + idStockAlmacen + "'")));
                    }

                    dgvAperturaAlmacen.Rows.Add(idStockAlmacen, insumo, cantidadApertura);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnMidificar_Click(object sender, EventArgs e)
        {
            var msj = MessageBox.Show("Desea Actualizar los Datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if(msj == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgvSaldosIniciales.Rows)
                {
                    string IDApertura = row.Cells["IDApertura"].Value.ToString();
                    string IDStockAlmacen = row.Cells["IDStockAlmacen"].Value.ToString();
                    string cantidadInicial = row.Cells["CantidadInicial"].Value.ToString();
                    string cantidadFinal = row.Cells["CantidadFinal"].Value.ToString();

                    fn.Modificar("[AperturaAlmacen.Detalle]", "CantidadInicial='" + cantidadInicial + "',CantidadFinal='" + cantidadFinal + "'", "IDApertura='" + IDApertura + "' and IDStockAlmacen='" + IDStockAlmacen + "'");
                }

                MessageBox.Show("Datos Actualizados", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmConfigurarAlmacen_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
            fn.añadir_ddl("TipoEntrada", "IDTipoEntrada", "TipoEntrada WHERE Estado = 1", cbxTipoEntrada);
            fn.añadir_ddl("TipoSalida", "IDTiposalida", "TipoSalida where Estado=1", cbxTipoSalida);
        }

        private bool validacionGuardar()
        {
            if (dgvEntrada.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgvEntrada.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cbxTipoEntrada.SelectedValue == null)
            {
                MessageBox.Show("Tipo de Entrada No Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            

            if(fn.Existencia("*","AperturaAlmacen","IDSucursal = '"+Datos.idSucursal+"' and FechaApertura='"+txtFecha.Text+"'") == false)
            {
                MessageBox.Show("Apertura de Almacen no Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("Desea REGISTRAR la Entrada de Insumos?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msj == DialogResult.OK)
            {

                string idApertura = fn.selectValue("select IDApertura from AperturaAlmacen WHERE IDSucursal = '" + txtSucursal.Tag + "' and FechaApertura = '"+txtFecha.Text+"'");


                string fecha = DateTime.Now.ToShortDateString();

                //REGISTRAMOS ENTRADA
                fn.RegistrarOficial("EntradaInsumo", "Fecha,IDTipoEntrada,IDAlmacenReceptor,Anulada,IDUsuario",
                    "'" + fecha + "','" + cbxTipoEntrada.SelectedValue + "','" + txtAlmacen.Tag + "','False','" + Datos.idUsuario + "'");

                //OBTENEMOS EL CODIGO DE ENTRADA
                string IDEntrada = fn.select_one_value("MAX(IDEntrada)", "EntradaInsumo", "IDEntrada>0", 0);

                if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + txtAlmacen.Tag + "'") == "True")
                {
                    //REGISTRAMOS LA ENTRADA A TIENDA
                    fn.RegistrarOficial("entradatienda", "IDEntrada,IDApertura", "'" + IDEntrada + "','" + idApertura + "'");
                }


                //REGISTRAMOS DETALLE ENTRADA
                for (short i = 0; i < dgvEntrada.Rows.Count; i++)
                {
                    string IDInsumo = dgvEntrada.Rows[i].Cells["cnCod"].Value.ToString();
                    string insumo = dgvEntrada.Rows[i].Cells["cnInsumo"].Value.ToString();
                    string cantidad = dgvEntrada.Rows[i].Cells["cnCantidad"].Value.ToString();

                    //REGISTRAMOS EL DETALLE DE ENTRADA
                    fn.RegistrarOficial("detalleEntradaInsumo", "IDEntradaInsumo,IDInsumo,Cantidad,Anulado",
                        "'" + IDEntrada + "','" + IDInsumo + "','" + cantidad + "','0'");


                    //VERIFICAMSO SI ESTA EN LA TABLA STOCKALMACEN
                    if (fn.Existencia("*", "StockAlmacen", "IDAlmacen='" + txtAlmacen.Tag + "' and IDInsumo='" + IDInsumo + "'") == true)
                    {
                        //AUMENTAMOS STOCK STOCK
                        fn.Modificar("StockAlmacen", "Stock=Stock+" + cantidad, "IDAlmacen='" + txtAlmacen.Tag + "' and IDInsumo='" + IDInsumo + "'");
                    }
                    else
                    {
                        //SI NO EXISTE LO REGISTRAMOS CON STOCK QUE INGRESA
                        fn.RegistrarOficial("StockAlmacen", "IDInsumo,IDAlmacen,Stock,PermitirControl", "'" + IDInsumo + "','" + txtAlmacen.Tag + "','" + cantidad + "','False'");
                    }

                    //REGISTRAMOS EL KARDEX
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','ENTRADA " + cbxTipoEntrada.Text + "','" + IDEntrada + "','" + cantidad + "','0',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + txtAlmacen.Tag + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + txtAlmacen.Tag + "' and IDInsumo='" + IDInsumo + "')");
                }
                dgvEntrada.Rows.Clear();
                MessageBox.Show("Entrada de Insumo REGISTRADA con el Codigo " + IDEntrada, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvInsumo, "select i.IDInsumo,i.Insumo,um.UniMedida from Insumo i inner join UnidadMedida um on i.IDUniMedida = um.IDUniMedida where i.Insumo like '%" + txtBuscar.Text + "%'");
        }

        private void dgvInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();

                if (frm.Cancelado == false && string.IsNullOrWhiteSpace(frm.txtCantidad.Text) == false)
                {
                    string idInsumo = dgvInsumo.CurrentRow.Cells[0].Value.ToString();
                    string insumo = dgvInsumo.CurrentRow.Cells[1].Value.ToString();
                    string cantidad = frm.txtCantidad.Text;
                    dgvEntrada.Rows.Add(idInsumo, insumo, cantidad, 'X');
                    txtBuscar.Focus();
                }
            }
        }

        private void dgvSalida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dgvEntrada.Columns[3].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgvEntrada.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("Desea Quitar el Insumo de la Lista", "SisVentas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            if (!row2.IsNewRow) dgvEntrada.Rows.Remove(row2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGridSalida();
        }

        private void MostrarDatosGridSalida()
        {
            fn.ActualizarGrid(dgvInsumoSalida, "select i.IDInsumo as Codigo,i.Insumo,sa.Stock,um.UniMedida from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.IDAlmacen = '" + txtAlmacen.Tag + "' and i.Insumo like '%" + txtBuscarInsumoSalida.Text + "%'");
        }

        private void dgvInsumoSalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();

                if (frm.Cancelado == false)
                {
                    string idInsumo = dgvInsumoSalida.CurrentRow.Cells[0].Value.ToString();
                    string insumo = dgvInsumoSalida.CurrentRow.Cells[1].Value.ToString();
                    string cantidad = frm.txtCantidad.Text;
                    dgvSalida.Rows.Add(idInsumo, insumo, cantidad, 'X');
                }
            }
        }

        private void dgvSalida_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dgvSalida.Columns[3].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgvSalida.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("Desea Quitar el Insumo de la Lista", "SisVentas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            if (!row2.IsNewRow) dgvSalida.Rows.Remove(row2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionGuardarSalida() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("Desea REGISTRAR la Salida de Insumos?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string fecha = DateTime.Now.ToShortDateString();
            if (msj == DialogResult.OK)
            {
                string idApertura = fn.selectValue("select IDApertura from AperturaAlmacen where IDSucursal  = '" + txtSucursal.Tag + "'  and  FechaApertura = '"+txtFecha.Text+"'");

                //REGISTRAMOS SALIDA
                fn.RegistrarOficial("SalidaInsumo", "Fecha,IDTipoSalida,IDAlmacenEmisor,Anulada,IDUsuario",
                    "'" + fecha + "','" + cbxTipoSalida.SelectedValue + "','" + txtAlmacen.Tag + "','False','" + Datos.idUsuario + "'");

                //OBTENEMOS EL CODIGO DE salida
                string IDSalida = fn.select_one_value("MAX(IDSalida)", "SalidaInsumo", "IDSalida>0", 0);

                if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + txtAlmacen.Tag + "'") == "True")
                {
                    //REGISTRAMOS LA SALIDA A LA TINEDA
                    fn.RegistrarOficial("salidatienda", "IDSalida,IDApertura", "'" + IDSalida + "','" + idApertura + "'");
                }


                //REGISTRAMOS DETALLE salida
                for (short i = 0; i < dgvSalida.Rows.Count; i++)
                {
                    string IDInsumo = dgvSalida.Rows[i].Cells["cnCodigoSalida"].Value.ToString();
                    string insumo = dgvSalida.Rows[i].Cells["cnInsumoSalida"].Value.ToString();
                    string cantidad = dgvSalida.Rows[i].Cells["cnCantidadSalida"].Value.ToString();


                    //REGISTRAMOS EL DETALLE DE SALIDA
                    fn.RegistrarOficial("detalleSalidaInsumo", "IDSalidaInsumo,IDInsumo,Cantidad,Anulado",
                        "'" + IDSalida + "','" + IDInsumo + "','" + cantidad + "','0'");

                    //AUMENTAMOS STOCK STOCK
                    fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDAlmacen='" + txtAlmacen.Tag + "' and IDInsumo='" + IDInsumo + "'");

                    //REGISTRAMOS EL KARDEX
                    fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen",
                        "'" + fecha + "','SALIDA " + cbxTipoSalida.Text + "','" + IDSalida + "','0','" + cantidad + "',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + txtAlmacen.Tag + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + txtAlmacen.Tag + "' and IDInsumo='" + IDInsumo + "')");
                }
                dgvSalida.Rows.Clear();
                MessageBox.Show("Salida de Insumo REGISTRADA con el Codigo " + IDSalida, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool validacionGuardarSalida()
        {
            //NO ESPECIFICA PRODUCTOS
            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //NO TIPO DE SALIDA
            if (cbxTipoSalida.SelectedValue == null)
            {
                MessageBox.Show("Tipo de salida No Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //NO ALMACEN
            if (txtAlmacen.Tag == null)
            {
                MessageBox.Show("Almacen Receptor No Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            





            return true;
        }

        private void btnAperturarAlmacen_Click(object sender, EventArgs e)
        {
            if(validacionApertura() == false)
            {
                return;
            }


            DialogResult msj = MessageBox.Show("¿Desea Abrir Almacen?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            {
                if (msj == DialogResult.OK)
                {
                    fn.RegistrarOficial("AperturaAlmacen", "FechaApertura,Hora,IDUsuario,Estado,IDAlmacen,Turno,IDSucursal",
                        "'" + txtFecha.Text + "','" + DateTime.Now.ToShortTimeString() + "','" + Datos.idUsuario + "','A','" + txtAlmacen.Tag + "','MAÑANA','" + txtSucursal.Tag + "'");

                    string IDApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);

                    for (int i = 0; i < dgvAperturaAlmacen.Rows.Count; i++)
                    {
                        string idStockAlmacen = dgvAperturaAlmacen.Rows[i].Cells["cnCodigo"].Value.ToString();
                        string cantidad = dgvAperturaAlmacen.Rows[i].Cells["cnCantidadApertura"].Value.ToString();

                        fn.RegistrarOficial("[AperturaAlmacen.Detalle]", "IDApertura,IDStockAlmacen,CantidadInicial", "'" + IDApertura + "','" + idStockAlmacen + "','" + cantidad + "'");
                        fn.Modificar("StockAlmacen", "Stock='" + cantidad + "'", "IDStockAlmacen='" + idStockAlmacen + "'");

                        //REGISTRAMOS KARDEX
                        fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen",
                            "'" + DateTime.Now.ToShortDateString() + "','CUADRE DE ALMACEN','" + IDApertura + "','0','0','" + cantidad + "','" + idStockAlmacen + "'");
                    }

                    MessageBox.Show("Apertura de Almacen Correctamente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private bool validacionApertura()
        {
           
            if (fn.Existencia("*", "AperturaAlmacen", "FechaApertura = '" + txtFecha.Text + "' AND IDSucursal = '" + txtSucursal.Tag + "'") == true)
            {
                MessageBox.Show("Ya Existe una Apertura de Almacen con la Fecha Actual", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            

            return true;
        }

        private void btnCerrarAlmacen_Click(object sender, EventArgs e)
        {

            if (validacionCerrarAlmacen() == false)
            {
                return;

            }


            DialogResult msj = MessageBox.Show("Desea Cerrar en Almacen", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            {
                if (msj == DialogResult.OK)
                {
                    string IDApertura = fn.selectValue("select idApertura from AperturaAlmacen where FechaApertura = '" + txtFecha.Text + "' and IDSucursal = '" + txtSucursal.Tag + "'");

                    fn.Modificar("AperturaAlmacen", "Estado='C',FechaCierre='" + DateTime.Now.ToShortDateString() + "'", "IDApertura='" + IDApertura + "'");

                    for (int i = 0; i < dgvCerrarAlmacen.Rows.Count; i++)
                    {
                        string idStockAlmacen = dgvCerrarAlmacen.Rows[i].Cells["cnCodigoCerrar"].Value.ToString();
                        string cantidad = dgvCerrarAlmacen.Rows[i].Cells["cnCantidadCerrada"].Value.ToString();

                        fn.Modificar("StockAlmacen", "Stock='" + cantidad + "'", "IDStockAlmacen ='" + idStockAlmacen + "'");
                        fn.Modificar("[AperturaAlmacen.Detalle]", "CantidadFinal='" + cantidad + "'", "IDApertura='" + IDApertura + "' and IDStockAlmacen='" + idStockAlmacen + "'");
                    }

                    MessageBox.Show("Almacen Cerrado Correctamente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private bool validacionCerrarAlmacen()
        {
            foreach(DataGridViewRow row in dgvCerrarAlmacen.Rows)
            {
                if((string.IsNullOrEmpty(row.Cells["cnSobrante"].Value.ToString()) == true) || (string.IsNullOrEmpty(row.Cells["cnCantidadCerrada"].Value.ToString()) == true))
                {
                    MessageBox.Show("Verificar que todos los insumos. Esten Especificados su saldo Final", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

           
            if(dgvCerrarAlmacen.Rows.Count == 0)
            {
                MessageBox.Show("Especificar Productos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;   
        }
    }
}
