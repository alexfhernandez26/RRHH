using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalCodeFirst.Models
{
	public class Contexto : DbContext
	{
		public Contexto()
         : base("Alex") // NOMBRE DE LA CADENA DE CONEXION
		{ }

		// Modulo Mantenimiento
		public DbSet<Cargo> Cargos { get; set; }
		public DbSet<Departamento> Departamentos { get; set; }
		public DbSet<Empleado> Empleados { get; set; }

		//Modulo Procesos
		public DbSet<CalculoNomina> CalculoNominas { get; set; }
		public DbSet<Licencia> Licencias { get; set; }
	    public DbSet<Permiso> Permisos { get; set; }
		public DbSet<SalidaEmpleado> SalidaEmpleados { get; set; }
		public DbSet<Vacaciones> vacaciones { get; set; }




	}
}