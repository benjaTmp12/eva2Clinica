using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace eva2Clinica.Models
{
    public class PacienteData
    {
        private readonly ConexionBD _conexionBD;

        public PacienteData(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD;
        }

        // 1. LEER: Obtiene la lista completa de pacientes
        public List<Paciente> Listar()
        {
            var lista = new List<Paciente>();
            using (var conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();
                var cmd = new MySqlCommand("SELECT * FROM Pacientes", conexion);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Paciente(
                            Convert.ToInt32(reader["Id"]),
                            reader["NombreCompleto"].ToString() ?? "",
                            reader["Rut"].ToString() ?? "",
                            Convert.ToInt32(reader["Edad"]),
                            reader["Telefono"].ToString() ?? "",
                            reader["Direccion"].ToString() ?? "",
                            reader["Correo"].ToString() ?? "",
                            reader["Diagnostico"].ToString() ?? ""
                        ));
                    }
                }
            }
            return lista;
        }

        // 2. CREAR: Inserta un nuevo paciente
        public void Crear(Paciente paciente)
        {
            using (var conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();
                string sql = "INSERT INTO Pacientes (NombreCompleto, Rut, Edad, Telefono, Direccion, Correo, Diagnostico) VALUES (@nombre, @rut, @edad, @telefono, @direccion, @correo, @diagnostico)";
                var cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                cmd.Parameters.AddWithValue("@rut", paciente.Rut);
                cmd.Parameters.AddWithValue("@edad", paciente.Edad);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", paciente.Direccion);
                cmd.Parameters.AddWithValue("@correo", paciente.Correo);
                cmd.Parameters.AddWithValue("@diagnostico", paciente.Diagnostico);
                cmd.ExecuteNonQuery();
            }
        }

        // 3. LEER POR ID: Busca un paciente específico
        public Paciente ObtenerPorId(int id)
        {
            Paciente paciente = new Paciente();
            using (var conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();
                var cmd = new MySqlCommand("SELECT * FROM Pacientes WHERE Id = @id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        paciente = new Paciente(
                            Convert.ToInt32(reader["Id"]),
                            reader["NombreCompleto"].ToString() ?? "",
                            reader["Rut"].ToString() ?? "",
                            Convert.ToInt32(reader["Edad"]),
                            reader["Telefono"].ToString() ?? "",
                            reader["Direccion"].ToString() ?? "",
                            reader["Correo"].ToString() ?? "",
                            reader["Diagnostico"].ToString() ?? ""
                        );
                    }
                }
            }
            return paciente;
        }

        // 4. ACTUALIZAR: Modifica los datos de un paciente
        public void Editar(Paciente paciente)
        {
            using (var conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();
                string sql = "UPDATE Pacientes SET NombreCompleto=@nombre, Rut=@rut, Edad=@edad, Telefono=@telefono, Direccion=@direccion, Correo=@correo, Diagnostico=@diagnostico WHERE Id=@id";
                var cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", paciente.Id);
                cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                cmd.Parameters.AddWithValue("@rut", paciente.Rut);
                cmd.Parameters.AddWithValue("@edad", paciente.Edad);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", paciente.Direccion);
                cmd.Parameters.AddWithValue("@correo", paciente.Correo);
                cmd.Parameters.AddWithValue("@diagnostico", paciente.Diagnostico);
                cmd.ExecuteNonQuery();
            }
        }

        // 5. ELIMINAR: Borra el registro de la base de datos
        public void Eliminar(int id)
        {
            using (var conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();
                var cmd = new MySqlCommand("DELETE FROM Pacientes WHERE Id = @id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}