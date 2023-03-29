﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoPDS.RegrasDeNegocio;
using ProjetoPDS.Contexto;
using MySql.Data.MySqlClient;


namespace ProjetoPDS
{
    public partial class CadastrarContato : Form
    {
        private MySqlConnection _conexao;
        public CadastrarContato()
        {
            InitializeComponent();
            Conexao();
            tbEmail.Enabled = false;
            tbNome.Enabled = false;
            tbTelefone.Enabled = false;
            dtpDataNasc.Enabled = false;
            tbSexo.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;

            

        }
        private void Conexao()
        {
            string conexaoString= "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            tbEmail.Enabled = true;
            tbNome.Enabled = true;
            tbTelefone.Enabled = true;
            dtpDataNasc.Enabled = true;
            tbSexo.Enabled = true;
            btSalvar.Enabled = true;
            btCancelar.Enabled = true;
            btAdd.Enabled = false;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            tbEmail.Enabled = false;
            tbNome.Enabled = false;
            tbTelefone.Enabled = false;
            dtpDataNasc.Enabled = false;
            tbSexo.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;
            btAdd.Enabled = true;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {


            try
            {

                var nome = tbNome.Text;
                dtpDataNasc.Format = DateTimePickerFormat.Custom;
                dtpDataNasc.CustomFormat = "yyyy-MM-dd";
                var data = dtpDataNasc.Text;
                var email = tbEmail.Text;
                var sexo = tbSexo.Text;
                var telefone = tbTelefone.Text;

                var sql = "INSERT INTO contato (nome_con, email_con, sexo_con, telefone_con, data_nasc_con) values (@_nome, @_email, @_sexo, @_telefone, @_data_nasc);";
                var comando = new MySqlCommand(sql, _conexao);

                comando.Parameters.AddWithValue("@_nome", nome);
                comando.Parameters.AddWithValue("@_data_nasc", data);
                comando.Parameters.AddWithValue("@_sexo", sexo);
                comando.Parameters.AddWithValue("@_email", email);
                comando.Parameters.AddWithValue("@_telefone", telefone);
                comando.ExecuteNonQuery();
                MessageBox.Show("SALVO COM SUCESSO!!!");

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Ocorreram erros ao salvar as informações! Contate a esquipe de suporte do sistema");
            }

            Cadastramento objcadastramento = new Cadastramento();
            objcadastramento.Email = tbEmail.Text;
            objcadastramento.Nome = tbNome.Text;
            objcadastramento.Telefone = tbTelefone.Text;
            objcadastramento.Data = dtpDataNasc.Value;
            objcadastramento.Sexo = tbSexo.Text;
            DadosContato.lista.Add(objcadastramento);
            tbEmail.Enabled = false;
            tbNome.Enabled = false;
            tbTelefone.Enabled = false;
            dtpDataNasc.Enabled = false;
            tbSexo.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;
            btAdd.Enabled = true;
            tbEmail.Clear();
            tbNome.Clear();
            tbTelefone.Clear();
            tbSexo.Clear();
           
        }

        private void CadastrarContato_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}