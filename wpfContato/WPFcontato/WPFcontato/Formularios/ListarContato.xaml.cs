using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFcontato.Contexto;
using WPFcontato.Formularios;
using WPFcontato.RegraDeNegocios;
using MySql.Data.MySqlClient;
using System.Data;
using K4os.Compression.LZ4.Internal;

namespace WPFcontato.Formularios
{
    /// <summary>
    /// Lógica interna para ListarContato.xaml
    /// </summary>
    public partial class ListarContato : Window
    {
        private MySqlConnection _conexao;
        public ListarContato()
        {
            InitializeComponent();
            Conexao();
            Listar();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }
        private void Listar()
        {

            string sql = "SELECT * FROM contato";
            var comando = new MySqlCommand(sql, _conexao);
            var reader = comando.ExecuteReader();
            var Lista = new List<Object>();
            while (reader.Read())
            {
                string data = "";
           

                try
                {
                    data = reader.GetDateTime("data_nasc_con").ToString("dd/MM/yyyy");
                }
                catch { }

                var contato = new
                {
                    nome = reader.GetString(1),
                    data_nasc = data,
                    sexo = reader.GetString(3),
                    email = reader.GetString(4),
                    telefone = reader.GetString(5),
                   
                    
                };
                Lista.Add(contato);
            }
            dtg.ItemsSource = Lista;


        }
        
    }
}
