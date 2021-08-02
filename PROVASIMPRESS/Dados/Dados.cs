using PROVASIMPRESS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROVASIMPRESS.Dados
{
    public class Dados
    {
        private SqlConnection con;

        public void Connection()
        {
            // string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString);
        }


        public List<Produto> Consulta()
        {
            Connection();

            List<Produto> lista = new List<Produto>();

            using (SqlCommand comm = new SqlCommand("procconsulta", con))
            {

                comm.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {
                    Models.Produto t = new Produto()
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        NOME = Convert.ToString(r["NOME"]),
                        DESCRICAO = Convert.ToString(r["DESCRICAO"]),
                        ATIVO = Convert.ToBoolean(r["ATIVO"]),
                        PERECIVEL = Convert.ToBoolean(r["PERECIVEL"]),
                        IDCATEGORIA = Convert.ToInt32(r["CATEGORIAID"])
                        


                    };


                    lista.Add(t);

                }
                con.Close();

                return lista;


            }



        }


        public bool Adicionartransacao(Produto t)
        {
            Connection();

            int i;
            using (SqlCommand comm = new SqlCommand("procinserir_alterar", con))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@nome", t.NOME);
                comm.Parameters.AddWithValue("@descricao", t.DESCRICAO);
                comm.Parameters.AddWithValue("@ativo", t.ATIVO);
                comm.Parameters.AddWithValue("@perecivel", t.PERECIVEL);
                comm.Parameters.AddWithValue("@categoriaid", t.IDCATEGORIA);
                con.Open();


                i = comm.ExecuteNonQuery();



            }
            con.Close();

            return i >= 1;
        }

        public bool Deletartransacao(int id)
        {
            Connection();

            int i;
            using (SqlCommand comm = new SqlCommand("procdeletar", con))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", id);


                con.Open();


                i = comm.ExecuteNonQuery();



            }
            con.Close();

            return i >= 1;
        }











    }
}