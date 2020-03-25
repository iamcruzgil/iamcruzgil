using VenueManagment.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VenueManagment.Models;

namespace VenueManagment.DataAccessLayer

{
    public class DA
    {
        public string _ConnectionStrVC { get; set; }

        public DA(string ConnectionStrVC)
        {
            _ConnectionStrVC = ConnectionStrVC;
        }

        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(_ConnectionStrVC);
            conn.Open();

            return conn;
        }

        private void CloseConnection(SqlConnection conn)
        {
            conn.Close();
        }

        public List<Evento> GetCalendarEvents(string fechaInicio, string fechaFin)
        {
            List<Evento> Evento = new List<Evento>();

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(@"select
            idEvento
                , nombre
                , fechaInicio
                , fechaFin
                , fullday
            from
            [Evento]
            where
            fechaInicio between @fechaInicio and @fechaFin", conn)
                {
                    CommandType = CommandType.Text
                })
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = fechaInicio;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = fechaFin;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Evento.Add(new Evento()
                            {
                                idEvento = Convert.ToInt32(dr["idEvento"]),
                                nombre = Convert.ToString(dr["nombre"]),
                                //fechaInicio = Convert.ToString(dr["fechaInicio"]),
                                //fechaFin = Convert.ToString(dr["fechaFin"]),
                                fullday = Convert.ToBoolean(dr["fullday"])
                            });
                        }
                    }
                }
            }

            return Evento;
        }

        public string UpdateEvent(Evento evt)
        {
            string message = "";
            SqlConnection conn = GetConnection();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(@"update
            [Evento]
            set

                , nombre =@nombre
	                                                , fechaInicio =@fechaInicio
	                                                , fechaFin =@fechaFin 
	                                                , fullday =@fullday
            where
            idEvento =@idEvento", conn, trans)
                {
                    CommandType = CommandType.Text
                };
               
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = evt.nombre;
                cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = evt.fechaInicio;
                cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = Helpers.ToDBNullOrDefault(evt.fechaFin);
                cmd.Parameters.Add("@fullday", SqlDbType.Bit).Value = evt.fullday;
                cmd.ExecuteNonQuery();

                trans.Commit();
            }
            catch (Exception exp)
            {
                trans.Rollback();
                message = exp.Message;
            }
            finally
            {
                CloseConnection(conn);
            }

            return message;
        }

        public string AddEvent(Evento evt, out int eventId)
        {
            string message = "";
            SqlConnection conn = GetConnection();
            SqlTransaction trans = conn.BeginTransaction();
            eventId = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(@"insert into [Evento]
                (
                    nombre
                    , fechaInicio
                    , fechaFin
                    , fullday
                )
            values
                (
	                                                @nombre	                                                
	                                                , @fechaInicio
	                                                , @fechaFin
	                                                , @fullday
                                                );
            select scope_identity()", conn, trans)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = evt.nombre;

                cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = evt.fechaInicio;
                cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = Helpers.ToDBNullOrDefault(evt.fechaFin);
                cmd.Parameters.Add("@fullday", SqlDbType.Bit).Value = evt.fullday;

                eventId = Convert.ToInt32(cmd.ExecuteScalar());

                trans.Commit();
            }
            catch (Exception exp)
            {
                trans.Rollback();
                message = exp.Message;
            }
            finally
            {
                CloseConnection(conn);
            }

            return message;
        }

        public string DeleteEvent(int idEvento)
        {
            string message = "";
            SqlConnection conn = GetConnection();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(@"delete from 
            [Evento]
            where
            idEvento =@idEvento", conn, trans)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                cmd.ExecuteNonQuery();

                trans.Commit();
            }
            catch (Exception exp)
            {
                trans.Rollback();
                message = exp.Message;
            }
            finally
            {
                CloseConnection(conn);
            }

            return message;
        }
    }
}
