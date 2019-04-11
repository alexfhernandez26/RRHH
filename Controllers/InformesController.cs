using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalCodeFirst.Models;
namespace PruebaFinal2019.Controllers
{
	public class InformesController : Controller
	{
		// GET: Informes
		Contexto BD = new Contexto();
		// *****************************************************************
		//                   Modulo de Informes
		// ******************************************************************


		public ActionResult InformeNomina()
		{
			return View(BD.CalculoNominas.ToList());
		}

		[HttpPost]
		public ActionResult InformeNomina(CalculoNomina CN, DateTime buscarNomina)
		{
			var query = from a in BD.CalculoNominas
						where a.FechaNomina == buscarNomina
						select a;

			if (query == null)
			{
				var query2 = from a in BD.CalculoNominas
							 select a;

				return View(query2);
			}
			else
			{
				//CN.FechaNomina;
				return View(query);
			}
			
		}

		public ActionResult InformeEmpleadosActivos()
		{

			var query = from a in BD.Empleados
						where a.Estado == "Activo"
						select a;

		   
			return View(query.ToList());
		}

		[HttpPost]
		public ActionResult InformeEmpleadosActivos(Empleado emp, String buscarEmpleado)
		{

		
			var query3 = (from a in BD.Empleados
					      where a.Estado == "Activo"
						  select a);

			if (Request.Form["Estado"] != null)
			{
				String selectedRadio = Request.Form["Estado"].ToString();
				//String  Nombre = "1";
				//String Departamento = "2";

				if (selectedRadio == "1")
				{
					var query = (from a in BD.Empleados
								 where a.NombreEmpleado == buscarEmpleado
								 select a);

					return View(query);
				}
				if (selectedRadio == "2")
				{
					var query2 = (from a in BD.Empleados
								  where a.Departamento == buscarEmpleado
								  select a);

					return View(query2);
				}
			}
		
	
				return View(query3);

			

		
		}

		public ActionResult InformeEmpleadosInactivos()
		{


			var query = from a in BD.Empleados
						where a.Estado == "Inactivo"
						select a;


			return View(query.ToList());

		}
		[HttpPost]
		public ActionResult InformeEmpleadosInactivos(Empleado emp, String buscarEmpleado )
		{

			var query3 = (from a in BD.Empleados
						  where a.Estado == "Inactivo"
						  select a);

			if (Request.Form["Estado"] != null)
			{
				String selectedRadio = Request.Form["Estado"].ToString();
			

				if (selectedRadio == "1")
				{
					var query = (from a in BD.Empleados
								 where a.NombreEmpleado == buscarEmpleado
								 select a);

					return View(query);
				}
				if (selectedRadio == "2")
				{
					var query2 = (from a in BD.Empleados
								  where a.Departamento == buscarEmpleado
								  select a);

					return View(query2);
				}
			}


			return View(query3);

		}



		public ActionResult InformePermisos()
		{

			var query = from a in BD.Permisos
						select a;

			return View(query.ToList());
		}

		[HttpPost]
		public ActionResult InformePermisos (Empleado emp, String buscarEmpleado)
		{

			var query = from a in BD.Permisos
						where a.Empleado == buscarEmpleado
						select a;


			return View(query);
		}


		public ActionResult EmpleadoActivoFecha()
		{
			var query = from a in BD.Empleados
						where a.Estado == "Activo"
						select a;


			return View(query.ToList());
		}
		[HttpPost]
		public ActionResult EmpleadoActivoFecha(Empleado emp, DateTime buscarEmpleado)
		{

			var query = from a in BD.Empleados
						where a.Fecha == buscarEmpleado
						select a;

			if (query == null)
			{
				var query2 = from a in BD.Empleados
							 select a;

				return View(query2);
			}
			else
			{

				return View(query);
			}

		}

		
		public ActionResult EmpleadoInactivoFecha()
		{
			var query = from a in BD.Empleados
						where a.Estado == "Inactivo"
						select a;


			return View(query.ToList());

		}
		[HttpPost]
		public ActionResult EmpleadoInactivoFecha(Empleado emp, DateTime buscarEmpleado)
		{

			var query = from a in BD.SalidaEmpleados
						where a.FechaSalida == buscarEmpleado
						select a;

			if (query == null)
			{
				var query2 = from a in BD.SalidaEmpleados
							 select a;

				return View(query2);
			}
			else
			{
		
				return View(query);
			}

		}










	}
}